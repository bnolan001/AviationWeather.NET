using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Models.Enums
{
    /// <summary>
    /// REF: https://aviationweather.gov/dataserver/fields?datatype=metar
    /// </summary>
    public class QualityControlFlagType
    {
        public static readonly QualityControlFlagType Corrected = new QualityControlFlagType("Corrected", 1, "Corrected");
        
        public static readonly QualityControlFlagType Auto = new QualityControlFlagType("Auto", Corrected.Value + 1, "Fully automated");
        
        public static readonly QualityControlFlagType AutoStation = new QualityControlFlagType("Auto_Station", Auto.Value + 1, "Indicates that the automated station type is one of the following: A01|A01A|A02|A02A|AOA|AWOS");
        
        public static readonly QualityControlFlagType MaintenanceIndicator = new QualityControlFlagType("Maintenance_Indicator", AutoStation.Value + 1, "Maintenance check indicator - maintenance is needed ");
        
        public static readonly QualityControlFlagType NoSignal = new QualityControlFlagType("No_Signal", MaintenanceIndicator.Value + 1, "No signal ");
        
        public static readonly QualityControlFlagType LightningSensorOff = new QualityControlFlagType("Lightning_Sensor_Off", NoSignal.Value + 1, "The lightning detection sensor is not operating- thunderstorm information is not available. ");
        
        public static readonly QualityControlFlagType FreezingRainSensorOff = new QualityControlFlagType("Freezing_Rain_Sensor_Off", LightningSensorOff.Value + 1, "The freezing rain sensor is not operating ");
        
        public static readonly QualityControlFlagType PresentWeatherSensorOff = new QualityControlFlagType("Present_Weather_Sensor_Off", FreezingRainSensorOff.Value + 1, "The present weather sensor is not operating ");
        
        public static readonly QualityControlFlagType Unknown = new QualityControlFlagType("Unknown", PresentWeatherSensorOff.Value + 1, "Unknown ");

        public string Name { get; private set; }

        public int Value { get; private set; }

        public string Description { get; private set; }

        private QualityControlFlagType(string name, int value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        public static List<QualityControlFlagType> List()
        {
            return new List<QualityControlFlagType> { Corrected, Auto, AutoStation, MaintenanceIndicator, NoSignal, LightningSensorOff, FreezingRainSensorOff, PresentWeatherSensorOff };
        }

        public static QualityControlFlagType ByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"'{nameof(name)} 'must have a value.");
            }

            var field = List().Where(m => String.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }

        public static QualityControlFlagType ByValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"'{nameof(value)} 'must have a value greater than 0.");
            }

            var field = List().Where(m => m.Value == value).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }
    }
}
