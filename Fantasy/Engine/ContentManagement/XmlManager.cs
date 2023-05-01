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
		/// Gets or sets the XMLDocuments.
		/// </summary>
		private static Dictionary<string, XmlDocument> XMLDocuments { get; set; }

		/// <summary>
		/// Loads the XMLDocuments.
		/// </summary>
		/// <param name="game">The game.</param>
		public static void LoadXMLDocuments(Game game)
		{
			LoadTileMaps(game);
		}

		/// <summary>
		/// Loads the TileMaps.
		/// </summary>
		/// <param name="game">The game.</param>
		private static void LoadTileMaps(Game game)
		{
			List<string> documentNames = new List<string>()
			{
				"test_map",
				"animated_test_map"
			};

			XMLDocuments = new Dictionary<string, XmlDocument>();
			foreach (string documentName in documentNames)
			{ 
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(Path.Combine(game.Content.RootDirectory, "tilemaps", documentName + ".xml"));
				XMLDocuments.Add(documentName, xmlDocument);
			}
		}

		/// <summary>
		/// Gets the XmlDocument with the provided name if it exists.
		/// </summary>
		/// <param name="xMLDocumentName">The name of the XmlDocument to get.</param>
		/// <returns>The XmlDocument.</returns>
		/// <exception cref="Exception">Thrown if a XmlDocument with the provided name does not exist.</exception>
		public static XmlDocument GetXMLDocument(string xMLDocumentName)
		{
			if (XMLDocuments.TryGetValue(xMLDocumentName, out XmlDocument xMLDocument))
			{
				return xMLDocument;
			}
			throw new Exception("XML Document with name " + xMLDocumentName + " was not found.");
		}
	}
}
