using LeoTheLegion.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Core.Component
{
    public class DumbPathFindingComponent
    {
        private Entity _me;

        public Vector2 TargetPostion { get; set; }

        public Vector2 NextPoint
        {
            get { return TargetPostion; }
        }

        

        public DumbPathFindingComponent(Entity me)
        {
            this._me = me;
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
