using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace gameExperiment.GUI
{
    internal class imageWidget : I_GUIElement
    {

        private Texture2D texture;

        private SpriteBatch spriteBatch;

        private Rectangle rectangle;

        public imageWidget (Rectangle rectangle, Texture2D texture)
        {
            this.rectangle = rectangle;
            this.texture = texture;
        }

        public imageWidget(Point position, Texture2D texture)
        {
            this.rectangle = new Rectangle(position, new Point(texture.Width, texture.Height));
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.Black);
        }

        public void Update(MouseState oldState, MouseState newState)
        {
            throw new NotImplementedException();
        }
    }
}
