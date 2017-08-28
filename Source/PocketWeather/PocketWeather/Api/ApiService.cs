using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PocketWeather.Models;
using Refit;

namespace PocketWeather.Api
{
  internal static partial class ApiService
  {
    internal static string Token
    {
      get
      {
        return "1212ee1dd762186ce0643bd9bfbea13e";
      }
    }

    internal static Task<Example> GetCurrentWeather()
    {
      var apiService = RestService.For<IOpenWeatherService>(Constants.HttpClient);
      return apiService.GetCurrentWeather("1566083", "metric", Token);
    }

    internal static Task<ExampleForecast> GetForecastWeather()
    {
      var apiService = RestService.For<IOpenWeatherService>(Constants.HttpClient);
      return apiService.GetForecastWeather("1566083", "metric", Token);
    }
  }
}
