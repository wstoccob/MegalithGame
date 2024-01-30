using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Megalith.Models;

public class Sprite
{
    protected Texture2D _texture;
    public Vector2 Position { get; set; }

    public Sprite(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        Position = position;
    }

    public void MoveRight()
    {
        Position = new Vector2(Position.X + 10, Position.Y);
    }
    
    public void MoveLeft()
    {
        Position = new Vector2(Position.X - 10, Position.Y);
    }
    
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Position, Color.White);
    }
}