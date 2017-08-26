using System;
namespace PocketWeather.Models
{
  public partial class DailyWeather
  {

    public string DayName { get; set; }

    public DailyWeather()
    {
    }
  }

  public partial class DailyWeather
  {
    public static DailyWeather[] Examples => new DailyWeather[]
    {
        new DailyWeather() { DayName = "Friday"},
        new DailyWeather() { DayName = "Saturday"},
        new DailyWeather() { DayName = "Sunday"}
    };
  }
}
