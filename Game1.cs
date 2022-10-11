using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LeoTheLegion.Core;
using System.Collections.Generic;
using rpg.Core;
using rpg.Test;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace rpg
{
    public enum Direction
    {
        Down,
        Up,
        Left,
        Right
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private OrthographicCamera _camera;

        private EntityManagementSystem _entityManagementSystem;

        private Player _player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 1280, 720);
            _camera = new OrthographicCamera(viewportAdapter);

            _entityManagementSystem = new EntityManagementSystem();

           
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Resources.Init(new Dictionary<string, Asset>()
            {
                { "playerWalkDownSheet", new SpriteSheet("Player/walkDown",1,4) },
                { "playerWalkRightSheet", new SpriteSheet("Player/walkRight",1,4) },
                { "playerWalkLeftSheet", new SpriteSheet("Player/walkLeft",1,4) },
                { "playerWalkUpSheet", new SpriteSheet("Player/walkUp",1,4) },
                { "backgroundSheet", new SpriteSheet("background",1,1) },
                { "ballsheet", new SpriteSheet("ball",1,1) },
            });

            Resources.LoadContent(Content);

            Resources.AddAfterLoadAssets(new Dictionary<string, Asset>()
            {
                { "idle", new Sprite((SpriteSheet)Resources.Load("playerWalkDownSheet"),1) },
                { "playerWalkDown",
                    new AnimatedSprite(
                        (SpriteSheet)Resources.Load("playerWalkDownSheet"),
                        new int[]{0,1,2,3})
                },
                { "playerWalkRight",
                    new AnimatedSprite(
                        (SpriteSheet)Resources.Load("playerWalkRightSheet"),
                        new int[]{0,1,2,3})
                },
                { "playerWalkLeft",
                    new AnimatedSprite(
                        (SpriteSheet)Resources.Load("playerWalkLeftSheet"),
                        new int[]{0,1,2,3})
                },
                { "playerWalkUp",
                    new AnimatedSprite(
                        (SpriteSheet)Resources.Load("playerWalkUpSheet"),
                        new int[]{0,1,2,3})
                },
                { "background",
                    new Sprite(
                        (SpriteSheet)Resources.Load("backgroundSheet"),
                        0)
                },
                { "ball",
                    new Sprite(
                        (SpriteSheet)Resources.Load("ballsheet"),
                        0)
                },
            });

            new Decorative("background", new Vector2(-500, -500)).SetSort(-1);

            new Decorative("idle", new Vector2(200, 100)).SetSort(1);
            new TestAnimationEntity("playerWalkDown", new Vector2(300, 100)).SetSort(1);
            new TestAnimationEntity("playerWalkRight", new Vector2(400, 100)).SetSort(1);
            new TestAnimationEntity("playerWalkLeft", new Vector2(500, 100)).SetSort(1);
            new TestAnimationEntity("playerWalkUp", new Vector2(600, 100)).SetSort(1);

            _player = new Player(new Vector2(300, 300));
            _player.SetSort(1);

            _entityManagementSystem.Start();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _entityManagementSystem.Update(gameTime);

            _camera.LookAt(_player.Position);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            var transformMatrix = _camera.GetViewMatrix();
            _spriteBatch.Begin(transformMatrix: transformMatrix);

            _entityManagementSystem.Render(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}