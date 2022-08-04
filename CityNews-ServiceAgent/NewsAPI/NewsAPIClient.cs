using CityNews_Domain.Business.NewsApi;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CityNews_ServiceAgent.NewsAPI {
  public class NewsApiClient : INewsAPI {
    private readonly IConfiguration _configuration;

    public NewsApiClient(IConfiguration configuration) {
      _configuration = configuration;
    }

    private async Task<ResponseEverything> DoRequest(string url) {
      HttpClient client = new HttpClient();
      client.DefaultRequestHeaders.Add("User-Agent", "CityNews");
      HttpResponseMessage response = await client.GetAsync(url);
      if(response.IsSuccessStatusCode) {
        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ResponseEverything>(data);
      } else throw new Exception($"Error :: {response.Content.ReadAsStringAsync().Result}");
    }

    public async Task<ResponseEverything> Get(string cityName) {
      try {
        var baseAddress = _configuration["NewsApi:BaseAddress"];
        var path = _configuration["NewsApi:Path"];
        var query = _configuration["NewsApi:Query"];
        var apiKey = _configuration["NewsApi:Key"];
        string formatedQuery = string.Format(query, cityName, apiKey);
        string completeURL = $"{baseAddress}{path}{formatedQuery}";        
        return await DoRequest(completeURL);
      } catch(Exception ex) {
        throw ex;
      }
    }
  }
}

