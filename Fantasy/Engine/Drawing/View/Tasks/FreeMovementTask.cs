using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Fantasy.Engine.Physics;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.Drawing.View.Tasks
{
    /// <summary>
    /// Camera task that allows for free movement of the camera based off user input.
    /// </summary>
    public struct FreeMovementTask : ICameraTask
    {
        private readonly MoveSpeed moveSpeed;
        private readonly Camera camera;

        /// <summary>
        /// The move speed the camera will move with.
        /// </summary>
        public MoveSpeed MoveSpeed { get => moveSpeed; }
        /// <summary>
        /// Gets the camera tasks type of this tasks.
        /// </summary>
        public CameraTaskTypes CameraTaskType { get => CameraTaskTypes.FreeMovement; }
        /// <summary>
        /// Gets the camera.
        /// </summary>
        public Camera Camera { get => camera; }

        /// <summary>
        /// Creates a new free movement task.
        /// </summary>
        /// <param name="moveSpeed">The move speed the task will move with.</param>
        /// <param name="camera">The camera.</param>
        public FreeMovementTask(MoveSpeed moveSpeed, Camera camera = null) 
        {
			this.camera = camera ?? Camera.GetCamera();
			this.moveSpeed = moveSpeed;
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
        /// <param name="gameTime">The game time.</param>
		/// <returns>False as this task never auto completes.</returns>
		public bool ProgressTask(GameTime gameTime)
        {
            //TODO
            return false;
        }
    }
}
