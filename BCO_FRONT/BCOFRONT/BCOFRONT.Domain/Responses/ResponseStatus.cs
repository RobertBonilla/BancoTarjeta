using System.Net;
namespace BCOFRONT.Domain.Responses
{
    public class ResponseStatus
    {
        public HttpStatusCode HttpCode { get; set; }
        public string Message { get; set; }
    }
}
