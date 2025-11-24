using Codeworkhub.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Codeworkhub.Controllers
{
    [Route("Ai")]
    public class AiController : Controller
    {
        [HttpPost("ProcessCommand")]
        public IActionResult ProcessCommand([FromBody] Dictionary<string, string> data)
        {
            var input = data["message"];
            var response = AiCommandHelper.ProcessCommand(input);

            return Json(new { replies = response.replies, action = response.actionUrl });
        }
    }

}
