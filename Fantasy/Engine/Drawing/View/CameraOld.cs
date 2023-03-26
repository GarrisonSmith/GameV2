﻿using Microsoft.Xna.Framework;
using System;

namespace Fantasy.Engine.Drawing.View
{
    /// <summary>
    /// Describes a scenes camera. Determines the placement and stretching of graphics when drawn by the spritebatch.
    /// </summary>
    class CameraOld
    {
        /// <summary>
        /// The center of whats on screen.
        /// </summary>
        public Point cameraCenter;
        /// <summary>
        /// The rectangle that describes what is in the cameras view.
        /// </summary>
        public Rectangle cameraPosition;
        /// <summary>
        /// The bounding collisionArea that the cameras center which can restricts the cameras movement.
        /// </summary>
        public Rectangle BoundingBox2;
        /// <summary>
        /// The current zoom level for this camera. Describes the pixel dimensions of a tile.
        /// </summary>
        public byte zoom = 64;
        /// <summary>
        /// The max zoom for this camera.
        /// </summary>
        public byte maxZoom = 192;
        /// <summary>
        /// The minimum zoom for this camera.
        /// </summary>
        public byte minZoom = 24;
        /// <summary>
        /// The stretching applied to this cameras transformation matrix.
        /// </summary>
        public float stretch = 1f;
        /// <summary>
        /// Determines how much the final drawing of the spritebatch is rotated around the origin.
        /// TODO Not implemented fully.
        /// </summary>
        public float rotation = 0f;
        /// <summary>
        /// Determines if vertical camera movement is restricted.
        /// </summary>
        public bool movementAllowedVertical = true;
        /// <summary>
        /// Determines if horizontal camera movement is restricted.
        /// </summary>
        public bool movementAllowedHorizontal = true;

        /// <summary>
        /// Creates a Camera with the given properties.
        /// </summary>
        /// <param name="startingBoundingBox2">Describes the point the Camera begins at. By default this is the top right position of the Camera.</param>
        /// <param name="centerStartingBoundingBox2">If true, centers the Camera on the starting BoundingBox2.</param>
        /// <param name="allowCentering">If true, allows Camera movement to be restricted with the Camera being centered on the TileMap if the TileMap BoundingBox2 is smaller than Camera view.</param>
        public CameraOld(Point startingBoundingBox2, bool centerStartingBoundingBox2, bool allowCentering)
        {
            //TODO
            //cameraPosition.Width = Global._graphics.PreferredBackBufferWidth;
            //cameraPosition.Height = Global._graphics.PreferredBackBufferHeight;
            if (centerStartingBoundingBox2)
            {
                startingBoundingBox2 = new Point(startingBoundingBox2.X - (cameraPosition.Width / 2), startingBoundingBox2.Y + (cameraPosition.Height / 2));
            }
            cameraPosition.X = startingBoundingBox2.X;
            cameraPosition.Y = startingBoundingBox2.Y;
            Reposition();
            SetBoundingBox2(allowCentering);
        }
        /// <summary>
        /// Creates a Camera with the given properties.
        /// </summary>
        /// <param name="startingBoundingBox2">Describes the point the Camera begins at. By default this is the top right position of the Camera.</param>
        /// <param name="centerStartingBoundingBox2">If true, centers the Camera on the starting BoundingBox2.</param>
        /// <param name="allowCentering">If true, allows Camera movement to be restricted with the Camera being centered on the TileMap if the TileMap BoundingBox2 is smaller than Camera view.</param>
        /// <param name="stretch">Stretch value this Camera will begin with.</param>
        public CameraOld(Point startingBoundingBox2, bool centerStartingBoundingBox2, bool allowCentering, float stretch) : this(startingBoundingBox2, centerStartingBoundingBox2, allowCentering)
        {
            Stretch(stretch, allowCentering);
        }
        /// <summary>
        /// Creates the transformation matrix used to apply camera effects when drawing.
        /// </summary>
        /// <returns>Matrix used to apply camera effects (Camera movement, Camera rotation) when drawing in Scene.</returns>
        public Matrix GetTransformation()
        {
            Matrix _transform =
                Matrix.CreateTranslation(new Vector3(-cameraPosition.X, cameraPosition.Y, 0)) *
                Matrix.CreateRotationZ(rotation) *
                Matrix.CreateScale(stretch);
            return _transform;
        }
        /// <summary>
        /// Repositions cameraCenter to be consistent with cameraPosition.
        /// </summary>
        public void Reposition()
        {
            cameraCenter = cameraPosition.Center;
        }
        /// <summary>
        /// Centers the provided point.
        /// </summary>
        /// <param name="foo">The point to be centered.</param>
        /// <returns>A point corresponding to foo that puts foo in the cameras center.</returns>
        public Point CenterPoint(Point foo)
        {
            foo.X -= (cameraPosition.Width / 2);
            foo.Y += (cameraPosition.Height / 2);
            return foo;
        }
        /// <summary>
        /// Sets this cameras zoom level to the default of 64.
        /// </summary>
        /// <param name="allowCentering">If true, allows Camera movement to be restricted with the Camera being centered on the TileMap if the TileMap BoundingBox2 is smaller than Camera view.</param>
        public void ZoomDefault(bool allowCentering)
        {
            Stretch(1f, allowCentering);
            zoom = 64;
        }
        /// <summary>
        /// Increases this cameras zoom level by one.
        /// </summary>
        /// <param name="allowCentering">If true, allows Camera movement to be restricted with the Camera being centered on the TileMap if the TileMap BoundingBox2 is smaller than Camera view.</param>
        /// <param name="direction">True zooms the camera in, False zooms the camera out.</param>
        public void Zoom(bool allowCentering, bool direction)
        {
            if (direction)
            {
                if (zoom + 1 <= maxZoom)
                {
                    Stretch(((zoom + 1f) / 64f), allowCentering);
                    zoom = (byte)(zoom + 1);
                }
            }
            else
            {
                if (zoom - 1 >= minZoom)
                {
                    Stretch(((zoom - 1f) / 64f), allowCentering);
                    zoom = (byte)(zoom - 1);
                }
            }
        }
        /// <summary>
        /// Sets the cameras zoom level to the provided amount.
        /// </summary>
        /// <param name="zoom">The new zoom level for this camera.</param>
        /// <param name="allowCentering">If true, allows Camera movement to be restricted with the Camera being centered on the TileMap if the TileMap BoundingBox2 is smaller than Camera view.</param>
        public void SetZoom(int zoom, bool allowCentering)
        {
            if (zoom > maxZoom)
            {
                zoom = maxZoom;
            }
            if (zoom < minZoom)
            {
                zoom = minZoom;
            }

            while (this.zoom != zoom)
            {
                if (this.zoom > zoom)
                {
                    Zoom(allowCentering, false);
                }
                else
                {
                    Zoom(allowCentering, true);
                }
            }
        }
        /// <summary>
        /// Increases this camera zoom amount by the provided percent.
        /// </summary>
        /// <param name="percentChange">The percent the zoom will be changed by.</param>
        /// <param name="allowCentering">If true, allows Camera movement to be restricted with the Camera being centered on the TileMap if the TileMap BoundingBox2 is smaller than Camera view.</param>
        /// /// <param name="direction">True zooms the camera in, False zooms the camera out.</param>
        public void SmoothZoom(float percentChange, bool allowCentering, bool direction)
        {
            if (direction)
            {
                SetZoom((int)(zoom + percentChange * (zoom)), allowCentering);
            }
            else
            {
                SetZoom((int)(zoom - percentChange * (zoom)), allowCentering);
            }
        }
        /// <summary>
        /// Sets the Camera stretch to the provided amount.
        /// </summary>
        /// <param name="newStretch">The stretch the Camera is being set to.</param>
        /// <param name="allowCentering">If true, allows Camera movement to be restricted with the Camera being centered on the TileMap if the TileMap BoundingBox2 is smaller than Camera view.</param>
        private void Stretch(float newStretch, bool allowCentering)
        {
            //TODO
            //cameraPosition.Width = (int)Math.Ceiling((Global._graphics.PreferredBackBufferWidth / newStretch));
            //cameraPosition.Height = (int)Math.Ceiling((Global._graphics.PreferredBackBufferHeight / newStretch));

            cameraPosition.X = cameraCenter.X - cameraPosition.Width / 2;
            cameraPosition.Y = cameraCenter.Y + cameraPosition.Height / 2;

            stretch = newStretch;
            //Global._currentStretch = newStretch;

            SetBoundingBox2(allowCentering);
        }
        /// <summary>
        /// Sets this Cameras BoundingBox2 to conform to the BoundingBox2 of the Cameras Scenes TileMap.
        /// </summary>
        /// <param name="allowCentering">If true, allows Camera movement to be restricted with the Camera being centered on the TileMap if the TileMap BoundingBox2 is smaller than Camera view.</param>
        public void SetBoundingBox2(bool allowCentering)
        {
            //TODO
            Point mapCenter = new();//Global._currentScene._tileMap.GetTileMapCenter();
            Rectangle mapBounding = new();//Global._currentScene._tileMap.GetTileMapBounding();
            if (mapBounding.Width <= cameraPosition.Width && allowCentering)
            {
                movementAllowedHorizontal = false;
                cameraPosition.X = mapCenter.X - (cameraPosition.Width / 2);
            }
            else
            {
                movementAllowedHorizontal = true;
            }
            BoundingBox2.X = mapBounding.X;
            BoundingBox2.Width = mapBounding.Width;

            if (mapBounding.Height <= cameraPosition.Height && allowCentering)
            {
                movementAllowedVertical = false;
                cameraPosition.Y = mapCenter.Y + (cameraPosition.Height / 2);
            }
            else
            {
                movementAllowedVertical = true;
            }
            BoundingBox2.Y = mapBounding.Y;
            BoundingBox2.Height = mapBounding.Height;

            Reposition();
        }
        /// <summary>
        /// Determines if the provide BoundingBox2 value is on this cameras bounding boxes perimeter.
        /// </summary>
        /// <param name="BoundingBox2Value">The BoundingBox2 value to be investigated.</param>
        /// <param name="axis">True if the BoundingBox2 value is on the x axis, False if the BoundingBox2 value is on the y axis.</param>
        /// <returns>True if the provided BoundingBox2 is on the cameras bounding boxes perimeter, False if not.</returns>
        public bool BoundingBox2ValueOnBoundingBox2(int BoundingBox2Value, bool axis)
        {
            if (axis) //x axis
            {
                if (BoundingBox2.X == BoundingBox2Value || BoundingBox2.X + BoundingBox2.Width == BoundingBox2Value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else //y axis
            {
                if (BoundingBox2.Y == BoundingBox2Value || BoundingBox2.Y - BoundingBox2.Height == BoundingBox2Value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Determines if a point is inside of the camera BoundingBox2.
        /// </summary>
        /// <param name="point">The point to be assessed</param>
        /// <returns>True if the point is inside or on the BoundingBox2, False if it not.</returns>
        public bool PointInBoundingBox2(Point point)
        {
            return BoundingBox2.Contains(point);
        }
        /// <summary>
        /// Pans camera by one increment with the provided specifications.
        /// </summary>
        /// <param name="destination">The point for the camera center to move towards.</param>
        /// <param name="movementAmount">The amount for the camera to move by.</param>
        /// <param name="forced">True results in this movement overriding camera movement restrictions. </param>
        /// <returns>True if the camera has finished its panning operation, False if not.</returns>
        public bool Pan(Point destination, int movementAmount, bool forced)
        {
            Point lastLocation = cameraPosition.Location;
            destination = CenterPoint(destination);

            if ((movementAllowedVertical && movementAllowedHorizontal) || forced)
            {
                if (Math.Abs(destination.X - cameraPosition.X) <= movementAmount)
                {
                    SetHorizontal(forced, destination.X, false);

                }
                if (Math.Abs(destination.Y - cameraPosition.Y) <= movementAmount)
                {
                    SetVertical(forced, destination.Y, false);
                }

                if ((cameraPosition.X < destination.X && cameraPosition.Y < destination.Y) || (cameraPosition.X < destination.X && cameraPosition.Y > destination.Y) ||
                    (cameraPosition.X > destination.X && cameraPosition.Y < destination.Y) || (cameraPosition.X > destination.X && cameraPosition.Y > destination.Y))
                {
                    movementAmount = (int)Math.Ceiling(movementAmount * (1 / Math.Sqrt(2)));
                }

                if (cameraPosition.X < destination.X)
                {
                    MoveHorizontal(forced, true, movementAmount);
                }
                else if (cameraPosition.X > destination.X)
                {
                    MoveHorizontal(forced, false, movementAmount);
                }

                if (cameraPosition.Y < destination.Y)
                {
                    MoveVertical(forced, true, movementAmount);
                }
                else if (cameraPosition.Y > destination.Y)
                {
                    MoveVertical(forced, false, movementAmount);
                }
                Reposition();

                return (lastLocation == cameraPosition.Location && movementAmount != 0);
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Used by camera panning tasks. Zooms the camera out by one increment.
        /// </summary>
        /// <param name="destination">The current destination of the camera panning task.</param>
        /// <param name="panMinZoom">The minimum zoom level allowed by this camera panning task.</param>
        /// <returns>True if the camera pan zoom out is complete, False if not.</returns>
        public bool Pan_ZoomOut(Point destination, byte panMinZoom)
        {
            if (cameraPosition.Contains(destination) || zoom == panMinZoom || zoom == minZoom)
            {
                return true;
            }
            else
            {
                SmoothZoom(.05f, false, false);
                return false;
            }
        }
        /// <summary>
        /// Used by camera panning tasks. Zooms the camera in by one increment.
        /// </summary>
        /// <param name="returnZoom">The original zoom of the camera prior to the camera panning task.</param>
        /// <returns>True if the camera pan zoom in is complete, False if not.</returns>
        public bool Pan_ZoomIn(byte returnZoom)
        {
            if (returnZoom < (byte)(zoom + .05 * (zoom)))
            {
                SetZoom(returnZoom, false);
                return true;
            }
            else
            {
                SmoothZoom(.05f, false, true);
                return false;
            }
        }
        /// <summary>
        /// Moves the Camera vertically by the provided amount.
        /// </summary>
        /// <param name="forced">True results in this movement overriding camera movement restrictions.</param>
        /// <param name="direction">True results in the Camera moving up, False results in the Camera moving down.</param>
        /// <param name="amount">The amount the Camera will move in the provided direction.</param>
        public void MoveVertical(bool forced, bool direction, int amount)
        {
            if (forced || !PointInBoundingBox2(cameraCenter))
            {
                if (direction)
                {
                    //moves up
                    cameraPosition.Y += amount;
                }
                else
                {
                    //moves down
                    cameraPosition.Y -= amount;
                }
                Reposition();
            }
            else if (movementAllowedVertical)
            {
                if (direction)
                {
                    //moves up
                    if (PointInBoundingBox2(new Point(cameraCenter.X, cameraCenter.Y + amount)))
                    {
                        cameraPosition.Y += amount;
                    }
                    else
                    {
                        cameraPosition.Y = BoundingBox2.Y + (cameraPosition.Height / 2);
                    }
                }
                else
                {
                    //moves down
                    if (PointInBoundingBox2(new Point(cameraCenter.X, cameraCenter.Y - amount)))
                    {
                        cameraPosition.Y -= amount;
                    }
                    else
                    {
                        cameraPosition.Y = BoundingBox2.Y - BoundingBox2.Height + (cameraPosition.Height / 2);
                    }
                }
                Reposition();
            }
        }
        /// <summary>
        /// Sets the Camera vertical BoundingBox2 to the provided Y.
        /// </summary>
        /// <param name="forced">True results in this movement overriding camera movement restrictions.</param>
        /// <param name="Y">New Y BoundingBox2 for this Camera. By default this is the top right position of the Camera.</param>
        /// <param name="centerDestination">If true, the Camera set the Y as the center.</param>
        public void SetVertical(bool forced, int Y, bool centerDestination)
        {
            if (centerDestination)
            {
                Y += cameraPosition.Height / 2;
            }

            if (forced)
            {
                cameraPosition.Y = Y;
                Reposition();
            }
            else if (movementAllowedVertical)
            {
                if (PointInBoundingBox2(new Point(cameraCenter.X, Y - (cameraPosition.Height / 2))))
                {
                    cameraPosition.Y = Y;
                }
                else if (Y >= BoundingBox2.Y)
                {
                    cameraPosition.Y = BoundingBox2.Y + (cameraPosition.Height / 2);
                }
                else
                {
                    cameraPosition.Y = BoundingBox2.Y - BoundingBox2.Height + (cameraPosition.Height / 2);
                }
                Reposition();
            }
        }
        /// <summary>
        /// Moves the camera horizontally by the provided amount.
        /// </summary>
        /// <param name="forced">True results in this movement overriding camera movement restrictions.</param>
        /// <param name="direction">True results in the Camera moving right, False results in the Camera moving left.</param>
        /// <param name="amount">The amount the camera will move in the provided direction.</param>
        public void MoveHorizontal(bool forced, bool direction, int amount)
        {
            if (forced || !PointInBoundingBox2(cameraCenter))
            {
                if (direction)
                {
                    //moves right
                    cameraPosition.X += amount;
                }
                else
                {
                    //moves left
                    cameraPosition.X -= amount;
                }
                Reposition();
            }
            else if (movementAllowedHorizontal)
            {
                if (direction)
                {
                    //moves right
                    if (PointInBoundingBox2(new Point(cameraCenter.X + amount, cameraCenter.Y)))
                    {
                        cameraPosition.X += amount;
                    }
                    else
                    {
                        cameraPosition.X = BoundingBox2.X + BoundingBox2.Width - (cameraPosition.Width / 2);
                    }
                }
                else
                {
                    //moves left
                    if (PointInBoundingBox2(new Point(cameraCenter.X - amount, cameraCenter.Y)))
                    {
                        cameraPosition.X -= amount;
                    }
                    else
                    {
                        cameraPosition.X = BoundingBox2.X - (cameraPosition.Width / 2);
                    }
                }
                Reposition();
            }
        }
        /// <summary>
        /// Sets the camera horizontal BoundingBox2 to the provided X. 
        /// </summary>
        /// <param name="forced">True results in this movement overriding camera movement restrictions.</param>
        /// <param name="X">New X BoundingBox2 for this Camera. By default this is the top right position of the Camera.</param>
        /// <param name="centerDestination">If true, the Camera set the X as the center.</param>
        public void SetHorizontal(bool forced, int X, bool centerDestination)
        {
            if (centerDestination)
            {
                X -= cameraPosition.Width / 2;
            }

            if (forced)
            {
                cameraPosition.X = X;
                Reposition();
            }
            else if (movementAllowedHorizontal)
            {
                if (PointInBoundingBox2(new Point(X + (cameraPosition.Width / 2), cameraCenter.Y)))
                {
                    cameraPosition.X = X;
                }
                else if (X <= BoundingBox2.X)
                {
                    cameraPosition.X = BoundingBox2.X - (cameraPosition.Width / 2);
                }
                else
                {
                    cameraPosition.X = (BoundingBox2.X + BoundingBox2.Width) - (cameraPosition.Width / 2);
                }
                Reposition();
            }
        }
        /// <summary>
        /// Sets the camera center to the cameraCenter. 
        /// </summary>
        /// <param name="forced">True results in this movement overriding camera movement restrictions.</param>
        /// <param name="BoundingBox2">New BoundingBox2 for this Camera. By default this is the top right position of the Camera.</param>
        /// <param name="centerDestination">If true, the BoundingBox2 is set as the Camera center.</param>
        public void SetBoundingBox2(bool forced, Point BoundingBox2, bool centerDestination)
        {
            SetHorizontal(forced, BoundingBox2.X, centerDestination);
            SetVertical(forced, BoundingBox2.Y, centerDestination);
        }
    }
}
