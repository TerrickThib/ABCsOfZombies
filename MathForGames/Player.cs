using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;


namespace MathForGames
{
    class Player : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        public Scene _scene;        
        
        //Allows us to give _ speed a value
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        //Allows us to give Velocity a value
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }
          
        public Player(char icon, float x, float y, float speed, Color color,Scene scene, string name = "Actor" ) 
            : base(icon, x, y, color, name)
        {
            _speed = speed;
            _scene = scene;
        }

        public override void Update(float deltaTime)
        {
            //GEts the player input direction
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));            
            int yDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            int xDirectionofBullet = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT));
            int yDirectionofBullet = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN));           
            
            if (xDirectionofBullet != 0 || yDirectionofBullet != 0)
            {
                Projectiles bullet = new Projectiles('o', Position.X, Position.Y, 200, xDirectionofBullet, yDirectionofBullet, Color.YELLOW, _scene, "Bullet");
                bullet.CollisionRadius = 5;               
                _scene.AddActor(bullet);                
            }

            //Creat a vector that stores the move input            
            Vector2 moveDirection = new Vector2(xDirection, yDirection);
                                             
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
