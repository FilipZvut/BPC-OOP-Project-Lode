namespace Battleships.Logic;
public class GameManager
{
    private Player _player1;
    private Player _player2;
    private Game _game;

    public const int SHIPS = 7;
    public const int BOARDLENGTH = 5;
    public Player CurrentPlayer { get { return _game.CurrentPlayer; } }
    public Player Player1 { get { return _player1; } }
    public Player Player2 { get { return _player2; } }

    public GameManager()
    {

    }

    public GameManager(string OldGameManager)
    {
        FromString(OldGameManager);
    }


    public void GameCreated(string name1, string name2, int id)
    {

        _player1 = new Player(1, name1);
        
        _player2 = new Player(2, name2);
        
        _game = new Game(_player1, _player2, id);

    }

    public void RandomPlace(int id)
    {
        if(id == 1)
            _game.PlaceShipsRandomly(_player1);
        else
            _game.PlaceShipsRandomly(_player1);       
    }

    public bool SelectPlaceShips(int row, int col, int id)
    {
        if (id == 1)
        {
            _player1.Board.PlaceShip(row, col);
            if (ShipNumber(1) == SHIPS)
                return true;
            return false;
        }
        else
        {
            _player2.Board.PlaceShip(row, col);
            if (ShipNumber(2) == SHIPS)
                return true;
            return false;
        }

    }

    public int ShipNumber(int id)
    {
        int PocetLodi = 0;
        Board.CellState[,] grid; 
        if(id == 1)
            grid = _player1.Grid;
        else
            grid = _player2.Grid;


        for (int i = 0; i < BOARDLENGTH; i++)
        {
            for (int j = 0; j < BOARDLENGTH; j++)
            {
                if (grid[i, j] == Board.CellState.Ship)
                    PocetLodi++;
            }
        }

        return PocetLodi;
    }

    public bool Play(int row, int col, int id)
    {
        if (id == CurrentPlayer.Id)
        {
            _game.Play(row, col);
            return true;
        }
        else
            return false;
    }

    public int TestVyhry()
    {
        if (_player1.Board.AllShipsSunk())
            return 1;
        else if (_player2.Board.AllShipsSunk())
            return 2;
        else
            return 0;
    }
    private void FromString(string oldGame)
    {
        string[] data = oldGame.Split(';');
        
        GameCreated(data[0], data[1], int.Parse(data[4]));

        _player1.Board.SetupGrid(data[2]);
        _player2.Board.SetupGrid(data[3]);
    }

    public override string ToString()
    {
        string data = "";
        data += _player1.Name + ";";
        data += _player2.Name + ";";

        for (int i = 0; i < BOARDLENGTH; i++)
        {
            for (int j = 0; j < BOARDLENGTH; j++)
            {
                data += _player1.StringGrid[i, j];
                if (j != BOARDLENGTH - 1)
                    data += ".";
            }
            if (i != BOARDLENGTH - 1)
                data += ",";
        }
        data += ";";

        for (int i = 0; i < BOARDLENGTH; i++)
        {
            for (int j = 0; j < BOARDLENGTH; j++)
            {
                data += _player2.StringGrid[i, j];
                if(j != BOARDLENGTH - 1)
                    data += ".";
            }
            if(i!= BOARDLENGTH - 1)
                data += ",";
        }
        data += ";"+ CurrentPlayer.Id;
        return data;
    }

}

