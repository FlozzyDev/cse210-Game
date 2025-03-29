using Raylib_cs;

public class Player : GameObject
{
    private const int SPEED = 8;
    private const int SIZE = 80;
    private int _lives;
    private int _score;

    public Player(int x, int y) : base(x, y, SIZE, SIZE, Color.Blue)
    {
        _lives = 3;
        _score = 0;
        LoadTexture("assets/captain.png");
    }

    public override void Draw() // adding a hp counter
    {
        base.Draw();
        for (int i = 0; i < _lives; i++)
        {
            int circleX = _positionX + (i * 20) + (_width / 2);
            int circleY = _positionY - 20;
            Raylib.DrawCircle(circleX, circleY, 8, Color.Red);
        }
    }

    public override void Move() // override to allow left/right (so long as it doesn't go off screen)
    {
        if ((Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A)) && _positionX > 0)
        {
            _velocityX = -SPEED;
        }
        else if ((Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D)) && _positionX < GameManager.SCREEN_WIDTH - _width)
        {
            _velocityX = SPEED;
        }
        else
        {
            _velocityX = 0;
        }

        base.Move();
    }

    public void AddScore(int point)
    {
        _score += point;
    }

    public void LoseLife(int value)
    {
        _lives = _lives - value;
    }

    public bool IsGameOver()
    {
        return _lives <= 0;
    }

    public int GetLives()
    {
        return _lives;
    }

    public int GetScore()
    {
        return _score;
    }

}
