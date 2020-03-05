using System;
using cqrs_Test.Application.Models.Query;
using cqrs_Test.Domain.Entities;

namespace cqrs_Test.Application.UseCase.Customer.Queries.GetCustomers
{
    public class GetCustomersDto : BaseDto
    {
        public Customers Data { get; set; }
    }
}
