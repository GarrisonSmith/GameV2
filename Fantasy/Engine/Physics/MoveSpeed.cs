using Fantasy.Engine.Physics.enums;
using Microsoft.Xna.Framework;
using System;

namespace Fantasy.Engine.Physics
{
	/// <summary>
	/// Represents a <c>MoveSpeed</c>.
	/// </summary>
	public class MoveSpeed
	{
		private static TimeSpan lastTotalGameTime;

		/// <summary>
		/// Gets or sets the last total game time.
		/// </summary>
		public static TimeSpan LastTotalGameTime { get => lastTotalGameTime; set => lastTotalGameTime = value; }

		/// <summary>
		/// Initialized the <c>MoveSpeed</c> class.
		/// </summary>
		public static void Initialize()
		{
			LastTotalGameTime = TimeSpan.Zero;
		}

		private float distancePerTimeType;
		private readonly TimeTypes timeType;
		private TimeSpan lastUpdateTotalGameTime;

		/// <summary>
		/// Gets or sets the distance per time type.
		/// </summary>
		public float DistancePerTimeType { get => this.distancePerTimeType; set => this.distancePerTimeType = value; }
		/// <summary>
		/// Gets or sets the time type.
		/// </summary>
		public TimeTypes TimeType { get => this.timeType; }
		/// <summary>
		/// Gets or sets the last update total game time.
		/// </summary>
		public TimeSpan LastUpdateTotalGameTime { get => this.lastUpdateTotalGameTime; set => this.lastUpdateTotalGameTime = value; }

		/// <summary>
		/// Creates a new <c>MoveSpeed</c> with the provided parameters.
		/// </summary>
		/// <param name="distancePerTimeType">The distance per time type.</param>
		/// <param name="timeType">The time type.</param>
		public MoveSpeed(float distancePerTimeType, TimeTypes timeType)
		{
			this.distancePerTimeType = distancePerTimeType;
			this.timeType = timeType;
			this.lastUpdateTotalGameTime = TimeSpan.Zero;
		}

		/// <summary>
		/// Gets the movement amount.
		/// </summary>
		/// <param name="gameTime">The game time.</param>
		/// <returns>The movement amount.</returns>
		public float GetMovementAmount(GameTime gameTime)
		{
			if (this.LastUpdateTotalGameTime != LastTotalGameTime)
			{
				this.LastUpdateTotalGameTime = gameTime.TotalGameTime;
				return 0;
			}

			this.LastUpdateTotalGameTime = gameTime.TotalGameTime;
			switch (this.timeType)
			{
				case TimeTypes.Ticks:
					return (gameTime.ElapsedGameTime.Ticks * this.DistancePerTimeType);
				case TimeTypes.Milliseconds:
					return (float)(gameTime.ElapsedGameTime.TotalMilliseconds * this.DistancePerTimeType);
				case TimeTypes.Seconds:
					return (float)(gameTime.ElapsedGameTime.TotalSeconds * this.DistancePerTimeType);
				case TimeTypes.Minutes:
					return (float)(gameTime.ElapsedGameTime.TotalMinutes * this.DistancePerTimeType);
				case TimeTypes.Hours:
					return (float)(gameTime.ElapsedGameTime.TotalHours * this.DistancePerTimeType);
				case TimeTypes.Day:
					return (float)(gameTime.ElapsedGameTime.TotalDays * this.DistancePerTimeType);
				default:
					return 0;
			}
		}
	}
}
