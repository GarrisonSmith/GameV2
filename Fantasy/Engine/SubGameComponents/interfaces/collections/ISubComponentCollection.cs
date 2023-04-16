using Fantasy.Engine.SubGameComponents.interfaces.components;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.interfaces.collections
{
    /// <summary>
    /// Represents of collection of subcomponents that can be used inside a <c>GameComponent</c>. 
    /// </summary>
    public interface ISubComponentCollection
    {
		/// <summary>
		/// Gets the list of type <c>ISubComponent</c>.
		/// </summary>
		List<ISubComponent> Components { get; }

		/// <summary>
		/// Initializes the <c>ISubComponentCollection</c>.
		/// </summary>
		void Initialize();
    }
}
