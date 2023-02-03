using Domain.Business.NewsApi;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INewsApplication
    {
        Task<ResponseEverything> GetNews(string nameCity);
    }
}
