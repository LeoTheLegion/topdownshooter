using LeoTheLegion.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Core.Component
{
    public class InputComponent
    {
        private Entity _entity;
        private KeyboardState _oldKState;
        private KeyboardState _currentKState;

        private float _leftHorizontal, _leftVertical;

        public float LeftHorizontal { get { return _leftHorizontal; } }
        public float LeftVertical { get { return _leftVertical; } }

        public Vector2 LeftAxis { get { return new Vector2(_leftHorizontal, _leftVertical); } }

        public InputComponent(Entity entity)
        {
            _entity = entity;
            this._oldKState = Keyboard.GetState();
        }

        public void Update(GameTime gameTime)
        {
            _currentKState = Keyboard.GetState();

            float lefthorizontal, leftvertical;
            lefthorizontal = leftvertical = 0;

            if (_currentKState.IsKeyDown(Keys.A) || _currentKState.IsKeyDown(Keys.Left))
                lefthorizontal = -1;

            if (_currentKState.IsKeyDown(Keys.D) || _currentKState.IsKeyDown(Keys.Right))
                lefthorizontal = 1;

            if (_currentKState.IsKeyDown(Keys.S) || _currentKState.IsKeyDown(Keys.Down))
                leftvertical = -1;

            if (_currentKState.IsKeyDown(Keys.W) || _currentKState.IsKeyDown(Keys.Up))
                leftvertical = 1;

            this._leftHorizontal = lefthorizontal;
            this._leftVertical = leftvertical;            
        }

        public void SaveState()
        {
            this._oldKState = _currentKState;
        }

        public bool isKeyPressedDown(Keys key)
        {
            return _currentKState.IsKeyDown(key) && _oldKState.IsKeyUp(key);
        }
    }
}
