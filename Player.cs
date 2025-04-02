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

    public override void Draw()
    {
        base.Draw();
        for (int i = 0; i < _lives; i++)
        {
            int circleX = _positionX + (i * 20) + (_width / 2);
            int circleY = _positionY - 20;
            Raylib.DrawCircle(circleX, circleY, 8, Color.Red);
        }
    }

    public override void Move()
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

    public override void HandleCollision(GameObject other)
    {
        int value = other.GetCollisionValue();
        if (value > 0)
        {
            _score += value;
        }
        else if (value < 0)
        {
            _lives += value; // Adding the negative value, so hurting the player
        }
    }

    public override bool IsOffScreen()
    {
        return false; // Player can never be off screen
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
