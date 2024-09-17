
using BCOFRONT.Core.Rest.Interfaces;
using BCOFRONT.Domain.Responses;
using Microsoft.Extensions.Options;
using RestSharp;

namespace BCOFRONT.Core.Rest.ApiRest
{
    public class ClienteApiRest : IClienteApiRest
    {
        private readonly AppSettings _appSettings;
        public ClienteApiRest(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public ClienteResponse GetCliente(string IdCliente)
        {
            try
            {
                string data = $"Cliente/GetCliente/" + IdCliente;
                RestClient rest = new RestClient(_appSettings.ApiBack);
                var restRequest = new RestRequest(data, Method.Get);
                restRequest.Timeout = new TimeSpan(0,0,60);
                var restResponse = rest.Execute<ClienteResponse>(restRequest);
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
