using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Fantasy.Engine.Physics.interfaces;

namespace Fantasy.Engine.Drawing.View.Tasks
{
    /// <summary>
    /// Defines a camera task for following a provided ILocatable object.
    /// </summary>
    public class FollowILocatableTask : ICameraTask
    {
        private readonly ILocatable locatable;

        /// <summary>
        /// Gets the locatable that this tasks is following.
        /// </summary>
        public ILocatable Locatable { get => locatable; }
        /// <summary>
        /// Gets the camera tasks type of this tasks.
        /// </summary>
        public CameraTaskTypes CameraTaskTypes { get => CameraTaskTypes.FollowILocatable; }

        /// <summary>
        /// Creates a new FollowILocatable task.
        /// </summary>
        /// <param name="locatable">The ILocatable object for the task to follow.</param>
        public FollowILocatableTask(ILocatable locatable)
        { 
            this.locatable = locatable;
        }

        /// <summary>
        /// Centers the camera on the center of the current locatable. 
        /// </summary>
        public void ProgressTask() {
            Camera.CenterCamera(locatable.BoundingBox2.Center);    
        }
    }
}
