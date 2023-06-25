using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.Drawing.View.Tasks
{
	/// <summary>
	/// A camera task that zooms the camera by increments.
	/// </summary>
	public struct ZoomByIncrementsTask : ICameraTask
	{
		private readonly byte zoomSpeed;
		private readonly byte? destinationZoom;
		private readonly Vector2? viewPoint;
		private readonly Camera camera;

		/// <summary>
		/// The speed of the zoom task.
		/// </summary>
		public byte ZoomSpeed { get => zoomSpeed; }
		/// <summary>
		/// The destination zoom for the task.
		/// </summary>
		public byte? DestinationZoom { get => destinationZoom; }
		/// <summary>
		/// The point which the camera will zoom out to until it is within the view of the camera or the camera's max zoom is reached.
		/// </summary>
		public Vector2? ViewPoint { get => viewPoint; }
		/// <summary>
		/// Gets the camera tasks type of this tasks.
		/// </summary>
		public CameraTaskTypes CameraTaskType { get => CameraTaskTypes.ZoomByIncrements; }
		/// <summary>
		/// Gets the camera.
		/// </summary>
		public Camera Camera { get => this.camera; }

		/// <summary>
		/// Creates a new zoom by increments task.
		/// </summary>
		/// <param name="speed">The speed the task will zoom with.</param>
		/// <param name="destinationZoom">The destination zoom of the task.</param>
		/// <param name="camera">The camera.</param>
		public ZoomByIncrementsTask(byte speed, byte destinationZoom, Camera camera = null)
		{
			this.camera = camera ?? Camera.GetCamera();
			this.zoomSpeed = speed;
			this.destinationZoom = destinationZoom;
			this.viewPoint = null;
		}
		/// <summary>
		/// Creates a new zoom by increments tasks.
		/// </summary>
		/// <param name="speed">The speed the task will zoom with.</param>
		/// <param name="viewPoint">The point which the camera will zoom out to until it is within the view of the camera or the camera's max zoom is reached.</param>
		/// <param name="camera">The camera.</param>
		public ZoomByIncrementsTask(byte speed, Vector2 viewPoint, Camera camera = null)
		{
			this.camera = camera ?? Camera.GetCamera();
			this.zoomSpeed = speed;
			this.destinationZoom = null;
			this.viewPoint = viewPoint;
		}

		/// <summary>
		/// Configures internal values for the task. 
		/// </summary>
		public void StartTask()
		{
			//nothing needed.
		}
		/// <summary>
		/// Progress the task by zooming the camera in or out by one.
		/// </summary>
		/// <param name="gameTime">The game time.</param>
		/// <returns>True if the Camera zoom has reached the destination zoom, False if not.</returns>
		public bool ProgressTask(GameTime gameTime)
		{
			if (ViewPoint != null)
			{
				if (Camera.AreaBox.Contains((Vector2)ViewPoint))
				{
					return true;
				}

				if (Camera.Zoom - ZoomSpeed > Camera.MinZoom)
				{
					Camera.Zoom -= ZoomSpeed;
				}
				else
				{
					Camera.Zoom = Camera.MinZoom;
					return true;
				}
				return false;
			}

			if (Camera.Zoom + ZoomSpeed < DestinationZoom)
			{
				Camera.Zoom += ZoomSpeed;
			}
			else if (Camera.Zoom - ZoomSpeed > DestinationZoom)
			{
				Camera.Zoom -= ZoomSpeed;
			}
			else
			{
				Camera.Zoom = (byte)DestinationZoom;
			}

			return Camera.Zoom == DestinationZoom;
		}
	}
}
