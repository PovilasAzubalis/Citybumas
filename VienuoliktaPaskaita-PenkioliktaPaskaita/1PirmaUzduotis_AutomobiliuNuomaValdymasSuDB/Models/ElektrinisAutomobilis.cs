using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Interfaces;

namespace _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Models
{       //Elektromobilis: papildoma savybė BaterijosTalpa.
    public class ElektrinisAutomobilis : Automobilis, IAutomobiliuSpausdinimas
    {
        public int BaterijosTalpa { get; set; }

        public ElektrinisAutomobilis(int _id, string _marke, string _modelis, int _gamybosMetai, string regNr, int baterijosTalpa) : base(_id, _marke, _modelis, _gamybosMetai, regNr)
        {
            BaterijosTalpa = baterijosTalpa;
        }
        public ElektrinisAutomobilis(string _marke, string _modelis, int _gamybosMetai, string regNr, int baterijosTalpa) : base(_marke, _modelis, _gamybosMetai, regNr)
        {
            BaterijosTalpa = baterijosTalpa;
        }
        public ElektrinisAutomobilis() : base()
        {
        }

        public override string ToString()
        {
            return $"| {AutomobilioId} | {Marke} | {Modelis} | {Gamybosmetai} | {RegNr} |{BaterijosTalpa} |";
        }
    }
}
