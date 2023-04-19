namespace Fantasy.Engine.Physics.interfaces
{
	/// <summary>
	/// Represents an object that has a <c>Position</c>.
	/// </summary>
	public interface ILocatable
    {
		/// <summary>
		/// Gets the <c>Position</c> of the object.
		/// </summary>
		Position Position { get; }
    }
}
