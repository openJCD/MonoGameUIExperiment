using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using gameExperiment.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace gameExperiment
{
    public class Checkbox : I_GUIElement
    {

        private Vector2 _position;

        private Rectangle _rect;

        private SpriteFont _font;

        private string label;

        private ToggleButton toggleButton;

        private bool enabled;


        public Checkbox(int height, int width, int x, int y, SpriteFont font, string label, UIEventHandler uiEventHandler, bool startEnabled=false)
        {
            _rect = new Rectangle(x, y, width, height);
            _font = font;
            this.label = label;
            _position = new Vector2(x, y);
            toggleButton = new ToggleButton(font, _position, uiEventHandler, label:label, labelIfOn:"1", labelIfOff:"0", startEnabled:startEnabled);
            enabled = startEnabled;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            toggleButton.Draw(spriteBatch);
            Rectangle throwawayRect = toggleButton.GetRectangle();
            Vector2 labelOffset = new Vector2(throwawayRect.Width + 10, 0);
            spriteBatch.DrawString(_font, label, _position - labelOffset, Color.White);

        }

        public void Toggle()
        {
            toggleButton.Toggle();
        }

        public void Update(MouseState oldState, MouseState newState)
        {
            toggleButton.Update(oldState, newState);

        }
    }
}
