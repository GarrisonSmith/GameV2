using Fantasy.Engine.Drawing.Animating.Frames;
using Fantasy.Engine.Physics;
using Fantasy.Engine.Physics.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Xml;

namespace Fantasy.Engine.Drawing.Animating
{
	/// <summary>
	/// Represents a sprite sheet animation.
	/// </summary>
	public class SpritesheetAnimation : Animation
	{
		protected readonly int minDurationMili;
		protected readonly int maxDurationExtensionMili;
		protected Rectangle currentSheetBox;
		protected Vector2 currentOffSetPosition;
		protected readonly SpritesheetFrame[] frames;

		/// <summary>
		/// Describes if the <c>Animation</c> is paused.
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
		/// Gets the minimum duration a frame will persist for in this <c>SpritesheetAnimation</c>.
		/// </summary>
		public int MinDurationMili { get => this.minDurationMili; }
		/// <summary>
		/// Gets the maximum duration a frame will randomly be extended for beyond the minimum duration in this <c>SpritesheetAnimation</c>.
		/// </summary>
		public int MaxDurationExtensionMili { get => this.maxDurationExtensionMili; }
		/// <summary>
		/// Gets the current sheet box used by the <c>SpritesheetAnimation</c>.
		/// </summary>
		public Rectangle CurrentSheetBox { get => this.currentSheetBox; protected set => this.currentSheetBox = value; }
		/// <summary>
		/// Gets the currently off set position of this <c>SpritesheetAnimation</c>.
		/// </summary>
		public Vector2 CurrentOffSetPosition { get => this.currentOffSetPosition; protected set => this.currentOffSetPosition = value; }
		/// <summary>
		/// Gets the array of frames that define the <c>SpritesheetAnimation</c>.
		/// </summary>
		public SpritesheetFrame[] Frames { get => this.frames; }

		/// <summary>
		/// Creates a new <c>SpritesheetAnimation</c> with the provided parameters.
		/// </summary>
		/// <param name="sheetBox"></param>
		/// <param name="spritesheet"></param>
		/// <param name="location"></param>
		/// <param name="animationElement"></param>
		public SpritesheetAnimation(Rectangle sheetBox, Texture2D spritesheet, ILocation location, XmlElement animationElement) : base(sheetBox, spritesheet, location)
		{
			foreach (XmlElement foo in animationElement)
			{
				if (foo.Name.Equals("activeFrameIndex"))
				{
					this.ActiveFrameIndex = byte.Parse(foo.InnerText);
					continue;
				}
				if (foo.Name.Equals("minDurationMili"))
				{
					this.minDurationMili = int.Parse(foo.InnerText);
					continue;
				}
				if (foo.Name.Equals("maxDurationExtensionMili"))
				{
					this.maxDurationExtensionMili = int.Parse(foo.InnerText);
					continue;
				}
				if (foo.Name.Equals("frames"))
				{
					this.frames = new SpritesheetFrame[int.Parse(foo.GetAttribute("length"))];
					int index = 0;
					foreach (XmlElement bar in foo)
					{
						this.frames[index++] = new SpritesheetFrame(bar);
					}
					continue;
				}

				this.CurrentSheetBox = new Rectangle(this.SheetBox.X + (this.ActiveFrameIndex * this.SheetBox.Width), this.SheetBox.Y, this.SheetBox.Width, this.SheetBox.Height);
				this.CurrentOffSetPosition = this.Location.VectorPosition + this.Frames[this.ActiveFrameIndex].OffSet;
				this.CurrentFrameDuration = TimeSpan.Zero;
				this.CurrentFrameMaxDuration = new TimeSpan(0, 0, 0, 0, this.MinDurationMili + RandomNumberGenerator.Random.Next(this.MaxDurationExtensionMili));
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="gameTime"></param>
		/// <param name="color"></param>
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
				this.CurrentOffSetPosition = this.Location.VectorPosition + this.Frames[this.ActiveFrameIndex].OffSet;
				this.CurrentFrameDuration = TimeSpan.Zero;
				this.CurrentFrameMaxDuration = new TimeSpan(0, 0, 0, 0, this.MinDurationMili + RandomNumberGenerator.Random.Next(this.MaxDurationExtensionMili));
			}

			if (color.HasValue)
			{
				SpriteBatchHandler.Draw(this.Spritesheet, this.CurrentOffSetPosition, this.CurrentSheetBox, color.Value);
			}
			else
			{
				SpriteBatchHandler.Draw(this.Spritesheet, this.CurrentOffSetPosition, this.CurrentSheetBox, Color.White);
			}
		}
	}
}