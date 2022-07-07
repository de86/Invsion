using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Microsoft.Xna.Framework;

namespace Invsion.Engine.Components
{
    class DynamicPositionComponent : PositionComponent, IDynamicPositionComponent
    {
        private float _accelerationX = 0;
        private float _accelerationY = 0;
        private float _decelerationX = 0;
        private float _decelerationY = 0;
        private float _decelerationRate = 0.4f;

        private Vector2 _velocity = new Vector2(0, 0);


        public DynamicPositionComponent (float x, float y, float acceleration) : base(x, y) {
            _accelerationX = acceleration;
            _accelerationY = acceleration;
            _decelerationX = acceleration;
            _decelerationY = acceleration;
        }



        public DynamicPositionComponent (float x, float y, float acceleration, float deceleration) : base(x, y)
        {
            _accelerationX = acceleration;
            _accelerationY = acceleration;
            _decelerationX = deceleration;
            _decelerationY = deceleration;
        }



        public DynamicPositionComponent (Vector2 position) : base(position) {}




        public void AccelerateAndMove (Vector2 moveVector, float maxSpeed, float delta)
        {
            if (moveVector.X > 0.1)
            {
                _velocity.X += _accelerationX * moveVector.X;
                _velocity.X = Math.Clamp(_velocity.X, -maxSpeed, maxSpeed);
                this._x += _velocity.X * delta;
            }
            else if (moveVector.X < -0.1)
            {
                _velocity.X += _accelerationX * moveVector.X;
                _velocity.X = Math.Clamp(_velocity.X, -maxSpeed, maxSpeed);
                this._x += _velocity.X * delta;
            }
            else
            {
                if (_velocity.X > 10)
                {
                    _velocity.X -= _velocity.X * _decelerationRate;
                    this._x += _velocity.X * delta;
                }
                else if (_velocity.X < -10)
                {
                    _velocity.X -= _velocity.X * _decelerationRate;
                    this._x += _velocity.X * delta;
                }
                else
                {
                    _velocity.X = 0;
                }
            }

            if (moveVector.Y > 0.1)
            {
                _velocity.Y += _accelerationY * moveVector.Y;
                _velocity.Y = Math.Clamp(_velocity.Y, -maxSpeed, maxSpeed);
                this._y += _velocity.Y * delta;
            }
            else if (moveVector.Y < -0.1)
            {
                _velocity.Y += _accelerationY * moveVector.Y;
                _velocity.Y = Math.Clamp(_velocity.Y, -maxSpeed, maxSpeed);
                this._y += _velocity.Y * delta;
            }
            else
            {
                if (_velocity.Y > 10)
                {
                    _velocity.Y -= _velocity.Y * _decelerationRate;
                    this._y += _velocity.Y * delta;
                }
                else if (_velocity.Y < -10)
                {
                    _velocity.Y -= _velocity.Y * _decelerationRate;
                    this._y += _velocity.Y * delta;
                }
                else
                {
                    _velocity.Y = 0;
                }
            }
        }



        public void SetAcceleration (float accelerationX, float accelerationY)
        {
            _accelerationX = accelerationX;
            _accelerationY = accelerationY;
        }



        public void SetDeceleration (float deceleration)
        {
            _decelerationX = deceleration;
            _decelerationY = deceleration;
        }
    }
}
