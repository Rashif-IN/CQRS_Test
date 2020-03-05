using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using cqrs_Test.Application.Models.Query;
using MediatR;

namespace cqrs_Test.Application.UseCase.Product.Command.PutProduct
{
    public class PutProductCommandHandler : IRequestHandler<PutProductCommand, PutProductCommandDto>
    {
        private readonly IContext konteks;

        public PutProductCommandHandler(IContext context)
        {
            konteks = context;
        }
        public async Task<PutProductCommandDto> Handle(RequestData<PutProductCommand> request, CancellationToken cancellationToken, int ID)
        {

            var pro = konteks.Product.Find(ID);
            pro.merhcant_id = request.Dataa.Attributes.Data.merhcant_id;
            pro.name = request.Dataa.Attributes.Data.name;
            pro.price = request.Dataa.Attributes.Data.price;
            
            pro.updated_at = request.Dataa.Attributes.Data.updated_at;



            await konteks.SaveChangesAsync(cancellationToken);

            return new PutProductCommandDto
            {
                Status = true,
                Message = "Product successfully putted"
            };

        }
    }
}
