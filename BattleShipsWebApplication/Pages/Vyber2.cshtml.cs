using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace projekt_lod�.Pages
{


    public class Vyber2Model : PageModel
    {
        private readonly ILogger<Vyber2Model> _logger;
        public string Chyba { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public int VybraneLode { get; set; } // Prom�nn� pro sledov�n� po�tu vybran�ch lod�
        
        public string gm {  get; set; }

        public Vyber2Model(ILogger<Vyber2Model> logger)
        {
            _logger = logger;
            Chyba = "";
            VybraneLode = 0; // Nastaven� po�tu vybran�ch lod� na za��tku
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
            VybraneLode++; // Inkrementace po�tu vybran�ch lod� po ka�d�m postu

            // Pokud jsou vybr�ny v�echny lod� (5), p�esm�ruj na �vodn� str�nku
            if (true)
            {
                _logger.LogInformation("Volana metoda onPost");
                var data = gamedata;
                return RedirectToPage("/game", new { data });
            }
            else
            {
                Chyba = "Vybrali jste " + VybraneLode + " lod�, vyberte dal��."; // Informace o po�tu vybran�ch lod�
                return Page(); // Z�sta� na stejn� str�nce
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
