using CityNews_Domain.Business.NewsApi;
using System.Threading.Tasks;

namespace CityNews_Application.Interfaces
{
    public interface ICityNewsApplication
    {
        Task<ResponseEverything> GetNews(string nameCity);
    }
}
