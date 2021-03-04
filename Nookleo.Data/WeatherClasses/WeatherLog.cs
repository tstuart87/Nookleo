using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Data.WeatherClasses
{
    public class WeatherLog
    {
        //Daily Weather Log for every Location from Ambee API
        //This data will be from three separate API calls
        // API CALLS - Yesterday Weather - Today Forecast - Soil Temperature/Moisture

        [Key]
        public int WeatherLogId { get; set; }
        public int LocationId { get; set; }
        public decimal TemperatureHigh { get; set; } //Yesterday's High to calculate GDDs
        public decimal TemperatureLow { get; set; } //Yesterday's Low to calculate GDDs
        public int GDDs { get; set; } //Accumulate everyday start at PlantingDate - Stop at HarvestDate
        public decimal Precipitation { get; set; }
        public decimal FiveDayTotalPrecipitation { get; set; }
        public decimal CloudCover { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal SoilTemperature { get; set; }
        public decimal SoilMoisture { get; set; }
    }
}
