using Fantasy.Engine.ContentManagement;
using Fantasy.Engine.Drawing;
using Fantasy.Engine.Drawing.View;
using Fantasy.Engine.Drawing.View.Tasks;
using Fantasy.Engine.Mapping;
using Fantasy.Engine.Physics;
using Fantasy.Engine.Physics.enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//System.Diagnostics.Debug.WriteLine(); <--GREATEST DEBUG
namespace Fantasy
{
	public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        public GraphicsDeviceManager Graphics
        { 
            get => _graphics;
            private set => _graphics = value;
        }

        public Game1()
        {
            this.Graphics = new GraphicsDeviceManager(this);
			this.Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
			Graphics.PreferredBackBufferHeight = 1000;
			Graphics.PreferredBackBufferWidth = 1500;
			Graphics.ApplyChanges();

            SpriteBatchHandler.Initialize(Graphics.GraphicsDevice);
            Camera camera = Camera.GetCamera(this, new Engine.Physics.Position(new Vector2()));
            TextureManager.Initialize(this);
            XmlManager.Initialize(this);
            MoveSpeed.Initialize();

			ActiveGameMap activeGameMap = ActiveGameMap.GetActiveGameMap(this, "animated_test_map");
			this.Components.Add(activeGameMap);
            this.Components.Add(camera);

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
                Camera.GetCamera().Position.Y -= 7f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
				Camera.GetCamera().Position.X -= 7f;
			}
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
				Camera.GetCamera().Position.X += 7f;
			}
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
				Camera.GetCamera().Position.Y += 7f;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
			{
				Camera.GetCamera().ZoomIn(3);
			}
			if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
			{
				Camera.GetCamera().ZoomOut(3);
			}
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
				Camera.GetCamera().Zoom = 64;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
				Camera.GetCamera().TaskStack.Push(new ZoomOutPanZoomIn(1, new MoveSpeed(.0005f, TimeTypes.Ticks), new Vector2(900, 200)));
				Camera.GetCamera().TaskStack.Push(new PanToTask(new MoveSpeed(.128f, TimeTypes.Milliseconds), new Vector2(0, 0)));
				Camera.GetCamera().TaskStack.Push(new PanToTask(new MoveSpeed(64f, TimeTypes.Seconds), new Vector2(500, 500)));
			}
            if (Keyboard.GetState().IsKeyDown(Keys.J))
            {
                ActiveGameMap.GetActiveGameMap().CreateCombinedTextures();
            }
			if (Keyboard.GetState().IsKeyDown(Keys.K))
			{
				Camera.GetCamera().CenterCamera(new Vector2(900, 200));
			}

			base.Update(gameTime);
            MoveSpeed.LastTotalGameTime = gameTime.TotalGameTime;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			//SpriteBatchHandler.Begin(Camera.GetTransformationMatrix());

			SpriteBatchHandler.Begin(Camera.GetCamera().GetTransformationMatrix());

			base.Draw(gameTime);

            SpriteBatchHandler.End();
        }
    }
}