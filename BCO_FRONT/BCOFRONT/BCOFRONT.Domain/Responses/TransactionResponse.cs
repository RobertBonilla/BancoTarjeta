
namespace BCOFRONT.Domain.Responses
{
    public class TransactionResponse
    {
        public ResponseStatus Status { get; set; }

        public string Message { get; set; }

        public bool IsSuccess { get; set; }
    }
}
