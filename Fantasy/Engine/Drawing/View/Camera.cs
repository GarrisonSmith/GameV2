using Fantasy.Engine.Drawing.View.Tasks;
using Fantasy.Engine.Drawing.View.Tasks.enums;
using Fantasy.Engine.Mapping.Tiling;
using Fantasy.Engine.Physics;
using Fantasy.Engine.Physics.interfaces;
using Microsoft.Xna.Framework;
using System;

namespace Fantasy.Engine.Drawing.View
{
	/// <summary>
	/// Represents a camera. 
	/// </summary>
	public class Camera : GameComponent, IPositional<Position>, ISpatial
	{
		private static Camera camera;

		/// <summary>
		/// Gets the current <c>Camera</c>.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="Position">The camera view position.</param>
		/// <returns>The current <c>Camera</c>.</returns>
		public static Camera GetCamera(Game game = null, Position Position = null)
		{ 
			camera ??= new Camera(game, Position);
			return camera;
		}

		private bool verticalMovementLocked = true;
		private bool horizontalMovementLocked = true;
		private byte zoom;
		private byte maxZoom;
		private byte minZoom;
		private float stretch;
		private float rotation;
		private Matrix cameraMatrix;
		private Position position;
		private Position cameraBoundingPosition;
		private AreaBox cameraView;
		private AreaBox cameraBounding;
		private TaskStack taskStack;

		/// <summary>
		/// Gets or sets a value indicating whether vertical movement is locked.
		/// </summary>
		public bool VerticalMovementLocked { get => this.verticalMovementLocked; set => this.verticalMovementLocked = value; }
		/// <summary>
		/// Gets or sets a value indicating whether horizontal movement is locked.
		/// </summary>
		public bool HorizontalMovementLocked { get => this.horizontalMovementLocked; set => this.horizontalMovementLocked = value; }
		/// <summary>
		/// Gets or sets a value indicating whether this <c>Camera</c> is accepting inputs.
		/// </summary>
		public bool AcceptingInput { get => this.TaskStack.Peek().CameraTaskType == CameraTaskTypes.FreeMovement; }
		/// <summary>
		/// Gets or sets the current zoom level of this <c>Camera</c>. Describes the pixel dimensions of a tile.
		/// </summary>
		public byte Zoom
		{
			get => zoom;
			set
			{
				if (MinZoom <= value && value <= MaxZoom)
				{
					zoom = value;
					Stretch = Zoom / (float)Tile.TILE_DIMENSION;
					Vector2 originalCenter = this.AreaBox.Center;
					AreaBox.Width = (int)Math.Ceiling(Game.GraphicsDevice.Viewport.Width / Stretch);
					AreaBox.Height = (int)Math.Ceiling(Game.GraphicsDevice.Viewport.Height / Stretch);
					this.CenterCamera(originalCenter);
				}
			}
		}
		/// <summary>
		/// Gets or sets the max zoom.
		/// </summary>
		public byte MaxZoom { get => this.maxZoom; set => this.maxZoom = value; }
		/// <summary>
		/// Gets or sets the min zoom.
		/// </summary>
		public byte MinZoom { get => this.minZoom; set => this.minZoom = value; }
		/// <summary>
		/// Gets or sets the stretch. 
		/// </summary>
		private float Stretch { get => this.stretch; set => this.stretch = value; }
		/// <summary>
		/// Gets or sets the rotation.
		/// </summary>
		public float Rotation { get => this.rotation; set => this.rotation = value; }
		/// <summary>
		/// Gets or sets the camera matrix.
		/// </summary>
		private Matrix CameraMatrix { get => this.cameraMatrix; set => this.cameraMatrix = value; }
		/// <summary>
		/// Gets or sets the camera view position.
		/// </summary>
		public Position Position { get => this.position; set => this.position = value; }
		/// <summary>
		/// Gets or sets the camera bounding position.
		/// </summary>
		public Position CameraBoundingPosition { get => this.cameraBoundingPosition; set => this.cameraBoundingPosition = value; }
		/// <summary>
		/// Gets or sets the camera view.
		/// </summary>
		public AreaBox AreaBox { get => this.cameraView; set => this.cameraView = value; }
		/// <summary>
		/// Gets or sets the camera bounding.
		/// </summary>
		public AreaBox CameraBounding { get => this.cameraBounding; set => this.cameraBounding = value; }
		/// <summary>
		/// Gets or sets the task stack.
		/// </summary>
		public TaskStack TaskStack { get => this.taskStack; set => this.taskStack = value; }

		/// <summary>
		/// Creates a new <c>Camera</c> with the provided parameters.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="Position">The camera view position.</param>
		private Camera(Game game, Position Position) : base(game)
		{
			this.position = Position;
			this.AreaBox = new AreaBox(this.position.GetPositionRef(), game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
			this.VerticalMovementLocked = false;
			this.HorizontalMovementLocked = false;
			this.MaxZoom = 192;
			this.MinZoom = 24;
			this.Zoom = 64;
			this.Stretch = 1f;
			this.Rotation = 0f;
			this.CameraMatrix = new Matrix()
			{
				M11 = 1f,
				M12 = 0f,
				M13 = 0f,
				M14 = 0f,
				M21 = 0f,
				M22 = 1f,
				M23 = 0f,
				M24 = 0f,
				M31 = 0f,
				M32 = 0f,
				M33 = 1f,
				M34 = 0f,
				M41 = 0f,
				M42 = 0f,
				M43 = 0f,
				M44 = 1f
			};
			
			this.TaskStack = new TaskStack(new FreeMovementTask());
		}
		/// <summary>
		/// Updates the <c>Camera</c>.
		/// </summary>
		/// <param name="gameTime">The game time.</param>
		public override void Update(GameTime gameTime)
		{
			this.TaskStack.Update();
		}

		/// <summary>
		/// Gets the transformation matrix used to apply camera effects when drawing.
		/// </summary>
		/// <returns>Matrix used to apply camera effects (Camera movement, Camera rotation) when drawing in Scene.</returns>
		public Matrix GetTransformationMatrix()
		{
			Matrix tempCameraMatrix = this.CameraMatrix;
			tempCameraMatrix.M41 = -this.AreaBox.TopLeft.X;
			tempCameraMatrix.M42 = -this.AreaBox.TopLeft.Y;

			return tempCameraMatrix * Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(Stretch);
		}

		/// <summary>
		/// Centers the camera on the provided Vector2.
		/// </summary>
		/// <param name="foo">The Vector2 position for the camera to center on.</param>
		public void CenterCamera(Vector2 foo)
		{
			if (this.CameraBounding != null && !this.CameraBounding.Contains(foo))
			{
				return;
			}

			this.position.VectorPosition = new Vector2(foo.X - this.AreaBox.Width / 2, foo.Y - this.AreaBox.Height / 2);
		}

		/// <summary>
		/// Zooms the camera in by the provided amount if the camera is not at max zoom already.
		/// </summary>
		/// <param name="amount">The amount to zoom in by.</param>
		public void ZoomIn(byte amount = 1)
		{
			if (Zoom + amount <= MaxZoom)
			{
				Zoom += amount;
			}
		}
		/// <summary>
		/// Zooms the camera out by the provided amount if the camera is not at min zoom already.
		/// </summary>
		/// <param name="amount">The amount to zoom out by.</param>
		public void ZoomOut(byte amount = 1)
		{
			if (MinZoom <= Zoom - amount)
			{
				Zoom -= amount;
			}
		}

		/// <summary>
		/// Zooms the camera in by the provided percent of the current zoom if the camera is not at max zoom already.
		/// </summary>
		/// <param name="percent">The percent of the current zoom to zoom in by. At a minimum will increase zoom by 1.</param>
		public void SmoothZoomIn(float percent = .01f)
		{
			if (percent <= 0)
			{
				return;
			}

			if (this.Zoom + (this.Zoom * percent) <= this.MaxZoom)
			{
				this.Zoom += (byte)Math.Ceiling(this.Zoom * percent);
			}
		}
		/// <summary>
		/// Zooms the camera out by the provided percent of the current zoom if the camera is not at min zoom already.
		/// </summary>
		/// <param name="percent">The percent of the current zoom to zoom out by. At a minimum will decrease zoom by 1.</param>
		public void SmoothZoomOut(float percent = .01f)
		{
			if (percent <= 0)
			{
				return;
			}

			if (this.MinZoom <= this.Zoom - (this.Zoom * percent))
			{
				this.Zoom -= (byte)Math.Ceiling(this.Zoom * percent);
			}
		}
	}
}
