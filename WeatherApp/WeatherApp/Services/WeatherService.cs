using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        const string ApiKey = "7f03ef27360f3d188b40c450bd04c5d7";

        public async Task<WeatherInfo> GetCityWeather(string city)
        {
            var client = new HttpClient();
            try
            {
                var response = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={city.ToLower()}&units=metric&appid={ApiKey}");
                var data = JsonConvert.DeserializeObject<WeatherInfo>(response);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<WeatherForecast> GetCityWeatherForecast(string city)
        {
            var client = new HttpClient();

            try
            {

                var response = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/forecast?q={city.ToLower()}&units=metric&appid={ApiKey}");
                var data = JsonConvert.DeserializeObject<WeatherForecast>(response);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Byte[]> GetImageFromUrl(string url)
        {
            using(var client = new HttpClient())
            {
                var msg = await client.GetAsync(url);
                if (msg.IsSuccessStatusCode)
                {
                    var byteArray = await msg.Content.ReadAsByteArrayAsync();
                    return byteArray;
                } else
                {
                    return null;
                }
            }
        }
    }
}