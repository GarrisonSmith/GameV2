using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Fantasy.Engine.Physics.interfaces;

namespace Fantasy.Engine.Drawing.View.Tasks
{
    /// <summary>
    /// A camera task for following a provided ILocation object.
    /// </summary>
    public readonly struct FollowILocationTask : ICameraTask
    {
        private readonly ILocation locatable;

        /// <summary>
        /// Gets the locatable that this tasks is following.
        /// </summary>
        public ILocation Locatable { get => locatable; }
        /// <summary>
        /// Gets the camera tasks type of this tasks.
        /// </summary>
        public CameraTaskTypes CameraTaskTypes { get => CameraTaskTypes.FollowILocation; }

        /// <summary>
        /// Creates a new FollowILocation task.
        /// </summary>
        /// <param name="locatable">The ILocation object for the task to follow.</param>
        public FollowILocationTask(ILocation locatable)
        { 
            this.locatable = locatable;
        }

        /// <summary>
        /// Configures internal values for the task. 
        /// </summary>
        public void StartTask() 
        {
            //nothing needed.
        }
		/// <summary>
		/// Centers the camera on the center of the current locatable. 
		/// </summary>
		/// <returns>False as this task never auto completes.</returns>
		public bool ProgressTask() {
            Camera.CenterCamera(locatable.BoundingBox2.Center);
            return false;
        }
    }
}
