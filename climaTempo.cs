using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace ASSISTENTE_TCC_01
{
    class climaTempo
    {
        private const string KEY = "9e1280f88eef9db700e867bb898fd3ec";

        public static List<string> GetInfoCity(string city)
        {
            List<string> infos = new List<string>();

            try
            {
                using (WebClient web = new WebClient())
                {
                    string url = String.Format("http://api.openweathermap.org/data/2.5/weather?q=%7B0%7D&appid={1}&units=metric&lang=pt", city, KEY);

                    var json = web.DownloadString(url);
                    var result = JsonConvert.DeserializeObject<climaTempoAp.root>(json);

                    climaTempoAp.root outPut = result;


                    infos.Add(outPut.nome); // [0]
                    infos.Add(outPut.coord.longi.ToString()); // [1]
                    infos.Add(outPut.coord.lati.ToString()); // [2]
                    infos.Add(outPut.weather[0].main.ToString()); // [3]
                    infos.Add(outPut.weather[0].description.ToString()); // [4]
                    infos.Add(outPut.main.tmep.ToString()); // [5]
                    infos.Add(outPut.main.temp_max.ToString()); // [6]
                    infos.Add(outPut.main.temp_min.ToString()); // [7]
                    infos.Add(outPut.main.feels_like.ToString()); // [8]
                    infos.Add(Math.Round((outPut.main.pessure / 1013), 2).ToString()); // [9]
                    infos.Add(outPut.main.humidity.ToString()); // [10]
                    infos.Add(outPut.wind.speed.ToString()); // [11]
                    infos.Add(outPut.wind.deg.ToString()); // [12]

                    return infos;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu um erro ao buscar informações sobre o tempo" +
                    "\n Verifique sua conexão com a rede." +
                    "\n\n\n" + e.Message, "Erro ao buscar informações");

                infos.Clear();
                infos.Add("error");
            }

            return infos;
        }
    }
}
