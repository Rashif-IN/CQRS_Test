using System;
using cqrs_Test.Application.Models.Query;
using FluentValidation;

namespace cqrs_Test.Application.UseCase.Product.Command.PostProduct
{
    public class PostProductCommandValidation : AbstractValidator<RequestData<PostProductCommand>>
    {
        public PostProductCommandValidation()
        {
            RuleFor(x => x.Dataa.Attributes.Data.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.Dataa.Attributes.Data.name).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.Dataa.Attributes.Data.price).NotEmpty().WithMessage("price can't be empty");
            RuleFor(x => x.Dataa.Attributes.Data.price).GreaterThan(1000).WithMessage("price must be greater than 1000");
        }
    }
}
