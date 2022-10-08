using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public class Player
    {
        private Vector2 position = new Vector2(500, 300);
        private int speed = 300;
        private Dir direction = Dir.Down;
        private bool isMoving = false;
        private KeyboardState kStateOld = Keyboard.GetState();
        public bool dead = false;

        public SpriteAnimation anim;
        public SpriteAnimation[] animations = new SpriteAnimation[4];

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public void setX(float x)
        {
            position.X = x;
        }

        public void setY(float y)
        {
            position.Y = y;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            isMoving = false;

            if (kstate.IsKeyDown(Keys.Right))
            {
                direction = Dir.Right;
                isMoving = true;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                direction = Dir.Left;
                isMoving = true;
            }

            if (kstate.IsKeyDown(Keys.Up))
            {
                direction = Dir.Up;
                isMoving = true;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                direction = Dir.Down;
                isMoving = true;
            }

            if (kstate.IsKeyDown(Keys.Space))
                isMoving = false;

            if (dead)
                isMoving = false;

            if (isMoving)
            {
                switch (direction)
                {
                    case Dir.Right:
                        if(position.X < 1275)
                            position.X += speed * dt;
                        break;
                    case Dir.Left:
                        if (position.X > 225)
                            position.X -= speed * dt;
                        break;
                    case Dir.Down:
                        if(position.Y < 1250)
                            position.Y += speed * dt;
                        break;
                    case Dir.Up:
                        if (position.Y > 200)
                            position.Y -= speed * dt;
                        break;
                }
            }

            anim = animations[(int)direction];
            anim.Position = position - new Vector2(48,48);

            if(kstate.IsKeyDown(Keys.Space))
                anim.setFrame(0);
            else if (isMoving)
                anim.Update(gameTime);
            else
                anim.setFrame(1);

            if (kstate.IsKeyDown(Keys.Space) && kStateOld.IsKeyUp(Keys.Space))
                Projectile.projectiles.Add(new Projectile(position, direction));

            kStateOld = kstate;
        }
    }
}
