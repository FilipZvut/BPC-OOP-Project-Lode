


public class Game
{
    public Player _player1;
    public Player _player2;
    private Player _currentPlayer;
    private Player _opponent;
    public Game(Player player1, Player player2)
    {
        _player1 = player1;
        _player2 = player2;
        _currentPlayer = _player1;
        _opponent = _player2;
    }
    public void PlaceShipsRandomly(Player player)
    {
        int ShipsPlaced = 0;
        Random random = new Random();
        while(ShipsPlaced==5)
        {
            
            int row = random.Next(0, Board.BoardLenght-1);
            int col = random.Next(0, Board.BoardLenght-1);
            if (player.Board.PlaceShip(row, col))
                ShipsPlaced++;
            
        }
    }
    public void SwitchTurn()
    {
        Player temp = _currentPlayer;
        _currentPlayer = _opponent;
        _opponent = temp;
    }
    public int Play(int row, int col)
    {
        bool hit = _opponent.Board.Attack(row, col);
        SwitchTurn();
        if (hit)
        {
            if (_opponent.Board.AllShipsSunk())
            {
                Console.WriteLine("Game Over!" + _opponent.Name + "Win!");
                return 2;
            }
            Console.WriteLine(_opponent.Name+ "Hit!");
            return 1;
        }
        else
        {
            Console.WriteLine(_opponent.Name + "Miss!");
            return 0;
        }
    }
}
