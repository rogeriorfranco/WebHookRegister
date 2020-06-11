using System.Threading.Tasks;

namespace WebHookRegister.Service.Interfaces
{
    public interface INotifyService
    {
        Task<bool> SendAsync(string json);
    }
}
