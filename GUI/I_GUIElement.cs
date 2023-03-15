using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
namespace gameExperiment
{
    public interface I_GUIElement
    {
        public abstract void Draw(SpriteBatch spriteBatch);
        public void Update(MouseState oldState, MouseState newState);

    }
}
