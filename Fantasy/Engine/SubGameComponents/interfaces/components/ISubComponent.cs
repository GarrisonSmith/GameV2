namespace Fantasy.Engine.SubGameComponents.interfaces.components
{
    /// <summary>
    /// Represents a subcomponent that can updated inside a <c>ISubComponentCollection</c>
    /// </summary>
    public interface ISubComponent
    {
        /// <summary>
        /// Initializes the subcomponent.
        /// </summary>
        void Initialize();
    }
}
