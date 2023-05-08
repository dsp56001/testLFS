using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace oneButtonGame
{
    class ShotController : DrawableGameComponent
    {
        
        public ShotManager SM;
        public SpaceShip SS;

        public ShotController(Game game, SpaceShip sS, TimedAlienSpawner a) : base(game)
        {
            SM = new ChainGun(this.Game, a);
            

            if (SM is RateLimitedShotManager)
            {
                ((RateLimitedShotManager)SM).LimitShotRate = .5f;
                ((RateLimitedShotManager)SM).MaxShots = 3;
            }
            this.Game.Components.Add(SM);
            SS = sS;
        }
        public override void Update(GameTime gameTime)
        {
            if (SS.State == SpaceShipState.Playing)
            {
                if (SS.controller.input.KeyboardState.HasReleasedKey(Microsoft.Xna.Framework.Input.Keys.Space))
                {
                    Shot s = new Shot(this.Game);
                    s.Location = SS.Location;
                    s.Direction = new Vector2(0, -1);
                    s.Speed = 600;
                    SM.Shoot(s);
                }
            }
            //if (SC.input.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.B))
            //{
            //    Shot s = new Shot(this.Game);
            //    s.Location = SS.Location;
            //    s.Speed = 600;
            //    SM.Shoot(s);
            //}

            base.Update(gameTime);
        }
    }
}
