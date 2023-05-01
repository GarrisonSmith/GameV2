using Fantasy.Engine.Drawing.Animating.Frames.interfaces;
using Microsoft.Xna.Framework;
using System.Xml;

namespace Fantasy.Engine.Drawing.Animating.Frames
{
	/// <summary>
	/// Represents a frame in a <c>SpriteSheetAnimation</c>.
	/// </summary>
	public readonly struct SpriteSheetFrame : IFrame
	{
		private readonly Vector2 offSet;

		/// <summary>
		/// Gets the offset of the frame relative to its position in the <c>Animation</c>.
		/// </summary>
		public Vector2 OffSet { get => this.offSet; }
		/// <summary>
		/// Gets the vertical offset of the frame relative to its position in the <c>Animation</c>.
		/// </summary>
		public float VerticalOffSet { get => this.offSet.Y; }
		/// <summary>
		/// Gets the horizontal offset of the frame relative to its position in the <c>Animation</c>.
		/// </summary>
		public float HorizontalOffSet { get => this.offSet.X; }

		/// <summary>
		/// Creates a new <c>SpriteSheetFrame</c> with the specified minimum and maximum durations, source box, and spriteSheet.
		/// </summary>
		public SpriteSheetFrame()
		{
			this.offSet = new Vector2();
		}
		/// <summary>
		/// Creates a new <c>SpriteSheetFrame</c> with the specified minimum and maximum durations, offset, source box, and spriteSheet.
		/// </summary>
		/// <param name="frameElement">XmlElement describe this <c>SpriteSheetFrame</c>.</param>
		public SpriteSheetFrame(XmlElement frameElement)
		{
			this.offSet = new Vector2(float.Parse(frameElement.GetAttribute("verticalOffset")), float.Parse(frameElement.GetAttribute("horizontalOffset")));
		}
	}
}