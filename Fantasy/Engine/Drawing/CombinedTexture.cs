using Fantasy.Engine.Physics;
using Fantasy.Engine.Physics.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fantasy.Engine.Drawing
{
	public readonly struct CombinedTexture : IPositional<Position>
	{
		private readonly Texture2D texture;
		private readonly Position position;

		/// <summary>
		/// Gets the bottom right position of this <c>CombinedTexture</c>.
		/// </summary>
		public Vector2 BottomRight { get => new Vector2(this.Position.X + this.Texture.Width, this.Position.Y + this.Texture.Height); }
		/// <summary>
		/// Gets the combined texture.
		/// </summary>
		public Texture2D Texture { get => this.texture; }
		/// <summary>
		/// Gets the position.
		/// </summary>
		public Position Position { get => this.position; }

		/// <summary>
		/// Creates a new <c>CombinedTexture</c> with the provided parameters.
		/// </summary>
		/// <param name="texture">The texture.</param>
		/// <param name="position">The position.</param>
		public CombinedTexture(Texture2D texture, Position position)
		{
			this.texture = texture;
			this.position = position;
		}

		/// <summary>
		/// Draws the <c>CombinedTexture</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public void Draw(GameTime gameTime, Color? color = null)
		{
			SpriteBatchHandler.Draw(this.Texture, this.Position.VectorPosition, color);
		}
		/// <summary>
		/// Draws the <c>CombinedTexture</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="offset">The offset to draw with.</param>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public void Draw(IPosition offset, GameTime gameTime, Color? color = null)
		{
			SpriteBatchHandler.Draw(this.Texture, this.Position.VectorPosition - offset.VectorPosition, color);
		}
	}
}
