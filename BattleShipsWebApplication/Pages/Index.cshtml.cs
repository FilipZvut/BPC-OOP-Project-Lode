using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace projekt_lodě.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var name1 = Request.Form["name1"];
            var name2 = Request.Form["name2"];
            var gameManager = new GameManager();
            gameManager.GameCreated(name1, name2);

            // Přesměrování na stránku uvodni s přidáním parametrů do URL
            return RedirectToPage("/uvodni", new { name1, name2 });

        }

    }
}
