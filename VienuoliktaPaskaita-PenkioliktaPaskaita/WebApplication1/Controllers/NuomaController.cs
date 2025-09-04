using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Interfaces;
using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Models;
using _1PirmaUzduotis_AutomobiliuNuomaValdymasSuDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutomobiliuNuomaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NuomaController : ControllerBase
    {
        private readonly INuomaService _nuomaService;
        public NuomaController(INuomaService nuomaService)
        {
            _nuomaService = nuomaService;
        }
        
        [HttpGet("GetAllAutomobiliai")]
        public List<Automobilis> GetAllAutomobiliai()
        {
           NuomaServiceUI.AutomobiliuSarasoSpausdinimas();
            
        }

    }
}
