using static Battleships.Logic.GameManager;
namespace Battleships.Logic;

public class Board
{
    private string[,] _stringGrid;
    private CellState[,] _grid;

    public CellState[,] Grid {  get { return _grid; } }
    public string[,] StringGrid { get { return _stringGrid; } }
    
    public enum CellState
    {
        Empty,
        Ship,
        Hit,
        Miss
    }

    public Board()
    {
        _grid = new CellState[BOARDLENGTH, BOARDLENGTH];
        _stringGrid = new string[BOARDLENGTH, BOARDLENGTH];
        InitializeGrid();
    }
    public void InitializeGrid()
    {
        for (int i = 0; i < BOARDLENGTH; i++)
        {
            for (int j = 0; j < BOARDLENGTH; j++)
            {
                _grid[i, j] = CellState.Empty;
            }
        }
        UpdateStringGrid();
    }
    private void UpdateStringGrid()
    {
        for (int i = 0; i < BOARDLENGTH; i++)
        {
            for (int j = 0; j < BOARDLENGTH; j++)
            {
                _stringGrid[i, j] = GetCellSymbol(_grid[i,j]);
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
        if (_grid[row, col] != CellState.Miss && _grid[row, col] != CellState.Hit)
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
                return true;
            }
        }
        else
            return false;
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
    private string GetCellSymbol(CellState cellState)
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
    public void SetupGrid(string oldgrid)
    {
        string[] dataradky = oldgrid.Split(',');
        for(int i =0; i < BOARDLENGTH; i++)
        {
            string[] dataPolozky = dataradky[i].Split('.');
            for(int j = 0; j < BOARDLENGTH; j++)
            {
                _stringGrid[i,j] = dataPolozky[j];
            }
        }
        UpdateGrid();
    }
    public void UpdateGrid()
    {
        for (int i = 0; i < BOARDLENGTH; i++)
        {
            for (int j = 0; j < BOARDLENGTH; j++)
            {
                _grid[i, j] = GetCellState(_stringGrid[i,j]);
            }
        }
    }
    CellState GetCellState(string cellname)
    {
        switch (cellname)
        {
            case "@":
                return CellState.Empty;
            case "@@":
                return CellState.Ship;
            case "@@@":
                return CellState.Hit;
            case "@@@@":
                return CellState.Miss;
            default:
                return CellState.Empty;
        }
    }
}
