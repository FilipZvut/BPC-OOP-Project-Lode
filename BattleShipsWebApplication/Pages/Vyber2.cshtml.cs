using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Battleships.Logic;

namespace Battleships.Pages;



public class Vyber2Model : PageModel
{
    private readonly ILogger<Vyber2Model> _logger;
    public string Name1 { get; set; }
    public string Name2 { get; set; }    
    public string gm {  get; set; }

    public Vyber2Model(ILogger<Vyber2Model> logger)
    {
        _logger = logger;

    }

    public void OnGet(string data)
    {
        GameManager gameManager = new GameManager(data);
        gm = gameManager.ToString();
        Name1 = gameManager.Player1.Name;
        Name2 = gameManager.Player2.Name;
    }

    public IActionResult OnPostSelect(string gamedata)
    {

        string row = Request.Form["row"];
        string col = Request.Form["col"];
        var data = gamedata;
        GameManager gameManager = new GameManager(data);
        _logger.LogInformation("Volana metoda select hrac 2");
        if (gameManager.SelectPlaceShips(int.Parse(row), int.Parse(col), 2))
        {
            data = gameManager.ToString();
            return RedirectToPage("/Game", new { data });
        }
        else
        {
            data = gameManager.ToString();
            return RedirectToPage("/Vyber2", new { data });
        }


    }

    public IActionResult OnPostNahodne(string gamedata)
    {
        var data = gamedata;
        GameManager gameManager = new GameManager(data);
        gameManager.RandomPlace(2);
        data = gameManager.ToString();
        _logger.LogInformation("hrac2 nahodne vybral nahodne");
        return RedirectToPage("/Game", new { data });
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

