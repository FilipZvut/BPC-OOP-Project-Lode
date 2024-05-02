using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Battleships.Logic;

namespace Battleships.Pages;


public class VyberModel : PageModel
{
    private readonly ILogger<VyberModel> _logger;
    public string Chyba { get; set; }
    public string Name1 { get; set; }
    public string Name2 { get; set; }
    public int VybraneLode { get; set; } // Proměnná pro sledování počtu vybraných lodí
    public string gm { get; set; }
    public VyberModel(ILogger<VyberModel> logger)
    {
        _logger = logger;
        Chyba = "";
        VybraneLode = 0; // Nastavení počtu vybraných lodí na začátku
    }
    public void OnGet(string data)
    {
        Chyba = "";
        GameManager gameManager = new GameManager(data);
        gm = gameManager.ToString();
        Name1 = gameManager.player1.Name;
        Name2 = gameManager.player2.Name;
    }
    public IActionResult OnPostSelect(string gamedata)
    {
        // Inkrementace počtu vybraných lodí po každém postu
        
        
        string row = Request.Form["row"];
        string col = Request.Form["col"];
        var data = gamedata;
        GameManager gameManager = new GameManager(data);
        if(gameManager.SelectPlaceShips(int.Parse(row), int.Parse(col),1))
        {
            data = gameManager.ToString();
        _logger.LogInformation("Volana metoda onPost");
            return RedirectToPage("/Vyber2", new { data });
        }
        else
        {
            data = gameManager.ToString();
            return RedirectToPage("/Vyber", new { data });
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
    public string GetCellSymbol(string cellState)
    {
        switch (cellState)
        {
            case "@":
                return "🌊";
            case "@@":
                return "🚢";
            case "@@@":
                return "💥";
            case "@@@@":
                return "❌";
            default:
                return "";
        }
    }
}

