using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Fantasy.Engine.ContentManagement
{
	public static class XmlManager
	{
		/// <summary>
		/// Gets or sets the game.
		/// </summary>
		private static Game Game { get; set; }

		/// <summary>
		/// Gets or sets the XMLDocuments.
		/// </summary>
		private static Dictionary<string, XmlDocument> XMLDocuments { get; set; }

		/// <summary>
		/// Initializes the <c>XmlManager</c>.
		/// </summary>
		/// <param name="game">The game.</param>
		public static void Initialize(Game game) 
		{
			Game = game;
			XMLDocuments = new Dictionary<string, XmlDocument>();
		}

		/// <summary>
		/// Loads the XMLDocuments.
		/// </summary>
		public static void LoadXMLDocuments()
		{
			LoadTileMaps();
		}

		/// <summary>
		/// Loads the TileMaps.
		/// </summary>
		private static void LoadTileMaps()
		{
			List<string> documentNames = new()
			{
				"test_map",
				"animated_test_map"
			};

			foreach (string documentName in documentNames)
			{
				if (XMLDocuments.ContainsKey(documentName))
				{
					continue;
				}

				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(Path.Combine(Game.Content.RootDirectory, "tilemaps", documentName + ".xml"));
				XMLDocuments.Add(documentName, xmlDocument);
			}
		}

		/// <summary>
		/// Gets the XmlDocument with the provided name if it exists.
		/// </summary>
		/// <param name="documentName">The name of the XmlDocument to get.</param>
		/// <returns>The XmlDocument.</returns>
		/// <exception cref="Exception">Thrown if a XmlDocument with the provided name does not exist.</exception>
		public static XmlDocument GetXMLDocument(string documentName)
		{
			if (XMLDocuments.TryGetValue(documentName, out XmlDocument xMLDocument))
			{
				return xMLDocument;
			}

			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(Path.Combine(Game.Content.RootDirectory, "tilemaps", documentName + ".xml"));
				XMLDocuments.Add(documentName, xmlDocument);
				return xmlDocument;
			}
			catch
			{
				throw new Exception("XML Document with name " + documentName + " was not found.");
			}
		}
	}
}
