using System;
using MediatR;

namespace cqrs_Test.Application.UseCase.Product.Command.PutProduct
{
    public class PutProductCommand : IRequest<PutProductCommandDto>
    {
        public PutProductData Data { get; set; }
    }
    public class PutProductData
    {
        public int id { get; set; }
        public int merhcant_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }
    }
}
