using Microsoft.Xna.Framework;

namespace Fantasy.Engine.Physics.interfaces
{
	/// <summary>
	/// Represents an object that is a location.
	/// </summary>
	public interface ILocation
    {
		/// <summary>
		/// Gets or sets the X value for the <c>ILocation</c>.
		/// </summary>
		public float X { get; }

		/// <summary>
		/// Gets or sets the Y value for the <c>ILocation</c>.
		/// </summary>
		public float Y { get; }

		/// <summary>
		/// Gets or sets the <c>ILocation</c> as a <c>Vector2</c>.
		/// </summary>
		public Vector2 VectorPosition { get; }

		/// <summary>
		/// Gets or sets the <c>ILocation</c> as a <c>Point</c>.
		/// </summary>
		public Point PointPosition { get; }

		/// <summary>
		/// Calculates the distance between this <c>ILocation</c> and the provided <c>ILocation</c>.
		/// </summary>
		/// <param name="locatable">The <c>ILocation</c>.</param>
		/// <returns>The distance between this <c>ILocation</c> and the provided <c>ILocation</c>.</returns>
		public float Distance(ILocation locatable);
	}
}
