using LeoTheLegion.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LeoTheLegion.Core
{
    public class SpriteSheet : Asset
    {
        private Texture2D _texture2d;
        private int _rows, _cols;
        private string _assetName;
        protected Rectangle[] _rectangles;

        public SpriteSheet(string assetName, int rows , int columns)
        {
            this._assetName = assetName;
            this._rows = rows;
            this._cols = columns;
        }

        public override void LoadContent(ContentManager _content)
        {
            this._texture2d = _content.Load<Texture2D>(_assetName);

            int width = this._texture2d.Width / this._cols;
            int height = this._texture2d.Height / this._rows;

            _rectangles = new Rectangle[this._cols * this._rows];

            for (int y = 0; y < this._rows; y++)
            {
                for (int x = 0; x < this._cols; x++)
                {
                    _rectangles[y * this._rows + x] = new Rectangle(x * width, y * height, width, height);
                }
            }
        }

        public Texture2D getSheet() { return _texture2d; }

        public Rectangle getSpriteRec(int i) { return _rectangles[i]; }
    }
}