using LeoTheLegion.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using rpg.Core;
using rpg.Core.Component;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    public class Player : Entity
    {
        private AnimatedSpriteRendererComponent _spriteRenderer;
        private InputComponent _inputComponent;
        private KinematicMovementComponent movementComponent;
        private float _speed = 300;
        private AnimatedSprite[] animatedSprites;
        private Direction facingDirection;
        public Player(Vector2 pos)
        {
            this.Position = pos;
        }

        public override void Start()
        {
            this.animatedSprites = new AnimatedSprite[] {
                (AnimatedSprite)Resources.Load("playerWalkDown"), //0
                (AnimatedSprite)Resources.Load("playerWalkUp"), //1
                (AnimatedSprite)Resources.Load("playerWalkLeft"), //2
                (AnimatedSprite)Resources.Load("playerWalkRight"), //3
            };

            this._spriteRenderer = new AnimatedSpriteRendererComponent(this,
                this.animatedSprites[0]
                , 8);
            this.facingDirection = Direction.Down;

            this._spriteRenderer.RenderOffset = new Vector2(-48, -48);

            this._inputComponent = new InputComponent(this);
            this.movementComponent = new KinematicMovementComponent(this);
        }

        public override void Update(GameTime gameTime)
        {
            this._inputComponent.Update(gameTime);

            Vector2 controlAxis = GetControlAxis();

            bool isMoving = controlAxis.Length() > 0.1f;
            bool isShooting = this._inputComponent.isKeyPressedDown(Keys.Space);

            if (!isShooting)
            {
                if (isMoving)
                {
                    this._spriteRenderer.ReleaseFrameControl();

                    if (controlAxis.X < 0)
                    {
                        this._spriteRenderer.setAnimationTo(animatedSprites[2]);
                        this.facingDirection = Direction.Left;
                    }
                        

                    if (controlAxis.X > 0)
                    {
                        this._spriteRenderer.setAnimationTo(animatedSprites[3]);
                        this.facingDirection = Direction.Right;
                    }
                        

                    if (controlAxis.Y < 0)
                    {
                        this._spriteRenderer.setAnimationTo(animatedSprites[0]);
                        this.facingDirection = Direction.Down;
                    }
                        

                    if (controlAxis.Y > 0)
                    {
                        this._spriteRenderer.setAnimationTo(animatedSprites[1]);
                        this.facingDirection = Direction.Up;
                    }
                        

                    Vector2 velocity = controlAxis * _speed;
                    velocity.Y = -velocity.Y; //revert y
                    this.movementComponent.Velocity = velocity;
                }
                else
                {
                    this._spriteRenderer.GainFrameControl();
                    this._spriteRenderer.setFrameTo(1);
                    this.movementComponent.Velocity = Vector2.Zero;
                }
            }
            else
            {

                Vector2 direction = Vector2.Zero;

                switch (this.facingDirection)
                {
                    case Direction.Up:
                        direction = new Vector2(0, -1);
                        break;
                    case Direction.Down:
                        direction = new Vector2(0, 1);
                        break;
                    case Direction.Left:
                        direction = new Vector2(-1, 0);
                        break;
                    case Direction.Right:
                        direction = new Vector2(1, 0);
                        break;
                }

                new Projectile(Position, direction).SetSort(2);

                this._spriteRenderer.GainFrameControl();
                this._spriteRenderer.setFrameTo(0);
                this.movementComponent.Velocity = Vector2.Zero;
            }

            this.movementComponent.Update(gameTime);
            this._spriteRenderer.Update(gameTime);

            this._inputComponent.SaveState();
        }

        private Vector2 GetControlAxis()
        {
            Vector2 v = this._inputComponent.LeftAxis;
            v.Normalize();

            if(Math.Abs(v.X) > Math.Abs(v.Y))
            {
                return new Vector2(v.X, 0);
            }
            else
            {
                return new Vector2(0, v.Y);
            }
        }

        public override void Render(SpriteBatch _spriteBatch)
        {
            this._spriteRenderer.Draw(_spriteBatch);
        }
    }
}
