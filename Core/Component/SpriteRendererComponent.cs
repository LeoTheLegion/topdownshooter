using LeoTheLegion.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace rpg.Core.Component
{
    public class SpriteRendererComponent
    {
        private Entity _entity;
        private Sprite _sprite;

        public Vector2 RenderOffset { get; set; }

        public SpriteRendererComponent(Entity entity, Sprite sprite)
        {
            _entity = entity;
            _sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_sprite.getSheet(), _entity.GetPosition() + RenderOffset, _sprite.getSpriteRec(), Color.White);
        }
    }
}
