using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Threading;

namespace tbMonoGameRotateImage
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        RouletteWheel wheel;

        //Character character;

        
        //EXEMPEL 1 och 2:
        SpriteFont thread_font; //En spritefont för att kunna rita ut text, inte trådspecifikt, men nyttjas här för exempel 1 och 2.
        //-----------


        //EXEMPEL 1: Dela data mellan trådar
        ThreadData thread_data; //Ett objekt i Game1 som håller tråd och tråddata, som Game1 också kommer åt, eftersom objektet defineras i Game1
        //-----------


        //EXEMPEL 2: Trådsäker kod med låsning av trådar
        object threadLock = new object(); //Objekt som nyttjas för att låsa ett stycke kod, så att inte två trådar kan komma åt stycket samtidigt.
        Thread a; //Exempeltråd A
        Thread b; //Exempeltåd B
        int data; //Data som trådarna ska komma åt och ändra
        bool runThread = true; //Flagga som avgör om trådarna ska köra sina respektive loopar

        public void Increase(object obj) //Metod som ökar data med 1 (A-tråden exekverar den här metoden)
        {
            while(runThread) //Loopar så längre runThread är sann
            {
                Debug.WriteLine(obj.ToString()); //Skriver ut trådens inparameter (strängen "A") i Debug-fönstret
                
                lock (threadLock) //Lås med objektet threadLock, dvs. om objektet redan har låsts av B-tåden måste A-tråden vänta tills threadLock är ledig/upplåst
                {
                    data++; //Öka data
                    Thread.Sleep(100); //Låt tråden sova i 100ms (0.1 sekunder)
                }
            }
        }

        public void Decrease(object obj) //Metod som minskar data med 1 (B-tråden exekverar den här metoden)
        {
            while (runThread) //Loopar så längre runThread är sann
            {
                Debug.WriteLine(obj.ToString()); //Skriver ut trådens inparameter ("Strängen "B") i Debug-fönstret
                
                lock (threadLock) //Lås med objektet threadLock, dvs. om objektet redan har låsts av A-tåden måste B-tråden vänta tills threadLock är ledig/upplåst
                {
                    data--; //Minska data
                    Thread.Sleep(1000); //Låt tråden sova i 1000ms (1 sekund)
                }
            }
        }
        //-----------

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Ändra storleken på fönstret
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 1000;
            
            //Sätt fullskärmsläge till false (dvs. kör fönsterläge)
            graphics.IsFullScreen = false;
            
            //Synliggör muspekaren
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            wheel = new RouletteWheel(Content.Load<Texture2D>("roulette"), new Vector2(500, 500), 1.0f);

            //character = new Character(Content.Load<Texture2D>("spritesheet"), new Vector2(500, 500));

            //EXEMPEL 1 och 2
            thread_font = Content.Load<SpriteFont>("threadfont"); //Ladda in font

            //EXEMPEL 1
            thread_data = new ThreadData(); //Definera thread_start
            thread_data.StartThread(); //Starta tråd genom den egenskrivna StartThread-metoden
            //-----------

            //EXEMPEL 2
            a = new Thread(new ParameterizedThreadStart(Increase)); //Exempel där ThreadStart kan innehålla parametrar
            b = new Thread(new ParameterizedThreadStart(Decrease)); //Då ska man skapa en ny ParameterizedThreadStart
            a.Start("A"); //Möjligt att skicka in en parameter
            b.Start("B"); //Möjligt att skicka in en parameter
            //-----------
        }

        protected override void UnloadContent()
        {
            //Sträng trådarna i UnloadContent, annars kommer de ligga och köra i bakgrunden
            //UnloadContent exekveras per automatik när man stänger MonoGames-fönstret
            
            //EXEMPEL 1 och 2:
            runThread = false;
            thread_data.StopThread();
            Debug.WriteLine("Trådar stängs...");
            //-----------
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            wheel.Update();
            //character.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            wheel.Draw(spriteBatch);
            //character.Draw(spriteBatch);

            //EXEMPEL 1
            spriteBatch.DrawString(thread_font, thread_data.GetData, new Vector2(50, 50), Color.White); //Grafiktråden läser data från thread_data
            //-----------

            //EXEMPEL 2 
            spriteBatch.DrawString(thread_font, data.ToString(), new Vector2(50, 100), Color.White); //Grafiktråden läser data som A och B ändrar
            //-----------

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
