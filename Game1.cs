using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Comora;

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

        Texture2D playerSprite, walkDown, walkUp, walkRight, walkLeft;
        Texture2D background, ball, skull;
        
        Player player = new Player();

        Camera camera;

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

            this.camera = new Camera(_graphics.GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            playerSprite = Content.Load<Texture2D>("Player/player");
            walkDown = Content.Load<Texture2D>("Player/walkDown");
            walkLeft = Content.Load<Texture2D>("Player/walkLeft");
            walkRight = Content.Load<Texture2D>("Player/walkRight");
            walkUp = Content.Load<Texture2D>("Player/walkUp");

            background = Content.Load<Texture2D>("background");
            ball = Content.Load<Texture2D>("ball");
            skull = Content.Load<Texture2D>("skull");

            player.animations[0] = new SpriteAnimation(walkDown, 4, 8);
            player.animations[1] = new SpriteAnimation(walkUp, 4, 8);
            player.animations[2] = new SpriteAnimation(walkLeft, 4, 8);
            player.animations[3] = new SpriteAnimation(walkRight, 4, 8);

            player.anim = player.animations[0];

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);

            if(!player.dead)
                Controller.Update(gameTime, skull);

            foreach (Projectile p in Projectile.projectiles)
            {
               p.Update(gameTime);
            }

            foreach (Enemy e in Enemy.enemies)
            {
                e.Update(gameTime,player.Position,player.dead);
                int sum = e.radius + 32;
                if(Vector2.Distance(player.Position, e.Position) < sum)
                {
                    player.dead = true;
                }
            }

            foreach (Projectile p in Projectile.projectiles)
            {
                foreach (Enemy e in Enemy.enemies)
                {
                    int sum = p.radius + e.radius;
                    if (Vector2.Distance(p.Position, e.Position) < sum)
                    {
                        p.Collided = true;
                        e.Dead = true;
                    }
                }
            }

            Projectile.projectiles.RemoveAll(p => p.Collided);
            Enemy.enemies.RemoveAll(e => e.Dead);

            this.camera.Position = this.player.Position;
            this.camera.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(this.camera);

            _spriteBatch.Draw(background,new Vector2(-500,-500), Color.White);

            if(!player.dead)
                player.anim.Draw(_spriteBatch);

            foreach (Enemy e in Enemy.enemies)
            {
                e.anim.Draw(_spriteBatch);
            }

            foreach (Projectile p in Projectile.projectiles)
            {
                _spriteBatch.Draw(ball, p.Position - new Vector2(48,48), Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}