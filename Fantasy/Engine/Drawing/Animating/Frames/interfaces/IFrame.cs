using Microsoft.Xna.Framework;

namespace Fantasy.Engine.Drawing.Animating.Frames.interfaces
{
	/// <summary>
	/// Represents a frame in a <c>Animation</c>.
	/// </summary>
	public interface IFrame
    {
		/// <summary>
		/// Gets the offset of the frame relative to its position in the <c>Animation</c>.
		/// </summary>
		public Vector2 OffSet { get; }
		/// <summary>
		/// Gets the vertical offset of the frame relative to its position in the <c>Animation</c>.
		/// </summary>
		public float VerticalOffSet { get; }
		/// <summary>
		/// Gets the horizontal offset of the frame relative to its position in the <c>Animation</c>.
		/// </summary>
		public float HorizontalOffSet { get; }
    }
}