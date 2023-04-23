using Microsoft.Xna.Framework;

namespace Fantasy.Engine.SubGameComponents.interfaces
{
    /// <summary>
    /// Represents a subcomponent that can updated inside a <c>ISubUpdateableCollection</c>
    /// </summary>
    public interface ISubUpdateable
    {
        /// <summary>
        /// Gets or sets a value indicating if this subcomponent is being updated or not. 
        /// Inactive subcomponent are defined as those with a <cref>UpdateOrder</cref> of 0.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the priority this subcomponent will be updated with in its <c>ISubUpdateableCollection</c> collection.
        /// Lower numbers are higher priority.
        /// 0 priority values are reserved for inactive subcomponent.
        /// </summary>
        byte UpdateOrder { get; set; }

        /// <summary>
        /// Updates the subcomponent using the specified <c>GameTime</c>.
        /// </summary>
        /// <param name="gameTime">The elapsed game time since the last update.</param>
        void Update(GameTime gameTime);
    }
}
