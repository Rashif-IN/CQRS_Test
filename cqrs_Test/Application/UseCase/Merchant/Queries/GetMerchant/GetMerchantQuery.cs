using System;
using MediatR;

namespace cqrs_Test.Application.UseCase.Merchant.Queries.GetMerchant
{
    public class GetMerchantQuery : IRequest<GetMerchantDto>
    {
        public int id { get; set; }
    }

}
