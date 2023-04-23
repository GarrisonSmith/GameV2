using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Fantasy.Engine.SubGameComponents.interfaces.collections
{
    /// <summary>
    /// Represents of collection of updateable subcomponents that can be used inside a <c>GameComponent</c>. 
    /// </summary>
    public interface ISubUpdateableCollection
    {
        /// <summary>
        /// Gets or sets a value indicating if this <c>ISubUpdateableCollection</c> is being updated or not. 
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets the dictionary <c>ISubUpdateable</c> lists in the <c>ISubUpdateableCollection</c>, identified by keys of type <c>byte</c>.
        /// Lower keys have higher update priority.
        /// 0 priority keys are reserved for inactive subcomponent.
        /// </summary>
        Dictionary<byte, List<ISubUpdateable>> SubUpdateables { get; }

        /// <summary>
        /// Updates the <c>ISubUpdateableCollection</c> using the specified <c>GameTime</c>.
        /// </summary>
        /// <param name="gameTime">The elapsed game time since the last update.</param>
        void Update(GameTime gameTime);
    }
}
