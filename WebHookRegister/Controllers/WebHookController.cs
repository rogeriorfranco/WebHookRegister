using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebHookRegister.Domain.Request;
using WebHookRegister.Service.Interfaces;

namespace WebHookRegister.Controllers
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class WebHookController : ControllerBase
    {
        public INotifyService _iNotifyService { get; }
        public WebHookController(INotifyService iNotifyService)
        {
            _iNotifyService = iNotifyService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]WebHookRequest request)
        {
            var result = await _iNotifyService.SendAsync(request.Event);

            return Ok(result);
        }
    }
}