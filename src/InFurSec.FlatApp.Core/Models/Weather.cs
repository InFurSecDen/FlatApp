using System;
namespace InFurSec.FlatApp.Core
{
    public class Weather
    {
        public double Temperature { get; set; }
        public double TemperatureWithWindChill { get; set; }
        public int Humidity { get; set; }
        public int WindSpeedAverage { get; set; }
        public int WindSpeedGust { get; set; }
        public int WindSpeedDirection { get; set; }
        public double Rainfall { get; set; }
    }
}
