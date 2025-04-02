using Raylib_cs;

public class Treasure : GameObject
{
    private const int SIZE = 40;
    private const int POINT_VALUE = 1;

    public Treasure(int x, int y) : base(x, y, SIZE, SIZE, Color.Gold)
    {
        _velocityY = Raylib.GetRandomValue(2, 5);
        LoadTexture("assets/gem.png");
    }

    public override void HandleCollision(GameObject other)
    {
        _shouldRemove = true;
    }

    public override int GetCollisionValue()
    {
        return POINT_VALUE;
    }
}
