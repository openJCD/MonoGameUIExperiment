using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using gameExperiment.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace gameExperiment
{
    public class ToggleButton : Button
    {
        // state variable
        /*
         * 
         * 0=static
         * 1=hover         
         * 2=clicked
         * 
         */
        
        // is the button enabled or not
        private bool enabled;

        private string labelIfOn;
        private string labelIfOff;

        private Button button;

        public ToggleButton(SpriteFont font, Vector2 position, UIEventHandler uiEventHandler, float thickness = 2, bool startEnabled=false, string label = "", string labelIfOn = "On", string labelIfOff = "Off") : base(label, font, position, uiEventHandler, thickness)
        {
            enabled = startEnabled;
            if (enabled)
                this.label = labelIfOn;
            else
                this.label = labelIfOff;

            this.labelIfOn = labelIfOn;
            this.labelIfOff = labelIfOff;

            button = new Button(label, font, position, uiEventHandler);

        }
        public new void Update(MouseState oldState, MouseState newState) 
        {
            state = 0;

            Rectangle rectangle = button.GetRectangle();

            //check to see if the button is enabled, if so, change the label
            if (enabled)
                this.label = labelIfOn;
            else
                this.label = labelIfOff;

            if (rectangle.Contains(new Point(newState.X, newState.Y)))
            {
                state = 1;
                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    Toggle();
                    state = 2;
                }
                state = 1;
            }

        }
        public void Toggle()
        {
            enabled = !enabled;
        }

        public bool IsEnabled()
        {
            return enabled;
        }
    }
}
