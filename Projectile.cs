using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public class Projectile
    {
        public static List<Projectile> projectiles = new List<Projectile>();

        private Vector2 position;
        private int speed = 1000;
        public int radius = 18;
        private Dir direction;
        private bool collided = false;

        public Projectile(Vector2 position, Dir direction)
        {
            this.position = position;
            this.direction = direction;
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public bool Collided {
            set { collided = value; } 
            get { return collided; } 
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            switch (direction)
            {
                case Dir.Right:
                    position.X += speed * dt;
                    break;
                case Dir.Left:
                    position.X -= speed * dt;
                    break;
                case Dir.Down:
                    position.Y += speed * dt;
                    break;
                case Dir.Up:
                    position.Y -= speed * dt;
                    break;
            }
        }
    }
}
