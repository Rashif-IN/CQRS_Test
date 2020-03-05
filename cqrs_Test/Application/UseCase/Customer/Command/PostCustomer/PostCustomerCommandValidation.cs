using System;
using cqrs_Test.Application.Models.Query;
using cqrs_Test.Domain.Entities;
using FluentValidation;


namespace cqrs_Test.Application.UseCase.Customer.Command.PostCustomer
{
    public class PostCustomerCommandValidation : AbstractValidator<RequestData<PostCustomerCommand>>
    {
        public PostCustomerCommandValidation()
        {
            RuleFor(x => x.Dataa.Attributes.Data.username).NotEmpty().WithMessage("username can't be empty");
            RuleFor(x => x.Dataa.Attributes.Data.username).MaximumLength(20).WithMessage("max username lenght is 20");
            RuleFor(x => x.Dataa.Attributes.Data.email).NotEmpty().WithMessage("email can't be empty");
            RuleFor(x => x.Dataa.Attributes.Data.email).EmailAddress().WithMessage("max username lenght is 20");
            //RuleFor(x => x.Dataa.Attributes.gender).IsInEnum().WithMessage("gender is one of male or female");
            RuleFor(x => x.Dataa.Attributes.Data.sex).Must(y => y == "female" || y == "male").WithMessage("gender is one of male or female");
            RuleFor(x => x.Dataa.Attributes.Data.sex).NotEmpty().WithMessage("gender can't be empty");
            RuleFor(x => x.Dataa.Attributes.Data.birthdate).NotEmpty().WithMessage("birhdate can't be empty");
            RuleFor(x => DateTime.Now.Year - x.Dataa.Attributes.Data.birthdate.Year).GreaterThan(18).WithMessage("age must be greater than 18");
        }
    }
}
