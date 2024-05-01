using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace projekt_lodì.Pages
{


    public class VyberModel : PageModel
    {
        private readonly ILogger<VyberModel> _logger;
        public string Chyba { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public int VybraneLode { get; set; } // Promìnná pro sledování poètu vybraných lodí

        public string gm { get; set; }

        public VyberModel(ILogger<VyberModel> logger)
        {
            _logger = logger;
            Chyba = "";
            VybraneLode = 0; // Nastavení poètu vybraných lodí na zaèátku
        }

        public void OnGet(string data)
        {
            Chyba = "";
            GameManager gameManager = new GameManager(data);
            gameManager.RandomPlace(1);
            gm = gameManager.ToString();
            Name1 = gameManager.player1.Name;
            Name2 = gameManager.player2.Name;

        }

        public IActionResult OnPost(string gamedata, string gameButton)
        {
            VybraneLode++; // Inkrementace poètu vybraných lodí po každém postu

            if (gamedata == "nahodne")
            {
                var data = gm;
                GameManager gameManager = new GameManager(data);
                //gameManager.RandomPlace(1);
                data = gameManager.ToString();
                return RedirectToPage("/Vyber2", new { data });
            }
            //Pokud jsou vybrány všechny lodì(5), pøesmìruj na úvodní stránku
            if (true)
            {
                _logger.LogInformation("Volana metoda onPost");
                var data = gamedata;
                GameManager gm = new GameManager(data);
                gm.RandomPlace(1);
                data = gm.ToString();
                return RedirectToPage("/Vyber2", new { data });
            }
            else
            {
                var data = gamedata;
                Chyba = "Vybrali jste " + VybraneLode + " lodí, vyberte další."; // Informace o poètu vybraných lodí
                return RedirectToPage("/Vyber", new { data }); // Zùstaò na stejné stránce
            }
        }

        public IActionResult OnPostNahodne(string gamedata)
        {
            var data = gamedata;
            GameManager gameManager = new GameManager(data);
            gameManager.RandomPlace(1);
            data = gameManager.ToString();
            _logger.LogWarning("hrac1 nahodne");
            return RedirectToPage("/Vyber2", new { data });
        }
    }
}
