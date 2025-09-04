using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Models
{
        internal class Klientai
        {
                string Vardas { get; set; }
                string Pavarde { get; set; }
                int Telefonas { get; set; }
                Klientai()
                {

                }
                Klientai(string vardas, string pavarde, int telefonas)
                {
                        Vardas = vardas;
                        Pavarde = pavarde;
                        Telefonas = telefonas;
                }
        }
}
