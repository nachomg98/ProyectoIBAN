//Quitamos las instrucciones using que no utilicemos.
using System;

namespace ProyectoIBAN
{
    public class Iban
    {
        /// <summary>
        /// Metodo que valida el IBAN.
        /// </summary>
        /// <param name="IBAN"></param>
        /// <returns></returns>
        public bool EsIBANvalido(string IBAN)
        {
            return IBAN == calcularIban(IBAN.Substring(4));
        }

        private string calcularIban(string ccc)
        {
            // Calculamos el IBAN
            string numeroCalcular = ccc.Trim();
            if (numeroCalcular.Length != 20)
            {
                return "La CCC debe tener 20 dígitos";
            }
            // Le añadimos el codigo del pais al ccc
            numeroCalcular = numeroCalcular + "142800";

            // Troceamos el ccc en partes (26 digitos)
            string[] partesCCC = new string[5];
            partesCCC[0] = numeroCalcular.Substring(0, 5);
            partesCCC[1] = numeroCalcular.Substring(5, 5);
            partesCCC[2] = numeroCalcular.Substring(10, 5);
            partesCCC[3] = numeroCalcular.Substring(15, 5);
            partesCCC[4] = numeroCalcular.Substring(20, 6);

            int miResultado = int.Parse(partesCCC[0]) % 97;
            string resultado = miResultado.ToString();
            for (int i = 0; i < partesCCC.Length - 1; i++)
            {
                miResultado = int.Parse(resultado + partesCCC[i + 1]) % 97;
                resultado = miResultado.ToString();
            }
            // Le restamos el resultado a 98
            int miRestoIban = 98 - int.Parse(resultado);
            string restoIban = miRestoIban.ToString();
            if (restoIban.Length == 1)
                restoIban = "0" + restoIban;

            //Devolvemos el Iban
            return "ES" + restoIban + ccc;
        }
    }
}
