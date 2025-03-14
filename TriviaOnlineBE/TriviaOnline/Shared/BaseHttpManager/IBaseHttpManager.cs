using Shared.RequestModel;
using Shared.ResponseModel;

namespace Shared.BaseHttpManager
{
    public interface IBaseHttpManager
    {
        Task<Response> Excecute(Request request, object? data, List<RequestParameter> parameters);
    }
}
