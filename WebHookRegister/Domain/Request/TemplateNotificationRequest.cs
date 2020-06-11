using WebHookRegister.Domain.Enums;

namespace WebHookRegister.Domain.Request
{
    public class TemplateNotificationRequest
    {
        public Event Event { get; set; }
        public string Name { get; set; }
        public string UrlNotification { get; set; }
    }
}
