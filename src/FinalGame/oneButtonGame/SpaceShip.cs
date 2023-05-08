using Microsoft.Xna.Framework;
using MonoGameLibrary.Sprite;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Util;


namespace oneButtonGame
{

    public enum SpaceShipState{Playing, Dead}
    public  class SpaceShip : DrawableSprite
    {
        public SpriteBatch sb2;
        public InputHandler input;
        public Texture2D shipTexture;
        public Texture2D deadTexture;

        public ShipController controller;
        ShotController shotController;

        public SpaceShipState State;
        


        public SpaceShip(Game game, TimedAlienSpawner a) : base(game) 
        {
            shotController = new ShotController(game, this, a);
            
            game.Components.Add(shotController);
            Speed = 300;

            controller = new ShipController(game);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        protected override void LoadContent()
        {
            //sb2 = new SpriteBatch(Game.GraphicsDevice);
            shipTexture = this.SpriteTexture = Game.Content.Load<Texture2D>("SpaceShip");
            deadTexture = Game.Content.Load<Texture2D>("Dead");
           
            base.LoadContent();
        }
        public override void Initialize()
        {
            this.Location = new Vector2(330, 440);
            base.Initialize();
        }

        public void changeShipState() 
        { 
            switch (State)
            {
                case SpaceShipState.Playing:
                    this.Enabled = true;
                    this.Visible = true;
                    break;

                case SpaceShipState.Dead:
                    this.Enabled = false;
                    this.Visible = false;
                    break;
               

            }
        }

       
        

       
        

        public override void Update(GameTime gameTime)
        {
           
            changeShipState();
            
            controller.SetInput(gameTime);
            this.Direction = controller.Direction;
            this.Location += this.Direction * (this.Speed * gameTime.ElapsedGameTime.Milliseconds / 1000);

            

            base.Update(gameTime);
        }
    }
}
