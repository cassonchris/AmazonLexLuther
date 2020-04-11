using System.Threading.Tasks;
using AmazonLexLuther.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmazonLexLuther.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BotController : Controller
    {
        private readonly IAmazonLexService _amazonLexService;

        public BotController(IAmazonLexService amazonLexService)
        {
            _amazonLexService = amazonLexService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SendMessage(string message)
        {
            var response = await _amazonLexService.SendTextMsgToLex(message, HttpContext.Session.Id);
            return Ok(response.Message);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Test()
        {
            return Ok("testing...");
        }
    }
}