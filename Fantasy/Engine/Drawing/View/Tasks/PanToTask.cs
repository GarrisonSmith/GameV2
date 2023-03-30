using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Microsoft.Xna.Framework;
using System;

namespace Fantasy.Engine.Drawing.View.Tasks
{
    /// <summary>
    /// 
    /// </summary>
    public class PanToTask : ICameraTask
    {
        private double theta;
		private float speed;
        private Vector2 destination;

        /// <summary>
        /// The angle between the camera center and destination.
        /// </summary>
        public double Theta { get => theta; }
        /// <summary>
        /// The speed of the camera will pan with.
        /// </summary>
        public float Speed { get => speed; }
        /// <summary>
        /// The destination of this pan to task.
        /// </summary>
        public Vector2 Destination { get => destination; }
        /// <summary>
        /// Gets the camera tasks type of this tasks.
        /// </summary>
        public CameraTaskTypes CameraTaskTypes { get => CameraTaskTypes.PanTo; }

        /// <summary>
        /// Creates a new pan to task.
        /// </summary>
        /// <param name="speed">The speed the task will pan with.</param>
        /// <param name="destination">The destination for this pan to task.</param>
        public PanToTask(float speed, Vector2 destination)
        { 
            this.speed = speed;
            this.destination = destination;

            theta = Math.Atan((Camera.CameraViewBoundingBox.Center.Y - destination.Y) / (Camera.CameraViewBoundingBox.Center.X - destination.X));
        }

        /// <summary>
        /// Moves the camera toward the destination by a single speed step.
        /// </summary>
        /// <returns>True if the camera has reach the destination, False if not.</returns>
        public bool ProgressTask()
        {
            double deltaX = (speed * Math.Cos(Theta));
			if (Camera.CameraViewBoundingBox.Center.X - Destination.X <= deltaX)
            {
                Camera.CenterCamera(destination);
                return true;
            }

            Camera.CameraViewBoundingBox.Center += new Vector2(
                (float)(Camera.CameraViewBoundingBox.Center.X + deltaX),
                (float)(Camera.CameraViewBoundingBox.Center.Y + (speed * Math.Sin(Theta)))
                );
            return false;
		}
    }
}
