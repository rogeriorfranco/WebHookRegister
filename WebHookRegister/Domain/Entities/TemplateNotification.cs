using WebHookRegister.Domain.Enums;

namespace WebHookRegister.Domain.Entities
{
    public class TemplateNotification
    {
        public long IdTemplateNotification { get; set; }
        public Event Event { get; set; }
        public string Name { get; set; }
        public string UrlNotification { get; set; }
    }
}
