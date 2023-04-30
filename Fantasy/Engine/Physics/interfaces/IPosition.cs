using Microsoft.Xna.Framework;

namespace Fantasy.Engine.Physics.interfaces
{
	/// <summary>
	/// Represents a position.
	/// </summary>
	public interface IPosition
    {
		/// <summary>
		/// Gets or sets the X value for the <c>IPosition</c>.
		/// </summary>
		public float X { get; }

		/// <summary>
		/// Gets or sets the Y value for the <c>IPosition</c>.
		/// </summary>
		public float Y { get; }

		/// <summary>
		/// Gets or sets the <c>IPosition</c> as a <c>Vector2</c>.
		/// </summary>
		public Vector2 VectorPosition { get; }

		/// <summary>
		/// Gets or sets the <c>IPosition</c> as a <c>Point</c>.
		/// </summary>
		public Point PointPosition { get; }

		/// <summary>
		/// Calculates the distance between this <c>IPosition</c> and the provided <c>IPosition</c>.
		/// </summary>
		/// <param name="locatable">The <c>IPosition</c>.</param>
		/// <returns>The distance between this <c>IPosition</c> and the provided <c>IPosition</c>.</returns>
		public float Distance(IPosition locatable);
	}
}
