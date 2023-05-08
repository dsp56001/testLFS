using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneButtonGame
{
    public class ShipController
    {
        public InputHandler input;
        ScoreManager scoreManager;
        Gamestate gamestate = Gamestate.isPlaying;
        //public bool Restartgame;


        public Vector2 Direction { get; private set; }

        public ShipController(Game game) : base()
        {
            input = (InputHandler)game.Services.GetService(typeof(IInputHandler));
            this.Direction = Vector2.Zero;
            
            if (input == null) 
            {
                input = new InputHandler(game);
                game.Components.Add(input);            
            }
        }

        public void SetInput(GameTime gametime)
        {
            this.Direction = Vector2.Zero;  //Start with no direction on each new upafet

            //No need to sum input only uses left and right
            if (input.KeyboardState.IsKeyDown(Keys.Left))
            {
                //Debug.WriteLine("left");
                this.Direction = new Vector2(-1, 0);
            }
            if (input.KeyboardState.IsKeyDown(Keys.Right))
            {
                this.Direction = new Vector2(1, 0);
            }


        }
    }
}
