using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using cqrs_Test.Application.Models.Query;
using MediatR;

namespace cqrs_Test.Application.UseCase.Customer.Command.PutCustomer
{
    public class PutCustomerCommandHandler : IRequestHandler<PutCustomerCommand, PutCustomerCommandDto>
    {
        private readonly IContext konteks;

        public PutCustomerCommandHandler(IContext context)
        {
            konteks = context;
        }
        public async Task<PutCustomerCommandDto> Handle(RequestData<PutCustomerCommand> request, CancellationToken cancellationToken, int ID)
        {

            var customers = konteks.Customer.Find(ID);
            customers.full_name = request.Dataa.Attributes.Data.full_name;
            customers.username = request.Dataa.Attributes.Data.username;
            customers.birthdate = request.Dataa.Attributes.Data.birthdate;
            customers.password = request.Dataa.Attributes.Data.password;
            customers.sex = request.Dataa.Attributes.Data.sex;
            customers.email = request.Dataa.Attributes.Data.email;
            customers.phone_number = request.Dataa.Attributes.Data.phone_number;
            customers.updated_at = request.Dataa.Attributes.Data.updated_at;

            if (request.Dataa.Attributes.Data.sex == "male")
            {
                request.Dataa.Attributes.Data.gender = kelamin.male;
            }
            else if (request.Dataa.Attributes.Data.sex == "female")
            {
                request.Dataa.Attributes.Data.gender = kelamin.female;
            }

            await konteks.SaveChangesAsync(cancellationToken);

            return new PutCustomerCommandDto
            {
                Status = true,
                Message = "Customer successfully putted",
            };

        }
    }
}
