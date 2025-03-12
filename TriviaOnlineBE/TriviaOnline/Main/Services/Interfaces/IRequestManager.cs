using Shared.RequestModel;
using Shared.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Services.Interfaces
{
    public interface IRequestManager
    {
        Task<Response> Excecute(Request request, object? data);
    }
}
