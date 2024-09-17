using BCOFRONT.Core.Rest.Interfaces;
using BCOFRONT.Domain.Dtos;
using BCOFRONT.Domain.Responses;
using Microsoft.Extensions.Options;
using RestSharp;

namespace BCOFRONT.Core.Rest.ApiRest
{
    public class TransactionApiRest : ITransactionApiRest
    {
        private readonly AppSettings _appSettings;
        public TransactionApiRest(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }
        public TransactionResponse compraTarjeta(cargoDto model)
        {
            try
            {
                string data = $"Transaction/Compra";
                RestClient rest = new RestClient(_appSettings.ApiBack);
                var restRequest = new RestRequest(data, Method.Post);
                restRequest.AddJsonBody(model);
                restRequest.Timeout = new TimeSpan(0, 0, 60);
                var restResponse = rest.Execute<TransactionResponse>(restRequest);
                if (restResponse.ErrorException != null)
                    throw new Exception(restResponse.ErrorMessage, restResponse.ErrorException);
                return restResponse.Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public TransactionResponse pagoTarjeta(abonoDto model)
        {
            try
            {
                string data = $"Transaction/Pago";
                RestClient rest = new RestClient(_appSettings.ApiBack);
                var restRequest = new RestRequest(data, Method.Post);
                restRequest.AddJsonBody(model);
                restRequest.Timeout = new TimeSpan(0, 0, 60);
                var restResponse = rest.Execute<TransactionResponse>(restRequest);
                if (restResponse.ErrorException != null)
                    throw new Exception(restResponse.ErrorMessage, restResponse.ErrorException);
                return restResponse.Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
