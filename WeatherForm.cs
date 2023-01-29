using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Weathear;

namespace Weather
{
    public partial class WeatherForm : Form
    {
        public WeatherForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double lat = Double.Parse(textBox1.Text);
                double lon = Double.Parse(textBox2.Text);
                string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid=0fb33c4a59bcf9edff5f7101358e0fec";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string response = reader.ReadToEnd();
                richTextBox1.Text += response;
                WeatherResponse wr = JsonConvert.DeserializeObject<WeatherResponse>(response);
                ICity.Text = wr.Name;
                ITemperatura.Text = (wr.Main.Temp - 273).ToString();
            }
            catch { richTextBox1.Text += "Неверный ввод данных  \r\n"; }
        }
    }
}

