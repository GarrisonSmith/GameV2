using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.Drawing.interfaces
{
	/// <summary>
	/// Represents a single item that be drawn.
	/// </summary>
	public interface ISingleDrawable
	{
		/// <summary>
		/// Gets the top left point of this item's starting texture on its spritesheet.
		/// </summary>
		Point TextureSourceTopLeft { get; }

		/// <summary>
		/// Gets the area of the spritesheet from which the item's texture is taken.
		/// </summary>
		Rectangle SheetBox { get; }

		/// <summary>
		/// Gets the spritesheet that the item's texture is taken from.
		/// </summary>
		Texture2D Spritesheet { get; }

		/// <summary>
		/// Draws the item using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		void Draw(GameTime gameTime);
	}
}
