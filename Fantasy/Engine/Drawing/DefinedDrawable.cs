using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.Physics.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fantasy.Engine.Drawing
{
	/// <summary>
	/// Represents a single item that can be drawn.
	/// </summary>
	public abstract class DefinedDrawable : IDefinedDrawable
	{
		protected readonly Rectangle sheetBox;
		protected readonly Texture2D spritesheet;
		protected readonly ILocation location;

		/// <summary>
		/// Gets the texture area of the spritesheet from which this <c>IDefinedDrawable</c>.
		/// </summary>
		public Rectangle SheetBox { get => this.sheetBox; }
		/// <summary>
		/// Gets the spritesheet for this <c>IDefinedDrawable</c>.
		/// </summary>
		public Texture2D Spritesheet { get => this.spritesheet; }
		/// <summary>
		/// Gets or sets the location of this <c>DefinedDrawable</c>.
		/// </summary>
		public ILocation Location { get => this.location; }

		/// <summary>
		/// Creates a new <c>DefinedDrawable</c> with the provided parameters.
		/// </summary>
		/// <param name="sheetBox">The sheet box.</param>
		/// <param name="spritesheet">The spritesheet.</param>
		/// <param name="location">The location.</param>
		public DefinedDrawable(Rectangle sheetBox, Texture2D spritesheet, ILocation location) 
		{
			this.sheetBox = sheetBox;
			this.spritesheet = spritesheet;
			this.location = location;
		}

		/// <summary>
		/// Draws the <c>DefinedDrawable</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public void Draw(GameTime gameTime, Color? color = null)
		{
			if (color.HasValue)
			{
				SpriteBatchHandler.Draw(this.Spritesheet, this.Location.VectorPosition, this.SheetBox, color.Value);
			}
			else 
			{
				SpriteBatchHandler.Draw(this.Spritesheet, this.Location.VectorPosition, this.SheetBox, Color.White);
			}
		}
	}
}
