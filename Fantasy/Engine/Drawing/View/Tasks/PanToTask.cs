using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Fantasy.Engine.Physics;
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
		private readonly MoveSpeed moveSpeed;
		private readonly Vector2 destination;
		private readonly Camera camera;

		/// <summary>
		/// The angle between the camera center and destination.
		/// </summary>
		public double Theta { get => theta; }
		/// <summary>
		/// The speed of the camera will pan with.
		/// </summary>
		public MoveSpeed MoveSpeed { get => moveSpeed; }
		/// <summary>
		/// The destination of this pan to task.
		/// </summary>
		public Vector2 Destination { get => destination; }
		/// <summary>
		/// Gets the camera tasks type of this tasks.
		/// </summary>
		public CameraTaskTypes CameraTaskType { get => CameraTaskTypes.PanTo; }
		/// <summary>
		/// Gets the camera.
		/// </summary>
		public Camera Camera { get => camera; }

		/// <summary>
		/// Creates a new pan to task.
		/// </summary>
		/// <param name="moveSpeed">The move speed the task will pan with.</param>
		/// <param name="destination">The destination for this pan to task.</param>
		/// <param name="camera">The camera.</param>
		public PanToTask(MoveSpeed moveSpeed, Vector2 destination, Camera camera = null)
		{
			this.camera = camera ?? Camera.GetCamera();
			this.moveSpeed = moveSpeed;
			this.destination = destination;
			theta = 0;
		}

		/// <summary>
		/// Configures internal values for the task. 
		/// </summary>
		public void StartTask()
		{
			theta = Math.Atan(
				((this.Camera.AreaBox.Center.Y == 0 ? .001 : this.Camera.AreaBox.Center.Y) - destination.Y) /
				((this.Camera.AreaBox.Center.X == 0 ? .001 : this.Camera.AreaBox.Center.X) - destination.X));
		}
		/// <summary>
		/// Moves the camera toward the destination by a single speed step.
		/// </summary>
		/// <param name="gameTime">The game time.</param>
		/// <returns>True if the camera has reach the destination, False if not.</returns>
		public bool ProgressTask(GameTime gameTime)
		{
			float movementAmount = this.MoveSpeed.GetMovementAmount(gameTime);
			float deltaX = (float)Math.Abs(movementAmount * Math.Cos((double)Theta));
			float deltaY = (float)Math.Abs(movementAmount * Math.Sin((double)Theta));
			Vector2 delta = new Vector2(
				destination.X > this.Camera.AreaBox.Center.X ? deltaX : -deltaX,
				destination.Y > this.Camera.AreaBox.Center.Y ? deltaY : -deltaY);

			if (Math.Abs(this.Camera.AreaBox.Center.X - Destination.X) <= Math.Abs(delta.X) &&
				Math.Abs(this.Camera.AreaBox.Center.Y - Destination.Y) <= Math.Abs(delta.Y))
			{
				this.Camera.CenterCamera(destination);
				return true;
			}

			this.Camera.Position.VectorPosition += delta;
			return false;
		}
	}
}
