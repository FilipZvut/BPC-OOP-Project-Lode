using Battleships.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Battleships.Pages;


public class VyberModel : PageModel
{
    private readonly ILogger<VyberModel> _logger;
    public string Name1 { get; set; }
    public string Name2 { get; set; }
    public string gm { get; set; }
    public VyberModel(ILogger<VyberModel> logger)
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

        if (gameManager.SelectPlaceShips(int.Parse(row), int.Parse(col), 1))
        {
            data = gameManager.ToString();
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

