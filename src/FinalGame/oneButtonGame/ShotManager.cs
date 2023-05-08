using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneButtonGame
{
    public interface IShotManager
    {
        List<Shot> Shots { get; set; }
        Shot Shoot();
        Shot Shoot(Shot s);
        string ShotTexture { get; set; }

    }


    public class ShotManager : DrawableGameComponent, IShotManager
    {

        SpriteBatch spriteBatch;
        TimedAlienSpawner As;

        List<Shot> shots; //Example of a Private Instance Data Member

        public List<Shot> Shots
        {
            get
            {
                return shots;
            }
            set
            {
                shots = value;
            }
        }

        #region Shoot
        public virtual Shot Shoot()
        {
            return Shoot(new Shot(this.Game));
        }

        public virtual Shot Shoot(Vector2 direction, float speed)
        {
            s.Direction = direction;
            s.Speed = speed;
            return this.Shoot(s);
        }

        public virtual Shot Shoot(Shot shot)
        {
            s = shot;
            if (!String.IsNullOrEmpty(this.ShotTexture))
            {
                s.ShotTexture = this.ShotTexture;
            }

            s.Initialize();
            this.addShot(s);
            return s;
        }

        #endregion
        List<Shot> shotsToRemove { get; set; }
        public string ShotTexture { get; set; }

        protected Shot s = null;

        //TODO this is a single alien probably should be alienManager
        Alien alien;

        public ShotManager(Game game, TimedAlienSpawner a) : base(game)
        {

            As = a;
            //scoremanager = new ScoreManager(game);
            this.shots = new List<Shot>();
            this.shotsToRemove = new List<Shot>();
            s = new Shot(game);

        }

        protected virtual void addShot(Shot s)
        {
            this.shots.Add(s);
        }

        protected virtual void removeShot(Shot s)
        {
            this.shots.Remove(s);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            base.LoadContent();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public override void Update(GameTime gameTime)
        {
            shotsToRemove.Clear();

            foreach (var s in Shots)
            {
                if (s.Enabled)
                {
                    s.Update(gameTime);
                    CheckForCollision(s);
                }
                else
                {
                    shotsToRemove.Add(s);
                }
            }

            foreach (Shot s in shotsToRemove)
            {
                this.removeShot(s);
            }
            base.Update(gameTime);
        }

        private void CheckForCollision(Shot s)
        {
            foreach (Alien alien in As.aliens)
                if (s.Intersects(alien))
                {
                    ScoreManager.Score += 100;
                    alien.Visible = false;
                    alien.Enabled = false;

                }
            As.aliens.Remove(alien);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            this.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
            
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var s in Shots)
            {
                if (s.Visible)
                    s.Draw(sb);
            }
        }
    }
}
