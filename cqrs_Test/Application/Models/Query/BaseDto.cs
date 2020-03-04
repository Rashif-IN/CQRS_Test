using System;
namespace cqrs_Test.Application.Models.Query
{
    public class BaseDto
    {
        public bool Status { set; get; }
        public string Message { set; get; }
    }
}
