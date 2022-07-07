using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine.State
{
    public interface IFiniteStateMachine
    {
        public void AddState (string key, IFSMState state);
        public void SetInitialState (string key);
        public void ChangeState (string key);

        public void Update (double deltaMS);

        public void Draw (SpriteBatch spriteBatch);
    }
}
