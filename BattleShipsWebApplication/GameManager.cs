using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameManager
{
    public Player player1;
    public Player player2;
    public Game game;

    public void GameCreated(string name1, string name2)
    {

        player1 = new Player(1, name1);
        
        player2 = new Player(2, name2);
        
        game = new Game(player1, player2);

    }

    public void RandomPlace(int id)
    {
        if(id == 1)
            game.PlaceShipsRandomly(game._player1);
        else
            game.PlaceShipsRandomly(game._player2);       
    }

    public void SelectPlaceShips(int id)
    {

    }

    public Player GetAktualniHrac() {  return game._currentPlayer; }

    void Main(string[] args)
    {
        Game game = new Game(player1, player2);
        game.PlaceShipsRandomly(game._player1);
        game.PlaceShipsRandomly(game._player2);

        while (true)
        {
            Console.WriteLine("Player's turn.");
            Console.Write("Enter target row (0-9): ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter target column (0-9): ");
            int col = int.Parse(Console.ReadLine());
            game.Play(row, col);
        }
    }
        


}

