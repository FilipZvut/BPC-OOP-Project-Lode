using static Battleships.Logic.GameManager;

namespace Battleships.Logic;
public class Game
{
    private Player _player1;
    private Player _player2;
    private Player _currentPlayer;
    private Player _opponent;

    public Player CurrentPlayer { get { return _currentPlayer; } }


    public Game(Player player1, Player player2, int id)
    {
        _player1 = player1;
        _player2 = player2;
        if (id == 1)
        {
            _currentPlayer = _player1;
            _opponent = _player2;
        }
        else
        {
            _currentPlayer = _player2;
            _opponent = _player1;
        }
    }
    public void PlaceShipsRandomly(Player player)
    {
        int ShipsPlaced = 0;
        player.Board.InitializeGrid();

        Random random = new Random();
        while(ShipsPlaced<SHIPS)
        {
            random.Next();
            int row = random.Next(0, BOARDLENGTH);
            random.Next();
            int col = random.Next(0, BOARDLENGTH);
            if (player.Board.PlaceShip(row, col))
                ShipsPlaced++;
            
        }
    }
    public void Play(int row, int col)
    {
        if(_opponent.Board.Attack(row, col))
            SwitchTurn();
        
    }
    private void SwitchTurn()
    {
        Player temp = _currentPlayer;
        _currentPlayer = _opponent;
        _opponent = temp;
    }
}
