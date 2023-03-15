using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Xml;
using System.Diagnostics;
using System.Collections.Generic;
using gameExperiment.Managers;

namespace gameExperiment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private SpriteFont redHatRegular;

        private UIEventHandler uiEventHandler;

        private SpriteFont Consolas;
        private SpriteFont ConsolasMedium;
        private SpriteFont ConsolasLarge;

        private SpriteBatch _spriteBatch;



        private Checkbox checkbox1;

        private MouseState oldState;

        private MessageBox debugMessageBox;

        public void PrintHello()
        {
            debugMessageBox.DisplayMessage("Buttons say Hi");
        }

        public Game1()
        {

            //NOTE: I am commenting all references to ScreenManagers in this code because
            //I think I really need to take a step back. 

            //MainMenuContent = new ContentManager(this.Services, Content.RootDirectory);
            //MainMenuScreen = new ScreenManager();


            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            redHatRegular = Content.Load<SpriteFont>("fonts/RedHatRegular");
            Consolas = Content.Load<SpriteFont>("fonts/Consolas");

            debugMessageBox = new MessageBox(200, 20, 500, 100, Consolas);
            
            uiEventHandler = new UIEventHandler(debugMessageBox);
            
            checkbox1 = new Checkbox(100,20, 100, 100, Consolas,"checkbox", uiEventHandler, startEnabled:true);

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //MainMenuScreen.LoadFromJson($"{Content.RootDirectory}/screenData/mainMenu.json", MainMenuScreen);
            //MainMenuScreen.LoadContent(MainMenuContent);
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState newState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //update buttons
            uiEventHandler.messageToSendForFlash = "HEY!!";

            //update checkbox
            checkbox1.Update(oldState, newState);

            base.Update(gameTime);
            //debugMessageBox.DisplayMessage((gameTime.TotalGameTime.TotalSeconds/gameTime.ElapsedGameTime.TotalSeconds).ToString());
            oldState = newState;
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            debugMessageBox.Draw(_spriteBatch);

            checkbox1.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
