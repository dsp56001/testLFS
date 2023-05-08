using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace oneButtonGame
{
    public enum playSong { alive, died }
    public class Audio : GameComponent
    {



        InputHandler input;     //From monogamelibrary

        public playSong state;


        Song backSong;   //using Microsoft.Xna.Framework.Media
        Song gameover;



        //Sound Effects are loaded and played ready to be replayed
        SoundEffect pacDie;  //using Microsoft.Xna.Framework.Audio



        //Sound Effect instances are loaded with replacement policies
        SoundEffectInstance pacSpawnInstance, pacChompInstance;



        private string outText;



        //Key maps one for when keys are released on for when keys are down
        Dictionary<Keys, string> onReleasedKeyMap, onKeyDownMap;



        public Audio(Game game) : base(game)
        {
            input = (InputHandler)this.Game.Services.GetService<IInputHandler>();
            if (input == null)
            {
                input = new InputHandler(this.Game);
                this.Game.Components.Add(input);



            }
            onReleasedKeyMap = new Dictionary<Keys, string>();
            onKeyDownMap = new Dictionary<Keys, string>();
        }

        public void gameoverSong()
        {
            MediaPlayer.Play(gameover);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 1;
        }

        public void backgroundSong()
        {
            MediaPlayer.Play(backSong);
            MediaPlayer.IsRepeating = true;
           
        }

        public override void Initialize()
        {
            //Back Ground Sound
            this.backSong = this.Game.Content.Load<Song>("DariusTwin(SNES)-Lankus");
            this.gameover = this.Game.Content.Load<Song>("Death - Thunder Fox [Arcade]");
            MediaPlayer.Play(backSong);     //Start the song playing
            // MediaPlayer.Play(gameover);



            //Load Sound Effects

            //pacChomp = this.Game.Content.Load<SoundEffect>("pacchomp");




            //MediaPlayer.IsRepeating = true;
            
            MediaPlayer.Volume = 1;   //set starting volume



            //Setup Song keys
            onReleasedKeyMap.Add(Keys.M, "Song Volume Up");
            onReleasedKeyMap.Add(Keys.N, "Song Volume Down");
            onReleasedKeyMap.Add(Keys.OemCloseBrackets, "Song Stop");





            base.Initialize();
        }



        public override void Update(GameTime gameTime)
        {
            UpdateInputAudio();
            base.Update(gameTime);
        }

        private void UpdateInputAudio()
        {
            UpdateReleasedKeyMap();

        }

        private void UpdateReleasedKeyMap()
        {
            //Has Released Keys
            foreach (var item in onReleasedKeyMap)
            {
                if (input.KeyboardState.HasReleasedKey(item.Key))
                {
                    switch (item.Value)
                    {
                        case "Song Volume Up":
                            MediaPlayer.Volume += .1f; //Song Volume UP
                            break;
                        case "Song Volume Down":
                            MediaPlayer.Volume -= .1f; //Song Volume Down
                            break;
                    }
                }
            }
        }
    }
}
