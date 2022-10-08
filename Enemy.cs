using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public class Enemy
    {
        public static List<Enemy> enemies = new List<Enemy>();  

        private Vector2 position = new Vector2(0,0);
        private int speed = 150;
        public SpriteAnimation anim;
        public int radius = 30;
        private bool dead = false;

        public Vector2 Position
        {
            get { return position; }
        }
        public bool Dead
        {
            set { dead = value; }
            get { return dead; }
        }

        public Enemy(Vector2 position, Texture2D spriteSheet)
        {
            this.position = position;
            this.anim = new SpriteAnimation(spriteSheet, 10, 6);
        }

        public void Update(GameTime gameTime, Vector2 playerPos, bool isPlayerDead)
        {
            this.anim.Position = this.Position - new Vector2(48,66);
            this.anim.Update(gameTime);

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!isPlayerDead)
            {
                Vector2 moveDir = playerPos - position;
                moveDir.Normalize();
                position += moveDir * speed * dt;
            }

            
        }
    }
}
