using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Fantasy.Engine.ContentManagement;
using Fantasy.Engine.Mapping;
using Fantasy.Engine.Drawing;

//System.Diagnostics.Debug.WriteLine(); <--GREATEST DEBUG
namespace Fantasy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        public GraphicsDeviceManager _Graphics
        { 
            get => _graphics;
        }


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
			_graphics.PreferredBackBufferHeight = 1000;
			_graphics.PreferredBackBufferWidth = 1500;
			_graphics.ApplyChanges();

            SpriteBatchHandler.Initialize(_graphics.GraphicsDevice);
            //Camera.Initialize(this);
            TextureManager.Initialize(this);
            XmlManager.Initialize(this);

			ActiveGameMap activeGameMap = ActiveGameMap.GetActiveGameMap(this, "animated_test_map");
			this.Components.Add(activeGameMap);

			base.Initialize(); //calls LoadContent()
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            TextureManager.LoadTextures();
			XmlManager.LoadXMLDocuments();
		}

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                //Camera.CameraViewBoundingBox.MoveUp(7f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                //Camera.CameraViewBoundingBox.MoveLeft(7f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                //Camera.CameraViewBoundingBox.MoveRight(7f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                //Camera.CameraViewBoundingBox.MoveDown(7f);
            }
			if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
			{
				//Camera.ZoomIn(3);
			}
			if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
			{
				//Camera.ZoomOut(3);
			}
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                //Camera.Zoom = 64;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
				//Camera.TaskStack.Push(new ZoomOutPanZoomIn(1, 7f, new Vector2(900, 200)));
				//Camera.TaskStack.Push(new PanToTask(7f, new Vector2(0, 0)));
				//Camera.TaskStack.Push(new PanToTask(7f, new Vector2(500, 500)));
			}
            if (Keyboard.GetState().IsKeyDown(Keys.J))
            {
                ActiveGameMap.GetActiveGameMap().CreateCombinedTextures();
            }

			base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			//SpriteBatchHandler.Begin(Camera.GetTransformationMatrix());

			SpriteBatchHandler.Begin();

			base.Draw(gameTime);

            SpriteBatchHandler.End();
        }
    }
}