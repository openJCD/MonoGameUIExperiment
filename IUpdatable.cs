using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Text;

namespace gameExperiment
{
    interface IUpdatable
    {
        public void Update(MouseState oldState, MouseState newState);
    }
}
