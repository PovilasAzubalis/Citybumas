using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Interfaces;

namespace _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Models
{        //NaftosKuroAutomobilis: papildoma savybė BakoTalpa.
    public class NaftosKuroAutomobilis : Automobilis, IAutomobiliuSpausdinimas
    {
        public int BakoTalpa { get; set; }
        public NaftosKuroAutomobilis(int _id, string _marke, string _modelis, int _gamybosMetai, string regNr, int bakoTalpa) : base(_id, _marke, _modelis, _gamybosMetai, regNr)
        {
            BakoTalpa = bakoTalpa;
        }
        public NaftosKuroAutomobilis(string _marke, string _modelis, int _gamybosMetai, string regNr, int bakoTalpa) : base(_marke, _modelis, _gamybosMetai, regNr)
        {
            BakoTalpa = bakoTalpa;
        }

        public NaftosKuroAutomobilis() : base()
        {
        }

        public override string ToString()
        {
            return $"| {AutomobilioId} | {Marke} | {Modelis} | {Gamybosmetai} | {RegNr} | {BakoTalpa} |";
        }
    }
}
