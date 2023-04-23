using System;

namespace Fantasy.Engine.Physics
{
	/// <summary>
	/// Provides random number generation throughout the project. 
	/// </summary>
	public static class RandomNumberGenerator
	{
		private readonly static Random random = new();

		/// <summary>
		/// Gets the <c>Random</c> object used throughout the project.
		/// </summary>
		public static Random Random { get => random; }
	}
}
