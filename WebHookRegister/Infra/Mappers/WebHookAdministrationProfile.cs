using AutoMapper;
using WebHookRegister.Domain.Entities;
using WebHookRegister.Domain.Request;
using WebHookRegister.Domain.Response;

namespace WebHookRegister.Infra.Mappers
{
    public class WebHookAdministrationProfile : Profile
    {
        public WebHookAdministrationProfile()
        {
            CreateMap<TemplateNotification, TemplateNotificationResponse>();
            CreateMap<TemplateNotificationRequest, TemplateNotification>();
        }
    }
}
