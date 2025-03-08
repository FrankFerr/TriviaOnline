using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class RepositoryResponse
    {
        public bool Result { get; set; } = true;
        public string Message { get; set; } = Constants.ERepositoryResponse.OK.ToString();
        public object? Data { get; set; }
    }
}
