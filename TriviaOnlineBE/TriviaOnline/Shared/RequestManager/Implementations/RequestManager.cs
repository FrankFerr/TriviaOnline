using Shared.BaseHttpManager;
using Shared.RequestModel;
using Shared.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Constants;

namespace Shared.RequestManager
{
    public class RequestManager : IRequestManager
    {
        private readonly List<RequestParameter> _parameters = new();
        private readonly IBaseHttpManager _baseHttpManager;

        public RequestManager(IBaseHttpManager baseHttpManager)
        {
            _baseHttpManager = baseHttpManager;
        }

        public void AddParameters(RequestParameter param)
        {
            _parameters.Add(param);
        }

        private void ClearParameters()
        {
            _parameters.Clear();
        }

        public async Task<Response> Execute(RequestConfig config, object? data)
        {
            Request request = new Request
            {
                BaseUrl = config.BaseUrl,
                Route = config.Route,
                Method = config.Method
            };

            Response response;

            try
            {
                response = await _baseHttpManager.Excecute(request, data, _parameters);
            }
            catch(Exception ex)
            {
                response = new()
                {
                    Result = false,
                    ResponseCode = EResponse.ERRORE_REQUEST,
                    Message = ex.Message
                };
            }
            finally
            {
                ClearParameters();
            }

            return response;
        }

        
    }
}
