using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using SocialMedia.Services;

namespace SocialMedia.Controllers
{
    [Route("api/[controller]")]
    public class MediaController : Controller
    {
        private OpenWeatherMapAPI _openWeatherMapAPI;
        public MediaController(OpenWeatherMapAPI openWeatherMapAPI)
        {
            _openWeatherMapAPI = openWeatherMapAPI;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public async Task<List<WeatherForecast>> WeatherForecasts(string city)
        {
            return await _openWeatherMapAPI.Get(city);
        }
    }
}
