using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
namespace gameExperiment
{
    interface IDrawable
    {
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
