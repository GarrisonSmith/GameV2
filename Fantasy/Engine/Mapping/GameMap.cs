using Fantasy.Engine.ContentManagement;
using Fantasy.Engine.Drawing;
using Fantasy.Engine.Drawing.Animating;
using Fantasy.Engine.Drawing.interfaces;
using Fantasy.Engine.Mapping.Tiling;
using Fantasy.Engine.Physics;
using Fantasy.Engine.SubGameComponents.collections;
using Fantasy.Engine.SubGameComponents.components;
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
		private readonly string tileMapName;
		private readonly SortedDictionary<byte, MapLayer> mapLayers;

		/// <summary>
		/// Gets the name of the tile <c>GameMap</c>.
		/// </summary>
		public string TileMapName { get => tileMapName; }
		/// <summary>
		/// Gets the collection of layers in the <c>GameMap</c>.
		/// </summary>
		public SortedDictionary<byte, MapLayer> MapLayers { get => mapLayers; }


		public GameMap(XmlElement gameMapElement)
		{
			this.mapLayers = new SortedDictionary<byte, MapLayer>();
			this.tileMapName = gameMapElement.GetAttribute("name");
			if (string.IsNullOrEmpty(this.tileMapName))
			{
				throw new Exception("GameMap with no name loaded.");
			}

			foreach (XmlElement layerElement in gameMapElement.SelectSingleNode("Engine.Logic.Mapping.MapLayers"))
			{
				byte layer = byte.Parse(layerElement.GetAttribute("layer"));
				mapLayers.Add(layer, new MapLayer(layer));
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
					byte mapLayer = byte.Parse(locationElements.GetAttribute("layer"));
					Position position = null;
					foreach (XmlElement locationElement in locationElements)
					{
						IDefinedDrawable definedDrawable = null;
						position = new Position(int.Parse(locationElement.GetAttribute("x")), int.Parse(locationElement.GetAttribute("y")));

						if (animationElement == null)
						{
							definedDrawable = new DefinedDrawable(sheetBox.Value, spritesheet, position.GetPositionRef());
						}
						else
						{
							definedDrawable = new SpritesheetAnimation(sheetBox.Value, spritesheet, position.GetPositionRef(), animationElement);
						}

						if (definedDrawable == null)
						{
							throw new Exception("Tile: " + tileId + " contains no defined drawable.");
						}

						Tile tile = new(255, tileId, position, definedDrawable);
						//TODO add the tile to the correct mapLayer
					}
				}

			}
		}

		public override void CreateCombinedTexture()
		{
			throw new NotImplementedException();
		}

		public override void Initialize()
		{
			throw new System.NotImplementedException();
		}

		public override void Update(GameTime gameTime)
		{
			throw new System.NotImplementedException();
		}

		public override void Draw(GameTime gameTime, Color? color = null)
		{
			throw new System.NotImplementedException();
		}
	}
}
