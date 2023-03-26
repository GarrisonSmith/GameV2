﻿using Fantasy.Engine.Drawing.View.Tasks.enums;

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
        /// Carries out the camera task.
        /// </summary>
        void ProgressTask();
    }
}
