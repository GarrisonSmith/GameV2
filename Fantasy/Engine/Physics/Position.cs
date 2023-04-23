using Fantasy.Engine.Physics.interfaces;
using Microsoft.Xna.Framework;
using System;

namespace Fantasy.Engine.Physics
{
	/// <summary>
	/// Represents a single <c>Position</c>.
	/// </summary>
	public class Position : ILocation
	{
		private Vector2 vectorPosition;

		/// <summary>
		/// Gets or sets the X value for the <c>Position</c>.
		/// </summary>
		public float X { get => this.vectorPosition.X; set => this.vectorPosition.X = value; }
		/// <summary>
		/// Gets or sets the Y value for the <c>Position</c>.
		/// </summary>
		public float Y { get => this.vectorPosition.Y; set => this.vectorPosition.Y = value; }
		/// <summary>
		/// Gets or sets the <c>Position</c> as a <c>Vector2</c>.
		/// </summary>
		public Vector2 VectorPosition { get => this.vectorPosition; set => this.vectorPosition = value; }
		/// <summary>
		/// Gets or sets the <c>Position</c> as a <c>Point</c>.
		/// </summary>
		public Point PointPosition
		{
			get => new Point((int)vectorPosition.X, (int)vectorPosition.Y);
			set 
			{
				this.vectorPosition.X = value.X;
				this.vectorPosition.Y = value.Y;
			}
		}

		/// <summary>
		/// Creates a new <c>Position</c> from the provided <c>Vector2</c>.
		/// </summary>
		/// <param name="vectorPosition">The <c>Position</c>.</param>
		public Position(Vector2 vectorPosition) 
		{ 
			this.VectorPosition = vectorPosition;
		}
		/// <summary>
		/// Creates a new <c>Position</c> from the provided <c>Point</c>.
		/// </summary>
		/// <param name="pointPosition">The <c>Position</c>.</param>
		public Position(Point pointPosition)
		{ 
			this.PointPosition = pointPosition;
		}

		/// <summary>
		/// Moves the <c>Position</c> vertically.
		/// Positive values will move the <c>Position</c> down, negative will move the <c>Position</c> up.
		/// </summary>
		/// <param name="value">The vertical movement value.</param>
		public void MoveVertically(float value)
		{
			this.vectorPosition.Y += value;
		}
		/// <summary>
		/// Moves the <c>Position</c> vertically.
		/// Positive values will move the <c>Position</c> down, negative will move the <c>Position</c> up.
		/// </summary>
		/// <param name="value">The vertical movement value.</param>
		public void MoveVertically(int value)
		{
			this.vectorPosition.Y += value;
		}
		/// <summary>
		/// Moves the <c>Position</c> horizontally.
		/// Positive values will move the <c>Position</c> right, negative will move the <c>Position</c> left.
		/// </summary>
		/// <param name="value">The horizontally movement value.</param>
		public void MoveHorizontally(float value)
		{
			this.vectorPosition.X += value;
		}
		/// <summary>
		/// Moves the <c>Position</c> horizontally.
		/// Positive values will move the <c>Position</c> right, negative will move the <c>Position</c> left.
		/// </summary>
		/// <param name="value">The horizontally movement value.</param>
		public void MoveHorizontally(int value)
		{
			this.vectorPosition.X += value;
		}

		/// <summary>
		/// Calculates the distance between this <c>Position</c> and the provided <c>ILocation</c>.
		/// </summary>
		/// <param name="locatable">The <c>ILocation</c>.</param>
		/// <returns>The distance between this <c>Position</c> and the provided <c>ILocation</c>.</returns>
		public float Distance(ILocation locatable)
		{
			return (float)Math.Sqrt(Math.Pow(locatable.X - this.VectorPosition.X, 2) + (Math.Pow(locatable.Y - this.VectorPosition.Y, 2)));
		}

		/// <summary>
		/// Gets a <c>PositionRef</c> for this <c>Position</c>.
		/// </summary>
		/// <returns>The <c>PositionRef</c>.</returns>
		public PositionRef GetPositionRef()
		{
			return new PositionRef(this);
		}

		/// <summary>
		/// Determines if this <c>Position</c> is equal to the provide <c>object</c>.
		/// </summary>
		/// <param name="obj">The <c>object</c>.</param>
		/// <returns>True if this <c>Position</c> is equal to the provide <c>object</c>, False if not.</returns>
		public override bool Equals(object obj)
		{
			if (obj != null && obj is ILocation foo)
			{
				return this == foo;
			}

			return false;
		}
		/// <summary>
		/// Generates a hashcode for this <c>Position</c>.
		/// </summary>
		/// <returns>The hashcode for this <c>Position</c>.</returns>
		public override int GetHashCode()
		{
			return this.VectorPosition.GetHashCode() * 7;
		}
		/// <summary>
		/// Generates a string representation of the <c>Position</c>.
		/// </summary>
		/// <returns>A string representing the <c>Position</c>.</returns>
		public override string ToString()
		{
			return this.VectorPosition.ToString();
		}

		/// <summary>
		/// Determines if the <c>Position</c> is equal with the provided <c>ILocation</c>.
		/// </summary>
		/// <param name="foo">The first <c>Positions</c>.</param>
		/// <param name="bar">The second <c>ILocation</c>.</param>
		/// <returns>True if the <c>Position</c> is equal with the provided <c>ILocation</c>, False if they are not equal.</returns>
		public static bool operator == (Position foo, ILocation bar)
		{
			return foo.VectorPosition == bar.VectorPosition;
		}
		/// <summary>
		/// Determines if the <c>Position</c> is not equal with the provided <c>ILocation</c>.
		/// </summary>
		/// <param name="foo">The first <c>Positions</c>.</param>
		/// <param name="bar">The second <c>ILocation</c>.</param>
		/// <returns>True if the <c>Position</c> is not equal with the provided <c>ILocation</c>, False if they are equal.</returns>
		public static bool operator != (Position foo, ILocation bar)
		{
			return foo.VectorPosition != bar.VectorPosition;
		}
	}
}
