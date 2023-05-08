using MonoGameLibrary.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Util;
using System;
using System.Security.Cryptography.X509Certificates;

namespace oneButtonGame
{
    public  class Alien : DrawableSprite
    {
        Shot shot;
        public Alien(Game game) : base (game)
        {
            shot = new Shot(game);
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
        public override void Initialize()
        {
            SetUpGhost();
            base.Initialize();
        }

        public void SetUpGhost()
        {
            this.Speed = 50;
            this.SpriteTexture = this.Game.Content.Load<Texture2D>("Alien");
        }
        public override void Update(GameTime gameTime)
        {
            UpdateGhostMove(gameTime);
            BottomScreenCollision();

            base.Update(gameTime);
        }
        private void UpdateGhostMove(GameTime gameTime)
        {
            this.Location += this.Direction * (this.Speed * gameTime.ElapsedGameTime.Milliseconds / 1000);
        }
        public void BottomScreenCollision()
        {
            if (this.Location.Y + this.spriteTexture.Height > this.Game.GraphicsDevice.Viewport.Height)
            {
                this.Enabled = false;
                this.Visible = false;
                ScoreManager.loseLife();

            }


        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
