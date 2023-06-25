namespace Fantasy.Engine.Drawing.View.Tasks.enums
{
    /// <summary>
    /// Defines different camera task types.
    /// </summary>
    public enum CameraTaskTypes
    {
        /// <summary>
        /// The follow IPosition type.
        /// </summary>
        FollowIPosition = 0,
        /// <summary>
        /// The free movement type.
        /// </summary>
        FreeMovement = 1,
        /// <summary>
        /// The pant to type.
        /// </summary>
        PanTo = 2,
        /// <summary>
        /// The zoom by increments type.
        /// </summary>
        ZoomByIncrements = 3,
        /// <summary>
        /// The zoom out, pan, zoom in type.
        /// </summary>
        ZoomOutPanZoomIn = 4,
    }
}
