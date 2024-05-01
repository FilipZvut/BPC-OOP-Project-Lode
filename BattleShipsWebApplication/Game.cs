
public class Game
{
    public Player _player1;
    public Player _player2;
    public Player _currentPlayer;
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
        while(ShipsPlaced<5)
        {
            random.Next();
            int row = random.Next(0, Board.BoardLength);
            random.Next();
            int col = random.Next(0, Board.BoardLength);
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
    public void Play(int row, int col)
    {
        _opponent.Board.Attack(row, col);
        SwitchTurn();
        
    }
}
