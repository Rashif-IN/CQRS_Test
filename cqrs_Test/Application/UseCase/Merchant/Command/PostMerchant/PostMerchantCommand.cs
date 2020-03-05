using System;
using MediatR;

namespace cqrs_Test.Application.UseCase.Merchant.Command.PostMerchant
{
    public class PostMerchantCommand : IRequest<PostMerchantCommandDto>
    {
        public PostMerchantData Data { get; set; }
    }
    public class PostMerchantData
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
