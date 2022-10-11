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
        private bool _isFrameControlled = false;

        private float timeElapsed;
        public bool IsLooping = true;
        private float timeToUpdate; //default, you may have to change it
        public int FramesPerSecond { set { timeToUpdate = (1f / value); } }

        protected int FrameIndex = 0;

        public Vector2 RenderOffset { get; set; }

        public AnimatedSpriteRendererComponent(Entity entity, AnimatedSprite sprite, int fps)
        {
            _entity = entity;
            _sprite = sprite;
            FramesPerSecond = fps;
        }

        public void Update(GameTime gameTime)
        {
            if (_isFrameControlled) return;

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
            spriteBatch.Draw(_sprite.getSheet(), _entity.GetPosition() + RenderOffset, _sprite.getFrame(FrameIndex), Color.White);
        }

        public void setAnimationTo(AnimatedSprite animatedSprite)
        {
            this._sprite = animatedSprite;
        }

        public void GainFrameControl()
        {
            _isFrameControlled = true;
        }

        public void ReleaseFrameControl()
        {
            _isFrameControlled = false;
        }

        public void setFrameTo(int v)
        {
            this.FrameIndex = v;
        }
    }
}
