using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneButtonGame
{
    public class ChainGun : RateLimitedShotManager
    {


        
            public ChainGun(Game game, TimedAlienSpawner a) : base(game, a)
            {
                this.LimitShotRate = .02f;
                this.MaxShots = 10;
            }
        
    }
}
