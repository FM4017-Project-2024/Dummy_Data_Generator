using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDataGenerator
{

    class Program
    {
        static void Main()
        {
            string filePath = "weather_energy_data.csv";
            Random random = new Random();

            // Create CSV headers
            string[] headers = { "Date", "Temperature (°C)", "Humidity (%)", "Wind Speed (km/h)", "Energy Consumption (kWh)" };
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(string.Join(",", headers));

                // Generate dummy data for 30 days
                for (int i = 0; i < 30; i++)
                {
                    DateTime date = DateTime.Now.AddDays(-i);
                    double temperature = random.Next(15, 30);  // Temperature between 15°C and 30°C
                    double humidity = random.Next(50, 80);     // Humidity between 50% and 80%
                    double windSpeed = random.Next(5, 20);     // Wind Speed between 5 and 20 km/h
                    double energyConsumption = Math.Round(100 + (temperature * 10) + (humidity * 0.5) - (windSpeed * 0.2));

                    string[] row = { date.ToString("yyyy-MM-dd"), temperature.ToString(), humidity.ToString(), windSpeed.ToString(), energyConsumption.ToString() };
                    writer.WriteLine(string.Join(",", row));
                }
            }

            Console.WriteLine($"Dummy data generated at {filePath}");
        }
    }

}

