using Microsoft.Xna.Framework;
using Fantasy.Engine.Physics;
using System;
using Fantasy.Engine.Mapping.Tiling;
using Fantasy.Engine.Drawing.View.Tasks;

namespace Fantasy.Engine.Drawing.View
{
    public static class Camera
    {
        private static bool verticalMovementLocked = true;
        private static bool horizontalMovementLocked = true;
        private static byte zoom;
        private static byte maxZoom;
        private static byte minZoom;
        private static float stretch;
        private static float rotation;
		private static Matrix positionMatrix;
		private static AreaBox cameraMovementBoundingBox;
        private static AreaBox cameraViewBoundingBox;
        private static TaskStack taskStack;
        private static Game1 game;

		/// <summary>
		/// Determines if vertical camera movement is restricted.
		/// </summary>
		public static bool VerticalMovementLocked
        {
            get => verticalMovementLocked;
            set => verticalMovementLocked = value;
        }
        /// <summary>
        /// Determines if horizontal camera movement is restricted.
        /// </summary>
        public static bool HorizontalMovementLocked
        {
            get => horizontalMovementLocked;
            set => horizontalMovementLocked = value;
        }
        /// <summary>
        /// The current zoom level of the camera. Describes the pixel dimensions of a tile.
        /// </summary>
        public static byte Zoom
        {
            get => zoom;
            set
            {
                if (MinZoom <= value && value <= MaxZoom)
                {
                    zoom = value;
                    Stretch = Zoom / (float)Tile.TILE_HEIGHT;
                    CameraViewBoundingBox.Width = (int)Math.Ceiling(Game._Graphics.PreferredBackBufferWidth / Stretch);
                    CameraViewBoundingBox.Height = (int)Math.Ceiling(Game._Graphics.PreferredBackBufferHeight / Stretch);
				}
			}
        }
        /// <summary>
        /// The max zoom of the camera.
        /// </summary>
        public static byte MaxZoom
        {
            get => maxZoom;
            set => maxZoom = value;
        }
        /// <summary>
        /// The minimum zoom of the camera.
        /// </summary>
        public static byte MinZoom
        {
            get => minZoom;
            set => minZoom = value;
        }
        /// <summary>
        /// The stretching applied to the cameras transformation matrix.
        /// </summary>
        private static float Stretch
        {
            get => stretch;
            set => stretch = value;
        }
        /// <summary>
        /// Determines how much the final drawing of the spritebatch is rotated around the origin of the frame.
        /// TODO Not implemented fully.
        /// </summary>
        public static float Rotation
        {
            get => rotation;
            set => rotation = value;
        }
		/// <summary>
		/// The unmodified position matrix of the camera. 
		/// </summary>
		private static Matrix PositionMatrix
		{
			get => positionMatrix;
		}
		/// <summary>
		/// The bounding box the camera center cannot leave.
		/// </summary>
		public static AreaBox CameraMovementBoundingBox
        {
            get => cameraMovementBoundingBox;
            set => cameraMovementBoundingBox = value;
        }
        /// <summary>
        /// The bounding box that describes what is inside the camera's view.
        /// </summary>
        public static AreaBox CameraViewBoundingBox
        {
            get => cameraViewBoundingBox;
            set => cameraViewBoundingBox = value;
        }
        /// <summary>
        /// The TaskStack of the camera. 
        /// </summary>
        public static TaskStack TaskStack 
        {
            get => taskStack;
        }
        /// <summary>
        /// The game this Camera is viewing.
        /// </summary>
        private static Game1 Game
        {
            get => game; 
            set => game = value;
        }

		/// <summary>
		/// Sets the initial values of the camera.
		/// </summary>
		public static void Initialize(Game1 game) {
			Game = game;
			//CameraMovementBoundingBox;
			CameraViewBoundingBox = new AreaBox(new Vector2(192, 64), game._Graphics.PreferredBackBufferWidth, game._Graphics.PreferredBackBufferHeight);
			VerticalMovementLocked = true;
            HorizontalMovementLocked = true;
			MaxZoom = 192;
			MinZoom = 24;
			Zoom = 64;
            Stretch = 1f;
            Rotation = 0f;
			positionMatrix = new Matrix()
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
            taskStack = new TaskStack(new FreeMovementTask());
		}
        /// <summary>
        /// Creates the transformation matrix used to apply camera effects when drawing.
        /// </summary>
        /// <param name="updateTask">Determines if the current camera task is update, true by default.</param>
        /// <returns>Matrix used to apply camera effects (Camera movement, Camera rotation) when drawing in Scene.</returns>
        public static Matrix GetTransformationMatrix(bool updateTask = true)
        {
            if (updateTask)
            {
                TaskStack.Update();
            }

            Matrix positionMatrix = PositionMatrix;
			positionMatrix.M41 = -CameraViewBoundingBox.TopLeft.X;
			positionMatrix.M42 = -CameraViewBoundingBox.TopLeft.Y;

			return positionMatrix * Matrix.CreateRotationZ(Rotation) * Matrix.CreateScale(Stretch);
        }
        /// <summary>
        /// Centers the camera on the provided Vector2.
        /// </summary>
        /// <param name="foo">The Vector2 position for the camera to center on.</param>
        public static void CenterCamera(Vector2 foo)
        {
            if (CameraMovementBoundingBox != null && !CameraMovementBoundingBox.Contains(foo))
            {
                return;
            }

            CameraViewBoundingBox.Center = foo;
        }
		/// <summary>
		/// Zooms the camera in by the provided amount if the camera is not at max zoom already.
		/// </summary>
        /// <param name="amount">The amount to zoom in by, is 1 by default.</param>
		public static void ZoomIn(byte amount = 1)
        {
            if (Zoom + amount <= MaxZoom)
            {
                Zoom += amount;
            }
        }
		/// <summary>
		/// Zooms the camera out by the provided amount if the camera is not at min zoom already.
		/// </summary>
		/// <param name="amount">The amount to zoom out by, is 1 by default.</param>
		public static void ZoomOut(byte amount = 1)
        {
            if (MinZoom <= Zoom - amount)
            { 
                Zoom -= amount;
            }
        }
		/// <summary>
		/// Zooms the camera in by the provided percent of the current zoom if the camera is not at max zoom already.
		/// </summary>
		/// <param name="percent">The percent of the current zoom to zoom in by, is .01 by default. At a minimum will increase zoom by 1.</param>
		public static void SmoothZoomIn(float percent = .01f)
		{
			if (percent <= 0)
			{
				return;
			}

			if (Zoom + (Zoom * percent) <= MaxZoom)
			{
				Zoom += (byte)Math.Ceiling(Zoom * percent);
			}
		}
		/// <summary>
		/// Zooms the camera out by the provided percent of the current zoom if the camera is not at min zoom already.
		/// </summary>
		/// <param name="percent">The percent of the current zoom to zoom out by, is .01 by default. At a minimum will decrease zoom by 1.</param>
		public static void SmoothZoomOut(float percent = .01f)
		{
            if (percent <= 0)
            {
                return;
            }

			if (MinZoom <= Zoom - (Zoom * percent))
			{
				Zoom -= (byte)Math.Ceiling(Zoom * percent);
			}
		}
	}
}
