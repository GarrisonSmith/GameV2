using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Drawing.View.Tasks.interfaces;
using Fantasy.Engine.Physics;
using Microsoft.Xna.Framework;

namespace Fantasy.Engine.Drawing.View.Tasks
{
	/// <summary>
	/// A camera task that zooms a camera out, pans to a destination, and then zooms the camera back in.
	/// </summary>
	public struct ZoomOutPanZoomIn : ICameraTask
	{
		private byte originalZoom;
		private readonly ICameraTask[] componentTasks;
		private readonly Camera camera;

		/// <summary>
		/// The original zoom of the camera.
		/// </summary>
		public byte OriginalZoom { get => originalZoom; }
		/// <summary>
		/// An array describing the component tasks of this task. 
		/// 0th index is the current task, 1st index is the pan out task, 2nd index is the pan to task, 3rd index is the pan in task.
		/// </summary>
		public ICameraTask[] ComponentTasks { get => componentTasks; }
		/// <summary>
		/// Gets the camera tasks type of this tasks.
		/// </summary>
		public CameraTaskTypes CameraTaskType { get => CameraTaskTypes.ZoomOutPanZoomIn; }
		/// <summary>
		/// Gets the camera.
		/// </summary>
		public Camera Camera { get => this.camera; }

		/// <summary>
		/// Creates a new zoom out, pan, zoom in task.
		/// </summary>
		/// <param name="zoomSpeed">The speed the task will zoom with.</param>
		/// <param name="panSpeed">The move speed the task will pan with.</param>
		/// <param name="destination">The destination of the panning.</param>
		/// <param name="camera">The camera.</param>
		public ZoomOutPanZoomIn(byte zoomSpeed, MoveSpeed panSpeed, Vector2 destination, Camera camera = null)
		{
			this.camera = camera ?? Camera.GetCamera();
			originalZoom = this.camera.Zoom;
			componentTasks = new ICameraTask[4];
			ComponentTasks[0] = ComponentTasks[1] = new ZoomByIncrementsTask(zoomSpeed, destination, camera);
			ComponentTasks[2] = new PanToTask(panSpeed, destination, camera);
			ComponentTasks[3] = new ZoomByIncrementsTask(zoomSpeed, Camera.Zoom, camera);
		}
		/// <summary>
		/// Creates a new zoom out, pan, zoom in task.
		/// </summary>
		/// <param name="zoomSpeed">The speed the task will zoom with.</param>
		/// <param name="destinationZoom">The zoom the first zoom task will reach.</param>
		/// <param name="panSpeed">The move speed the task will pan with.</param>
		/// <param name="destination">The destination of the panning.</param>
		/// <param name="camera">The camera.</param>
		public ZoomOutPanZoomIn(byte zoomSpeed, byte destinationZoom, MoveSpeed panSpeed, Vector2 destination, Camera camera = null)
		{
			this.camera = camera ?? Camera.GetCamera();
			originalZoom = this.camera.Zoom;
			componentTasks = new ICameraTask[4];
			ComponentTasks[0] = ComponentTasks[1] = new ZoomByIncrementsTask(zoomSpeed, destinationZoom, camera);
			ComponentTasks[2] = new PanToTask(panSpeed, destination, camera);
			ComponentTasks[3] = new ZoomByIncrementsTask(zoomSpeed, Camera.Zoom, camera);
		}

		/// <summary>
		/// Configures internal values for the task. 
		/// </summary>
		public void StartTask()
		{
			originalZoom = Camera.Zoom;
			for (int i = 1; i <= 3; i++)
			{
				ComponentTasks[i].StartTask();
			}
		}
		/// <summary>
		/// Progress the task by zooming the camera in or out by one or panning the camera toward the destination by one increment.
		/// </summary>
		/// <param name="gameTime">The game time.</param>
		/// <returns>True if the Camera zoom is the original zoom and the camera pan to it's destination, False if not.</returns>
		public bool ProgressTask(GameTime gameTime)
		{
			if (Camera.AreaBox.Center == ((PanToTask)ComponentTasks[2]).Destination && Camera.Zoom == OriginalZoom)
			{
				return true;
			}

			if (ComponentTasks[0].ProgressTask(gameTime))
			{
				if (ComponentTasks[0] is ZoomByIncrementsTask && Camera.AreaBox.Center != ((PanToTask)ComponentTasks[2]).Destination)
				{
					ComponentTasks[0] = ComponentTasks[2];
					return false;
				}
				else if (ComponentTasks[0] is PanToTask)
				{
					ComponentTasks[0] = ComponentTasks[3];
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
