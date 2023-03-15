using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace gameExperiment
{
    public class MessageBox : I_GUIElement
    {
        private List<string> messsageHistory;

        private string currentMessage;

        private Rectangle _rect;

        private SpriteFont _font;

        private Vector2 _position;

        public MessageBox(int width, int height, int posX, int posY, SpriteFont font)
        {

            _position = new Vector2(posX, posY);
            _font = font;
            currentMessage = "a message will appear here";
            _rect = new Rectangle(posX, posY, (int)font.MeasureString(currentMessage).X, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _rect = new Rectangle((int)_position.X, (int)_position.Y, (int)_font.MeasureString(currentMessage).X, (int)_font.MeasureString(currentMessage).Y);
            spriteBatch.DrawRectangle(_rect, Color.White, 1f);
            spriteBatch.DrawString(_font, currentMessage, _position, Color.White);
        }

        public void DisplayMessage (string message)
        {
            currentMessage = message;
        }

        public void Update(MouseState oldState, MouseState newState)
        {
            throw new NotImplementedException();
        }
    }
}
