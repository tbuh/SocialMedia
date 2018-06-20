using Newtonsoft.Json;
using System;

namespace SocialMedia.Models
{
    public class OpenWeatherMap
    {
        public string cod { get; set; }
        public string message { get; set; }
        public string cnt { get; set; }
        public City city { get; set; }
        public Item[] list { get; set; }

        public string Error { get; set; }
    }

    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Item
    {
        public string dt { get; set; }
        public string name { get; set; }
        public string dt_txt { get; set; }
        public DateTime Date
        {
            get
            {
                return DateTime.Parse(dt_txt);
            }
        }

        public ItemMain main { get; set; }
        public Weather[] weather { get; set; }

        [JsonIgnore]
        public Weather WeatherItem
        {
            get
            {
                if (weather?.Length > 0) return weather[0];
                return new Weather();
            }
        }

        public override string ToString()
        {
            return $"{dt_txt} {WeatherItem.description} temp {main.temp} min {main.temp_min} max {main.temp_max};";
        }
    }

    public class Weather
    {
        public string id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
    }

    public class ItemMain
    {
        public string temp { get; set; }
        public string temp_min { get; set; }
        public string temp_max { get; set; }
        public string humidity { get; set; }
    }
}
