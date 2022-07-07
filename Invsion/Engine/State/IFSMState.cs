using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine.State
{
    public interface IFSMState
    {
        public void Exit ();
        public void Enter ();

        public void Update (double deltaMS);

        public void Draw (SpriteBatch spriteBatch);
    }
}
