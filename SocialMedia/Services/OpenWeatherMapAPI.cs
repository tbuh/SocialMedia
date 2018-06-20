using Newtonsoft.Json;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class OpenWeatherMapAPI
    {
        private SocialAPISettings _socialAPISettings;
        public OpenWeatherMapAPI(SocialAPISettings socialAPISettings)
        {
            _socialAPISettings = socialAPISettings;
        }

        public async Task<List<WeatherForecast>> Get(string city)
        {
            string api = $"http://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&APPID={_socialAPISettings.OpenWeatherAPPID}";
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(15);
                var resp = await client.GetAsync(api);

                if (resp.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<OpenWeatherMap>(resp.Content.ReadAsStringAsync().Result);
                    return GetAndMap(result);
                }
                return null;
            }
        }

        private List<WeatherForecast> GetAndMap(OpenWeatherMap model)
        {
            var res = new List<WeatherForecast>();
            foreach (var item in model.list.Where(i => i.Date > DateTime.Now).Take(6))
            {
                res.Add(new WeatherForecast
                {
                    DateFormatted = item.Date.ToLongTimeString(),
                    Description = item.WeatherItem.description,
                    Temp = item.main.temp,
                    TempMin = item.main.temp_min,
                    TempMax = item.main.temp_max,
                    City = model.city.name,
                });
            }
            return res;
        }
    }
}
