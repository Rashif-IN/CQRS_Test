using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using cqrs_Test.Application.Models.Query;

namespace cqrs_Test.Application.UseCase.Merchant.Command.PutMerchant
{
    public class PutMerchantCommandHandler : IRequestHandler<PutMerchantCommand, PutMerchantCommandDto>
    {
        private readonly IContext konteks;

        public PutMerchantCommandHandler(IContext context)
        {
            konteks = context;
        }
        public async Task<PutMerchantCommandDto> Handle(RequestData<PutMerchantCommand> request, CancellationToken cancellationToken, int ID)
        {

            var mer = konteks.merhcants.Find(ID);
            mer.name = request.Dataa.Attributes.Data.name;
            mer.image = request.Dataa.Attributes.Data.image;
            mer.address = request.Dataa.Attributes.Data.address;
            mer.rating = request.Dataa.Attributes.Data.rating;
            mer.updated_at = request.Dataa.Attributes.Data.updated_at;



            await konteks.SaveChangesAsync(cancellationToken);

            return new PutMerchantCommandDto
            {
                Status = true,
                Message = "Merchant successfully putted"
            };

        }
    }
}
