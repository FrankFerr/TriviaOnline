using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Constants;

namespace Shared.ResponseModel
{
    public class RepositoryResponse : Response
    {
        public object? Data { get; set; }
    }
}
