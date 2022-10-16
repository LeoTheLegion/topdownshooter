using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public class GameController
    {
        public double timer = 2D;
        public double maxTime = 2D;
        static Random random = new Random();

        public void Update(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (timer <= 0)
            {
                int side = random.Next(4);
                Vector2 pos = Vector2.Zero; 

                switch (side)
                {
                    case 0:
                        pos = new Vector2(-500, random.Next(-500, 2000));
                        break;
                    case 1:
                        pos = new Vector2(2000, random.Next(-500, 2000));
                        break;
                    case 2:
                        pos = new Vector2(random.Next(-500, 2000), -500);
                        break;
                    case 3:
                        pos = new Vector2(random.Next(-500, 2000), 2000);
                        break;

                }

                new Skull(pos);

                timer = maxTime;

                if (maxTime > 0.5)
                {
                    maxTime -= 0.05D;
                }
            }
        }
    }
}
