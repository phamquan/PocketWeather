using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PocketWeather.Models;
using Refit;

namespace PocketWeather.Api
{
  public interface IOpenWeatherService
  {
    #region Weather
    [Get("/weather")]
    Task<Example> GetCurrentWeather(string id, string units, string appid);

    [Get("/forecast/daily")]
    Task<ExampleForecast> GetForecastWeather(string id, string units, string appid);
    #endregion
  }
}
