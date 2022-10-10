using LeoTheLegion.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using rpg.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Core
{
    public class Decortive : Entity
    {
        private string spriteName;
        private SpriteRendererComponent _spriteRenderer;

        public Decortive(string assetName, Vector2 pos)
        {
            this._position = pos;
            this.spriteName = assetName;
        }

        public override void Start()
        {
            this._spriteRenderer = new SpriteRendererComponent(this, (Sprite)Resources.Load(spriteName));
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Render(SpriteBatch _spriteBatch)
        {
            this._spriteRenderer.Draw(_spriteBatch);
        }
    }
}
