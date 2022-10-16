using Microsoft.Xna.Framework;
using rpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTheLegion.Core.Collision
{
    public class CircleCollider : Collider
    {
        public float Radius { set; get; }
        public Vector2 Position { get { return this.Entity.Position; } }

        public CircleCollider(Entity e, int radius): base(e)
        {
            this.Radius = radius;
        }
    }
}
