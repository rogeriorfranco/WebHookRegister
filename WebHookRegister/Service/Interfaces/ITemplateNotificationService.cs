using System.Collections.Generic;
using System.Threading.Tasks;
using WebHookRegister.Domain.Enums;
using WebHookRegister.Domain.Request;
using WebHookRegister.Domain.Response;

namespace WebHookRegister.Service.Interfaces
{
    public interface ITemplateNotificationService
    {
        Task<IEnumerable<TemplateNotificationResponse>> GetByEventAsync(Event Eventname);
        Task<TemplateNotificationResponse> InsertAsync(TemplateNotificationRequest templateNotification);
        Task<bool> DeleteByIdAsync(long idTemplateNotification);
    }
}
