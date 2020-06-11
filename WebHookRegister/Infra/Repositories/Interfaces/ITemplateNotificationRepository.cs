using System.Collections.Generic;
using System.Threading.Tasks;
using WebHookRegister.Domain.Entities;
using WebHookRegister.Domain.Enums;

namespace WebHookRegister.Infra.Repositories.Interfaces
{
    public interface ITemplateNotificationRepository
    {
        Task<TemplateNotification> GetByUrlAsync(string url);
        Task<IEnumerable<TemplateNotification>> GetByEventAsync(Event eventName);
        Task<TemplateNotification> InsertAsync(TemplateNotification templateNotification);
        Task<int> DeleteByIdAsync(long idTemplateNotification);
    }
}

