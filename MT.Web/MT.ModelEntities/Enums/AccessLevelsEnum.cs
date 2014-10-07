namespace MT.ModelEntities.Enums
{
    /// <summary>
    /// Describes the level of an access to the library resource.
    /// </summary>
    public enum AccessLevelsEnum
    {
        /// <summary>
        /// Доступний лише для власника.
        /// </summary>
        Private = 1,

        /// <summary>
        /// Доступний для власника та користувачів з якими у нього взаємний "follow".
        /// </summary>
        Protected = 2,

        /// <summary>
        /// Доступний для всіх користувачів.
        /// </summary>
        Public = 3
    }
}
