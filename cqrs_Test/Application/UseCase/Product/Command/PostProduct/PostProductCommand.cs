using System;
using MediatR;

namespace cqrs_Test.Application.UseCase.Product.Command.PostProduct
{
    public class PostProductCommand : IRequest<PostProductCommandDto>
    {
        public PostProductData Data { get; set; }
    }
    public class PostProductData
    {
        public int id { get; set; }
        public int merhcant_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }
    }
}
