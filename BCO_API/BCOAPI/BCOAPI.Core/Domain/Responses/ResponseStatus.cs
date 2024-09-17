using System.Net;

namespace BCOAPI.Core.Domain.Responses
{
    public class ResponseStatus
    {
        public HttpStatusCode HttpCode { get; set; }
        public string Message { get; set; }
    }
}
