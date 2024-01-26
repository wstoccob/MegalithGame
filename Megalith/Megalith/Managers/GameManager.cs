using Megalith.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Megalith.Managers;

public class GameManager
{
    private readonly Game _game;
    private readonly GraphicsDeviceManager _graphics;
    private readonly Sprite _sprite;

    public GameManager(Game game, GraphicsDeviceManager graphics)
    {
        _game = game;
        _graphics = graphics;
        _sprite = new(_game.Content.Load<Texture2D>("screen"), new Vector2(0, 0));
    }
    
    private void SetResolution(int width, int height)
    {
        _graphics.PreferredBackBufferWidth = width;
        _graphics.PreferredBackBufferHeight = height;
        _graphics.ApplyChanges();
    }
    
    public void Update()
    {
        InputManager.Update();
        if (InputManager.IsKeyPressed(Keys.F1)) SetResolution(400, 300);
        if (InputManager.IsKeyPressed(Keys.F2)) SetResolution(1920, 1080);
        if (InputManager.IsKeyPressed(Keys.F3)) SetResolution(640, 1080);
        // if (InputManager.IsKeyPressed(Keys.F4)) ;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        _sprite.Draw(spriteBatch);
        spriteBatch.End();
    }
}