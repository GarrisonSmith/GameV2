using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;

namespace Fantasy.Engine.Drawing.View.Tasks
{
    /// <summary>
    /// Camera task that allows for free movement of the camera based off user input.
    /// </summary>
    public struct FreeMovementTask : ICameraTask
    {
        private readonly float speed;
        private readonly Camera camera;

        /// <summary>
        /// The speed the camera will move with.
        /// </summary>
        public float Speed { get => speed; }
        /// <summary>
        /// Gets the camera tasks type of this tasks.
        /// </summary>
        public CameraTaskTypes CameraTaskTypes { get => CameraTaskTypes.FreeMovement; }
        /// <summary>
        /// Gets the camera.
        /// </summary>
        public Camera Camera { get => camera; }

        /// <summary>
        /// Creates a new free movement task.
        /// </summary>
        /// <param name="speed">The speed the task will move with.</param>
        /// <param name="camera">The camera.</param>
        public FreeMovementTask(float speed, Camera camera) 
        {
            this.speed = speed;
            this.camera = camera;
        }

		/// <summary>
		/// Configures internal values for the task. 
		/// </summary>
		public void StartTask()
		{
			//nothing needed.
		}
		/// <summary>
		/// Moves the camera freely based off user input.
		/// </summary>
		/// <returns>False as this task never auto completes.</returns>
		public bool ProgressTask()
        {
            //TODO
            return false;
        }
    }
}
