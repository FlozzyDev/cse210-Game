using Raylib_cs;

public class Treasure : GameObject
{
    private const int SIZE = 40;

    public Treasure(int x, int y) : base(x, y, SIZE, SIZE, Color.Gold)
    {
        _velocityY = Raylib.GetRandomValue(2, 5);
        LoadTexture("assets/gem.png");
    }

    public int GetPoint() // This way I can change the point value, going to look at randomizing it
    {
        return 1;
    }

    public bool IsOffScreen()
    {
        return _positionY > GameManager.SCREEN_HEIGHT;
    }
}
