using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace projekt_lod�.Pages
{


    public class VyberModel : PageModel
    {
        private readonly ILogger<VyberModel> _logger;
        public string Chyba { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public int VybraneLode { get; set; } // Prom�nn� pro sledov�n� po�tu vybran�ch lod�

        public string gm { get; set; }

        public VyberModel(ILogger<VyberModel> logger)
        {
            _logger = logger;
            Chyba = "";
            VybraneLode = 0; // Nastaven� po�tu vybran�ch lod� na za��tku
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
            VybraneLode++; // Inkrementace po�tu vybran�ch lod� po ka�d�m postu

            if (gamedata == "nahodne")
            {
                var data = gm;
                GameManager gameManager = new GameManager(data);
                //gameManager.RandomPlace(1);
                data = gameManager.ToString();
                return RedirectToPage("/Vyber2", new { data });
            }
            //Pokud jsou vybr�ny v�echny lod�(5), p�esm�ruj na �vodn� str�nku
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
                Chyba = "Vybrali jste " + VybraneLode + " lod�, vyberte dal��."; // Informace o po�tu vybran�ch lod�
                return RedirectToPage("/Vyber", new { data }); // Z�sta� na stejn� str�nce
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
