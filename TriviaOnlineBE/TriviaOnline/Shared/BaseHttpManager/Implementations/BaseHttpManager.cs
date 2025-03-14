using Newtonsoft.Json;
using Shared.RequestModel;
using Shared.ResponseModel;
using System.Text;
using static Shared.Constants;
using Microsoft.Extensions.Logging;

namespace Shared.BaseHttpManager
{
    public class BaseHttpManager : IBaseHttpManager
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BaseHttpManager> _logger;
        private readonly HttpRequestMessage _message;

        public BaseHttpManager(IHttpClientFactory httpClienttFactory, ILogger<BaseHttpManager> logger)
        {
            _httpClientFactory = httpClienttFactory;
            _logger = logger;
            _message = new HttpRequestMessage();
        }

        public async Task<Response> Excecute(Request request, object? data, List<RequestParameter> parameters)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            _message.Headers.Add("Accept", "application/json");
            _message.Method = HttpMethod.Parse(request.Method);

            UpdateMessageWithParameters(parameters, request.Route, out string newRoute);

            _message.RequestUri = new Uri(request.BaseUrl + newRoute);

            if(data != null)
            {
                _message.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage? httpResponse = null;

            try
            {
                _logger.LogInformation($"Eseguo la chiamata [{_message.Method.ToString()}: {_message.RequestUri.OriginalString}]");
                httpResponse = await client.SendAsync(_message);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Errore durante la chiamata {_message.Method.ToString()} al path {_message.RequestUri.OriginalString} " + ex.Message);

                throw;
            }

            _logger.LogInformation($"Chiamata avvenuta con successo [{_message.Method.ToString()}: {_message.RequestUri.OriginalString}]");

            string responseContent = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response>(responseContent)!;
        }

        private void UpdateMessageWithParameters(List<RequestParameter> parameters, string route, out string newRoute)
        {
            StringBuilder routeBuilder = new StringBuilder(route);
            bool firstQuery = true;

            foreach(RequestParameter param in parameters)
            {
                switch (param.Type)
                {
                    case ParametersType.HEADERS:
                        {
                            _message.Headers.Add(param.Key, param.Value);
                            break;
                        }

                    case ParametersType.PATH:
                        {
                            routeBuilder.Replace($"{{{param.Key.ToLower()}}}", param.Value);
                            break;
                        }

                    case ParametersType.QUERY:
                        {
                            if (firstQuery)
                            {
                                routeBuilder.Append('?');
                                firstQuery = false;
                            }
                            else
                            {
                                routeBuilder.Append('&');
                            }

                            routeBuilder.Append($"{param.Key}={param.Value}");
                            break;
                        }
                }
            }

            newRoute = routeBuilder.ToString();
        }

    }
}
