using Fantasy.Engine.Physics.interfaces;
using Microsoft.Xna.Framework;
using System;

namespace Fantasy.Engine.Physics
{
	/// <summary>
	/// Represents a two-dimensional <c>AreaBox</c> defined by a <c>Position</c>, <c>Width</c>, and <c>Height</c>.
	/// </summary>
	public class AreaBox : IPositional<PositionRef>
	{
		protected PositionRef position;
		protected float width;
		protected float height;

		/// <summary>
		/// Gets or sets the width of the <c>AreaBox</c>.
		/// </summary>
		public float Width { get => width; set => width = value; }
		/// <summary>
		/// Gets or sets the height of the <c>AreaBox</c>.
		/// </summary>
		public float Height { get => height; set => height = value; }
		/// <summary>
		/// Gets or sets the top-left point of the <c>AreaBox</c>.
		/// </summary>
		public Vector2 TopLeft { get => Position.VectorPosition; }
		/// <summary>
		/// Gets the center point of the <c>AreaBox</c>.
		/// </summary>
		public Vector2 Center { get => new(Position.X + (Width / 2), Position.Y + (Height / 2)); }
		/// <summary>
		/// Gets the bottom-right point of the <c>AreaBox</c>.
		/// </summary>
		public Vector2 BottomRight { get => new(Position.X + Width, Position.Y + Height); }
		/// <summary>
		/// Gets a rectangle that represents the <c>AreaBox</c>, with the top-left point being the
		/// <c>TopLeft</c> property and the width and height being the <c>Width</c> and <c>Height</c> properties respectively.
		/// </summary>
		public Rectangle Rectangle { get => new((int)position.X, (int)position.Y, (int)Width, (int)Height); }
		/// <summary>
		/// Gets or sets the position of the <c>AreaBox</c>. The <c>Position</c> contains the top-left details of the <c>AreaBox</c>.
		/// </summary>
		public PositionRef Position { get => this.position; set => this.position = value; }

		/// <summary>
		/// Initializes a new instance of the <c>AreaBox</c> class with the specified top-left position and dimensions.
		/// </summary>
		/// <param name="topLeft">The top-left <c>PositionRef</c>.</param>
		/// <param name="width">The width of the <c>AreaBox</c>.</param>
		/// <param name="height">The height of the <c>AreaBox</c>.</param>
		public AreaBox(PositionRef topLeft, float width, float height)
        {
            this.Position = topLeft;
            this.Width = width;
            this.Height = height;
        }

		/// <summary>
		/// Determines if the provided <c>IPosition</c> is inside this <c>AreaBox</c>.
		/// </summary>
		/// <param name="foo">The <c>IPosition</c>.</param>
		/// <returns>True if the provided <c>IPosition</c> is inside this <c>AreaBox</c>, False if not.</returns>
		public bool Contains(IPosition foo)
		{
			return foo.X >= this.TopLeft.X && foo.X <= this.BottomRight.X &&
				   foo.Y >= this.TopLeft.Y && foo.Y <= this.BottomRight.Y;
		}
		/// <summary>
		/// Determines if this <c>AreaBox</c> completely contains the provided <c>ISpatial</c>.
		/// </summary>
		/// <param name="foo">The <c>ISpatial</c>.</param>
		/// <returns>True if the provided <c>ISpatial</c> is completely contained by this <c>AreaBox</c>, False if not.</returns>
		public bool Contains(ISpatial foo)
		{
			return foo.AreaBox.TopLeft.X >= this.TopLeft.X &&
				   foo.AreaBox.TopLeft.Y >= this.TopLeft.Y &&
				   foo.AreaBox.BottomRight.X <= this.BottomRight.X &&
				   foo.AreaBox.BottomRight.Y <= this.BottomRight.Y;
		}
		/// <summary>
		/// Determines if this <c>AreaBox</c> completely contains the provided <c>Vector2</c>.
		/// </summary>
		/// <param name="foo">The <c>ISpatial</c>.</param>
		/// <returns>True if the provided <c>Vector2</c> is completely contained by this <c>AreaBox</c>, False if not.</returns>
		public bool Contains(Vector2 foo)
		{
			return foo.X >= this.TopLeft.X &&
				   foo.Y >= this.TopLeft.Y &&
				   foo.X <= this.BottomRight.X &&
				   foo.Y <= this.BottomRight.Y;
		}

		/// <summary>
		/// Determines if the provided <c>ISpatial</c> intersects this <c>AreaBox</c>.
		/// </summary>
		/// <param name="foo">The <c>ISpatial</c>.</param>
		/// <returns>True if the provided <c>ISpatial</c> is inside this <c>AreaBox</c>, False if not.</returns>
		public bool Intersects(ISpatial foo)
        {
            return !(this.TopLeft.X > foo.AreaBox.BottomRight.X ||
				this.BottomRight.X < foo.AreaBox.TopLeft.X ||
				this.BottomRight.Y < foo.AreaBox.TopLeft.Y ||
				this.TopLeft.Y > foo.AreaBox.BottomRight.Y);
        }

		/// <summary>
		/// Calculates the distance between this <c>AreaBox</c> and another <c>IPosition</c>. 
		/// </summary>
		/// <param name="foo">The <c>IPosition</c>.</param>
		/// <returns>0 if the <c>IPosition</c> is contained by the <c>AreaBox</c>, otherwise the distance between the <c>AreaBox</c> and <c>IPosition</c>.</returns>
		public float Distance(IPosition foo)
        {
            if (Contains(foo))
            {
                return 0f;
            }
            
            float dx = Math.Min(this.TopLeft.X - foo.X, this.BottomRight.X - foo.X);
            float dy = Math.Min(this.TopLeft.Y - foo.Y, this.BottomRight.Y - foo.Y);
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
		/// <summary>
		/// Calculates the distance between this <c>AreaBox</c> and another <c>ISpatial</c>. 
		/// </summary>
		/// <param name="foo">The <c>ISpatial</c>.</param>
		/// <returns>0 if the <c>ISpatial</c> is intersected by the <c>AreaBox</c>, otherwise the distance between the <c>AreaBox</c> and <c>ISpatial</c>.</returns>
		public float Distance(ISpatial foo)
		{
			if (Intersects(foo))
			{
				return 0f; 
			}

			float dx = Math.Min(this.TopLeft.X - foo.AreaBox.BottomRight.X, this.BottomRight.X - foo.AreaBox.TopLeft.X);
			float dy = Math.Min(this.TopLeft.Y - foo.AreaBox.BottomRight.Y, this.BottomRight.Y - foo.AreaBox.TopLeft.Y);
			return (float)Math.Sqrt(dx * dx + dy * dy);
		}

		/// <summary>
		/// Determines if this <c>AreaBox</c> is equal to the provide <c>object</c>.
		/// </summary>
		/// <param name="obj">The <c>object</c>.</param>
		/// <returns>True if this <c>AreaBox</c> is equal to the provide <c>object</c>, False if not.</returns>
		public override bool Equals(object obj)
        {
            if (obj != null && obj is AreaBox foo)
            {
                return this == foo;
            }

            return false;
        }
		/// <summary>
		/// Generates a hashcode for this <c>AreaBox</c>.
		/// </summary>
		/// <returns>The hashcode for this <c>AreaBox</c>.</returns>
		public override int GetHashCode()
        {
            return HashCode.Combine(this.Position.GetHashCode, this.Width.GetHashCode, this.Height.GetHashCode);
        }
		/// <summary>
		/// Generates a string representation of the <c>AreaBox</c>.
		/// </summary>
		/// <returns>A string representing the <c>AreaBox</c>.</returns>
		public override string ToString()
		{
			return "{X:" + this.Position.X + ", Y:" + this.Position.Y + ", Width: " + this.Width + ", Height: " + this.Height + "}";
		}

		/// <summary>
		/// Determines if two <c>AreaBox</c> are equal.
		/// </summary>
		/// <param name="foo">The first <c>AreaBox</c>.</param>
		/// <param name="bar">The second <c>AreaBox</c>.</param>
		/// <returns>True if the two <c>AreaBox</c> are equal, False if they are not equal.</returns>
		public static bool operator == (AreaBox foo, AreaBox bar)
		{
			if (foo is null && bar is null)
			{
				return true;
			}
			else if (foo is null)
			{
				return false;
			}
			else if (bar is null)
			{
				return false;
			}

			return (foo.Position == bar.Position && foo.Width == bar.Width && foo.Height == bar.Height);
		}
		/// <summary>
		/// Determines if two <c>AreaBox</c> are not equal.
		/// </summary>
		/// <param name="foo">The first <c>AreaBox</c>.</param>
		/// <param name="bar">The second <c>AreaBox</c>.</param>
		/// <returns>True if the two <c>AreaBox</c> are not equal, False if they are equal.</returns>
		public static bool operator != (AreaBox foo, AreaBox bar)
        {
			if (foo is null && bar is null)
			{
				return false;
			}
			else if (foo is null)
			{
				return true;
			}
			else if (bar is null)
			{
				return true;
			}

			return (foo.Position != bar.Position || foo.Width != bar.Width || foo.Height != bar.Height);
        }
    }
}