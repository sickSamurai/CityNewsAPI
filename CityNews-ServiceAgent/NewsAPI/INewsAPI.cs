using CityNews_Domain.Business.NewsApi;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CityNews_ServiceAgent.NewsAPI {
  public interface INewsAPI {
    Task<ResponseEverything> Get(string cityName);
  }
}
