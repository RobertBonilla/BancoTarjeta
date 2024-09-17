
using BCOFRONT.Core.Rest.Interfaces;
using BCOFRONT.Domain.Responses;
using Microsoft.Extensions.Options;
using RestSharp;

namespace BCOFRONT.Core.Rest.ApiRest
{
    public class ReporteApiRest : IReporteApiRest
    {
        private readonly AppSettings _appSettings;
        public ReporteApiRest(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }
        public historialTarjetaResponse GetHistorial(string noTarjeta)
        {
            try
            {
                string data = $"Reporte/GetHistorial/" + noTarjeta;
                RestClient rest = new RestClient(_appSettings.ApiBack);
                var restRequest = new RestRequest(data, Method.Get);
                restRequest.Timeout = new TimeSpan(0, 0, 60);
                var restResponse = rest.Execute<historialTarjetaResponse>(restRequest);
                if (restResponse.ErrorException != null)
                    throw new Exception(restResponse.ErrorMessage, restResponse.ErrorException);
                return restResponse.Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public infoTarjetaResponse GetInfoGeneral(string noTarjeta)
        {
            try
            {
                string data = $"Reporte/GetInfoGeneral/" + noTarjeta;
                RestClient rest = new RestClient(_appSettings.ApiBack);
                var restRequest = new RestRequest(data, Method.Get);
                restRequest.Timeout = new TimeSpan(0, 0, 60);
                var restResponse = rest.Execute<infoTarjetaResponse>(restRequest);
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
