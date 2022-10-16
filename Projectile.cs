using LeoTheLegion.Core;
using LeoTheLegion.Core.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using rpg.Core.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public class Projectile : Entity, ICollide
    {
        private Vector2 _direction;
        private int speed = 1000;
        public int radius = 18;
        private KinematicMovementComponent _movementComponent;
        private SpriteRendererComponent _spriteRenderer;
        private CircleCollider _circleCollider;

        public Projectile(Vector2 position, Vector2 direction)
        {
            this.Position = position;
            this._direction = direction.NormalizedCopy();
        }

        public override void Start()
        {
            this._movementComponent = new KinematicMovementComponent(this);
            this._spriteRenderer = new SpriteRendererComponent(this, (Sprite)Resources.Load("ball"));
            this._spriteRenderer.RenderOffset = new Vector2(-48, -48);
            this._circleCollider = new CircleCollider(this,15);
        }

        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            this._movementComponent.Velocity = this._direction * speed;

            this._movementComponent.Update(gameTime);
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
            if(collide is Skull)
            {
                collide.GetCollider().Entity.Destroy();
                this.Destroy();
            }
        }
    }
}
