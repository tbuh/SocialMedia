using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia
{
    public class SocialAPISettings
    {
        private IConfiguration _configuration;
        public SocialAPISettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string OpenWeatherAPPID => _configuration["OpenWeather"];
        public string Facebook_verify_token => _configuration["Facebook:verify_token"];
        public string Facebook_access_token => _configuration["Facebook:access_token"];
    }
}
