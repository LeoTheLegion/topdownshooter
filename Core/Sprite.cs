using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTheLegion.Core
{
    public class Sprite : Asset
    {
        private SpriteSheet _spriteSheet;
        private int _index;

        public Sprite(SpriteSheet spriteSheet, int index)
        {
            _spriteSheet = spriteSheet;
            _index = index;
        }

        public override void LoadContent(ContentManager _content)
        {
        }

        public Texture2D getSheet() { return _spriteSheet.getSheet(); }

        public Rectangle getSpriteRec() { return _spriteSheet.getSpriteRec(_index); }
    }
}
