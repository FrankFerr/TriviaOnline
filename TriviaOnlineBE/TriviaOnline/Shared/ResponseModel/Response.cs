using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.Constants;

namespace Shared.ResponseModel
{
    public class Response
    {
        public bool Result { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public EResponse ResponseCode { get; set; } = EResponse.OK;
        public object? Data { get; set; }

        public override string ToString()
        {
            return $"RESPONSE:\n{{\n{nameof(Result)}: {Result}\nMessage: {nameof(Message)}\n{nameof(ResponseCode)}: {ResponseCode}\n{nameof(Data)}: {Data}\n}}";
        }
    }
}
