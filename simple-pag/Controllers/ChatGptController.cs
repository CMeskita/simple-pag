using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using simple_pag_Application.ServiceOpenai;

namespace simple_pag.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ChatGptController : ControllerBase
    {
        private readonly IChatGPTServiceApi _chatGPTServiceApi;

        public ChatGptController(IChatGPTServiceApi chatGPTServiceApi)
        {
            _chatGPTServiceApi = chatGPTServiceApi;
        }

        [HttpGet]
        [AllowAnonymous]
       // [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> PergunteAoChatGpy(string pergunta)
        {
            var response = await _chatGPTServiceApi.ObterRespotaChatGpt(pergunta);
            return Ok(response);
        }

    }
   
}
