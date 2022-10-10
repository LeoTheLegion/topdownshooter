﻿using LeoTheLegion.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using rpg.Core;
using rpg.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public class Player : Entity
    {
        private string spriteName;
        private AnimatedSpriteRendererComponent _spriteRenderer;

        public Player(string assetName, Vector2 pos)
        {
            this._position = pos;
            this.spriteName = assetName;
        }

        public override void Start()
        {
            this._spriteRenderer = new AnimatedSpriteRendererComponent(this,
                (AnimatedSprite)Resources.Load(spriteName)
                ,8);
        }

        public override void Update(GameTime gameTime)
        {
            this._spriteRenderer.Update(gameTime);
        }

        public override void Render(SpriteBatch _spriteBatch)
        {
            this._spriteRenderer.Draw(_spriteBatch);
        }
    }
}
