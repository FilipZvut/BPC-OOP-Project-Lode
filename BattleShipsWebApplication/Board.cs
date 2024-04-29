public class Board
{
    public const int BoardLength = 5;
    public enum CellState
    {
        Empty,
        Ship,
        Hit,
        Miss
    }

    public CellState[,] _grid;

    public Board()
    {
        _grid = new CellState[BoardLength, BoardLength];
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < BoardLength; i++)
        {
            for (int j = 0; j < BoardLength; j++)
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
