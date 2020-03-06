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
       

        public async Task<PutCustomerPaymentCardCommandDto> Handle(PutCustomerPaymentCardCommand request, CancellationToken cancellationToken)
        {
            var cpc = konteks.CPC.Find(request.Dataa.Attributes.id);
            cpc.customer_id = request.Dataa.Attributes.customer_id;
            cpc.name_on_card = request.Dataa.Attributes.name_on_card;
            cpc.exp_month = request.Dataa.Attributes.exp_month;
            cpc.exp_year = request.Dataa.Attributes.exp_year;
            cpc.postal_code = request.Dataa.Attributes.postal_code;
            cpc.credit_card_number = request.Dataa.Attributes.credit_card_number;
            cpc.updated_at =  Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);



            await konteks.SaveChangesAsync(cancellationToken);

            return new PutCustomerPaymentCardCommandDto
            {
                Status = true,
                Message = "Customer Payment Card successfully putted"
            };
        }
    }
}
