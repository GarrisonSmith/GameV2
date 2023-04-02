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

        /// <summary>
        /// The speed the camera will move with.
        /// </summary>
        public float Speed { get => speed; }
        /// <summary>
        /// Gets the camera tasks type of this tasks.
        /// </summary>
        public CameraTaskTypes CameraTaskTypes { get => CameraTaskTypes.FreeMovement; }

        /// <summary>
        /// Creates a new free movement task.
        /// </summary>
        /// <param name="speed">The speed the task will move with.</param>
        public FreeMovementTask(float speed = 7) 
        {
            this.speed = speed;
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
		/// <exception cref="System.NotImplementedException">TODO</exception>
		public bool ProgressTask()
        {
            //TODO
            return false;
        }
    }
}
