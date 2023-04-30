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
		protected byte activeFrameIndex;
		protected TimeSpan currentFrameDuration;
		protected TimeSpan currentFrameMaxDuration;

		/// <summary>
		/// Describes if the <c>Animation</c> is paused.
		/// Initialized to false when all <c>Animation</c> objects are created.
		/// </summary>
		public bool IsPaused { get => this.isPaused; set => this.isPaused = value; }
		/// <summary>
		/// The index of the currently drawn frame in the <c>Animation</c>.
		/// </summary>
		public byte ActiveFrameIndex { get => this.activeFrameIndex; protected set => this.activeFrameIndex = value; }
		/// <summary>
		/// The amount of time the current frame has been drawn for.
		/// </summary>
		public TimeSpan CurrentFrameDuration { get => this.currentFrameDuration; protected set => this.currentFrameDuration = value; }
		/// <summary>
		/// The total amount of time the current frame will be drawn for.
		/// </summary>
		public TimeSpan CurrentFrameMaxDuration { get => this.currentFrameMaxDuration; protected set => this.currentFrameMaxDuration = value; }

		/// <summary>
		/// Creates a new <c>Animation</c> with the provided parameters.
		/// </summary>
		/// <param name="sheetBox">The sheet box.</param>
		/// <param name="spritesheet">The spritesheet.</param>
		/// <param name="position">The location.</param>
		public Animation(Rectangle sheetBox, Texture2D spritesheet, PositionRef position) : base(sheetBox, spritesheet, position)
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