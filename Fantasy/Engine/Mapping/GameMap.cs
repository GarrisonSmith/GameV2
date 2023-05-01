using Fantasy.Engine.ContentManagement;
using Fantasy.Engine.Drawing;
using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.Mapping.Tiling;
using Fantasy.Engine.Physics;
using Fantasy.Engine.SubGameComponents.collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Fantasy.Engine.Mapping
{
	/// <summary>
	/// Represents a <c>GameMap</c> consisting of multiple <c>MapLayers</c>.
	/// </summary>
	public class GameMap : SubDrawableUpdateableCollection
	{
		protected readonly string tileMapName;
		protected readonly XmlElement gameMapElement;
		protected SortedDictionary<byte, MapLayer> mapLayers;

		/// <summary>
		/// Gets the name of the tile <c>GameMap</c>.
		/// </summary>
		public string TileMapName { get => this.tileMapName; }
		/// <summary>
		/// Gets the collection of layers in the <c>GameMap</c>.
		/// </summary>
		public SortedDictionary<byte, MapLayer> MapLayers { get => this.mapLayers; protected set => this.mapLayers = value; }

		/// <summary>
		/// Creates a new <c>GameMap</c> with the provided parameters.
		/// </summary>
		/// <param name="gameMapDocument">The game map document.</param>
		/// <param name="isVisible">A value indicating whether this <c>GameMap</c> is visible or not.</param>
		/// <param name="isActive">A value indicating if this <c>GameMap</c> is being updated or not.</param>
		/// <param name="drawOrder">The draw order.</param>
		/// <param name="updateOrder">The update order.</param>
		/// <exception cref="Exception">Thrown if the <c>gameMapElement</c> contains no name attribute.</exception>
		public GameMap(XmlDocument gameMapDocument, bool isVisible, bool isActive, byte drawOrder, byte updateOrder) : base(isVisible, isActive, drawOrder, updateOrder)
		{
			this.gameMapElement = gameMapDocument.DocumentElement;
			this.tileMapName = this.gameMapElement.GetAttribute("name");
			if (string.IsNullOrEmpty(this.tileMapName))
			{
				throw new Exception("GameMap with no name loaded.");
			}
		}
		/// <summary>
		/// Creates a new <c>GameMap</c> with the provided parameters.
		/// </summary>
		/// <param name="gameMapDocument">The game map document.</param>
		/// <exception cref="Exception">Thrown if the <c>gameMapElement</c> contains no name attribute.</exception>
		public GameMap(XmlDocument gameMapDocument)
		{
			this.gameMapElement = gameMapDocument.DocumentElement;
			this.tileMapName = this.gameMapElement.GetAttribute("name");
			if (string.IsNullOrEmpty(this.tileMapName))
			{
				throw new Exception("GameMap with no name loaded.");
			}
		}

		/// <summary>
		/// Initializes the <c>MapLayer</c>.
		/// </summary>
		public override void Initialize()
		{
			base.Initialize();
			this.mapLayers = new SortedDictionary<byte, MapLayer>();

			foreach (XmlElement layerElement in gameMapElement.SelectSingleNode("Engine.Logic.Mapping.MapLayers"))
			{
				byte layer = byte.Parse(layerElement.GetAttribute("layer"));
				MapLayer mapLayer = new(layer);
				mapLayer.Initialize();
				mapLayers.Add(layer, mapLayer);
				this.AddSubComponent(mapLayer);
			}

			foreach (XmlElement tileElement in gameMapElement.GetElementsByTagName("Engine.Logic.Mapping.Tiling.Tile"))
			{
				string tileId = tileElement.GetAttribute("tileId");
				Texture2D spriteSheet = null;
				Rectangle? sheetBox = null;
				XmlElement animationElement = null;
				List<XmlElement> layerLocationElements = new();

				foreach (XmlElement innerTileElement in tileElement)
				{
					if (innerTileElement.Name.Equals("spritesheet"))
					{
						spriteSheet = TextureManager.GetSpriteSheet(innerTileElement.InnerText);
					}
					else if (innerTileElement.Name.Equals("sheetCoordinates"))
					{
						sheetBox = new Rectangle(int.Parse(innerTileElement.GetAttribute("col")) * Tile.TILE_DIMENSION, int.Parse(innerTileElement.GetAttribute("row")) * Tile.TILE_DIMENSION, Tile.TILE_DIMENSION, Tile.TILE_DIMENSION);
					}
					else if (innerTileElement.Name.Equals("spritesheetAnimation"))
					{
						animationElement = innerTileElement;
					}
					else if (innerTileElement.Name.Equals("locations"))
					{
						layerLocationElements.Add(innerTileElement);
					}
				}

				if (string.IsNullOrEmpty(tileId))
				{
					throw new Exception("Tile with no tileId provided: " + this.tileMapName);
				}
				else if (spriteSheet == null)
				{
					throw new Exception("Tile: " + tileId + " contains no spriteSheet or has a invalid spriteSheet name.");
				}
				else if (!sheetBox.HasValue)
				{
					throw new Exception("Tile: " + tileId + " contains no sheetCoordinates.");
				}
				else if (layerLocationElements.Count == 0)
				{
					throw new Exception("Tile: " + tileId + " contains no location.");
				}

				foreach (XmlElement locationElements in layerLocationElements)
				{
					byte layer = byte.Parse(locationElements.GetAttribute("layer"));
					foreach (XmlElement locationElement in locationElements)
					{
						IDefinedDrawable definedDrawable = null;
						Position position = new(int.Parse(locationElement.GetAttribute("x")), int.Parse(locationElement.GetAttribute("y")));
						PositionRef positionRef = position.GetPositionRef(); 

						if (animationElement == null)
						{
							definedDrawable = new DefinedDrawable(sheetBox.Value, spriteSheet, positionRef);
						}
						else
						{
							definedDrawable = new SpriteSheetAnimation(sheetBox.Value, spriteSheet, positionRef, animationElement);
						}

						if (definedDrawable == null)
						{
							throw new Exception("Tile: " + tileId + " contains no defined drawable.");
						}

						Tile tile = new(definedDrawable is Animation? (byte)254 : (byte)255, tileId, position, definedDrawable);
						if (this.MapLayers.TryGetValue(layer, out MapLayer map))
						{
							map.TileCollection.AddTile(tile);
						}
						else
						{
							throw new Exception("Tile: " + tileId + " exists on a layer that doesn't exist.");
						}
					}
				}
			}
		}
	}
}
