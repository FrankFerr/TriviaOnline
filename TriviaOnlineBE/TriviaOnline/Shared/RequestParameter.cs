using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Constants;

namespace Shared
{
    public class RequestParameter
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public ParametersType Type { get; set; }
    }
}
