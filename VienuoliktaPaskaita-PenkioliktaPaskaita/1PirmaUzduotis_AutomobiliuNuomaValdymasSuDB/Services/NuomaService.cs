using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Interfaces;
using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Models;

namespace _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Services
{
    public class NuomaService: INuomaService
    {
        private readonly IDatabaseRepository _databaseRepository;
        public NuomaService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public void PridetiRegistruotaAuto(Automobilis automobilis)
        {
            if (automobilis is ElektrinisAutomobilis)
            {
                 _databaseRepository.AddElektrinisAutomobilis((ElektrinisAutomobilis)automobilis);
            }
            else
            {
                _databaseRepository.AddNaftosKuroAutomobilis((NaftosKuroAutomobilis)automobilis);
            }
        }

        
    }

}
