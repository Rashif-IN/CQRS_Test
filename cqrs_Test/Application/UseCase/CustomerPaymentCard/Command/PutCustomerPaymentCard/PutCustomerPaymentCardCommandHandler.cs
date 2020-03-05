using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using cqrs_Test.Application.Models.Query;
using MediatR;

namespace cqrs_Test.Application.UseCase.CustomerPaymentCard.Command.PutCustomerPaymentCard
{
    public class PutCustomerPaymentCardCommandHandler : IRequestHandler<PutCustomerPaymentCardCommand, PutCustomerPaymentCardCommandDto>
    {
        private readonly IContext konteks;

        public PutCustomerPaymentCardCommandHandler(IContext context)
        {
            konteks = context;
        }
        public async Task<PutCustomerPaymentCardCommandDto> Handle(RequestData<PutCustomerPaymentCardCommand> request, CancellationToken cancellationToken, int ID)
        {

            var cpc = konteks.CPC.Find(ID);
            cpc.customer_id = request.Dataa.Attributes.Data.customer_id;
            cpc.name_on_card = request.Dataa.Attributes.Data.name_on_card;
            cpc.exp_month = request.Dataa.Attributes.Data.exp_month;
            cpc.exp_year = request.Dataa.Attributes.Data.exp_year;
            cpc.postal_code = request.Dataa.Attributes.Data.postal_code;
            cpc.credit_card_number = request.Dataa.Attributes.Data.credit_card_number;
            cpc.updated_at = request.Dataa.Attributes.Data.updated_at;

            

            await konteks.SaveChangesAsync(cancellationToken);

            return new PutCustomerPaymentCardCommandDto
            {
                Status = true,
                Message = "Customer Payment Card successfully putted"
            };

        }
    }
}
