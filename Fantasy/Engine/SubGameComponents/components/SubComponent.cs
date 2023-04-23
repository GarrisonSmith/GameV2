using Fantasy.Engine.SubGameComponents.interfaces;

namespace Fantasy.Engine.SubGameComponents.components
{
    /// <summary>
    /// Represents a subcomponent that can updated inside a <c>ISubComponentCollection</c>
    /// </summary>
    public abstract class SubComponent : ISubComponent
	{
		/// <summary>
		/// Initializes the subcomponent.
		/// </summary>
		public abstract void Initialize();
	}
}
