using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_Test.Application.UseCase.Customer.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersDto>
    {
        private readonly IContext konteks;

        public GetCustomersQueryHandler(IContext context)
        {
            konteks = context;
        }

        public async Task<GetCustomersDto> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await konteks.Customer.ToListAsync();

            return new GetCustomersDto
            {
                Status = true,
                Message = "Customers successfully retrieved",
                Data = result
            };
        }

       
    }
}
