using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Microsoft.Xna.Framework;
using System;

namespace Fantasy.Engine.Drawing.View.Tasks
{
    public class PanToTask : ICameraTask
    {
        private Vector2 destination;

        /// <summary>
        /// The destination of this pan to task.
        /// </summary>
        public Vector2 Destination { get; }
        /// <summary>
        /// Gets the camera tasks type of this tasks.
        /// </summary>
        public CameraTaskTypes CameraTaskTypes { get => CameraTaskTypes.PanTo; }

        /// <summary>
        /// Creates a new pan to task.
        /// </summary>
        /// <param name="destination">The destination for this pan to task.</param>
        public PanToTask(Vector2 destination)
        { 
            this.destination = destination;
        }


        public void ProgressTask()
        {
            throw new NotImplementedException();
        }
    }
}
