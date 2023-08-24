using Fantasy.Engine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Fantasy.Engine.Drawing.Animating
{
	/// <summary>
	/// Represents an animation.
	/// </summary>
	public abstract class Animation : DefinedDrawable
	{
		protected bool isPaused;
		protected byte activeFrameColumn;
		protected TimeSpan currentFrameDuration;
		protected TimeSpan currentFrameMaxDuration;

		/// <summary>
		/// Gets or sets a value indicating if the <c>Animation</c> is paused.
		/// Initialized to false when all <c>Animation</c> objects are created.
		/// </summary>
		public abstract bool IsPaused { get; set; }
		/// <summary>
		/// Gets the column of the currently drawn frame in the spritesheet of the <c>Animation</c>.
		/// </summary>
		public byte ActiveFrameColumn { get => this.activeFrameColumn; protected set => this.activeFrameColumn = value; }
		/// <summary>
		/// Gets the amount of time the current frame has been drawn for.
		/// </summary>
		public TimeSpan CurrentFrameDuration { get => this.currentFrameDuration; protected set => this.currentFrameDuration = value; }
		/// <summary>
		/// Gets the total amount of time the current frame will be drawn for.
		/// </summary>
		public TimeSpan CurrentFrameMaxDuration { get => this.currentFrameMaxDuration; protected set => this.currentFrameMaxDuration = value; }

		/// <summary>
		/// Creates a new <c>Animation</c> with the provided parameters.
		/// </summary>
		/// <param name="sheetBox">The sheet box. The most top left frame in the <c>Animation</c>.</param>
		/// <param name="spriteSheet">The spriteSheet.</param>
		/// <param name="position">The location.</param>
		public Animation(Rectangle sheetBox, Texture2D spriteSheet, PositionRef position) : base(sheetBox, spriteSheet, position)
		{
			this.IsPaused = false;
		}

		/// <summary>
		/// Draws the <c>Animation</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public override abstract void Draw(GameTime gameTime, Color? color = null);
	}
}