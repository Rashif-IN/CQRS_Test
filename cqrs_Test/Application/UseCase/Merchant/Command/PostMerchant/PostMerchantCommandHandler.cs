using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using cqrs_Test.Application.Models.Query;
using MediatR;

namespace cqrs_Test.Application.UseCase.Merchant.Command.PostMerchant
{
    public class PostMerchantCommandHandler : IRequestHandler<PostMerchantCommand, PostMerchantCommandDto>
    {
        private readonly IContext konteks;

        public PostMerchantCommandHandler(IContext context)
        {
            konteks = context;
        }
        public async Task<PostMerchantCommandDto> Handle(RequestData<PostMerchantCommand> request, CancellationToken cancellationToken)
        {

            var mer = new Domain.Entities.Merchants
            {
                id = request.Dataa.Attributes.Data.id,
                name = request.Dataa.Attributes.Data.name,
                image = request.Dataa.Attributes.Data.image,
                address = request.Dataa.Attributes.Data.address,
                rating = request.Dataa.Attributes.Data.rating,
                created_at = request.Dataa.Attributes.Data.created_at,
                updated_at = request.Dataa.Attributes.Data.updated_at
            };

            konteks.merhcants.Add(mer);
            await konteks.SaveChangesAsync(cancellationToken);

            return new PostMerchantCommandDto
            {
                Status = true,
                Message = "Merchant successfully posted",
            };

        }
    }
}
