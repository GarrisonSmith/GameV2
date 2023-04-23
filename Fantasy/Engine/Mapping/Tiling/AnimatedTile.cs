﻿using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.Physics;
using System;
using System.Xml;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Fantasy.Engine.Drawing.View;

namespace Fantasy.Engine.Mapping.Tiling
{
	/// <summary>
	/// Represents a animated tile in a MapLayer.
	/// </summary>
	public class AnimatedTile : Tile
	{
		private readonly XmlElement spritesheetAnimationElement;
		private readonly Dictionary<int, Dictionary<AreaBox, SpritesheetAnimation>> animations;

		/// <summary>
		/// The XmlElement the describes the spritesheet animation of this tile.
		/// </summary>
		public XmlElement SpritesheetAnimationElement
		{
			get => spritesheetAnimationElement;
		}
		/// <summary>
		/// The dictionary of animations for this tile. 
		/// The first key describes the layer of the animation, the second key describes the BoundingBox2 of the animation.
		/// </summary>
		public Dictionary<int, Dictionary<AreaBox, SpritesheetAnimation>> Animations
		{
			get => animations;
		}

		/// <summary>
		/// Creates a new AnimatedTile based on the given XML element.
		/// </summary>
		/// <param name="animatedTileElement">The XML element representing the tile.</param>
		/// <returns>true if the tile was created successfully; false if a tile with the same ID already exists.</returns>
		public static new bool CreateTile(XmlElement animatedTileElement)
		{
			if (!UNIQUE_TILES.ContainsKey(animatedTileElement.GetAttribute("id")))
			{
				AnimatedTile tile = new(animatedTileElement);
				UNIQUE_TILES.Add(animatedTileElement.GetAttribute("id"), tile);
				return true;
			}
			return false;
		}

        /// <summary>
        /// Creates a new AnimatedTile based on the given XML element.
        /// </summary>
        /// <param name="animatedTileElement">The XML element representing the tile.</param>
        /// <exception cref="Exception">Throws an exception if the XML element is invalid or if the spritesheet, id, locations, or animations elements are missing.</exception>
        private AnimatedTile(XmlElement animatedTileElement) : base(animatedTileElement)
		{
            animations = new Dictionary<int, Dictionary<AreaBox, SpritesheetAnimation>>();
			foreach (XmlElement foo in animatedTileElement)
			{
				if (foo.Name.Equals("spritesheetAnimation"))
				{
                    spritesheetAnimationElement = foo;
					break;
                }
			}

			foreach (int key in LayerBoundingBoxes.Keys)
			{ 
				foreach (AreaBox coord in LayerBoundingBoxes[key]) 
				{
                    if (!Animations.TryGetValue(key, out var coordDict))
                    {
                        coordDict = new Dictionary<AreaBox, SpritesheetAnimation>();
                        Animations[key] = coordDict;
                    }

                    coordDict[coord] = new SpritesheetAnimation(this, SpritesheetAnimationElement);
                }
			}

			if (SpritesheetAnimationElement == null)
			{
				throw new Exception("Invalid AnimatedTile XmlElement: " + animatedTileElement);
			}
		}

		/// <summary>
		/// Removes the draw location of the tile from the specified layer.
		/// </summary>
		/// <param name="layer">The layer number to remove the draw location from.</param>
		public new void RemoveDrawLocation(int layer, AreaBox boundBox)
		{
			if (!IsInLayer(layer))
			{
				return;
			}
			DrawBoundingBoxes[layer].RemoveWhere(drawBoundBox => boundBox == drawBoundBox); //TODO could be optimized. probably. probably doesn't need to be.
			Animations[layer][boundBox].IsPaused = false;
		}
		/// <summary>
		/// Draws the tile on the specified layer using the current frame of each animation.
		/// </summary>
		/// <param name="gameTime">The current game time.</param>
		/// <param name="layer">The layer on which to draw the tile.</param>
		public new void Draw(GameTime gameTime, int layer)
		{
            DrawBoundingBoxes.TryGetValue(layer, out HashSet<AreaBox> layerDrawBoundingBox2);
			foreach (AreaBox boundBox in layerDrawBoundingBox2)
			{
				if (Camera.CameraViewBoundingBox.Intersects(boundBox))
				{
					Animations[layer][boundBox].DrawCurrentFrame(boundBox, Color.White);
				}
			}
		}
	}
}
