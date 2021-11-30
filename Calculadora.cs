using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSISTENTE_TCC_01
{
    class Calculadora
    {
        public static string Calcule(string entrada)
        {

            // qnt é cinco mais cinco
            //0 - qnt
            //1 - é
            //2 - cinco
            //3 - mais
            //4 - cinco
            string[] parts = entrada.Split(' ');
            double n1 = Gramaticas.DicNumeros[parts[2]];
            double n2;
            double result = 0;

            try
            {
                n2 = Gramaticas.DicNumeros[parts[4]];
            }
            catch (KeyNotFoundException)
            {
                n2 = Gramaticas.DicNumeros[parts[5]];
            }

            try
            {


                switch (parts[3])
                {
                    case "mais":
                        result = n1 + n2;
                        break;

                    case "menos":
                        result = n1 - n2;
                        break;

                    case "vezes":
                        result = n1 * n2;
                        break;

                    case "dividido":
                        result = n1 / n2;
                        break;

                    case "elevado":
                        result = Math.Pow(n1, n2);
                        break;

                    case "raiz":
                        result = Math.Pow(n1, 1 / n2);
                        break;
                }
            }
            catch (Exception)
            {
                return "Cálculo inválido";
            }

            return Math.Round(result, 2).ToString();

            
        }
    }
}
