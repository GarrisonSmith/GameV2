namespace Fantasy.Engine.Physics.interfaces
{
	/// <summary>
	/// Represents a object with a position.
	/// </summary>
	public interface IPositional<T> where T : IPosition
	{
		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		public T Position { get; }
	}
}
