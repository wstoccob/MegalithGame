using Megalith.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Megalith.Managers;

public class GameManager
{
    private readonly Game _game;
    private readonly GraphicsDeviceManager _graphics;
    
    private readonly Sprite _carSprite;
    private const string carSpriteName = "carSprite";
    

    private Canvas _canvas;

    public GameManager(Game game, GraphicsDeviceManager graphics)
    {
        _game = game;
        _graphics = graphics;
        _canvas = new Canvas(_graphics.GraphicsDevice, 320, 540);
        _carSprite = new Sprite(_game.Content.Load<Texture2D>(carSpriteName), new Vector2(144, 468));
        SetResolution(1920, 1080);
    }

    private void SetFullscreen()
    {
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _game.Window.IsBorderless = true;
        _graphics.ApplyChanges();
        _canvas.SetDestinationRectangle();

    }
    
    private void SetResolution(int width, int height)
    {
        _graphics.PreferredBackBufferWidth = width;
        _graphics.PreferredBackBufferHeight = height;
        _game.Window.IsBorderless = false;
        _graphics.ApplyChanges();
        _canvas.SetDestinationRectangle();
    }
    
    public void Update()
    {
        InputManager.Update();
        if (InputManager.IsKeyPressed(Keys.F1)) SetResolution(400, 300);
        if (InputManager.IsKeyPressed(Keys.F2)) SetResolution(1920, 500);
        if (InputManager.IsKeyPressed(Keys.F3)) SetResolution(640, 1080);
        if (InputManager.IsKeyPressed(Keys.F4)) SetFullscreen();

        if (InputManager.IsKeyPressed(Keys.Right))
        {
            _carSprite.MoveRight();
        }
        if (InputManager.IsKeyPressed(Keys.Left))
        {
            _carSprite.MoveLeft();
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _canvas.Activate();
        
        spriteBatch.Begin();
        _carSprite.Draw(spriteBatch);
        spriteBatch.End();
        
        _canvas.Draw(spriteBatch);
    }
}