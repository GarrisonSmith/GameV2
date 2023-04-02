﻿using Microsoft.Xna.Framework;
using System;

namespace Fantasy.Engine.Physics
{
    /// <summary>
    /// Represents a two-dimensional BoundingBox2 defined by a top-left point and a center point.
    /// </summary>
    public class BoundingBox2
    {
        private Vector2 topLeft;
        private Vector2 center;

        /// <summary>
        /// The top-left point of the BoundingBox2.
        /// </summary>
        public Vector2 TopLeft
        {
            get => topLeft;
            set
            {
                center += value - topLeft;
                topLeft = value;
            }
        }
        /// <summary>
        /// The center point of the BoundingBox2.
        /// </summary>
        public Vector2 Center
        {
            get => center;
            set
            {
                topLeft += value - center;
                center = value;
            }
        }
        /// <summary>
        /// The bottom-right point of the BoundingBox2.
        /// </summary>
        public Vector2 BottomRight
        {
            get => new(TopLeft.X + Width, TopLeft.Y + Height);
        }
        /// <summary>
        /// Returns a rectangle that represents the BoundingBox2, with the top-left point being the
        /// <see cref="TopLeft"/> property and the width and height being the <see cref="Width"/> and <see cref="Height"/> properties respectively.
        /// </summary>
        public Rectangle Rectangle
        {
            get => new((int)topLeft.X, (int)topLeft.Y, (int)Width, (int)Height);
        }
        /// <summary>
        /// The width of the BoundingBox2, calculated as the distance between the center and top-left point multiplied by 2.
        /// </summary>
        public float Width
        {
            get => (Center.X - TopLeft.X) * 2;
            set
            {
				topLeft.X = center.X - (value / 2);
            }
        }
        /// <summary>
        /// The height of the BoundingBox2, calculated as the distance between the center and top-left point multiplied by 2.
        /// </summary>
        public float Height
        {
            get => (Center.Y - TopLeft.Y) * 2;
            set
            {
				topLeft.Y = center.Y - (value / 2);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBox2"/> class with the specified top-left and center values.
        /// </summary>
        /// <param name="topLeftX">The x-BoundingBox2 of the top-left point.</param>
        /// <param name="topLeftY">The y-BoundingBox2 of the top-left point.</param>
        /// <param name="centerX">The x-BoundingBox2 of the center point.</param>
        /// <param name="centerY">The y-BoundingBox2 of the center point.</param>
        /// <exception cref="ArgumentException">Thrown if the top-left point is not to the top and left of the center point.</exception>
        public BoundingBox2(float topLeftX, float topLeftY, float centerX, float centerY)
        {
            if (topLeftX > centerX || topLeftY > centerY)
            {
                throw new ArgumentException("BoundingBox2 TopLeft value must be to the top left of BoundingBox2 Center value.");
            }

            topLeft = new Vector2(topLeftX, topLeftY);
            center = new Vector2(centerX, centerY);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBox2"/> class with the specified top-left and center points.
        /// </summary>
        /// <param name="topLeft">The top-left point of the BoundingBox2.</param>
        /// <param name="center">The center point of the BoundingBox2.</param>
        /// <exception cref="ArgumentException">Thrown if the top-left point is not to the top and left of the center point.</exception>
        public BoundingBox2(Vector2 topLeft, Vector2 center)
        {
            if (topLeft.X > center.X || topLeft.Y > center.Y)
            {
                throw new ArgumentException("BoundingBox2 TopLeft value must be to the top left of BoundingBox2 Center value.");
            }

            this.topLeft = topLeft;
            this.center = center;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBox2"/> class with the specified top-left and dimensions.
        /// </summary>
        /// <param name="topLeft">The top-left point of the BoundingBox2.</param>
        /// <param name="width">The width of the BoundingBox2.</param>
        /// <param name="height">The height of the BoundingBox2.</param>
        public BoundingBox2(Vector2 topLeft, float width, float height)
        {
            this.topLeft = topLeft;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Determines if the provided Vector2 is inside this BoundingBox2.
        /// </summary>
        /// <param name="foo">The Vector2 to be investigated.</param>
        /// <returns>True if the provided Vector2 is inside this BoundingBox2, False if not.</returns>
        public bool Contains(Vector2 foo)
        {
            return foo.X >= TopLeft.X && foo.X <= BottomRight.X &&
                   foo.Y >= TopLeft.Y && foo.Y <= BottomRight.Y;
        }
        /// <summary>
        /// Determines if the provided BoundingBox2 intersects this BoundingBox2.
        /// </summary>
        /// <param name="foo">The BoundingBox2 to be investigated.</param>
        /// <returns>True if the provided BoundingBox2 is inside this BoundingBox2, False if not.</returns>
        public bool Intersects(BoundingBox2 foo)
        {
            return !(TopLeft.X > foo.BottomRight.X ||
                BottomRight.X < foo.TopLeft.X ||
                BottomRight.Y < foo.TopLeft.Y ||
                TopLeft.Y > foo.BottomRight.Y);
        }
        /// <summary>
        /// Determines if this BoundingBox2 completely contains the provided BoundingBox2.
        /// </summary>
        /// <param name="foo">The BoundingBox2 to be investigated.</param>
        /// <returns>True if the provided BoundingBox2 is completely contained by this BoundingBox2, False if not.</returns>
        public bool Contains(BoundingBox2 foo)
        {
            return foo.TopLeft.X >= TopLeft.X &&
                   foo.TopLeft.Y >= TopLeft.Y &&
                   foo.BottomRight.X <= BottomRight.X &&
                   foo.BottomRight.Y <= BottomRight.Y;
        }
        /// <summary>
        /// Calculates the distance between this BoundingBox2 and another BoundingBox2. 
        /// The distance is defined by the space between the two points on the BoundingBox2 boundaries that are closest two each other.
        /// </summary>
        /// <param name="foo">The BoundingBox2 to be investigated.</param>
        /// <returns>0 if the BoundingBox2s intersect, the distance between the BoundingBox2s otherwise.</returns>
        public float Distance(BoundingBox2 foo)
        {
            if (Intersects(foo))
            {
                return 0f;
            }
            
            float dx = Math.Min(TopLeft.X - foo.BottomRight.X, BottomRight.X - foo.TopLeft.X);
            float dy = Math.Min(TopLeft.Y - foo.BottomRight.Y, BottomRight.Y - foo.TopLeft.Y);
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
        /// <summary>
        /// Moves the BoundingBox2 up by the specified amount.
        /// </summary>
        /// <param name="amount">The amount to move the BoundingBox2 up by.</param>
        public void MoveUp(float amount)
        {
            topLeft.Y -= amount;
            center.Y -= amount;
        }
        /// <summary>
        /// Moves the BoundingBox2 down by the specified amount.
        /// </summary>
        /// <param name="amount">The amount to move the BoundingBox2 down by.</param>
        public void MoveDown(float amount)
        {
            topLeft.Y += amount;
            center.Y += amount;
        }
        /// <summary>
        /// Moves the BoundingBox2 right by the specified amount.
        /// </summary>
        /// <param name="amount">The amount to move the BoundingBox2 right by.</param>
        public void MoveRight(float amount)
        {
            topLeft.X += amount;
            center.X += amount;
        }
        /// <summary>
        /// Moves the BoundingBox2 left by the specified amount.
        /// </summary>
        /// <param name="amount">The amount to move the BoundingBox2 left by.</param>
        public void MoveLeft(float amount)
        {
            topLeft.X -= amount;
            center.X -= amount;
        }
        /// <summary>
        /// Returns a string representation of the BoundingBox2 object.
        /// </summary>
        public override string ToString()
        {
            return "TopLeft: " + topLeft + ", Center: " + center;
        }
        /// <summary>
        /// Compares if this BoundingBox2 instance is equal with another.
        /// </summary>
        /// <param name="obj">The object to compare equality with.</param>
        /// <returns>True if this BoundingBox2 object is equivalent to another, False if not.</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is BoundingBox2 foo)
            {
                return (topLeft == foo.topLeft && center == foo.center);
            }

            return false;
        }
        /// <summary>
        /// Gets the Hash Code for the BoundingBox2
        /// </summary>
        /// <returns>The hash Code for the BoundingBox2.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(topLeft, center);
        }

        public static bool operator == (BoundingBox2 foo, BoundingBox2 bar)
        {
			if (foo is null)
			{
				return (bar is null);
			}
			else if (bar is null)
			{
				return false;
			}

			return (foo.topLeft == bar.topLeft && foo.center == bar.center);
        }

        public static bool operator != (BoundingBox2 foo, BoundingBox2 bar)
        {
            if (foo is null)
            {
                return (bar is not null);
            }
            else if (bar is null)
            {
                return true;
            }

            return (foo.topLeft != bar.topLeft || foo.center != bar.center);
        }
    }
}