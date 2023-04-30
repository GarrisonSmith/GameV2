using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Fantasy.Engine.Physics.interfaces;

namespace Fantasy.Engine.Drawing.View.Tasks
{
    /// <summary>
    /// A camera task for following a provided IPosition object.
    /// </summary>
    public readonly struct FollowIPositionTask : ICameraTask
    {
        private readonly IPosition locatable;

        /// <summary>
        /// Gets the locatable that this tasks is following.
        /// </summary>
        public IPosition Locatable { get => locatable; }
        /// <summary>
        /// Gets the camera tasks type of this tasks.
        /// </summary>
        public CameraTaskTypes CameraTaskTypes { get => CameraTaskTypes.FollowIPosition; }

        /// <summary>
        /// Creates a new FollowIPosition task.
        /// </summary>
        /// <param name="locatable">The IPosition object for the task to follow.</param>
        public FollowIPositionTask(IPosition locatable)
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
