using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebHookRegister.Domain.Enums;
using WebHookRegister.Domain.Request;
using WebHookRegister.Infra.Validators;
using WebHookRegister.Service.Interfaces;

namespace WebHookRegister.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TemplateNotificationController : ControllerBase
    {
        public ITemplateNotificationService _iTemplateNotificationService { get; }
        public TemplateNotificationController(ITemplateNotificationService iTemplateNotificationService)
        {
            _iTemplateNotificationService = iTemplateNotificationService;
        }

        [HttpGet("Event/{name}")]
        public async Task<IActionResult> GetByEventAsync([FromRoute]Event name)
        {
            var result = await _iTemplateNotificationService.GetByEventAsync(name);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TemplateNotificationRequest request)
        {
            var validation = new TemplateNotificationValidator().Validate(request);

            if (validation.IsValid is false)
                return BadRequest(validation.Errors);

            var result = await _iTemplateNotificationService.InsertAsync(request);
          
            return Ok(result);
        }

        [HttpDelete("{idTemplateNotification}")]
        public async Task<IActionResult> Delete([FromRoute]long idTemplateNotification)
        {
            var result = await _iTemplateNotificationService.DeleteByIdAsync(idTemplateNotification);

            if (result is false)
                return BadRequest();

            return Ok(result);
        }
    }
}
