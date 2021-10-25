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
        public int _xdirection;
        public int _ydirection;

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

        public Projectiles(char icon, float x, float y, float speed,int xdirection, int ydirection, Color color, string name = "Actor") 
            : base(icon, x, y, color, name)
        {
            _speed = speed;
            _xdirection = xdirection;
            _ydirection = ydirection;
        }

        public override void Update(float deltaTime)
        {            
            //Creat a vector that stores the move input            
            Vector2 moveDirection = new Vector2(_xdirection,_ydirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            //Uses velocity with current Position
            Position += Velocity;
            
            base.Update(deltaTime);
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemy)
            {
                Engine.CloseApplication();
            }
        }
        
        
    }
}
