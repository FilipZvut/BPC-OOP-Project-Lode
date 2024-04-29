using Microsoft.AspNetCore.Mvc.RazorPages;

public class uvodniModel : PageModel
{
    public string Nazev1 { get; set; }
    public string Nazev2 { get; set; }

    public void OnGet(string name1, string name2)
    {
        // Vytvoření instance GameManager s použitím předaných jmen hráčů
        var gameManager = new GameManager();
        gameManager.GameCreated(name1, name2);

        // Přiřazení jmen hráčů do vlastností modelu pro použití na stránce
        Nazev1 = gameManager.player1.Name;
        Nazev2 = gameManager.player2.Name;
    }
}
