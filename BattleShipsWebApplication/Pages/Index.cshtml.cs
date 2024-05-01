using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace projekt_lodě.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Chyba { get; set; }
        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Chyba = "";       
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation("Volana metoda onPost");
            var name1 = Request.Form["name1"];
            var name2 = Request.Form["name2"];
            GameManager gameManager = new GameManager();
            gameManager.GameCreated(name1, name2);
            var data = gameManager.ToString();


            // Přesměrování na stránku uvodni s přidáním parametrů do URL
            if (string.IsNullOrEmpty(name1) || string.IsNullOrEmpty(name2))
            {

                Chyba = "Zadejte přezdívky obou hráčů";
                return Page();

            }
            else if (name1.ToString() == name2.ToString())
            {
                Chyba = "Zadejte rozdílné přezdívky hráčů";
                return Page();
            }
            else
                return RedirectToPage("/Vyber", new { data });
        }

    }

}

