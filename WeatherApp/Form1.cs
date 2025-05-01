using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace WeatherApp
{
    // Form1 inherits from Form or UI window
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string APIKey = "021f9a05df6086948d2b751d47883fed";

        // This method runs when the "Search" button is clicked

        private void btn_search_Click(object sender, EventArgs e)
        {
            getWeather();
        }

        // Method to get weather data from the API
        private void getWeather()
        {
            //WebClient to make HTTP requests from your application to weatherapi
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=imperial", TbCity.Text, APIKey);
                
                // Sending request and getting response as JSON string
                var json = web.DownloadString(url);

                // Converting JSON into a WeatherInfo.root C# object

                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                // Displaying the weather icon in the UI
                pic_icon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";

                // label or box initialization to display the weather information 
                lab_condtion.Text = "Conditions: "+ Info.weather[0].main;
                lab_detail.Text = "Detail: " + Info.weather[0].description;
                lab_temp.Text = "Temperature: " + Info.main.temp + " °F";
                lab_sunset.Text = ConvertUnixToTimeString(Info.sys.sunset).ToString();
                lab_sunrise.Text = ConvertUnixToTimeString(Info.sys.sunrise).ToString();
                lab_windspeed.Text = Info.wind.speed.ToString() +  " mph";
                lab2.Text = "Humidity: " + Info.main.humidity.ToString() + "%";
                lab4.Text = "Wind: "  + Info.wind.speed.ToString() + "mph";

                //Converting hPa or hectopascals into inHg or inches of mercury
                lab_pressure.Text = (Info.main.pressure * 0.02953).ToString("0.00")+" inHg";

            }

        }
        // Convert Unix timestamp into readable time
        private string ConvertUnixToTimeString(long unixTime)
        {
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            date = date.AddSeconds(unixTime).ToLocalTime();
            return date.ToString("hh:mm tt"); 
        }

        //Intializing X button to close Application
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TbCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lab_condtion_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pic_icon_Click(object sender, EventArgs e)
        {

        }

        private void lab2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
