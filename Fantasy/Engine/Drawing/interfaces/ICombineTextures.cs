using Fantasy.Engine.SubGameComponents.interfaces.collections;
using Fantasy.Engine.SubGameComponents.interfaces.components;
using System.Collections.Generic;

namespace Fantasy.Engine.Drawing.interfaces
{
	/// <summary>
	/// Represents a object with a combined texture.
	/// </summary>
	public interface ICombineTextures : ISubDrawableCollection
	{
		/// <summary>
		/// Gets a value indicating if this <c>ICombineTextures</c> should use its combined texture. 
		/// </summary>
		bool UseCombinedTexture { get; }

		/// <summary>
		/// Gets the <c>CombinedTexture</c>.
		/// </summary>
		CombinedTexture CombinedTexture { get; }

		/// <summary>
		/// Gets the dictionary <c>ISubDrawableComponent</c> lists in the <c>ISubDrawableCollection</c>, identified by keys of type <c>byte</c> which are excluded from the <c>CombinedTexture</c>.
		/// Lower keys have higher draw priority.
		/// 0 priority keys are reserved for invisible subcomponent.
		/// </summary>
		SortedDictionary<byte, List<ISubDrawableComponent>> ExcludedSubDrawableComponents { get; }
	}
}
