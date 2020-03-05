using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using MediatR;

namespace cqrs_Test.Application.UseCase.Product.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductCommandDto>
    {
        private readonly IContext konteks;

        public DeleteProductCommandHandler(IContext context)
        {
            konteks = context;
        }
        public async Task<DeleteProductCommandDto> Handle(DeleteProductCommand request, int ID, CancellationToken cancellationToken)
        {
            var data = await konteks.merhcants.FindAsync(ID);
            if (data == null)
            {
                return new DeleteProductCommandDto
                {
                    Message = "Product not found",
                    Status = false
                };
            }
            else
            {
                konteks.merhcants.Remove(data);
                await konteks.SaveChangesAsync(cancellationToken);

                return new DeleteProductCommandDto
                {
                    Status = true,
                    Message = "Product sucessfully removed"
                };
            }


        }
    }
}
