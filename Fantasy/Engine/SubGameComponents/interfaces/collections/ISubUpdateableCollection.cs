using Fantasy.Engine.SubGameComponents.interfaces.components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.interfaces.collections
{
    /// <summary>
    /// Represents of collection of updateable subcomponents that can be used inside a <c>GameComponent</c>. 
    /// </summary>
    public interface ISubUpdateableCollection : ISubComponentCollection, ISubUpdateableComponent
	{
        /// <summary>
        /// Gets or sets a value indicating if this <c>ISubUpdateableCollection</c> is being updated or not. 
        /// </summary>
        new bool IsActive { get; set; }

		/// <summary>
		/// Gets the dictionary <c>ISubUpdateableComponent</c> lists in the <c>ISubUpdateableCollection</c>, identified by keys of type <c>byte</c>.
		/// Lower keys have higher update priority.
		/// 0 priority keys are reserved for inactive subcomponent.
		/// </summary>
		SortedDictionary<byte, List<ISubUpdateableComponent>> SubUpdateables { get; }

		/// <summary>
		/// Adds a ISubUpdateableComponent to the <c>ISubUpdateableCollection</c>;
		/// </summary>
		/// <param name="subUpdateableComponent">The ISubUpdateableComponent.</param>
		void AddSubUpdateable(ISubUpdateableComponent subUpdateableComponent);

		/// <summary>
		/// Updates the <c>ISubUpdateableCollection</c> using the specified <c>GameTime</c>.
		/// </summary>
		/// <param name="gameTime">The elapsed game time since the last update.</param>
		new void Update(GameTime gameTime);
    }
}
