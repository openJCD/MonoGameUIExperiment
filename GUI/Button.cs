using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using gameExperiment.Managers;


namespace gameExperiment
{
    public class Button : IDrawable, IUpdatable
    {

        private Rectangle selectRect;

        private float thickness;

        public UIEventHandler uiEventHandler;
        
        public UIEventHandler.EventType onClick;

        private bool isPrimitive;

        public string label;

        private Rectangle _rect;
        
        private SpriteFont _font;

        private Vector2 _position;

        public int state; 
        
        //state variable explanation:
        /* 
           0:static
           1:hovered
           2:clicked 
        */
        private Vector2 textPosition;

        public Button(float width, float height, Vector2 position, UIEventHandler uiEventHandler, UIEventHandler.EventType onClick, float thickness = 1)
        {
            _rect = new Rectangle((int)position.X, (int)position.Y, (int)width, (int)height);

            _position = position;
            
            selectRect = new Rectangle((int)((int)position.X - thickness), (int)((int)position.Y-thickness), (int)((int)width+thickness*2), (int)((int) height+thickness*2));
            // ^^ rectangle used for selection (mouse hover state)
            this.onClick = onClick;
            
            isPrimitive = true; //If this overload is used, or any other overload that does not require a 
                                //Texture2D, then this is set to True so the Draw function knows to draw a
                                //rect instead of a sprite.

            label = ""; // the label for this button, left empty for this overload
            state = 0;
            this.thickness = thickness;
            this.uiEventHandler = uiEventHandler;
        }
        public Button(string label, SpriteFont font, float width, float height, Vector2 position, UIEventHandler.EventType onClick, UIEventHandler uiEventHandler, float thickness = 3)
        {
            _rect = new Rectangle((int)position.X, (int)position.Y, (int)width, (int)height);
            _position = position;
            selectRect = new Rectangle((int)(position.X-thickness), (int)(position.Y - thickness), (int)(width + thickness*2), (int)(height + thickness*2));

            this.onClick = onClick;
            isPrimitive = true; //If this overload is used, or any other overload that does not require a 
                                //Texture2D, then this is set to True so the Draw function knows to draw a
                                //rect instead of a sprite.
            this.label = label;
            this._font = font;
            state = 0;
            this.thickness = thickness;
            this.uiEventHandler = uiEventHandler;
        }

        public Button(string label, SpriteFont font, Vector2 position, UIEventHandler.EventType onClick, UIEventHandler uiEventHandler, float thickness = 2)
        {
            this._font = font;
            _rect = new Rectangle((int)position.X, (int)position.Y, (int)(font.MeasureString(label).X+thickness), (int)(font.MeasureString(label).Y + thickness));
            selectRect = new Rectangle((int)((int)position.X - thickness), (int)((int)position.Y - thickness), (int)(font.MeasureString(label).X + thickness*2), (int)(font.MeasureString(label).Y + thickness*2));
            _position = position;
            this.onClick = onClick;
            isPrimitive = true; //If this overload is used, or any other overload that does not require a 
                                //Texture2D, then this is set to True so the Draw function knows to draw a
                                //rect instead of a sprite.
            this.label = label;
            state = 0;
            this.thickness = thickness;
            this.uiEventHandler = uiEventHandler;
        }

        public Button(string label, SpriteFont font, Vector2 position, UIEventHandler uiEventHandler, float thickness = 2)
        {
            this._font = font;
            _rect = new Rectangle((int)position.X, (int)position.Y, (int)(font.MeasureString(label).X + thickness+2), (int)(font.MeasureString(label).Y + thickness));
            selectRect = new Rectangle((int)((int)position.X - thickness), (int)((int)position.Y - thickness), (int)(font.MeasureString(label).X + thickness * 4), (int)(font.MeasureString(label).Y + thickness * 3));
            _position = position;
            textPosition = position + new Vector2(thickness+1); // Took me fking ages to figure this one out

            isPrimitive = true; //If this overload is used, or any other overload that does not require a 
                                //Texture2D, then this is set to True so the Draw function knows to draw a
                                //rect instead of a sprite.
            this.label = label;
            state = 0;
            this.thickness = thickness;
            this.uiEventHandler = uiEventHandler;

        }

        public void Update(MouseState oldState, MouseState newState)
        {
            textPosition = new Vector2((_rect.X + _rect.Width / _font.MeasureString(label).X),(_rect.Y)); 
            state = 0;
            
            if (_rect.Contains(new Point(newState.X, newState.Y))) 
            {
                state = 1;
                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    uiEventHandler.HandleEvent(onClick);
                    state = 2;

                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isPrimitive)
            {
                if (state == 1)
                    Primitives2D.DrawRectangle(spriteBatch, selectRect, Color.Gray, thickness);
                Primitives2D.DrawRectangle(spriteBatch, _rect, Color.LightGray, thickness);

                spriteBatch.DrawString(_font, label, textPosition, Color.LightGray); //add cosmetic fanciness at a later date
            } 
            else
            {
                //Implement sprite drawing code for another overload.
            }       

        }
        
        public Rectangle GetRectangle()
        {
            return _rect;
        }

        
    }

}
