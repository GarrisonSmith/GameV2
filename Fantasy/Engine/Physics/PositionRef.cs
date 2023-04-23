using Fantasy.Engine.Physics.interfaces;
using Microsoft.Xna.Framework;
using System;

namespace Fantasy.Engine.Physics
{
	/// <summary>
	/// Represents a reference to a <c>Position</c>.
	/// </summary>
	public readonly struct PositionRef : ILocation
	{
		private readonly Position position;

		/// <summary>
		/// Gets the <c>Position</c> this <c>PositionRef</c> references.
		/// </summary>
		private Position Position { get => position; }

		/// <summary>
		/// Gets the X value for the <c>PositionRef</c>.
		/// </summary>
		public float X { get => this.Position.VectorPosition.X; }
		/// <summary>
		/// Gets the Y value for the <c>PositionRef</c>.
		/// </summary>
		public float Y { get => this.Position.VectorPosition.Y; }
		/// <summary>
		/// Gets the <c>PositionRef</c> as a <c>Vector2</c>.
		/// </summary>
		public Vector2 VectorPosition { get => this.Position.VectorPosition; }
		/// <summary>
		/// Gets the <c>PositionRef</c> as a <c>Point</c>.
		/// </summary>
		public Point PointPosition { get => new Point((int)VectorPosition.X, (int)VectorPosition.Y); }

		/// <summary>
		/// Creates a new <c>PositionRef</c> with the provided <c>Position</c>.
		/// </summary>
		/// <param name="position">The <c>Position</c>.</param>
		public PositionRef(Position position)
		{
			this.position = position;
		}

		/// <summary>
		/// Calculates the distance between this <c>PositionRef</c> and the provided <c>ILocation</c>.
		/// </summary>
		/// <param name="locatable">The <c>ILocation</c>.</param>
		/// <returns>The distance between this <c>PositionRef</c> and the provided <c>ILocation</c>.</returns>
		public float Distance(ILocation locatable)
		{
			return (float)Math.Sqrt(Math.Pow(locatable.X - this.VectorPosition.X, 2) + (Math.Pow(locatable.Y - this.VectorPosition.Y, 2)));
		}

		/// <summary>
		/// Determines if this <c>PositionRef</c> is equal to the provide <c>object</c>.
		/// </summary>
		/// <param name="obj">The <c>object</c>.</param>
		/// <returns>True if this <c>PositionRef</c> is equal to the provide <c>object</c>, False if not.</returns>
		public override bool Equals(object obj)
		{
			if (obj != null && obj is ILocation foo)
			{
				return this == foo;
			}

			return false;
		}
		/// <summary>
		/// Generates a hashcode for this <c>PositionRef</c>.
		/// </summary>
		/// <returns>The hashcode for this <c>PositionRef</c>.</returns>
		public override int GetHashCode()
		{
			return (this.VectorPosition.GetHashCode() * 7) + 3;
		}
		/// <summary>
		/// Generates a string representation of the <c>PositionRef</c>.
		/// </summary>
		/// <returns>A string representing the <c>PositionRef</c>.</returns>
		public override string ToString()
		{
			return "Ref:" + this.VectorPosition.ToString();
		}

		/// <summary>
		/// Determines if the <c>PositionRef</c> is equal with the provided <c>ILocation</c>.
		/// </summary>
		/// <param name="foo">The first <c>PositionRef</c>.</param>
		/// <param name="bar">The second <c>ILocation</c>.</param>
		/// <returns>True if the <c>PositionRef</c> is equal with the provided <c>ILocation</c>, False if they are not equal.</returns>
		public static bool operator ==(PositionRef foo, ILocation bar)
		{
			return foo.VectorPosition == bar.VectorPosition;
		}
		/// <summary>
		/// Determines if the <c>PositionRef</c> is not equal with the provided <c>ILocation</c>.
		/// </summary>
		/// <param name="foo">The first <c>PositionRef</c>.</param>
		/// <param name="bar">The second <c>ILocation</c>.</param>
		/// <returns>True if the <c>PositionRef</c> is not equal with the provided <c>ILocation</c>, False if they are equal.</returns>
		public static bool operator !=(PositionRef foo, ILocation bar)
		{
			return foo.VectorPosition != bar.VectorPosition;
		}
	}
}
