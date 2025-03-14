using Shared.RequestModel;
using Shared.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestManager
{
    public interface IRequestManager
    {
        Task<Response> Execute(RequestConfig config, object? data);
        void AddParameters(RequestParameter param);
    }
}
