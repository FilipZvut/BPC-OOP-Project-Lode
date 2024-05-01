using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace projekt_lodì.Pages
{


    public class Vyber2Model : PageModel
    {
        private readonly ILogger<Vyber2Model> _logger;
        public string Chyba { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public int VybraneLode { get; set; } // Promìnná pro sledování poètu vybraných lodí
        
        public string gm {  get; set; }

        public Vyber2Model(ILogger<Vyber2Model> logger)
        {
            _logger = logger;
            Chyba = "";
            VybraneLode = 0; // Nastavení poètu vybraných lodí na zaèátku
        }

        public void OnGet(string data)
        {
            Chyba = "";
            GameManager gameManager = new GameManager(data);
            gm = gameManager.ToString();
            Name1 = gameManager.player1.Name;
            Name2 = gameManager.player2.Name;
        }

        public IActionResult OnPost(string gamedata)
        {
            VybraneLode++; // Inkrementace poètu vybraných lodí po každém postu

            // Pokud jsou vybrány všechny lodì (5), pøesmìruj na úvodní stránku
            if (true)
            {
                _logger.LogInformation("Volana metoda onPost");
                var data = gamedata;
                return RedirectToPage("/game", new { data });
            }
            else
            {
                Chyba = "Vybrali jste " + VybraneLode + " lodí, vyberte další."; // Informace o poètu vybraných lodí
                return Page(); // Zùstaò na stejné stránce
            }
        }

        public IActionResult OnPostNahodne(string gamedata)
        {
            var data = gamedata;
            GameManager gameManager = new GameManager(data);
            gameManager.RandomPlace(2);
            data = gameManager.ToString();
            _logger.LogWarning("hrac2 nahodne");
            return RedirectToPage("/game", new { data });
        }
    }
}
