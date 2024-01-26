using System;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Megalith.Models;

public class Canvas
{
    private RenderTarget2D _target;
    private readonly GraphicsDevice _graphics;
    private Rectangle _destinationRectangle;

    public Canvas(GraphicsDevice graphics, int width, int height)
    {
        _graphics = graphics;
        _target = new RenderTarget2D(_graphics, width, height);
    }

    public void SetDestinationRectangle()
    {
        var screenSize = _graphics.PresentationParameters.Bounds;

        var scaleX = (float)screenSize.X / _target.Width;
        var scaleY = (float)screenSize.Y / _target.Height;
        var scale = Math.Min(scaleX, scaleY);

        int newWidth = (int) (_target.Width * scale);
        int newHeight = (int)(_target.Height * scale);

        int posX = (screenSize.X - newWidth) / 2;
        int posY = (screenSize.Y - newHeight) / 2;

        _destinationRectangle = new Rectangle(posX, posY, newWidth, newHeight);
    }

    public void Activate()
    {
        _graphics.SetRenderTarget(_target);
        _graphics.Clear(Color.DarkGray);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _graphics.SetRenderTarget(null);
        _graphics.Clear(Color.Black);
        spriteBatch.Begin();
        spriteBatch.Draw(_target, _destinationRectangle, Color.White);
    }
    
    
}