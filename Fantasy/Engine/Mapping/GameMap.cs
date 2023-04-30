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
		/// <param name="gameMapElement">The game map element.</param>
		/// <param name="isVisible">A value indicating whether this <c>GameMap</c> is visible or not.</param>
		/// <param name="isActive">A value indicating if this <c>GameMap</c> is being updated or not.</param>
		/// <param name="drawOrder">The draw order.</param>
		/// <param name="updateOrder">The update order.</param>
		/// <exception cref="Exception">Thrown if the <c>gameMapElement</c> contains no name attribute.</exception>
		public GameMap(XmlElement gameMapElement, bool isVisible, bool isActive, byte drawOrder, byte updateOrder) : base(isVisible, isActive, drawOrder, updateOrder)
		{
			this.tileMapName = gameMapElement.GetAttribute("name");
			this.gameMapElement = gameMapElement;
			if (string.IsNullOrEmpty(this.tileMapName))
			{
				throw new Exception("GameMap with no name loaded.");
			}
		}
		/// <summary>
		/// Creates a new <c>GameMap</c> with the provided parameters.
		/// </summary>
		/// <param name="gameMapElement">The game map element.</param>
		/// <exception cref="Exception">Thrown if the <c>gameMapElement</c> contains no name attribute.</exception>
		public GameMap(XmlElement gameMapElement)
		{
			this.tileMapName = gameMapElement.GetAttribute("name");
			this.gameMapElement = gameMapElement;
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
			}

			foreach (XmlElement tileElement in gameMapElement.GetElementsByTagName("Engine.Logic.Mapping.Tiling.Tile"))
			{
				string tileId = tileElement.GetAttribute("tileId");
				Texture2D spritesheet = null;
				Rectangle? sheetBox = null;
				XmlElement animationElement = null;
				List<XmlElement> layerLocationElements = new();

				foreach (XmlElement foo in tileElement)
				{
					if (tileElement.Name.Equals("spritesheet"))
					{
						spritesheet = TextureManager.GetSpritesheet(foo.InnerText);
					}
					else if (tileElement.Name.Equals("sheetCoordinates"))
					{
						sheetBox = new Rectangle(int.Parse(foo.GetAttribute("col")), int.Parse(foo.GetAttribute("row")), Tile.TILE_DIMENSION, Tile.TILE_DIMENSION);
					}
					else if (tileElement.Name.Equals("spritesheetAnimation"))
					{
						animationElement = foo;
					}
					else if (tileElement.Name.Equals("locations"))
					{
						layerLocationElements.Add(foo);
					}
				}

				if (string.IsNullOrEmpty(tileId))
				{
					throw new Exception("Tile with no tileId provided: " + this.tileMapName);
				}
				else if (spritesheet == null)
				{
					throw new Exception("Tile: " + tileId + " contains no spritesheet or has a invalid spritesheet name.");
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
							definedDrawable = new DefinedDrawable(sheetBox.Value, spritesheet, positionRef);
						}
						else
						{
							definedDrawable = new SpritesheetAnimation(sheetBox.Value, spritesheet, positionRef, animationElement);
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
