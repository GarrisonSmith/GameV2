using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Fantasy.Engine.Physics;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.Drawing.View.Tasks
{
    /// <summary>
    /// A camera task for following a provided IPosition object.
    /// </summary>
    public readonly struct FollowPositionRefTask : ICameraTask
    {
        private readonly PositionRef positionRef;
        private readonly Camera camera;

        /// <summary>
        /// Gets the position that this tasks is following.
        /// </summary>
        public PositionRef PositionRef { get => positionRef; }
        /// <summary>
        /// Gets the camera tasks type of this tasks.
        /// </summary>
        public CameraTaskTypes CameraTaskType { get => CameraTaskTypes.FollowIPosition; }
        /// <summary>
        /// Gets the camera.
        /// </summary>
        public readonly Camera Camera { get => this.camera; }

		/// <summary>
		/// Creates a new follow position task.
		/// </summary>
		/// <param name="positionRef">The PositionRef object for the task to follow.</param>
        /// <param name="camera">The camera.</param>
		public FollowPositionRefTask(PositionRef positionRef, Camera camera = null)
        {
			this.camera = camera ?? Camera.GetCamera();
			this.positionRef = positionRef;
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
        /// <param name="gameTime">The game time.</param>
		/// <returns>False as this task never auto completes.</returns>
		public bool ProgressTask(GameTime gameTime) {
            this.Camera.CenterCamera(positionRef.VectorPosition);
            return false;
        }
    }
}
