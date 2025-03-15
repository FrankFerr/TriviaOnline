using Shared.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestConfigManager
{
    public interface IRequestConfigManager
    {
        Task<RequestConfig> Get(string key);
        Task<string> GetString(string key);
    }
}
