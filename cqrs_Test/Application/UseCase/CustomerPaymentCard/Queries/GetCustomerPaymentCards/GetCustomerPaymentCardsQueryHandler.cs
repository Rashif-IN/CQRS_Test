using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_Test.Application.UseCase.CustomerPaymentCard.Queries.GetCustomerPaymentCards
{
    public class GetCustomerPaymentCardsQueryHandler : IRequestHandler<GetCustomerPaymentCardsQuery, GetCustomerPaymentCardsDto>
    {
        private readonly IContext konteks;

        public GetCustomerPaymentCardsQueryHandler(IContext context)
        {
            konteks = context;
        }

        public async Task<GetCustomerPaymentCardsDto> Handle(GetCustomerPaymentCardsQuery request, CancellationToken cancellationToken)
        {

            var result = await konteks.CPC.ToListAsync();

            return new GetCustomerPaymentCardsDto
            {
                Status = true,
                Message = "Customer successfully retrieved",
                Data = result
            };

        }
    }
}
