using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTheLegion.Core.Collision
{
    public abstract class Collider
    {
        public Entity Entity { get; protected set; }

        protected Collider(Entity entity)
        {
            Entity = entity;
        }
    }
}
