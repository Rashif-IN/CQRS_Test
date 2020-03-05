using System;
using cqrs_Test.Application.Models.Query;
using FluentValidation;

namespace cqrs_Test.Application.UseCase.CustomerPaymentCard.Command.PostCustomerPaymentCard
{
    public class PostCustomerPaymentCardCommandValidation : AbstractValidator<RequestData<PostCustomerPaymentCardCommand>>
    {
        public PostCustomerPaymentCardCommandValidation()
        {
            RuleFor(x => x.Dataa.Attributes.Data.name_on_card).NotEmpty().WithMessage("name_on_card can't be empty");
            RuleFor(x => x.Dataa.Attributes.Data.name_on_card).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.Dataa.Attributes.Data.exp_month).NotEmpty().WithMessage("exp_month can't be empty");
            RuleFor(x => Convert.ToInt32(x.Dataa.Attributes.Data.exp_month)).ExclusiveBetween(1, 12).WithMessage("exp_month is bettween 1-12");
            RuleFor(x => x.Dataa.Attributes.Data.exp_year).NotEmpty().WithMessage("exp_year can't be empty");
            RuleFor(x => x.Dataa.Attributes.Data.credit_card_number).CreditCard().WithMessage("credit_card_number must be type of credit card number");
        }
    }
}
