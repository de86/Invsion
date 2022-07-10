using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Microsoft.Xna.Framework;

namespace Invsion.Engine.Components
{
    class PositionAccelerator : IPositionAccelerator
    {
        private float _accelerationX = 0;
        private float _accelerationY = 0;
        private float _decelerationRate = 0.4f;

        private Position _position;
        private Vector2 _velocity = Vector2.Zero;


        public PositionAccelerator (Position position, float acceleration)
        {
            _position = position;
            _accelerationX = acceleration;
            _accelerationY = acceleration;
        }

        public PositionAccelerator (Position position, float acceleration, float decelerationRate)
        {
            _position = position;
            _accelerationX = acceleration;
            _accelerationY = acceleration;
            _decelerationRate = decelerationRate;
        }


        public void AccelerateAndMove (Vector2 moveVector, float maxSpeed, float delta)
        {
            if (moveVector.X > 0.1)
            {
                _velocity.X += _accelerationX * moveVector.X;
                _velocity.X = Math.Clamp(_velocity.X, -maxSpeed, maxSpeed);
                _position.X += _velocity.X * delta;
            }
            else if (moveVector.X < -0.1)
            {
                _velocity.X += _accelerationX * moveVector.X;
                _velocity.X = Math.Clamp(_velocity.X, -maxSpeed, maxSpeed);
                _position.X += _velocity.X * delta;
            }
            else
            {
                if (_velocity.X > 10)
                {
                    _velocity.X -= _velocity.X * _decelerationRate;
                    _position.X += _velocity.X * delta;
                }
                else if (_velocity.X < -10)
                {
                    _velocity.X -= _velocity.X * _decelerationRate;
                    _position.X += _velocity.X * delta;
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
                _position.Y += _velocity.Y * delta;
            }
            else if (moveVector.Y < -0.1)
            {
                _velocity.Y += _accelerationY * moveVector.Y;
                _velocity.Y = Math.Clamp(_velocity.Y, -maxSpeed, maxSpeed);
                _position.Y += _velocity.Y * delta;
            }
            else
            {
                if (_velocity.Y > 10)
                {
                    _velocity.Y -= _velocity.Y * _decelerationRate;
                    _position.Y += _velocity.Y * delta;
                }
                else if (_velocity.Y < -10)
                {
                    _velocity.Y -= _velocity.Y * _decelerationRate;
                    _position.Y += _velocity.Y * delta;
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
        public void SetDecelerationRate (float decelerationRate)
        {
            _decelerationRate = decelerationRate;
        }
    }
}
