using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    // This class holds all the data models that match the structure of the JSON returned by the weather API
    internal class WeatherInfo
    {
        
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }

        }
        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
        // The main class holds the temperature, pressure, and humidity data
        public class main
        {
            public double temp { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }

        }
        // The wind class holds the wind speed data
        public class wind
        {
            public double speed { get; set; }
        }
        public class sys
        {
            public long sunrise { get; set; }
            public long sunset { get; set; }
        }
        // The root class holds all the data returned by the API
        public class root
        {
            public coord coord { get; set; }
            public List<weather> weather { get; set; }
            public main main { get; set; }
            public wind wind { get; set; }
            public sys sys  { get; set; }

        }
    }
}
