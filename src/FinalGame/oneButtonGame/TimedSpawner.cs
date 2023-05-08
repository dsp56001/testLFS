using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneButtonGame
{
    public class TimedSpawner : Spawner
    {
        protected float spawnTime, lastSpawn;

        public float SpawnTime
        {
            get { return spawnTime; }
            set { this.spawnTime = value; }
        }

        public void SetSpawnTime(float timeTillNextSpawn)
        {
            this.spawnTime = timeTillNextSpawn;
        }

        public TimedSpawner(Game game)
            : base(game)
        {
            spawnTime = 500;
            lastSpawn = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (lastSpawn > spawnTime)
            {
                this.Spawn();
                lastSpawn = 0;
            }

            lastSpawn += gameTime.ElapsedGameTime.Milliseconds;
            base.Update(gameTime);
        }
    }
}
