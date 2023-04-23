namespace Fantasy.Engine.SubGameComponents.interfaces
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
