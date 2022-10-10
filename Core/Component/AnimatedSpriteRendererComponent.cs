using LeoTheLegion.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Core.Component
{
    internal class AnimatedSpriteRendererComponent
    {
        private Entity _entity;
        private AnimatedSprite _sprite;

        private float timeElapsed;
        public bool IsLooping = true;
        private float timeToUpdate; //default, you may have to change it
        public int FramesPerSecond { set { timeToUpdate = (1f / value); } }

        protected int FrameIndex = 0;

        public AnimatedSpriteRendererComponent(Entity entity, AnimatedSprite sprite, int fps)
        {
            _entity = entity;
            _sprite = sprite;
            FramesPerSecond = fps;
        }

        public void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if (FrameIndex < _sprite.Length - 1)
                    FrameIndex++;

                else if (IsLooping)
                    FrameIndex = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_sprite.getSheet(), _entity.GetPosition(), _sprite.getFrame(FrameIndex), Color.White);
        }
    }
}
