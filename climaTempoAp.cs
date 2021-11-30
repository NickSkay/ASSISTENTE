using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSISTENTE_TCC_01
{
    class climaTempoAp
    {
        public class coord
        {
            public double longi { get; set; }

            public double lati { get; set; }
        }

        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
        }

        public class main 
        {
             public double tmep { get; set; }
             public double feels_like { get; set; }

            public double temp_min { get; set; }
            public double temp_max { get; set; }

            public double pessure { get; set; }
            public double humidity { get; set; }

        }

        public class wind
        {
            public double speed { get; set; }
            public double deg { get; set; }
        }

        public class root
        {
            public coord coord { get; set; }
            public wind wind { get; set; }
            public main main { get; set; }
            public string nome { get; set; }
            public List<weather> weather { get; set; }

    }


    }
}
