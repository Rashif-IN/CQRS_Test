using System;
using MediatR;

namespace cqrs_Test.Application.UseCase.Customer.Command.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerCommandDto>
    {
        public DeleteCustomerData Data { get; set; }

    }
    public class DeleteCustomerData : IRequest<DeleteCustomerCommandDto>
    {
        public int id { get; set;}
    }
}
