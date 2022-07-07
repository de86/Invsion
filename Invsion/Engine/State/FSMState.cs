using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine.State
{
    public abstract class FSMState : IFSMState
    {
        public abstract void Enter ();

        public abstract void Update (double deltaMs);

        public abstract void Draw (SpriteBatch spriteBatch);

        public abstract void Exit ();
    }
}
