using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Projectiles : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Player _player;

        public float Speed
        {
            get { return _speed ; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Projectiles(char icon, float x, float y, float speed, Color color,Player player, string name = "Actor") 
            : base(icon, x, y, color, name)
        {
            _speed = speed;
        }
            
    }
}
