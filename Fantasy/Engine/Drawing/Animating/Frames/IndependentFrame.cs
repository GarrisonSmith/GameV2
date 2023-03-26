﻿using Fantasy.Engine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fantasy.Engine.Drawing.Animating.Frames
{
	/// <summary>
	/// Represents a single independent frame of an animation.
	/// Does not require information from a greater <see cref="Animation"/> object to be drawn.
	/// </summary>
	public readonly struct IndependentFrame : IFrame
	{
		private readonly int minDurationMili;
		private readonly int maxDurationExtension;
		private readonly Vector2 offSet;
		private readonly Rectangle sheetBox;
		private readonly Texture2D spritesheet;

		/// <summary>
		/// Gets the minimum duration of the frame in milliseconds.
		/// </summary>
		public int MinDurationMili
		{
			get => minDurationMili;
		}
		/// <summary>
		/// Get the maximum about the frame can be extended beyond its minimum duration in milliseconds.
		/// </summary>
		public int MaxDurationExtension
		{ 
			get => maxDurationExtension;
		}
		/// <summary>
		/// Gets the offset of the frame relative to its position in the animation.
		/// </summary>
		public Vector2 OffSet
		{
			get => offSet;
		}
		/// <summary>
		/// Gets the vertical offset of the frame relative to its position in the animation.
		/// </summary>
		public float VerticalOffset
		{
			get => offSet.Y;
		}
		/// <summary>
		/// Gets the horizontal offset of the frame relative to its position in the animation.
		/// </summary>
		public float HorizontalOffseet
		{
			get => offSet.X;
		}
		/// <summary>
		/// Gets the source rectangle of the frame in the spritesheet.
		/// </summary>
		public Rectangle SheetBox
		{
			get => sheetBox;
		}
		/// <summary>
		/// Gets the spritesheet texture that contains the frame.
		/// </summary>
		public Texture2D Spritesheet
		{
			get => spritesheet;
		}

		/// <summary>
		/// Creates a new frame with the specified minimum and maximum durations, source box, and spritesheet.
		/// </summary>
		/// <param name="minDurationMili">The minimum duration of the frame, in milliseconds.</param>
		/// <param name="maxDurationExtension">The chance for the frame to end after the frame has existed for the minimum duration in milliseconds.</param>
		/// <param name="sheetBox">The rectangular area on the spritesheet that contains the frame image.</param>
		/// <param name="spritesheet">The spritesheet that contains the frame image.</param>
		public IndependentFrame(int minDurationMili, byte maxDurationExtension, Rectangle sheetBox, Texture2D spritesheet)
		{
			this.minDurationMili = minDurationMili;
			this.maxDurationExtension = maxDurationExtension;
			offSet = new Vector2();
			this.sheetBox = sheetBox;
			this.spritesheet = spritesheet;
		}
		/// <summary>
		/// Creates a new frame with the specified minimum and maximum durations, offset, source box, and spritesheet.
		/// </summary>
		/// <param name="minDurationMili">The minimum duration of the frame, in milliseconds.</param>
		/// <param name="maxDurationExtension">The chance for the frame to end after the frame has existed for the minimum duration in milliseconds.</param>
		/// <param name="offSet">The offset of the frame, in pixels.</param>
		/// <param name="sheetBox">The rectangular area on the spritesheet that contains the frame image.</param>
		/// <param name="spritesheet">The spritesheet that contains the frame image.</param>
		public IndependentFrame(int minDurationMili, byte maxDurationExtension, Vector2 offSet, Rectangle sheetBox, Texture2D spritesheet)
		{
			this.minDurationMili = minDurationMili;
			this.maxDurationExtension = maxDurationExtension;
			this.offSet = offSet;
			this.sheetBox = sheetBox;
			this.spritesheet = spritesheet;
		}

		/// <summary>
		/// Draws the frame at the specified BoundingBox2 with the specified color.
		/// </summary>
		/// <param name="BoundingBox2">The BoundingBox2 at which to draw the frame.</param>
		/// <param name="color">The color to use when drawing the frame.</param>
		public void DrawFrame(BoundingBox2 BoundingBox2, Color color)
		{
			SpriteBatchHandler.Draw(Spritesheet, BoundingBox2.TopLeft + OffSet, SheetBox, color);
		}
	}
}