using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.UseCase.Customer.Models;
using MediatR;

namespace cqrs_Test.Application.UseCase.Customer.Queries.GetCustomer
{
    public class GetCustomerQueryHandler: IRequestHandler<GetCustomerQuery, GetCustomerDto>
    {
        private readonly IBlogContext _context;

        public GetCustomerQueryHandler(IBlogContext context)
        {
            _context = context;
        }
        public async Task<GetCustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Creators.FirstOrDefaultAsync(e => e.id == request.id);

            return new GetCustomerDto
            {
                Status = true,
                Message = "Creator successfully retrieved",
                Data = result
            };

        }
    }
}
