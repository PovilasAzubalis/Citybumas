namespace _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Models
{        //Automobiliai bus suskirstyti į du tipus: naftos kuro automobilius ir elektromobilius.

        //Paveldėjimas:
        //Sukurkite bazinę klasę Automobilis, kuri turės savybes: Id, Marke, Modelis, Metai, RegistracijosNumeris.
        public class Automobilis
        {
                public int AutomobilioId { get; set; }
                public string Marke { get; protected set; }
                public string Modelis { get; protected set; }
                public int Gamybosmetai { get; protected set; }
                public string RegNr { get; protected set; }
                public Automobilis()
                {

                }
                public Automobilis(int automobilioId)
                {
                        AutomobilioId = automobilioId;
                }

                public Automobilis(string marke, string modelis, int gamybosmetai, string regNr)
                {
                        Marke = marke;
                        Modelis = modelis;
                        Gamybosmetai = gamybosmetai;
                        RegNr = regNr;
                }

                public Automobilis(int automobilioId, string marke, string modelis, int gamybosmetai, string regNr)
                {
                        AutomobilioId = automobilioId;
                        Marke = marke;
                        Modelis = modelis;
                        Gamybosmetai = gamybosmetai;
                        RegNr = regNr;
                }


                public override string ToString()
                {
                        return $"| {AutomobilioId} | {Marke} | {Modelis} | {Gamybosmetai} | {RegNr} |";
                }

        }
}
