using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PocketWeather.Models
{
  [DataContract]
  public class City
  {

    [DataMember(Name = "geoname_id")]
    public int geoname_id { get; set; }

    [DataMember(Name = "name")]
    public string name { get; set; }

    [DataMember(Name = "lat")]
    public double lat { get; set; }

    [DataMember(Name = "lon")]
    public double lon { get; set; }

    [DataMember(Name = "country")]
    public string country { get; set; }

    [DataMember(Name = "iso2")]
    public string iso2 { get; set; }

    [DataMember(Name = "type")]
    public string type { get; set; }

    [DataMember(Name = "population")]
    public int population { get; set; }
  }

  [DataContract]
  public class Temp
  {

    [DataMember(Name = "day")]
    public double day { get; set; }

    [DataMember(Name = "min")]
    public double min { get; set; }

    [DataMember(Name = "max")]
    public double max { get; set; }

    [DataMember(Name = "night")]
    public double night { get; set; }

    [DataMember(Name = "eve")]
    public double eve { get; set; }

    [DataMember(Name = "morn")]
    public double morn { get; set; }
  }

  [DataContract]
  public class ListInfo
  {

    [DataMember(Name = "dt")]
    public int dt { get; set; }

    [DataMember(Name = "temp")]
    public Temp temp { get; set; }

    [DataMember(Name = "pressure")]
    public double pressure { get; set; }

    [DataMember(Name = "humidity")]
    public int humidity { get; set; }

    [DataMember(Name = "weather")]
    public IList<Weather> weather { get; set; }

    [DataMember(Name = "speed")]
    public double speed { get; set; }

    [DataMember(Name = "deg")]
    public int deg { get; set; }

    [DataMember(Name = "clouds")]
    public int clouds { get; set; }

    [DataMember(Name = "snow")]
    public double snow { get; set; }
  }

  [DataContract]
  public class ExampleForecast
  {

    [DataMember(Name = "cod")]
    public string cod { get; set; }

    //[DataMember(Name = "message")]
    //public int message { get; set; }

    [DataMember(Name = "city")]
    public City city { get; set; }

    [DataMember(Name = "cnt")]
    public int cnt { get; set; }

    [DataMember(Name = "list")]
    public IList<ListInfo> list { get; set; }
  }
}