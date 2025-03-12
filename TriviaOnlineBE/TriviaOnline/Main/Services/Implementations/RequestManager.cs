using Main.Services.Interfaces;
using Newtonsoft.Json;
using Shared.RequestModel;
using Shared.ResponseModel;
using System;
using System.Net;
using System.Text;
using static Shared.Constants;

namespace Main.Services.Implementations
{
    public class RequestManager : IRequestManager
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<RequestManager> _logger;

        public RequestManager(IHttpClientFactory httpClienttFactory, ILogger<RequestManager> logger)
        {
            _httpClientFactory = httpClienttFactory;
            _logger = logger;
        }

        public async Task<Response> Excecute(Request request, object? data)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            message.Method = GetMethodType(request.Method);
            message.RequestUri = new Uri(request.BaseUrl + request.Route);

            if(data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage? httpResponse = null;

            try
            {
                httpResponse = await client.SendAsync(message);
            }
            catch(Exception ex)
            {
                _logger.LogError("Errore durante la chiamata {method} al path {path} " + ex.Message, message.Method.ToString(), message.RequestUri.OriginalString);

                return new Response { Result = false, ResponseCode = EResponse.ERRORE_REQUEST };
            }

            string responseContent = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response>(responseContent)!;
        }

        private HttpMethod GetMethodType(string method)
        {
            throw new NotImplementedException();
        }
    }
}
