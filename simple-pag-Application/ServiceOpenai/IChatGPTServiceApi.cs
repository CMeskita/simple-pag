using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Application.ServiceOpenai
{
    public interface IChatGPTServiceApi
    {
        Task<string> ObterRespotaChatGpt(string prompt);
    }
}
