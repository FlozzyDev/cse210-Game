using Raylib_cs;

public class GameManager
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;

    private string _title;
    private Player _player;
    private List<GameObject> _items;
    private int _spawnTimer;
    private int _spawnDelay = 30; 
    private bool _gameOver;
    private Texture2D _backgroundTexture;

    public GameManager()
    {
        _title = "Captain Catcher";
        _items = new List<GameObject>();
        _spawnTimer = 0;
        _gameOver = false;
        _player = new Player(0, 0);
    }

    /// <summary>
    /// The overall loop that controls the game. It calls functions to
    /// handle interactions, update game elements, and draw the screen.
    /// </summary>
    public void Run()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, _title);
        // If using sound, un-comment the lines to init and close the audio device
        // Raylib.InitAudioDevice();

        InitializeGame();

        while (!Raylib.WindowShouldClose() && !_gameOver)
        {
            ProcessActions();
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            DrawElements();
            Raylib.EndDrawing();
        }

        // game over screen
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            DrawElements();
            Raylib.DrawRectangle(SCREEN_WIDTH/2 - 200, SCREEN_HEIGHT/2 - 70, 400, 160, Color.White);
            Raylib.DrawText("Arrr! Game Over!", SCREEN_WIDTH/2 - 170, SCREEN_HEIGHT/2 - 50, 40, Color.Red);
            Raylib.DrawText($"Final Score: {_player.GetScore()}", SCREEN_WIDTH/2 - 110, SCREEN_HEIGHT/2 + 10, 30, Color.Black);
            Raylib.DrawText("Press SPACE to exit", SCREEN_WIDTH/2 - 100, SCREEN_HEIGHT/2 + 60, 20, Color.Red);
            Raylib.EndDrawing();

            if (Raylib.IsKeyPressed(KeyboardKey.Space))
                break;
        }

        // Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }

    /// <summary>
    /// Sets up the initial conditions for the game.
    /// </summary>
    private void InitializeGame()
    {
        _player = new Player(SCREEN_WIDTH/2, SCREEN_HEIGHT - 100);
        _backgroundTexture = Raylib.LoadTexture("assets/ship_background.png");
    }

    /// <summary>
    /// Processes any actions such as moving objects or handling collisions. Adding spawn as well
    /// </summary>
    private void ProcessActions()
    {

        _player.Move();

        _spawnTimer++;
        if (_spawnTimer >= _spawnDelay)
        {
            SpawnItem();
            _spawnTimer = 0;
        }

        foreach (var item in _items)
        {
            item.Move();

            if (item is Treasure treasure && item.CollidesWithObject(_player))
            {
                _player.AddScore(treasure.GetPoint());
                _items.Remove(item);
            }
            else if (item is Bomb bomb && item.CollidesWithObject(_player))
            {
                _player.LoseLife(bomb.GetDamage());
                _items.Remove(item);
                if (_player.IsGameOver())
                {
                    _gameOver = true;
                }
            }

            else if ((item is Treasure t && t.IsOffScreen()) || // if item is off screen, remove it
                     (item is Bomb b && b.IsOffScreen()))
            {
                _items.Remove(item);
            }
        }
    }

    private void SpawnItem()
    {
        int x = Raylib.GetRandomValue(0, SCREEN_WIDTH - 20);
        if (Raylib.GetRandomValue(0, 3) == 0) // more bomb chances 
        {
            _items.Add(new Treasure(x, -20));
        }
        else
        {
            _items.Add(new Bomb(x, -20));
        }
    }

    /// <summary>
    /// Draws all elements on the screen.
    /// </summary>
    private void DrawElements() // background / player / items / score
    {
        
        Raylib.DrawTexture(_backgroundTexture, 0, 0, Color.White);

        _player.Draw();

        foreach (var item in _items)
        {
            item.Draw();
        }
        
        Raylib.DrawRectangle(5, 5, 150, 65, Color.White);
        Raylib.DrawText($"Lives: {_player.GetLives()}", 10, 10, 20, Color.Black);
        Raylib.DrawText($"Score: {_player.GetScore()}", 10, 40, 20, Color.Black);
    }
}