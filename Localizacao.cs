using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
namespace ASSISTENTE_TCC_01
{
    class Localizacao
    {
        public static string GetCidadeNome(string ip)
        {
            string city;
            try
            {
                using (WebClient webC = new WebClient())
                {
                    String url = String.Format("https://api.ipify.org", ip);

                    var json = webC.DownloadString(url);
                    var result = JsonConvert.DeserializeObject<LocalizacaoAp.root>(json);

                    LocalizacaoAp.root saida = result;

                    city = saida.city;

                }
            }
            catch (Exception)
            {
                city = "error";
            }

            return city;
        }
    }
}
