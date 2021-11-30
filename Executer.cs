using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Speech;
using Microsoft.Speech.Recognition;

namespace ASSISTENTE_TCC_01
{
    class Executer
    {
        // Metodos de fala
        public static void GetHoras()
        {
            SaidaSom.Speak(DateTime.Now.ToShortTimeString());
        }

        public static void GetData()
        {
            SaidaSom.Speak(DateTime.Now.ToShortDateString());
        }

        public static void ModoSilencioso()
        {
            SaidaSom.Speak("Entrando no modo silencioso");
        }

        public static void VoltandoDoModoSilencioso()
        {
            SaidaSom.Speak("Estou de volta");
        }


     


        // Clima e Tempo

        public static void GetTemperature(string city)
        {
            List<string> infos = climaTempo.GetInfoCity(city);

            if (infos[0] == "error")
                return;

            SaidaSom.Speak("Hoje a temperatura é: " + infos[5] + "graus");
        }

        public static void GetMainInfos(string city)
        {
            List<string> infos = climaTempo.GetInfoCity(city);

            if (infos[0] == "error")
                return;

            string msg = String.Format(
                "Temperatura: {0} graus, " +
                "Sensação térmica: {1} graus " +
                "Temperaturas previstas: " +
                "Mínima de {2} graus, " +
                "Máxima de {3} graus," +
                "Humidade do ar: {4}%",

                infos[5],
                infos[8],
                infos[6],
                infos[7],
                infos[10]


                );

            SaidaSom.Speak(msg);
        }
        

        // Localização
        public static string GetIp()
        {
            return new WebClient().DownloadString("http://icanhazip.com");
        }

        public static string GetLocalizacao(string ip)
        {
            return Localizacao.GetCidadeNome(ip);
        }

        // Respostas básicas

       


    }
}
