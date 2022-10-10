using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LeoTheLegion.Core;
using Comora;
using System.Collections.Generic;
using rpg.Core;

namespace rpg
{
    public enum Dir
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

        private EntityManagementSystem _entityManagementSystem;

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
            });

            new Decortive("idle", new Vector2(200, 100));
            new Player("playerWalkDown", new Vector2(300, 100));
            new Player("playerWalkRight", new Vector2(400, 100));
            new Player("playerWalkLeft", new Vector2(500, 100));
            new Player("playerWalkUp", new Vector2(600, 100));


            _entityManagementSystem.Start();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _entityManagementSystem.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _entityManagementSystem.Render(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}