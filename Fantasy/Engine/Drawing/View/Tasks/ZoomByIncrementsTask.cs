using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.Drawing.View.Tasks
{
	/// <summary>
	/// A camera task that zooms the camera by increments.
	/// </summary>
	public class ZoomByIncrementsTask : ICameraTask
	{
		private byte speed;
		private byte destinationZoom;
		private Vector2? viewPoint;

		/// <summary>
		/// The speed of the zoom task.
		/// </summary>
		public byte Speed { get => speed; }
		/// <summary>
		/// The destination zoom for the task.
		/// </summary>
		public byte DestinationZoom { get => destinationZoom; }
		/// <summary>
		/// The point which the camera will zoom out to until it is within the view of the camera or the camera's max zoom is reached.
		/// </summary>
		public Vector2? ViewPoint { get => viewPoint; }
		/// <summary>
		/// Gets the camera tasks type of this tasks.
		/// </summary>
		public CameraTaskTypes CameraTaskTypes { get => CameraTaskTypes.ZoomByIncrements; }

		/// <summary>
		/// Creates a new zoom by increments task.
		/// </summary>
		/// <param name="speed">The speed the task will zoom with.</param>
		/// <param name="destinationZoom">The destination zoom of the task.</param>
		public ZoomByIncrementsTask(byte speed, byte destinationZoom)
		{ 
			this.speed = speed;
			this.destinationZoom = destinationZoom;
			this.viewPoint = null;
		}
		/// <summary>
		/// Creates a new zoom by increments tasks.
		/// </summary>
		/// <param name="speed">The speed the task will zoom with.</param>
		/// <param name="viewPoint">The point which the camera will zoom out to until it is within the view of the camera or the camera's max zoom is reached.</param>
		public ZoomByIncrementsTask(byte speed, Vector2 viewPoint)
		{
			this.speed = speed;
			this.viewPoint = viewPoint;
		}

		/// <summary>
		/// Progress the task by zooming the camera in or out by one.
		/// </summary>
		/// <returns>True if the Camera zoom has reached the destination zoom, False if not.</returns>
		public bool ProgressTask()
		{
			if (ViewPoint != null)
			{
				if (Camera.CameraViewBoundingBox.Contains((Vector2)ViewPoint))
				{
					return true;
				}

				if (Camera.Zoom + Speed < Camera.MaxZoom)
				{
					Camera.Zoom += Speed;
				}
				else
				{
					Camera.Zoom = Camera.MaxZoom;
					return true;
				}
				return false;
			}

			if (Camera.Zoom + Speed < DestinationZoom)
			{
				Camera.Zoom += Speed;
			}
			else if (Camera.Zoom - Speed > DestinationZoom)
			{
				Camera.Zoom -= Speed;
			}
			else
			{
				Camera.Zoom = DestinationZoom;
			}

			return Camera.Zoom == DestinationZoom;
		}
	}
}
