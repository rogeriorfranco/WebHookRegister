using FluentValidation;
using WebHookRegister.Domain.Request;

namespace WebHookRegister.Infra.Validators
{
    public class TemplateNotificationValidator : AbstractValidator<TemplateNotificationRequest>
    {
        public TemplateNotificationValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Event).NotEmpty();
            RuleFor(x => x.UrlNotification).NotEmpty();
        }
    }
}
