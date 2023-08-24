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
	public class SpriteSheetRowAnimation : Animation
	{
		protected readonly int minMillisecondDuration;
		protected readonly int maxDurationMillisecondExtension;
		protected Rectangle currentSheetBox;
		protected Vector2 currentOffSetPosition;
		protected readonly SpriteSheetFrame[] frames;

		/// <summary>
		/// Gets or sets a value indicating if the <c>SpriteSheetRowAnimation</c> is paused.
		/// Initialized to false when all <c>SpriteSheetRowAnimation</c> objects are created.
		/// </summary>
		public override bool IsPaused
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
					this.CurrentFrameMaxDuration = new TimeSpan(0, 0, 0, 0, RandomNumberGenerator.Random.Next(this.MinMillisecondDuration));
				}

				this.isPaused = value;
			}
		}
		/// <summary>
		/// Gets the minimum duration a frame will persist for in this <c>SpriteSheetAnimation</c>.
		/// </summary>
		public int MinMillisecondDuration { get => this.minMillisecondDuration; }
		/// <summary>
		/// Gets the maximum duration a frame will randomly be extended for beyond the minimum duration in this <c>SpriteSheetAnimation</c>.
		/// </summary>
		public int MaxDurationMillisecondExtension { get => this.maxDurationMillisecondExtension; }
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
		/// <param name="sheetBox">The sheet box. The most top left frame in the <c>SpriteSheetAnimation</c>.</param>
		/// <param name="spriteSheet">The sprite sheet.</param>
		/// <param name="position">The position.</param>
		/// <param name="animationElement">The animation element.</param>
		public SpriteSheetRowAnimation(Rectangle sheetBox, Texture2D spriteSheet, PositionRef position, XmlElement animationElement) : base(sheetBox, spriteSheet, position)
		{
			foreach (XmlElement foo in animationElement)
			{
				if (foo.Name.Equals("activeFrameColumn"))
				{
					this.ActiveFrameColumn = byte.Parse(foo.InnerText);
				}
				else if (foo.Name.Equals("minMillisecondDuration"))
				{
					this.minMillisecondDuration = int.Parse(foo.InnerText);
				}
				else if (foo.Name.Equals("maxDurationMillisecondExtension"))
				{
					this.maxDurationMillisecondExtension = int.Parse(foo.InnerText);
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

			this.CurrentSheetBox = new Rectangle(this.SheetBox.X + (this.ActiveFrameColumn * this.SheetBox.Width), this.SheetBox.Y, this.SheetBox.Width, this.SheetBox.Height);
			this.CurrentOffSetPosition = this.Position.VectorPosition + this.Frames[this.ActiveFrameColumn].OffSet;
			this.CurrentFrameDuration = TimeSpan.Zero;
			this.CurrentFrameMaxDuration = new TimeSpan(0, 0, 0, 0, this.MinMillisecondDuration + RandomNumberGenerator.Random.Next(this.MaxDurationMillisecondExtension));
		}

		/// <summary>
		/// Draws the <c>SpriteSheetAnimation</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		/// <param name="color">The color to be drawn with.</param>
		public override void Draw(GameTime gameTime, Color? color = null)
		{
			if (!IsPaused)
			{
				this.CurrentFrameDuration += gameTime.ElapsedGameTime;
				if (this.CurrentFrameDuration >= this.CurrentFrameMaxDuration)
				{
					this.ActiveFrameColumn++;
					if (this.ActiveFrameColumn >= this.Frames.Length)
					{
						this.ActiveFrameColumn = 0;
					}
					this.currentSheetBox.X = this.SheetBox.X + (this.ActiveFrameColumn * this.SheetBox.Width);
					this.CurrentOffSetPosition = this.Position.VectorPosition + this.Frames[this.ActiveFrameColumn].OffSet;
					this.CurrentFrameDuration = TimeSpan.Zero;
					this.CurrentFrameMaxDuration = new TimeSpan(0, 0, 0, 0, this.MinMillisecondDuration + RandomNumberGenerator.Random.Next(this.MaxDurationMillisecondExtension));
				}
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