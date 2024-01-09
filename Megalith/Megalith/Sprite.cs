using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Megalith;

public class Sprite
{
    protected Texture2D _texture;
    public Vector2 _position { get; set; }

    public Sprite(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }
}