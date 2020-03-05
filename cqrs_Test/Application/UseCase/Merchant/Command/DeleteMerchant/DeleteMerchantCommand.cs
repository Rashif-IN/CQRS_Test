using System;
using MediatR;

namespace cqrs_Test.Application.UseCase.Merchant.Command.DeleteMerchant
{
    public class DeleteMerchantCommand : IRequest<DeleteMerchantCommandDto>
    {
        public DeleteMerchantData Data { get; set; }
    }
    public class DeleteMerchantData : IRequest<DeleteMerchantCommandDto>
    {
        public int id { get; set; }
    }
}
