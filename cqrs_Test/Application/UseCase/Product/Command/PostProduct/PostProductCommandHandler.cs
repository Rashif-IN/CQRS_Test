using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using cqrs_Test.Application.Models.Query;
using MediatR;

namespace cqrs_Test.Application.UseCase.Product.Command.PostProduct
{
    public class PostProductCommandHandler
    {
        public PostProductCommandHandler : IRequestHandler<PostProductCommand, PostProductCommandDto>
        {
            private readonly IContext konteks;

            public PostProductCommandHandler(IContext context)
            {
                konteks = context;
            }
            public async Task<PostProductCommandDto> Handle(RequestData<PostProductCommand> request, CancellationToken cancellationToken)
            {

                var pro = new Domain.Entities.Products
                {
                    id = request.Dataa.Attributes.Data.id,
                    merhcant_id = request.Dataa.Attributes.Data.merhcant_id,
                    name = request.Dataa.Attributes.Data.name,
                    price = request.Dataa.Attributes.Data.price,
                    created_at = request.Dataa.Attributes.Data.created_at,
                    updated_at = request.Dataa.Attributes.Data.updated_at
                };

                konteks.Product.Add(pro);
                await konteks.SaveChangesAsync(cancellationToken);

                return new PostProductCommandDto
                {
                    Status = true,
                    Message = "Product successfully posted",
                };

            }
        }
}

