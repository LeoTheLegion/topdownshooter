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
    public class KinematicMovementComponent
    {
        private Entity _entity;
        public Vector2 Velocity { get; set; }
        public KinematicMovementComponent(Entity entity)
        {
            _entity = entity;
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            this._entity.Position += this.Velocity * dt;
        }
    }
}
