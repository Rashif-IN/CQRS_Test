using System;
using MediatR;

namespace cqrs_Test.Application.UseCase.Merchant.Command.PutMerchant
{
    public class PutMerchantCommand : IRequest<PutMerchantCommandDto>
    {
        public PutMerchantData Data { get; set; }
    }
    public class PutMerchantData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }
    }
}
