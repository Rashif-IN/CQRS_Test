using System;
using MediatR;

namespace cqrs_Test.Application.UseCase.Customer.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<GetCustomerDto>
    {
        public int id { get; set; }    
    }
}
