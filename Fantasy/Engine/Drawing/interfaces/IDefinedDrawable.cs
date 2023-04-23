using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Fantasy.Engine.Physics.interfaces;

namespace Fantasy.Engine.Drawing.interfaces
{
	/// <summary>
	/// Represents a single item that can be drawn.
	/// </summary>
	public interface IDefinedDrawable
	{
		/// <summary>
		/// Gets the texture area of the spritesheet from which this <c>IDefinedDrawable</c>.
		/// </summary>
		Rectangle SheetBox { get; }

		/// <summary>
		/// Gets the spritesheet for this <c>IDefinedDrawable</c>.
		/// </summary>
		Texture2D Spritesheet { get; }

		/// <summary>
		/// Gets or sets the location of this <c>IDefinedDrawable</c>.
		/// </summary>
		ILocation Location { get; }

		/// <summary>
		/// Draws the <c>IDefinedDrawable</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		void Draw(GameTime gameTime, Color? color = null);
	}
}
