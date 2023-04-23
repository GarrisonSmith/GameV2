using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.collections
{
    /// <summary>
    /// Represents of collection of subcomponents that can be used inside a <c>GameComponent</c>. 
    /// </summary>
    public abstract class SubComponentCollection : ISubComponentCollection, ISubComponent
	{
		protected List<ISubComponent> components;

		/// <summary>
		/// Gets the list of type <c>ISubComponent</c>.
		/// </summary>
		public List<ISubComponent> Components { get => this.components; }

		/// <summary>
		/// Initializes the <c>ISubComponentCollection</c>.
		/// </summary>
		public abstract void Initialize();
	}
}
