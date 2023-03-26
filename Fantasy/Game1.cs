using Fantasy.Engine;
using Fantasy.Engine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Xml;
using Fantasy.Engine.ContentManagement;
using Fantasy.Engine.Mapping;
using Fantasy.Engine.Drawing;
using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.Drawing.View;

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
            _graphics.ApplyChanges();

            SpriteBatchHandler.Initialize(_graphics.GraphicsDevice);
            Camera.Initialize(this);
            TextureManager.LoadSpritesheets(this);

            base.Initialize(); //calls LoadContent()
        }

        protected override void LoadContent()
        {
			// TODO: use this.Content to load your game content here
			ActiveGameMap.LoadMap(this, "animated_test_map");
			ActiveGameMap.GetGameComponents(Components);
		}

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            Animation.UpdateActiveAnimations(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Up)) {
                Camera.CameraViewBoundingBox.MoveUp(10f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Camera.CameraViewBoundingBox.MoveLeft(10f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Camera.CameraViewBoundingBox.MoveRight(10f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Camera.CameraViewBoundingBox.MoveDown(10f);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            SpriteBatchHandler.Begin(Camera.GetTransformationMatrix());

            base.Draw(gameTime);

            SpriteBatchHandler.End();
        }
    }
}