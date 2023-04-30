using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Fantasy.Engine.Physics;
using Fantasy.Engine.Physics.interfaces;

namespace Fantasy.Engine.Drawing.interfaces
{
	/// <summary>
	/// Represents defined drawing parameters of something.
	/// </summary>
	public interface IDefinedDrawable : IPositional<PositionRef>
	{
		/// <summary>
		/// Gets the bottom right position of this <c>CombinedTexture</c>.
		/// </summary>
		Vector2 BottomRight { get => new Vector2(this.Position.X + this.SheetBox.Width, this.Position.Y + this.SheetBox.Height); }

		/// <summary>
		/// Gets the texture area of the spritesheet from which this <c>IDefinedDrawable</c>.
		/// </summary>
		Rectangle SheetBox { get; }

		/// <summary>
		/// Gets the spritesheet for this <c>IDefinedDrawable</c>.
		/// </summary>
		Texture2D Spritesheet { get; }

		/// <summary>
		/// Draws the <c>IDefinedDrawable</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		void Draw(GameTime gameTime, Color? color = null);
		/// <summary>
		/// Draws the <c>DefinedDrawable</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="offset">The offset to draw with.</param>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		void Draw(IPosition offset, GameTime gameTime, Color? color = null);

	}
}
