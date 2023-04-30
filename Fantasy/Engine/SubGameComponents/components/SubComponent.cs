using Fantasy.Engine.SubGameComponents.interfaces.components;

namespace Fantasy.Engine.SubGameComponents.components
{
    /// <summary>
    /// Represents a subcomponent that can updated inside a <c>ISubComponentCollection</c>
    /// </summary>
    public abstract class SubComponent : ISubComponent
	{
		/// <summary>
		/// Creates a new <c>SubComponent</c>.
		/// </summary>
		public SubComponent() { }

		/// <summary>
		/// Initializes the subcomponent.
		/// </summary>
		public abstract void Initialize();
	}
}
