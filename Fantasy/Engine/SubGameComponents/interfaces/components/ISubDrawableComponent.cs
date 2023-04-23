using Fantasy.Engine.Drawing.interfaces;

namespace Fantasy.Engine.SubGameComponents.interfaces.components
{
	/// <summary>
	/// Represents a component that can be drawn.
	/// </summary>
	public interface ISubDrawableComponent
	{
		/// <summary>
		/// Gets the defined drawable for this subcomponent.
		/// </summary>
		IDefinedDrawable DefinedDrawable { get; }
	}
}
