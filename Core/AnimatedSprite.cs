using LeoTheLegion.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Core
{
    public class AnimatedSprite : Asset
    {
        private SpriteSheet _spriteSheet;
        private int[] _indexs;

        public int Length { get { return _indexs.Length; } }

        public AnimatedSprite(SpriteSheet spriteSheet, int[] indexs)
        {
            _spriteSheet = spriteSheet;
            _indexs = indexs;
        }

        public override void LoadContent(ContentManager _content)
        {

        }

        public Texture2D getSheet() { return _spriteSheet.getSheet(); }

        public Rectangle getFrame(int i) { return _spriteSheet.getSpriteRec(_indexs[i]); }
    }
}
