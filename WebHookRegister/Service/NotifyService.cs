using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebHookRegister.Domain.Enums;
using WebHookRegister.Infra.Repositories.Interfaces;
using WebHookRegister.Service.Interfaces;

namespace WebHookRegister.Service
{
    public class NotifyService : INotifyService
    {
        public ITemplateNotificationRepository _iTemplateNotificationRepository { get; }
        public IMapper _mapper { get; }
        public NotifyService(ITemplateNotificationRepository iEventRepository, IMapper mapper)
        {
            _iTemplateNotificationRepository = iEventRepository;
            _mapper = mapper;
        }
        public async Task<bool> SendAsync(string json)
        {
            var templateNotification = await _iTemplateNotificationRepository.GetByEventAsync(Event.EVENT_NAME);

            foreach (var item in templateNotification)
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
                    var response = client.PostAsync(item.UrlNotification, content);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var strResult = JsonConvert.DeserializeObject<JObject>(response.Result.Content.ReadAsStringAsync().Result);
                    }
                }
            }
            return true;
        }
    }

}
