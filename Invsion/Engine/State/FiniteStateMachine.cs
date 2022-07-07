using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine.State
{
    public class FiniteStateMachine : IFiniteStateMachine
    {
        private Dictionary<string, IFSMState> _states;
        private IFSMState _currentState;



        public FiniteStateMachine ()
        {
            _states = new Dictionary<string, IFSMState>();
        }



        public void SetInitialState (string key)
        {
            _states.TryGetValue(key, out _currentState);
            _currentState.Enter();
        }



        public void AddState (string key, IFSMState state)
        {
            _states.Add(key, state);
        }



        public void ChangeState (string key)
        {
            IFSMState _nextState;
            _states.TryGetValue(key, out _nextState);

            if (_nextState == null)
                return;

            _currentState.Exit();
            _nextState.Enter();
            _currentState = _nextState;
        }



        public void Update (double deltaMS)
        {
            _currentState.Update(deltaMS);
        }



        public void Draw (SpriteBatch spriteBatch)
        {
            _currentState.Draw(spriteBatch);
        }
    }
}
