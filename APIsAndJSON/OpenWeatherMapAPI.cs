using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        //

        public static void GetTemp()
        {

            var appsettingsText = File.ReadAllText("appsettings.json");

            var apiKey = JObject.Parse(appsettingsText).GetValue("key").ToString();

            Console.WriteLine("Enter Zip:");

            var zip = Console.ReadLine();

            var url = $"http://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";

            var client = new HttpClient();

            var jsonText = client.GetStringAsync(url).Result;

            var weatherObj = JObject.Parse(jsonText);

            Console.WriteLine($"Temp: {weatherObj["main"]["temp"]}");
        }
    }
}
