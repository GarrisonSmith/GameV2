using Fantasy.Engine.Drawing.Animating.Frames;
using Fantasy.Engine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Xml;

namespace Fantasy.Engine.Drawing.Animating
{
	/// <summary>
	/// Represents a sprite sheet animation.
	/// </summary>
	public class SpriteSheetAnimation : Animation
	{
		protected readonly int minDurationMili;
		protected readonly int maxDurationExtensionMili;
		protected Rectangle currentSheetBox;
		protected Vector2 currentOffSetPosition;
		protected readonly SpriteSheetFrame[] frames;

		/// <summary>
		/// Gets or sets a value indicating if the <c>Animation</c> is paused.
		/// Initialized to false when all <c>Animation</c> objects are created.
		/// </summary>
		public new bool IsPaused
		{
			get => this.isPaused;
			set
			{
				if (value == this.isPaused)
				{
					return;
				}

				if (!value)
				{
					this.CurrentFrameDuration = TimeSpan.Zero;
					this.CurrentFrameMaxDuration = new TimeSpan(0, 0, 0, 0, RandomNumberGenerator.Random.Next(this.MinDurationMili));
				}

				this.isPaused = value;
			}
		}
		/// <summary>
		/// Gets the minimum duration a frame will persist for in this <c>SpriteSheetAnimation</c>.
		/// </summary>
		public int MinDurationMili { get => this.minDurationMili; }
		/// <summary>
		/// Gets the maximum duration a frame will randomly be extended for beyond the minimum duration in this <c>SpriteSheetAnimation</c>.
		/// </summary>
		public int MaxDurationExtensionMili { get => this.maxDurationExtensionMili; }
		/// <summary>
		/// Gets the current sheet box used by the <c>SpriteSheetAnimation</c>.
		/// </summary>
		public Rectangle CurrentSheetBox { get => this.currentSheetBox; protected set => this.currentSheetBox = value; }
		/// <summary>
		/// Gets the currently off set position of this <c>SpriteSheetAnimation</c>.
		/// </summary>
		public Vector2 CurrentOffSetPosition { get => this.currentOffSetPosition; protected set => this.currentOffSetPosition = value; }
		/// <summary>
		/// Gets the array of frames that define the <c>SpriteSheetAnimation</c>.
		/// </summary>
		public SpriteSheetFrame[] Frames { get => this.frames; }

		/// <summary>
		/// Creates a new <c>SpriteSheetAnimation</c> with the provided parameters.
		/// </summary>
		/// <param name="sheetBox"></param>
		/// <param name="spriteSheet"></param>
		/// <param name="position"></param>
		/// <param name="animationElement"></param>
		public SpriteSheetAnimation(Rectangle sheetBox, Texture2D spriteSheet, PositionRef position, XmlElement animationElement) : base(sheetBox, spriteSheet, position)
		{
			foreach (XmlElement foo in animationElement)
			{
				if (foo.Name.Equals("activeFrameIndex"))
				{
					this.ActiveFrameIndex = byte.Parse(foo.InnerText);
				}
				else if (foo.Name.Equals("minDurationMili"))
				{
					this.minDurationMili = int.Parse(foo.InnerText);
				}
				else if (foo.Name.Equals("maxDurationExtensionMili"))
				{
					this.maxDurationExtensionMili = int.Parse(foo.InnerText);
				}
				else if (foo.Name.Equals("frames"))
				{
					this.frames = new SpriteSheetFrame[int.Parse(foo.GetAttribute("length"))];
					int index = 0;
					foreach (XmlElement bar in foo)
					{
						this.frames[index++] = new SpriteSheetFrame(bar);
					}
				}
			}

			this.CurrentSheetBox = new Rectangle(this.SheetBox.X + (this.ActiveFrameIndex * this.SheetBox.Width), this.SheetBox.Y, this.SheetBox.Width, this.SheetBox.Height);
			this.CurrentOffSetPosition = this.Position.VectorPosition + this.Frames[this.ActiveFrameIndex].OffSet;
			this.CurrentFrameDuration = TimeSpan.Zero;
			this.CurrentFrameMaxDuration = new TimeSpan(0, 0, 0, 0, this.MinDurationMili + RandomNumberGenerator.Random.Next(this.MaxDurationExtensionMili));
		}

		/// <summary>
		/// Draws the <c>SpriteSheetAnimation</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public override void Draw(GameTime gameTime, Color? color = null)
		{
			if (IsPaused)
			{
				return;
			}

			this.CurrentFrameDuration += gameTime.ElapsedGameTime;
			if (this.CurrentFrameDuration >= this.CurrentFrameMaxDuration)
			{
				this.ActiveFrameIndex++;
				if (this.ActiveFrameIndex >= this.Frames.Length)
				{
					this.ActiveFrameIndex = 0;
				}
				this.currentSheetBox.X = this.SheetBox.X + (this.ActiveFrameIndex * this.SheetBox.Width);
				this.CurrentOffSetPosition = this.Position.VectorPosition + this.Frames[this.ActiveFrameIndex].OffSet;
				this.CurrentFrameDuration = TimeSpan.Zero;
				this.CurrentFrameMaxDuration = new TimeSpan(0, 0, 0, 0, this.MinDurationMili + RandomNumberGenerator.Random.Next(this.MaxDurationExtensionMili));
			}

			if (color.HasValue)
			{
				SpriteBatchHandler.Draw(this.SpriteSheet, this.CurrentOffSetPosition, this.CurrentSheetBox, color.Value);
			}
			else
			{
				SpriteBatchHandler.Draw(this.SpriteSheet, this.CurrentOffSetPosition, this.CurrentSheetBox, Color.White);
			}
		}
	}
}