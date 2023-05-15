using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;

namespace Fantasy.Engine.Drawing
{
    /// <summary>
    /// A utility class for handling a spritebatch from the Monogame framework.
    /// </summary>
    public static class SpriteBatchHandler
    {
        private static SpriteBatch spriteBatch;
        private static GraphicsDevice graphicsDevice;

        /// <summary>
        /// Gets the spritebatch.
        /// </summary>
        public static SpriteBatch SpriteBatch { get => spriteBatch; private set => spriteBatch = value; }
        /// <summary>
        /// Gets the graphic device. 
        /// </summary>
        public static GraphicsDevice GraphicsDevice { get => graphicsDevice; private set => graphicsDevice = value; }

		/// <summary>
		/// Initializes the spritebatch object with a given GraphicsDevice.
		/// </summary>
		/// <param name="graphicDevice">The GraphicsDevice to use for initialization.</param>
		public static void Initialize(GraphicsDevice graphicDevice)
        {
			SpriteBatch = new SpriteBatch(graphicDevice);
			GraphicsDevice = graphicDevice;
        }

        /// <summary>
        /// Begins the spritebatch drawing.
        /// </summary>
        public static void Begin()
        {
            spriteBatch.Begin(
                SpriteSortMode.Deferred, //first things drawn on bottom, last things on top
				BlendState.AlphaBlend);
        }
        /// <summary>
        /// Begins the spritebatch drawing with the provided TransformMatrix.
        /// </summary>
        /// <param name="transformMatrix">The TransformMatrix to be applied.</param>
        public static void Begin(Matrix transformMatrix)
        {
            spriteBatch.Begin(
                SpriteSortMode.Deferred, //first things drawn on bottom, last things on top
                BlendState.AlphaBlend,
                SamplerState.PointWrap,
                null,
                null,
                null,
                transformMatrix);
        }

        /// <summary>
        /// Ends the spritebatch drawing.
        /// </summary>
        public static void End()
        {
            spriteBatch.End();
        }

		/// <summary>
		/// Draws a texture with a specified position and color.
		/// </summary>
		/// <param name="texture">The texture to draw.</param>
		/// <param name="position">The position of the texture, describes the top left position of the texture.</param>
		/// <param name="color">The color of the texture.</param>
		public static void Draw(Texture2D texture, Vector2 position, Color? color)
		{
			if (!color.HasValue)
			{
				color = Color.White;
			}

			SpriteBatch.Draw(texture, position, color.Value);
        }
		/// <summary>
		/// Draws a texture with a specified position, sheet box, and color.
		/// </summary>
		/// <param name="texture">The texture to draw.</param>
		/// <param name="position">The position of the texture, describes the top left position of the texture.</param>
		/// <param name="sheetBox">The sheet box of the texture.</param>
		/// <param name="color">The color of the texture.</param>
		public static void Draw(Texture2D texture, Vector2 position, Rectangle sheetBox, Color? color)
        {
            if (!color.HasValue)
            { 
                color = Color.White;
            }

            SpriteBatch.Draw(texture, position, sheetBox, color.Value);
        }
    }
}