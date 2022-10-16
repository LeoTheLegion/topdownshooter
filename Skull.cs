using LeoTheLegion.Core;
using LeoTheLegion.Core.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using rpg.Core;
using rpg.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public class Skull : Entity , ICollide
    {
        private AnimatedSpriteRendererComponent _spriteRenderer;
        private KinematicMovementComponent _movementComponent;
        private DumbPathFindingComponent _pathFindingComponent;
        private Entity _chaseTarget;
        private CircleCollider _circleCollider;

        private float _speed = 150;

        public Skull(Vector2 position)
        {
            this.Position = position;
            this._chaseTarget = Player.MAIN;
        }

        public override void Start()
        {
            AnimatedSprite sprite = (AnimatedSprite)Resources.Load("skull");
            this._spriteRenderer = new AnimatedSpriteRendererComponent(this,
                sprite
                , 8);

            Rectangle firstFrame = sprite.getFrame(0);

            this._spriteRenderer.RenderOffset = new Vector2(-firstFrame.Width/2, -firstFrame.Height/2);

            this._movementComponent = new KinematicMovementComponent(this);
            this._pathFindingComponent = new DumbPathFindingComponent(this);
            this._circleCollider = new CircleCollider(this, 15);
        }

        public override void Update(GameTime gameTime)
        {
            this._pathFindingComponent.TargetPostion = this._chaseTarget.Position;
            this._pathFindingComponent.Update(gameTime);

            Vector2 direction = this._pathFindingComponent.NextPoint - this.Position;
            direction.Normalize();

            this._movementComponent.Velocity = direction * _speed;

            this.SetSort(1000 + (int)this.Position.Y);

            this._movementComponent.Update(gameTime);
            this._spriteRenderer.Update(gameTime);
        }

        public override void Render(SpriteBatch _spriteBatch)
        {
            this._spriteRenderer.Draw(_spriteBatch);
        }

        public bool IsColliderActive()
        {
            return this.GetActive();
        }

        public Collider GetCollider()
        {
            return this._circleCollider;
        }

        public void hit(ICollide collide)
        {

        }
    }
}
