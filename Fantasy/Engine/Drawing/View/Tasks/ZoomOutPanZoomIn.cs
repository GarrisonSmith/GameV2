using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.Drawing.View.Tasks
{
	/// <summary>
	/// A camera task that zooms a camera out, pans to a destination, and then zooms the camera back in.
	/// </summary>
	public class ZoomOutPanZoomIn : ICameraTask
	{
		private byte originalZoom;
		private ICameraTask currentTask;
		private ZoomByIncrementsTask zoomByIncrementsTaskOut;
		private ZoomByIncrementsTask zoomByIncrementsTaskIn;
		private PanToTask panToTask;

		/// <summary>
		/// The original zoom of the camera.
		/// </summary>
		public byte OriginalZoom { get => originalZoom; }
		/// <summary>
		/// The current task of this ZoomOutPanZoomIn task.
		/// </summary>
		public ICameraTask CurrentTask { get => currentTask; }
		/// <summary>
		/// The zoom out task.
		/// </summary>
		public ZoomByIncrementsTask ZoomByIncrementsTaskOut { get => zoomByIncrementsTaskOut; }
		/// <summary>
		/// The zoom back in task.
		/// </summary>
		public ZoomByIncrementsTask ZoomByIncrementsTaskIn { get => zoomByIncrementsTaskIn; }
		/// <summary>
		/// The pan task.
		/// </summary>
		public PanToTask PanToTask { get => panToTask; }
		/// <summary>
		/// Gets the camera tasks type of this tasks.
		/// </summary>
		public CameraTaskTypes CameraTaskTypes { get => CameraTaskTypes.ZoomOutPanZoomIn; }

		/// <summary>
		/// Creates a new zoom out, pan, zoom in task.
		/// </summary>
		/// <param name="zoomSpeed">The speed the task will zoom with.</param>
		/// <param name="panSpeed">The speed the task will pan with.</param>
		/// <param name="destination">The destination of the panning.</param>
		public ZoomOutPanZoomIn(byte zoomSpeed, byte panSpeed, Vector2 destination)
		{
			originalZoom = Camera.Zoom;
			this.zoomByIncrementsTaskOut = new ZoomByIncrementsTask(zoomSpeed, destination);
			this.panToTask = new PanToTask(panSpeed, destination);
			this.zoomByIncrementsTaskIn = new ZoomByIncrementsTask(zoomSpeed, OriginalZoom);
			this.currentTask = ZoomByIncrementsTaskOut;
		}
		/// <summary>
		/// Creates a new zoom out, pan, zoom in task.
		/// </summary>
		/// <param name="zoomSpeed">The speed the task will zoom with.</param>
		/// <param name="destinationZoom">The zoom the first zoom task will reach.</param>
		/// <param name="panSpeed">The speed the task will pan with.</param>
		/// <param name="destination">The destination of the panning.</param>
		public ZoomOutPanZoomIn(byte zoomSpeed, byte destinationZoom, byte panSpeed, Vector2 destination)
		{
			originalZoom = Camera.Zoom;
			this.zoomByIncrementsTaskOut = new ZoomByIncrementsTask(zoomSpeed, destinationZoom);
			this.panToTask = new PanToTask(panSpeed, destination);
			this.zoomByIncrementsTaskIn = new ZoomByIncrementsTask(zoomSpeed, OriginalZoom);
			this.currentTask = ZoomByIncrementsTaskOut;
		}

		/// <summary>
		/// Progress the task by zooming the camera in or out by one or panning the camera toward the destination by one increment.
		/// </summary>
		/// <returns>True if the Camera zoom is the original zoom and the camera pan to it's destination, False if not.</returns>
		public bool ProgressTask()
		{
			if (Camera.CameraViewBoundingBox.Center == PanToTask.Destination && Camera.Zoom == OriginalZoom)
			{
				return true;
			}

			if (CurrentTask.ProgressTask())
			{
				if (CurrentTask is ZoomByIncrementsTask && Camera.CameraViewBoundingBox.Center != PanToTask.Destination)
				{
					currentTask = PanToTask;
					return false;
				}
				else if (CurrentTask is PanToTask)
				{
					currentTask = ZoomByIncrementsTaskIn;
					return false;
				}
				else 
				{
					return true;
				}
			}
			return false;
		}
	}
}
