using System;
using System.Net.Http;

namespace PocketWeather
{
  public static class Constants
  {

    private static String API_BASE_URL
    {
      get
      {
        return "http://api.openweathermap.org/data/2.5";
      }
    }

    public static HttpClient HttpClient
    {
      get
      {
        return new HttpClient()
        {
          BaseAddress = new Uri(API_BASE_URL)
        };
      }
    }

    public static string CURRENCY_FORMAT
    {
      get
      {
        return "n0";
      }
    }

    public static string DATETIME_FORMAT
    {
      get
      {
        return "dd/MM/yyyy";
      }
    }
  }
}
