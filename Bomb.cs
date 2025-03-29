using Raylib_cs;

public class Bomb : GameObject
{
    private const int SIZE = 40;

    public Bomb(int x, int y) : base(x, y, SIZE, SIZE, Color.Red)
    {
        _velocityY = Raylib.GetRandomValue(4, 9); 
        LoadTexture("assets/bomb.png");
    }

    public bool IsOffScreen()
    {
        return _positionY > GameManager.SCREEN_HEIGHT;
    }

    public int GetDamage() // maybe make this a higher number if we change the health up
    {
        return 1;
    }
}

