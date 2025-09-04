using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutomobiliuNuomaWebPage.Models;
using AutomobiliuNuomaWebPage.Services;

namespace AutomobiliuNuomaWebPage.Pages
{
        public class IndexModel : PageModel
        {
                private readonly ILogger<IndexModel> _logger;
                private readonly DataBaseService _databaseService;

                public IndexModel(ILogger<IndexModel> logger)
                {
                        _logger = logger;
                }
                public IndexModel (IDatabaseService databaseService)
                {
                        _databaseService = databaseService;
                }

                public void OnGet()
                {

                }
        }
}
