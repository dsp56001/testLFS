using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.State;
using MonoGameLibrary.Util;


namespace oneButtonGame
{
   
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public SpriteFont font;
        public InputHandler input;
        Audio gamesound;
        SpaceShip spaceship;
        ScoreManager score;
        TimedAlienSpawner ts;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            gamesound = new Audio(this);
            this.Components.Add(gamesound);

            ts = new TimedAlienSpawner(this);
            this.Components.Add(ts);
            //alien = new Alien(this);
            
            spaceship = new SpaceShip(this, ts);
            this.Components.Add(spaceship);
            spaceship.ShowMarkers = true;

            score = new ScoreManager(this, spaceship, ts, gamesound);
            this.Components.Add(score);

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Arial Bold");
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }
       
        
        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }
    }
}