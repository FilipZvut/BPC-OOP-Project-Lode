namespace Lode.logic;
public class Board
{
    public const int BoardLenght = 5;
    public enum CellState
    {
        Empty,
        Ship,
        Hit,
        Miss
    }

    private CellState[,] _grid;

    public Board()
    {
        _grid = new CellState[BoardLenght, BoardLenght];
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < BoardLenght; i++)
        {
            for (int j = 0; j < BoardLenght; j++)
            {
                _grid[i, j] = CellState.Empty;
            }
        }
    }

    public bool PlaceShip(int row, int col)
    {
        if (_grid[row, col] == CellState.Empty)
        {
            _grid[row, col] = CellState.Ship;
            return true;
        }
        return false;
    }

    public bool Attack(int row, int col)
    {
        if (_grid[row, col] == CellState.Ship)
        {
            _grid[row, col] = CellState.Hit;
            return true;
        }
        else
        {
            _grid[row, col] = CellState.Miss;
            return false;
        }
    }

    public bool AllShipsSunk()
    {
        foreach (var cell in _grid)
        {
            if (cell == CellState.Ship)
            {
                return false;
            }
        }
        return true;
    }

    public CellState[,] GetGrid()
    {
        return _grid;
    }
}
