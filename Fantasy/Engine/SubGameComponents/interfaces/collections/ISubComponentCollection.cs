using System.Collections.Generic;
using Fantasy.Engine.SubGameComponents.interfaces.components;

namespace Fantasy.Engine.SubGameComponents.interfaces.collections
{
    /// <summary>
    /// Represents of collection of subcomponents that can be used inside a <c>GameComponent</c>. 
    /// </summary>
    public interface ISubComponentCollection : ISubComponent
    {
		/// <summary>
		/// Gets the list of type <c>ISubComponent</c>.
		/// </summary>
		List<ISubComponent> SubComponents { get; }

		/// <summary>
		/// Adds a ISubComponent to the <c>SubComponentCollection</c>;
		/// </summary>
		/// <param name="subComponents">The ISubComponent.</param>
	    void AddSubComponent(ISubComponent subComponents);

		/// <summary>
		/// Initializes the <c>ISubComponentCollection</c>.
		/// </summary>
		new void Initialize();
    }
}
