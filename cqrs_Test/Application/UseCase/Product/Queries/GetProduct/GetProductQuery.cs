using System;
using MediatR;

namespace cqrs_Test.Application.UseCase.Product.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductDto>
    {
        public int id { get; set; }
    }
}
