using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Models;

namespace _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Interfaces
{ //Funkcionalumai:
  //Automobilių registracija ir jų tipų priskyrimas.
  //Automobilių sąrašo gavimas su galimybe filtruoti pagal tipą.
  //Automobilių informacijos atnaujinimas.
  //Automobilių ištrinimas.
  //Automobilio išnuomavimas pasirinkus automobilį ir pasirinkus klientą, bei priskyrus laiką.Jeigu Automobilis jau yra kažkam tuo laikotarpiu išnuomotas, turi būti metama klaida, jog automobilio išnuomuoti negalima.

        public interface IDatabaseRepository
        {       
                IEnumerable<ElektrinisAutomobilis> GetElektrinisAutomobiliuSarasas();
                IEnumerable<NaftosKuroAutomobilis> GetNaftosAutomobiliuSarasas();
                void AddElektrinisAutomobilis(ElektrinisAutomobilis naujasAutomobilis);
                void AddNaftosKuroAutomobilis(NaftosKuroAutomobilis naujasAutomobilis);
                void UpdateElektrinisAutomobilis(ElektrinisAutomobilis naujasAutomobilis);
                void UpdateNaftosKuroAutomobilis(NaftosKuroAutomobilis naujasAutomobilis);
                void DeleteElektrinisAutomobilis(int id);
                void DeleteNaftosKuroAutomobilis(int id);

        }
}
