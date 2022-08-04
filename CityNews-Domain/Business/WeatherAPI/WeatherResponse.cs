namespace CityNews_Domain.Business.WeatherApi
{
    public class WeatherResponse
    {
        public string name { get; set; }
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public Main main { get; set; }
    }

    public class Coord {
        public double lat { get; set; }
        public double lon { get; set; }
    }


    public class Weather {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
    }
}

