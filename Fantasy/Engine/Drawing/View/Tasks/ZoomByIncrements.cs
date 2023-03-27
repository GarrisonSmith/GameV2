using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;

namespace Fantasy.Engine.Drawing.View.Tasks
{
	/// <summary>
	/// A camera task that zooms the camera by increments.
	/// </summary>
	public class ZoomByIncrements : ICameraTask
	{
		private byte destinationZoom; 

		/// <summary>
		/// The destination zoom for the task.
		/// </summary>
		public byte DestinationZoom { get => destinationZoom; }
		/// <summary>
		/// Gets the camera tasks type of this tasks.
		/// </summary>
		public CameraTaskTypes CameraTaskTypes { get => CameraTaskTypes.ZoomByIncrements; }

		/// <summary>
		/// Creates a new zoom bu increments task.
		/// </summary>
		/// <param name="destinationZoom">The destination zoom of the task.</param>
		public ZoomByIncrements(byte destinationZoom)
		{ 
			this.destinationZoom = destinationZoom;
		}

		/// <summary>
		/// Progress the task by zooming the camera in or out by one.
		/// </summary>
		/// <returns>True if the Camera zoom has reached the destination zoom, False if not.</returns>
		public bool ProgressTask()
		{
			if (Camera.Zoom < DestinationZoom)
			{
				Camera.Zoom++;
			}
			else if (Camera.Zoom > DestinationZoom)
			{ 
				Camera.Zoom--;
			}

			return Camera.Zoom == DestinationZoom;
		}
	}
}
