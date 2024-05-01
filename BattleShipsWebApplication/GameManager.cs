using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Board;

public class GameManager
{
    public Player player1;
    public Player player2;
    public Game game;

    public GameManager()
    {

    }

    public GameManager(string OldGameManager)
    {
        FromString(OldGameManager);
    }


    public void GameCreated(string name1, string name2, int id)
    {

        player1 = new Player(1, name1);
        
        player2 = new Player(2, name2);
        
        game = new Game(player1, player2, id);

    }

    public void RandomPlace(int id)
    {
        if(id == 1)
            game.PlaceShipsRandomly(game._player1);
        else
            game.PlaceShipsRandomly(game._player2);       
    }

    public bool SelectPlaceShips(int row, int col, int id)
    {
        if (id == 1)
        {
            player1.Board.PlaceShip(row, col);
            if (PocetLodi(1) == 5)
                return true;
            return false;
        }
        else
        {
            player2.Board.PlaceShip(row, col);
            if (PocetLodi(2) == 5)
                return true;
            return false;
        }

    }

    public int PocetLodi(int id)
    {
        int PocetLodi = 0;
        Board.CellState[,] grid; 
        if(id == 1)
            grid = game._player1.GetGrid();
        else
            grid = game._player2.GetGrid();


        for (int i = 0; i < BoardLength; i++)
        {
            for (int j = 0; j < BoardLength; j++)
            {
                if (grid[i, j] == Board.CellState.Ship)
                    PocetLodi++;
            }
        }

        return PocetLodi;
    }
    public Player GetAktualniHrac() {  return game._currentPlayer; }

    public bool Play(int row, int col, int id)
    {
        if (id == game._currentPlayer.Id)
        {
            game.Play(row, col);
            return true;
        }
        else
            return false;
    }

    public int TestVyhry()
    {
        if (player1.Board.AllShipsSunk())
            return 1;
        else if (player2.Board.AllShipsSunk())
            return 2;
        else
            return 0;
    }

    public override string ToString()
    {
        string data = "";
        data += player1.Name + ";";
        data += player2.Name + ";";

        for (int i = 0; i < Board.BoardLength; i++)
        {
            for (int j = 0; j < Board.BoardLength; j++)
            {
                data += player1.Board.StringGrid[i, j];
                if (j != Board.BoardLength - 1)
                    data += ".";
            }
            if (i != Board.BoardLength - 1)
                data += ",";
        }
        data += ";";

        for (int i = 0; i < Board.BoardLength; i++)
        {
            for (int j = 0; j < Board.BoardLength; j++)
            {
                data += player2.Board.StringGrid[i, j];
                if(j != Board.BoardLength - 1)
                    data += ".";
            }
            if(i!= Board.BoardLength - 1)
                data += ",";
        }
        data += ";"+ game._currentPlayer.Id;
        return data;
    }

    public void FromString(string oldGame)
    {
        string[] data = oldGame.Split(';');
        
        GameCreated(data[0], data[1], int.Parse(data[4]));

        player1.Board.SetupGrid(data[2]);
        player2.Board.SetupGrid(data[3]);
    }


}

