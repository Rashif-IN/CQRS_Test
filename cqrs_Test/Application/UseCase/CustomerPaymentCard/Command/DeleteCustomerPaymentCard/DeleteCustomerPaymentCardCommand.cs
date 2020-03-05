using System;
using MediatR;

namespace cqrs_Test.Application.UseCase.CustomerPaymentCard.Command.DeleteCustomerPaymentCard
{
    public class DeleteCustomerPaymentCardCommand : IRequest<DeleteCustomerPaymentCardCommandDto>
    {
        public DeleteCustomerPaymentCardData Data { get; set; }

    }
    public class DeleteCustomerPaymentCardData : IRequest<DeleteCustomerPaymentCardCommandDto>
    {
        public int id { get; set; }
    }

}
