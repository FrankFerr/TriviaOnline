using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestModel
{
    public class Request
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
    }
}
