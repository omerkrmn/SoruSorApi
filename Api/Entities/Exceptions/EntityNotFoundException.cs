namespace Entities.Exceptions
{
    public sealed class EntityNotFoundException<T> : NotFoundException
        where T : class
    {
        public EntityNotFoundException(int id) : base($"The {typeof(T).Name} with ID: {id} could not be found.")
        {
        }
    }
}
