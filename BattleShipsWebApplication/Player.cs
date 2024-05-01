public class Player
{
    public Board Board { get; set; }
    public int Id { get; init; }
    public string Name { get; set; }

    public Player(int id, string name)
    {
        Board = new Board();
        Id = id;
        Name = name;
    }

    public Board.CellState[,] GetGrid()
    {
        return Board.GetGrid();
    }

    public String[,] GetStringGrid()
    {
        return Board.GetStringGrid();
    }
}