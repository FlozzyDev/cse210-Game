using Raylib_cs;

public class Bomb : GameObject
{
    private const int SIZE = 40;
    private const int DAMAGE_VALUE = -1;

    public Bomb(int x, int y) : base(x, y, SIZE, SIZE, Color.Red)
    {
        _velocityY = Raylib.GetRandomValue(4, 9); 
        LoadTexture("assets/bomb.png");
    }

    public override void HandleCollision(GameObject other)
    {
        _shouldRemove = true;
    }

    public override int GetCollisionValue()
    {
        return DAMAGE_VALUE;
    }
}

