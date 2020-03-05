using System;
using cqrs_Test.Application.Interfaces;
using MediatR;

namespace cqrs_Test.Application.UseCase.Customer.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersDto>
    {
        private readonly IContext konteks;

        public GetCustomersQueryHandler(IContext context)
        {
            konteks = context;
        }
        public async Task<GetCustomersDto>()
        {
            var result = await konteks.Customer;

            return new GetCustomersDto
            {
                Status = true,
                Message = "Customers successfully retrieved",
                Data = result
            };
        }
    }
}
