using Raylib_cs;

public class GameObject
{
    protected int _positionX;
    protected int _positionY;
    protected int _velocityX;
    protected int _velocityY;
    protected int _width;
    protected int _height;
    protected Color _color;
    protected Texture2D? _texture;
    protected bool _shouldRemove;

    public GameObject(int x, int y, int width, int height, Color color) // leaving in color in case the asset doesn't load 
    {
        _positionX = x;
        _positionY = y;
        _velocityX = 0;
        _velocityY = 0;
        _width = width;
        _height = height;
        _color = color;
        _texture = null;
        _shouldRemove = false;
    }

    public virtual void Move()
    {
        _positionX += _velocityX;
        _positionY += _velocityY;
    }

    public virtual void Draw()
    {
        if (_texture != null)
        {
            Raylib.DrawTexture(_texture.Value, _positionX, _positionY, Color.White);
        }
        else
        {
            Raylib.DrawRectangle(_positionX, _positionY, _width, _height, _color);
        }
    }

    public Rectangle GetBounds()
    {
        return new Rectangle(_positionX, _positionY, _width, _height);
    }

    public bool CollidesWithObject(GameObject other)
    {
        return Raylib.CheckCollisionRecs(GetBounds(), other.GetBounds());
    }

    public virtual void HandleCollision(GameObject other)
    {
    }

    public virtual bool IsOffScreen()
    {
        return _positionY > GameManager.SCREEN_HEIGHT;
    }

    public virtual int GetCollisionValue()
    {
        return 0;
    }

    public bool ShouldRemove()
    {
        return _shouldRemove || IsOffScreen();
    }

    protected virtual void LoadTexture(string path)
    {
        try
        {
            string fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
            {
                return;
            }
            _texture = Raylib.LoadTexture(fullPath);
        }   
        catch (Exception e)
        {
            Console.WriteLine($"Error loading texture: {e.Message}");
            _texture = null;
        }
    }
}