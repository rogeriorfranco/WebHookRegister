using WebHookRegister.Domain.Enums;

namespace WebHookRegister.Domain.Response
{
    public class TemplateNotificationResponse
    {
        public long IdTemplateNotification { get; set; }
        public Event Event { get; set; }
        public string Name { get; set; }
        public string UrlNotification { get; set; }
    }
}
