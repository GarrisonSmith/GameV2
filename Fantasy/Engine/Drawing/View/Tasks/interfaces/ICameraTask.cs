using Fantasy.Engine.Drawing.View.Tasks.enums;

namespace Fantasy.Engine.Drawing.View.Tasks.interfaces
{
    /// <summary>
    /// Defines a type of Camera Task.
    /// </summary>
    public interface ICameraTask
    {
        /// <summary>
        /// Gets the Camera Task Type of this Task.
        /// </summary>
        CameraTaskTypes CameraTaskTypes { get; }
        /// <summary>
        /// Gets the Camera.
        /// </summary>
        Camera Camera { get; }

        /// <summary>
        /// Configures internal values for the task. 
        /// </summary>
        void StartTask();

        /// <summary>
        /// Carries out the camera task.
        /// </summary>
        /// <returns>True if the task is completed, False if not.</returns>
        bool ProgressTask();
    }
}
