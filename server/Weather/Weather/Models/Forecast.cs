using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Models
{
    public class Forecast
    {
        public string Location { get; set; }
        public string Time { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string Sky { get; set; }
        public string Temp { get; set; }
        public string Dew { get; set; }
        public string Humidity { get; set; }
        public string Presurre { get; set; }
    }
}