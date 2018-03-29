using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1{
    public class Game1 : Game{
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player pOne;
        Player pTwo;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize() {
            base.Initialize();
        }
        protected override void LoadContent(){
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pOne = new Player(0, 270, GraphicsDevice, PlayerIndex.One);
            pTwo = new Player(900, 270, GraphicsDevice, PlayerIndex.Two);
        }

        protected override void UnloadContent() {
        }

        protected override void Update(GameTime gameTime){
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            pOne.Update();
            pTwo.Update();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime){
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            pOne.Draw(spriteBatch);
            pTwo.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
