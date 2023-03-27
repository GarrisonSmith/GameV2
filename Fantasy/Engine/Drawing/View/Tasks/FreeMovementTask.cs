using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;

namespace Fantasy.Engine.Drawing.View.Tasks
{
    /// <summary>
    /// Camera task that allows for free movement of the camera based off user input.
    /// </summary>
    public class FreeMovementTask : ICameraTask
    {
        /// <summary>
        /// Gets the camera tasks type of this tasks.
        /// </summary>
        public CameraTaskTypes CameraTaskTypes { get => CameraTaskTypes.FreeMovement; }

        /// <summary>
        /// Creates a new free movement task.
        /// </summary>
        public FreeMovementTask() { }

		/// <summary>
		/// Moves the camera freely based off user input.
		/// </summary>
		/// <returns>False as this task never auto completes.</returns>
		/// <exception cref="System.NotImplementedException">TODO</exception>
		public bool ProgressTask()
        {
            throw new System.NotImplementedException();
        }
    }
}
