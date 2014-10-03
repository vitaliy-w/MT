namespace MT.ModelEntities.Enums
{
    public enum AccessLevelsEnum
    {
        /// <summary>
        /// AccessLevelsEnum - вказує на рівень доступу до сутності LibraryResource.
        /// Private = 1   - доступний лише для власника.
        /// Protected = 2 - доступний для власника та користувачів з якими у нього взаємний "follow".
        /// Public = 3    - доступний для всіх користувачів.
        /// </summary>
        Private = 1,
        Protected = 2,
        Public = 3
    }
}
