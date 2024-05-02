namespace Battleships.Logic;
public class Player
{
    public Board Board { get; set; }
    public int Id { get; init; }
    public string Name { get; set; }
    public Board.CellState[,] Grid { get { return Board.Grid;} }
    public String[,] StringGrid { get { return Board.StringGrid; } }

    public Player(int id, string name)
    {
        Board = new Board();
        Id = id;
        Name = name;
    }


}