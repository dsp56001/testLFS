using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oneButtonGame
{
    public enum AlienSpawnerState { PlayerAlive, PlayerDead };
    public class TimedAlienSpawner : TimedSpawner
    {
        Alien alien;
        Shot shot;
        public List<Alien> aliens { get; set; }
        public List<Alien> removeAliens { get; set; }
        public AlienSpawnerState alienstate;

        public TimedAlienSpawner(Game game) : base(game)
        {
            this.alien = new Alien(game);
            this.SetSpawnKey(Microsoft.Xna.Framework.Input.Keys.S);
            aliens = new List<Alien>();
            removeAliens = new List<Alien>();
        }

        public override GameComponent Spawn()
        {
            
            //Local variable example:
            Alien alien = new Alien(this.Game);
            alien.Initialize();
            alien.Location = this.GetRandLocation(alien.spriteTexture);
            alien.Direction = new Vector2(0, 1);
            this.instance = alien;

            aliens.Add(alien);


            if (alien.Direction.Y == 300)
            {
                alien.Enabled = false;
                ScoreManager.Lives--;
            }
            return base.Spawn();

        }

        public void changeAlienState()
        {
            switch (alienstate)
            {
                case AlienSpawnerState.PlayerAlive:
                    this.Enabled = true;
                    this.Visible = true;
                    break;

                case AlienSpawnerState.PlayerDead:
                    this.Enabled = false;
                    this.Visible = false;
                    break;


            }
        }

        public void ridofAliens()
        {
            foreach (var alien in this.aliens)
            {
                if (alien.Enabled == true)
                {
                    alien.Enabled = false;
                    alien.Visible = false;
                    
                }
            }
            aliens.Clear();
        }

        public override void Update(GameTime gameTime)
        {
            
            changeAlienState();
            if (ScoreManager.gamestate == Gamestate.isPlaying)
            {
                for (int i = 0; i < aliens.Count; i++)
                {
                    if (!aliens[i].Enabled)
                    {
                        aliens.Remove(aliens[i]);
                    }
                }

                base.Update(gameTime);
            }
        }

    }
}
