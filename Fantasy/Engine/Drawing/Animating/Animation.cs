using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.Physics.interfaces;
using Fantasy.Engine.SubGameComponents.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Fantasy.Engine.Drawing.Animating
{
    /// <summary>
    /// An abstract class representing an animation for a <see cref="ISubDrawable"/> subject.
    /// </summary>
    public abstract class Animation : DefinedDrawable
	{
		protected bool isPaused;
		protected byte activeFrameIndex;
		protected TimeSpan currentFrameDuration;
		protected TimeSpan currentFrameMaxDuration;

        /// <summary>
        /// Describes if the animation is active and being updated.
        /// Initialized to true when all Animation object are created.
        /// </summary>
        public bool IsPaused { get => this.isPaused; set => this.isPaused = value; }
		/// <summary>
		/// The index of the currently active frame in the animation.
		/// </summary>
		public byte ActiveFrameIndex { get => activeFrameIndex; }
		/// <summary>
		/// The amount of time the current frame has been active.
		/// </summary>
		public TimeSpan CurrentFrameDuration { get => currentFrameDuration; }
		/// <summary>
		/// The total amount of time the current frame will be active for.
		/// </summary>
		public TimeSpan CurrentFrameMaxDuration { get => currentFrameMaxDuration; }

		/// <summary>
		/// Generic inherited constructor.
		/// </summary>
		public Animation()
		{
			isPaused = true;
			ActiveAnimations.Add(this);
		}

		public void Draw(GameTime gameTime, Color? color = null)
		{
			throw new NotImplementedException();
		}
	}
}