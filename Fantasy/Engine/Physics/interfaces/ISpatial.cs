namespace Fantasy.Engine.Physics.interfaces
{
	/// <summary>
	/// Represents an object that has a <c>AreaBox</c>.
	/// </summary>
	public interface ISpatial
	{
		/// <summary>
		/// Gets the <c>AreaBox</c> of the object.
		/// </summary>
		AreaBox AreaBox { get; }
	}
}