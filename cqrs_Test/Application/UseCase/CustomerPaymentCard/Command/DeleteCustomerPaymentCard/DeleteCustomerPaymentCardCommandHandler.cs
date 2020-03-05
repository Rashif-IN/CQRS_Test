using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using MediatR;

namespace cqrs_Test.Application.UseCase.CustomerPaymentCard.Command.DeleteCustomerPaymentCard
{
    public class DeleteCustomerPaymentCardCommandHandler : IRequestHandler<DeleteCustomerPaymentCardCommand, DeleteCustomerPaymentCardCommandDto>
    {
        private readonly IContext konteks;

        public DeleteCustomerPaymentCardCommandHandler(IContext context)
        {
            konteks = context;
        }
        public async Task<DeleteCustomerPaymentCardCommandDto> Handle(DeleteCustomerPaymentCardCommand request, int ID, CancellationToken cancellationToken)
        {
            var data = await konteks.CPC.FindAsync(ID);
            if (data == null)
            {
                return new DeleteCustomerPaymentCardCommandDto
                {
                    Message = "Customer not found",
                    Status = false
                };
            }
            else
            {
                konteks.CPC.Remove(data);
                await konteks.SaveChangesAsync(cancellationToken);

                return new DeleteCustomerPaymentCardCommandDto
                {
                    Status = true,
                    Message = "Customer sucessfully added"
                };
            }


        }
    }
}
