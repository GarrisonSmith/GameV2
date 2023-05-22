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
		private readonly Camera camera;

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
		/// Gets the camera.
		/// </summary>
		public Camera Camera { get => camera; }

		/// <summary>
		/// Creates a new pan to task.
		/// </summary>
		/// <param name="speed">The speed the task will pan with.</param>
		/// <param name="destination">The destination for this pan to task.</param>
		/// <param name="camera">The camera.</param>
		public PanToTask(float speed, Vector2 destination, Camera camera)
		{
			this.speed = speed;
			this.destination = destination;
			theta = 0;
			delta = new Vector2();
			this.camera = camera;
		}

		/// <summary>
		/// Configures internal values for the task. 
		/// </summary>
		public void StartTask()
		{
			theta = Math.Atan(
				((this.Camera.AreaBox.Center.Y == 0 ? .001 : this.Camera.AreaBox.Center.Y) - destination.Y) /
				((this.Camera.AreaBox.Center.X == 0 ? .001 : this.Camera.AreaBox.Center.X) - destination.X));

			float deltaX = (float)Math.Abs(speed * Math.Cos((double)Theta));
			float deltaY = (float)Math.Abs(speed * Math.Sin((double)Theta));
			delta = new Vector2(
				destination.X > this.Camera.AreaBox.Center.X ? deltaX : -deltaX,
				destination.Y > this.Camera.AreaBox.Center.Y ? deltaY : -deltaY);
		}
		/// <summary>
		/// Moves the camera toward the destination by a single speed step.
		/// </summary>
		/// <returns>True if the camera has reach the destination, False if not.</returns>
		public bool ProgressTask()
		{
			if (Math.Abs(this.Camera.AreaBox.Center.X - Destination.X) <= Math.Abs(Delta.X) &&
				Math.Abs(this.Camera.AreaBox.Center.Y - Destination.Y) <= Math.Abs(Delta.Y))
			{
				this.Camera.CenterCamera(destination);
				return true;
			}

			this.Camera.CameraViewPosition.VectorPosition += Delta;
			return false;
		}
	}
}
