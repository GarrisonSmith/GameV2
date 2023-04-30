using Fantasy.Engine.Drawing.interfaces;

namespace Fantasy.Engine.SubGameComponents.interfaces
{
    /// <summary>
    /// Represents something that can be drawn.
	/// </summary>
    public interface ISubDrawable
    {
		/// <summary>
		/// Gets a value indicating whether this subcomponent is animated or not.
		/// </summary>
		bool IsAnimated { get; }

		/// <summary>
		/// Gets the defined drawable for this subcomponent.
		/// </summary>
		IDefinedDrawable DefinedDrawable { get; }
	}
}
