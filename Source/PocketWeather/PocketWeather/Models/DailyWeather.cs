using System;
namespace PocketWeather.Models
{
  public partial class DailyWeather
  {

    public string DayName
    {
      get
      {
        //DateTime d = new DateTime(dt);
        var d = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(dt).ToUniversalTime();
        return d.DayOfWeek.ToString();
      }
    }
    public Double Temp { get; set; }
    public Double TempMin { get; set; }
    public Double TempMax { get; set; }
    public String Main { get; set; }
    public int dt { get; set; }

    public string WeatherIcon { get; set; }

    public DailyWeather()
    {
    }


  }

  public partial class DailyWeather
  {
    //public static DailyWeather[] Examples => new DailyWeather[]
    //{
    //    new DailyWeather() { DayName = "Friday"},
    //    new DailyWeather() { DayName = "Saturday"},
    //    new DailyWeather() { DayName = "Sunday"}
    //};
  }
}
