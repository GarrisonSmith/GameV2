using Fantasy.Engine.SubGameComponents.interfaces.components;

namespace Fantasy.Engine.SubGameComponents.interfaces.collections
{
	/// <summary>
	/// Represents of collection of drawable and updateable subcomponents that can be used inside a <c>GameComponent</c>. 
	/// </summary>
	public interface ISubDrawableUpdateableCollection : ISubDrawableCollection, ISubUpdateableCollection, ISubDrawableUpdateableComponent
	{
	}
}
