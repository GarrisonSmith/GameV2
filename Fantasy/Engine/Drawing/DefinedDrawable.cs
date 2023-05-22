﻿using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.Physics;
using Fantasy.Engine.Physics.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fantasy.Engine.Drawing
{
	/// <summary>
	/// Represents defined drawing parameters of an object.
	/// </summary>
	public class DefinedDrawable : IDefinedDrawable
	{
		protected readonly Rectangle sheetBox;
		protected readonly Texture2D spriteSheet;
		protected readonly PositionRef position;

		/// <summary>
		/// Gets the bottom right position of this <c>CombinedTexture</c>.
		/// </summary>
		public Vector2 BottomRight { get => new Vector2(this.CameraViewPosition.X + this.SheetBox.Width, this.CameraViewPosition.Y + this.SheetBox.Height); }
		/// <summary>
		/// Gets the texture area of the spriteSheet from which this <c>IDefinedDrawable</c>.
		/// </summary>
		public Rectangle SheetBox { get => this.sheetBox; }
		/// <summary>
		/// Gets the position of this <c>DefinedDrawable</c>.
		/// </summary>
		public PositionRef CameraViewPosition { get => this.position; }
		/// <summary>
		/// Gets the spriteSheet for this <c>IDefinedDrawable</c>.
		/// </summary>
		public Texture2D SpriteSheet { get => this.spriteSheet; }

		/// <summary>
		/// Creates a new <c>DefinedDrawable</c> with the provided parameters.
		/// </summary>
		/// <param name="sheetBox">The sheet box.</param>
		/// <param name="spriteSheet">The spriteSheet.</param>
		/// <param name="position">The position.</param>
		public DefinedDrawable(Rectangle sheetBox, Texture2D spriteSheet, PositionRef position)
		{
			this.sheetBox = sheetBox;
			this.spriteSheet = spriteSheet;
			this.position = position;
		}

		/// <summary>
		/// Draws the <c>DefinedDrawable</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public virtual void Draw(GameTime gameTime, Color? color = null)
		{
			SpriteBatchHandler.Draw(this.SpriteSheet, this.CameraViewPosition.VectorPosition, this.SheetBox, color);
		}
		/// <summary>
		/// Draws the <c>DefinedDrawable</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="offset">The offset to draw with.</param>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public void Draw(IPosition offset, GameTime gameTime, Color? color = null)
		{
			SpriteBatchHandler.Draw(this.SpriteSheet, this.CameraViewPosition.VectorPosition - offset.VectorPosition, this.SheetBox, color);
		}
	}
}
