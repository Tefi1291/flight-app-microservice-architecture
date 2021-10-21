using System.Threading.Tasks;

namespace FlightService.Clients.Interfaces 
{
    public interface IApiHttpClient 
    {
        Task SendPostAsync(string url, object requestBody);
    }
}
