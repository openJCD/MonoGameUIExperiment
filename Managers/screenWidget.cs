using System;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace gameExperiment
{
    public class screenWidget : IDisposable, IDrawable
    {
        private Vector2 _position;

        public string label { get; }

        public float position_x { get; set; }

        public float position_y { get; set; }

        public Vector2 position { get; set; }

        public string texturePath { get; }
        public Texture2D texture { get; set; }

        public string fontPath { get; set; }
        public SpriteFont font { get; set; }

        public screenWidget(string font, string texture)
        {
            this.fontPath = font;
            this.texturePath = texture;
            _position.X = this.position_x;
            _position.Y = this.position_y;
            position = _position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.label, new Vector2(this.position.X, this.position.Y - (this.texture.Height / 3) * 2), Color.White, 0f, this.font.MeasureString(this.label), 1f, SpriteEffects.None, 0.5f);
            spriteBatch.Draw(this.texture, this.position, Color.White);
            Primitives2D.DrawRectangle(spriteBatch, texture.Bounds, Color.White, 2f);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            position = _position;
        }

        public void LoadContent(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>(texturePath);
            font = contentManager.Load<SpriteFont>(fontPath);
        }
    }
}
