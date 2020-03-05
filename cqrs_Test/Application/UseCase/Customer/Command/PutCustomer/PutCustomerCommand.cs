using System;
using MediatR;

namespace cqrs_Test.Application.UseCase.Customer.Command.PutCustomer
{
    public class PutCustomerCommand : IRequest<PutCustomerCommandDto>
    {
       public PutCustomerData Data { get; set; }
    }
    public class PutCustomerData
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string username { get; set; }
        public DateTime birthdate { get; set; }
        public string password { get; set; }
        public kelamin gender { get; set; }
        public string sex { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }
    }
    public enum kelamin
    {
        male,
        female,
        transexual_male,
        transexual_female,
        Metrosexual_male,
        Metrosexual_female,
        male_but_curious_what_being_female_is_like,
        female_but_curious_what_being_male_is_like

    }
}
