using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebHookRegister.Domain.Entities;

namespace WebHookRegister.Infra.Repositories.Context.Configurations
{
    public class TemplateNotificationConfiguration
    {
        public static void Configure(EntityTypeBuilder<TemplateNotification> builder)
        {
            builder.ToTable(nameof(TemplateNotification)).HasKey(t => t.IdTemplateNotification);
            builder.Property(t => t.IdTemplateNotification).UseIdentityColumn();
            builder.Property(t => t.Event).HasColumnType("VARCHAR(50)").HasConversion<string>();
            builder.Property(t => t.Name).IsRequired().HasColumnType("VARCHAR(100)");
            builder.Property(t => t.UrlNotification).IsRequired().HasColumnType("VARCHAR(100)");
        }
    }
}
