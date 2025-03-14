using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestConfigManager
{
    public class RequestConfigManager : IRequestConfigManager
    {
        public JObject? Content { get; set; }

        public T Initialize<T>(string filename)
        {
            Content = JObject.Parse(File.ReadAllText(filename));
            return (T)Convert.ChangeType(this, typeof(T));
        }

        public async Task<RequestConfig?> Get(string key)
        {
            RequestConfig? result = default;

            await Task.Run(() =>
            {
                JToken? token = Content?.SelectToken(key);
                string tokenStr = token?.ToString() ?? string.Empty;

                if (string.IsNullOrEmpty(tokenStr))
                {
                    Serilog.Log.Error($"Configurazione repository mancante: [{key}]");
                }
                else
                {
                    Serilog.Log.Information($"Configurazione recuperata [{key}]: {tokenStr}");
                    result = JsonConvert.DeserializeObject<RequestConfig>(tokenStr)!;
                }
            });

            return result;
        }

        public async Task<string> GetString(string key)
        {
            string result = "";

            await Task.Run(() =>
            {
                JToken? token = Content?.SelectToken(key);
                string tokenStr = token?.ToString() ?? string.Empty;

                if (string.IsNullOrEmpty(tokenStr))
                {
                    Serilog.Log.Error($"Configurazione repository mancante: [{key}]");
                }
                else
                {
                    Serilog.Log.Information($"Configurazione recuperata [{key}]: {tokenStr}");
                    result = tokenStr;
                }
            });

            return result;
        }
    }
}
