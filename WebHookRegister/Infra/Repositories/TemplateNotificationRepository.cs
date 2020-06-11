using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHookRegister.Domain.Entities;
using WebHookRegister.Domain.Enums;
using WebHookRegister.Infra.Repositories.Context;
using WebHookRegister.Infra.Repositories.Interfaces;

namespace WebHookRegister.Infra.Repositories
{
    public class TemplateNotificationRepository : ITemplateNotificationRepository
    {
        private readonly WebHookContext _context;
        public TemplateNotificationRepository(WebHookContext context)
        {
            _context = context;
        }
        public async Task<TemplateNotification> GetByUrlAsync(string url)
        {
            return await _context.TemplateNotifications.Where(x => x.UrlNotification == url).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<TemplateNotification>> GetByEventAsync(Event eventName)
        {
            return await _context.TemplateNotifications.Where(x => x.Event == eventName).ToListAsync();
        }
        public async Task<TemplateNotification> InsertAsync(TemplateNotification templateNotification)
        {
            var insert = await _context.TemplateNotifications.AddAsync(templateNotification);
            _context.SaveChanges();
            return insert.Entity;
        }
        public async Task<int> DeleteByIdAsync(long idTemplateNotification)
        {
            await _context.TemplateNotifications.Where(x => x.IdTemplateNotification == idTemplateNotification).FirstOrDefaultAsync();
            _context.TemplateNotifications.Remove(null);
            return _context.SaveChanges();
        }
    }
}
