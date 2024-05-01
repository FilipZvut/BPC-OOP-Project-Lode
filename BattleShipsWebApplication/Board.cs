using static Board;

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

    public string[,] StringGrid;

    public CellState[,] _grid;

    public Board()
    {
        _grid = new CellState[BoardLength, BoardLength];
        StringGrid = new string[BoardLength, BoardLength];
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
        UpdateStringGrid();
    }

    private void UpdateStringGrid()
    {
        for (int i = 0; i < BoardLength; i++)
        {
            for (int j = 0; j < BoardLength; j++)
            {
                StringGrid[i, j] = GetCellSymbol(_grid[i,j]);
            }
        }
    }

    public bool PlaceShip(int row, int col)
    {
        if (_grid[row, col] == CellState.Empty)
        {
            _grid[row, col] = CellState.Ship;
            UpdateStringGrid();
            return true;
        }
        return false;
    }

    public bool Attack(int row, int col)
    {
        if (_grid[row, col] == CellState.Ship)
        {
            _grid[row, col] = CellState.Hit;
            UpdateStringGrid();
            return true;
        }
        else
        {
            _grid[row, col] = CellState.Miss;
            UpdateStringGrid();
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

    public string GetCellSymbol(CellState cellState)
    {
        switch (cellState)
        {
            case CellState.Empty:
                return "@";
            case CellState.Ship:
                return "@@";
            case CellState.Hit:
                return "@@@";
            case CellState.Miss:
                return "@@@@";
            default:
                return "";
        }
    }

    public CellState[,] GetGrid()
    {
        return _grid;
    }


    public String[,] GetStringGrid()
    {
        return StringGrid;
    }

    public void SetupGrid(string oldgrid)
    {
        string[] dataradky = oldgrid.Split(',');
        for(int i =0; i < BoardLength; i++)
        {
            string[] dataPolozky = dataradky[i].Split('.');
            for(int j = 0; j < BoardLength; j++)
            {
                StringGrid[i,j] = dataPolozky[j];
            }
        }
        UpdateGrid();
    }

    public void UpdateGrid()
    {
        for (int i = 0; i < BoardLength; i++)
        {
            for (int j = 0; j < BoardLength; j++)
            {
                _grid[i, j] = GetCellState(StringGrid[i,j]);
            }
        }
    }

    CellState GetCellState(string cellname)
    {
        switch (cellname)
        {
            case "x222":
                return CellState.Empty;
            case "x223":
                return CellState.Ship;
            case "x224":
                return CellState.Hit;
            case "x225":
                return CellState.Miss;
            default:
                return CellState.Empty;
        }
    }
}
