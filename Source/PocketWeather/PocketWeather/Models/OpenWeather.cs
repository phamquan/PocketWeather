using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PocketWeather.Models
{
  [DataContract]
  public class Coord
  {

    [DataMember(Name = "lon")]
    public double lon { get; set; }

    [DataMember(Name = "lat")]
    public double lat { get; set; }
  }

  [DataContract]
  public class Weather
  {

    [DataMember(Name = "id")]
    public int id { get; set; }

    [DataMember(Name = "main")]
    public string main { get; set; }

    [DataMember(Name = "description")]
    public string description { get; set; }

    [DataMember(Name = "icon")]
    public string icon { get; set; }
  }

  [DataContract]
  public class Main
  {

    [DataMember(Name = "temp")]
    public double temp { get; set; }

    [DataMember(Name = "pressure")]
    public int pressure { get; set; }

    [DataMember(Name = "humidity")]
    public int humidity { get; set; }

    [DataMember(Name = "temp_min")]
    public double temp_min { get; set; }

    [DataMember(Name = "temp_max")]
    public double temp_max { get; set; }
  }

  [DataContract]
  public class Wind
  {

    [DataMember(Name = "speed")]
    public double speed { get; set; }

    [DataMember(Name = "deg")]
    public int deg { get; set; }
  }

  [DataContract]
  public class Clouds
  {

    [DataMember(Name = "all")]
    public int all { get; set; }
  }

  [DataContract]
  public class Sys
  {

    [DataMember(Name = "type")]
    public int type { get; set; }

    [DataMember(Name = "id")]
    public int id { get; set; }

    [DataMember(Name = "message")]
    public double message { get; set; }

    [DataMember(Name = "country")]
    public string country { get; set; }

    [DataMember(Name = "sunrise")]
    public int sunrise { get; set; }

    [DataMember(Name = "sunset")]
    public int sunset { get; set; }
  }

  [DataContract]
  public class Example
  {

    [DataMember(Name = "coord")]
    public Coord coord { get; set; }

    [DataMember(Name = "weather")]
    public IList<Weather> weather { get; set; }

    [DataMember(Name = "main")]
    public Main main { get; set; }

    [DataMember(Name = "visibility")]
    public int visibility { get; set; }

    [DataMember(Name = "wind")]
    public Wind wind { get; set; }

    [DataMember(Name = "clouds")]
    public Clouds clouds { get; set; }

    [DataMember(Name = "dt")]
    public int dt { get; set; }

    [DataMember(Name = "sys")]
    public Sys sys { get; set; }

    [DataMember(Name = "id")]
    public int id { get; set; }

    [DataMember(Name = "name")]
    public string name { get; set; }

    [DataMember(Name = "cod")]
    public int cod { get; set; }
  }


}
