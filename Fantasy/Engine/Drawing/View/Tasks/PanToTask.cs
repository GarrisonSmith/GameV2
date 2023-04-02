using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Microsoft.Xna.Framework;
using System;

namespace Fantasy.Engine.Drawing.View.Tasks
{
	/// <summary>
	/// Camera task that will pan the camera to a destination.
	/// </summary>
	public struct PanToTask : ICameraTask
	{
		private double theta;
		private readonly float speed;
		private Vector2 delta;
		private readonly Vector2 destination;

		/// <summary>
		/// The angle between the camera center and destination.
		/// </summary>
		public double Theta { get => theta; }
		/// <summary>
		/// The speed of the camera will pan with.
		/// </summary>
		public float Speed { get => speed; }
		/// <summary>
		/// The delta X and Y values the task will pan with. 
		/// </summary>
		public Vector2 Delta { get => delta; }
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
			theta = 0;
			delta = new Vector2();
		}

		/// <summary>
		/// Configures internal values for the task. 
		/// </summary>
		public void StartTask()
		{
			theta = Math.Atan(
				((Camera.CameraViewBoundingBox.Center.Y == 0 ? .001 : Camera.CameraViewBoundingBox.Center.Y) - destination.Y) /
				((Camera.CameraViewBoundingBox.Center.X == 0 ? .001 : Camera.CameraViewBoundingBox.Center.X) - destination.X));

			float deltaX = (float)Math.Abs(speed * Math.Cos((double)Theta));
			float deltaY = (float)Math.Abs(speed * Math.Sin((double)Theta));
			delta = new Vector2(
				destination.X > Camera.CameraViewBoundingBox.Center.X ? deltaX : -deltaX,
				destination.Y > Camera.CameraViewBoundingBox.Center.Y ? deltaY : -deltaY);
		}
		/// <summary>
		/// Moves the camera toward the destination by a single speed step.
		/// </summary>
		/// <returns>True if the camera has reach the destination, False if not.</returns>
		public bool ProgressTask()
		{
			if (Math.Abs(Camera.CameraViewBoundingBox.Center.X - Destination.X) <= Math.Abs(Delta.X) &&
				Math.Abs(Camera.CameraViewBoundingBox.Center.Y - Destination.Y) <= Math.Abs(Delta.Y))
			{
				Camera.CenterCamera(destination);
				return true;
			}

			Camera.CameraViewBoundingBox.Center += (Vector2)Delta;
			return false;
		}
	}
}
