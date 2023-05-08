using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameLibrary.Util;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;

namespace oneButtonGame
{
    public enum Gamestate { isPlaying, Lose, Restart }
    public class ScoreManager : DrawableGameComponent
    {
        //change 
        Color RestartColor;
        Color lostColor;

        SpriteFont font;
        SpriteBatch sb;
        public static int Lives;
        public static int Level;
        public static int Score;
        public static int HiScore;
        
        

        SpaceShip ship;
        TimedAlienSpawner TS;
        Alien alien;
        Audio gamesound;

        InputHandler input;






        public static Gamestate gamestate;

        Vector2 scoreLoc, livesLoc, hiscoreLoc; 
        int livesLocX, livesLocY;

        public ScoreManager(Game game, SpaceShip ship, TimedAlienSpawner alienSpawner, Audio sound) : base(game)
        {
            gamesound = sound;  
            TS = alienSpawner;
            RestartColor = new Color();
            lostColor = new Color();
            
            this.ship = ship;
            
             gamestate = Gamestate.isPlaying;

            livesLocX = 10;
            livesLocY = 10;
            SetupNewGame();
            lostColor = Color.Transparent;
            RestartColor = Color.Transparent;

            //Get service 
            input = (InputHandler)this.Game.Services.GetService<IInputHandler>();
            if(input == null )
            {
                input = new InputHandler(this.Game);

            }
        }
        
        public void updateScore()
        {
            if (Score >= HiScore)
            {
                HiScore = Score;

            }

        }

        public void GetGameState()
        {
            
            switch (gamestate)
            {
                case Gamestate.isPlaying:
                    
                    if (ScoreManager.Lives <= 0)
                    {
                        gamestate = Gamestate.Lose;
                        
                        gamesound.gameoverSong();
                    }
                    break;

                case Gamestate.Lose:

                    ship.State = SpaceShipState.Dead;
                    RestartColor = Color.White;
                    lostColor = Color.White;
                    TS.ridofAliens();
                    if (input.KeyboardState.IsKeyDown(Keys.R))
                    {
                        gamestate = Gamestate.Restart;


                    }
                    break;
                case Gamestate.Restart:
                    gamesound.backgroundSong();
                    
                    gamestate = Gamestate.isPlaying;
                    ship.Enabled = true;
                    ship.State = SpaceShipState.Playing;

                    TS.Enabled = true;
                    TS.alienstate = AlienSpawnerState.PlayerAlive;
                    
                    RestartColor = Color.Transparent;
                    lostColor = Color.Transparent;
                    Lives = 3;
                    Score = 0;
                    


                    break;
                default:
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            GetGameState();
            updateScore();

            base.Update(gameTime);
        }

        private static void SetupNewGame()  //Generally mixing static and non static methods is messy be careful
        {
            Lives = 3;
            HiScore = 25000;
            Score = 0;
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            font = this.Game.Content.Load<SpriteFont>("Arial");

            livesLoc = new Vector2(livesLocX, livesLocY);
            hiscoreLoc = new Vector2(300, 10);
            scoreLoc = new Vector2(450, 10);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();

            sb.DrawString(font, "Lives: " + Lives, livesLoc, Color.Red);
            sb.DrawString(font, "Score: " + Score, scoreLoc, Color.White);
            sb.DrawString(font, "HI-Score: " + HiScore, hiscoreLoc, Color.Yellow);

            sb.DrawString(font, "Retry? Press R", new Vector2(250, 100), RestartColor);
            sb.DrawString(font, "You Failed!", new Vector2(250, 80), lostColor);

            sb.End();
            base.Draw(gameTime);
        }

        internal static void loseLife()
        {
            if(gamestate == Gamestate.isPlaying)
            {
                ScoreManager.Lives--;
            }
        }
    }
}
