namespace _7YA_HVOYA.Services.Contracts.Exceptions
{
    /// <summary>
    /// Запрашиваемая сущность не найдена
    /// </summary>
    public class FamilyHvoyaEntityNotFoundException<TEntity> : FamilyHvoyaNotFoundException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FamilyHvoyaEntityNotFoundException{TEntity}"/>
        /// </summary>
        public FamilyHvoyaEntityNotFoundException(Guid id)
            : base($"Сущность {typeof(TEntity)} c id = {id} не найдена.")
        {
        }
    }
}
