using Microsoft.EntityFrameworkCore;
using WebHookRegister.Domain.Entities;
using WebHookRegister.Infra.Repositories.Context.Configurations;

namespace WebHookRegister.Infra.Repositories.Context
{
    public class WebHookContext : DbContext
    {
        public WebHookContext(DbContextOptions<WebHookContext> options) : base(options)
        {
        }
        public virtual DbSet<TemplateNotification> TemplateNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            TemplateNotificationConfiguration.Configure(modelBuilder.Entity<TemplateNotification>());
        }
    }
}
