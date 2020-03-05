using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using cqrs_Test.Application.Models.Query;
using MediatR;

namespace cqrs_Test.Application.UseCase.Customer.Command.PostCustomer
{
    public class PostCustomerCommandHandler : IRequestHandler<PostCustomerCommand, PostCustomerCommandDto>
    {
        private readonly IContext konteks;

        public PostCustomerCommandHandler(IContext context)
        {
            konteks = context;
        }
        public async Task<PostCustomerCommandDto> Handle(RequestData<PostCustomerCommand> request, CancellationToken cancellationToken)
        {

            var customers = new Domain.Entities.Customers
            {
                full_name = request.Dataa.Attributes.Data.full_name,
                username = request.Dataa.Attributes.Data.username,
                birthdate = request.Dataa.Attributes.Data.birthdate,
                password = request.Dataa.Attributes.Data.password,
                sex = request.Dataa.Attributes.Data.sex,
                email = request.Dataa.Attributes.Data.email,
                phone_number = request.Dataa.Attributes.Data.phone_number
            };
            if (request.Dataa.Attributes.Data.sex == "male")
            {
                request.Dataa.Attributes.Data.gender = kelamin.male;
            }
            else if (request.Dataa.Attributes.Data.sex == "female")
            {
                request.Dataa.Attributes.Data.gender = kelamin.female;
            }
            konteks.Customer.Add(customers);
            await konteks.SaveChangesAsync(cancellationToken);

            return new PostCustomerCommandDto
            {
                Status = true,
                Message = "Customer successfully posted",
            };

        }
    }
}
