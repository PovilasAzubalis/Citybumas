using AutomobiliuNuomaWebPage.Models;
namespace AutomobiliuNuomaWebPage.Services
{
        public interface IDatabaseService
        {
                IEnumerable<Automobilis> GetAutomobilis();
        }
}
