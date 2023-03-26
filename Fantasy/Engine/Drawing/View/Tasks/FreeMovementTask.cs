using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;

namespace Fantasy.Engine.Drawing.View.Tasks
{
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
        /// <exception cref="System.NotImplementedException">TODO</exception>
        public void ProgressTask()
        {
            throw new System.NotImplementedException();
        }
    }
}
