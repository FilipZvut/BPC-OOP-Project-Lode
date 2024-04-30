using Microsoft.AspNetCore.Mvc.RazorPages;

public class uvodniModel : PageModel
{
    public string Nazev1 { get; set; }
    public string Nazev2 { get; set; }
    public Board.CellState[,] Grid1 { get; set; }
    public Board.CellState[,] Grid2 { get; set; }
    public Player AktualniHrac { get; set; }

    public void OnGet(string name1, string name2)
    {
        // Vytvoření instance GameManager s použitím předaných jmen hráčů
        var gameManager = new GameManager();
        gameManager.GameCreated(name1, name2);

        // Přiřazení jmen hráčů do vlastností modelu pro použití na stránce
        Nazev1 = gameManager.player1.Name;
        Nazev2 = gameManager.player2.Name;
        Grid1 = gameManager.player1.GetGrid();
        Grid2 = gameManager.player2.GetGrid();
        gameManager.RandomPlace(1);
        gameManager.RandomPlace(2);
        AktualniHrac = gameManager.GetAktualniHrac();
    }

    public string GetCellSymbol(Board.CellState cellState)
    {
        switch (cellState)
        {
            case Board.CellState.Empty:
                return "";
            case Board.CellState.Ship:
                return "S";
            case Board.CellState.Hit:
                return "X";
            case Board.CellState.Miss:
                return "O";
            default:
                return "";
        }
    }
}
