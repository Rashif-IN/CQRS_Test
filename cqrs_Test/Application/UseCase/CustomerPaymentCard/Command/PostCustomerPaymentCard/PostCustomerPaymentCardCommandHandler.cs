using System;
using System.Threading;
using System.Threading.Tasks;
using cqrs_Test.Application.Interfaces;
using cqrs_Test.Application.Models.Query;
using MediatR;

namespace cqrs_Test.Application.UseCase.CustomerPaymentCard.Command.PostCustomerPaymentCard
{
    public class PostCustomerPaymentCardCommandHandler : IRequestHandler<PostCustomerPaymentCardCommand, PostCustomerCommandPaymentCardDto>
    {
        private readonly IContext konteks;

        public PostCustomerPaymentCardCommandHandler(IContext context)
        {
            konteks = context;
        }
        public async Task<PostCustomerPaymentCardCommandDto> Handle(RequestData<PostCustomerPaymentCardCommand> request, CancellationToken cancellationToken)
        {

            var cpc = new Domain.Entities.CustomerPaymentCards
            {
                id = request.Dataa.Attributes.Data.id,
                customer_id = request.Dataa.Attributes.Data.customer_id,
                name_on_card = request.Dataa.Attributes.Data.name_on_card,
                exp_month = request.Dataa.Attributes.Data.exp_month,
                exp_year = request.Dataa.Attributes.Data.exp_year,
                postal_code = request.Dataa.Attributes.Data.postal_code,
                credit_card_number = request.Dataa.Attributes.Data.credit_card_number,
                created_at = request.Dataa.Attributes.Data.created_at,
                updated_at = request.Dataa.Attributes.Data.updated_at
            };
            
            konteks.CPC.Add(cpc);
            await konteks.SaveChangesAsync(cancellationToken);

            return new PostCustomerPaymentCardCommandDto
            {
                Status = true,
                Message = "Customer Payment Card successfully posted",
            };

        }
    }
}
