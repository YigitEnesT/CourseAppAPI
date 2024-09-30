namespace Entities.Exceptions
{
    public sealed class CourseNotFoundException : NotFoundException
    {
        public CourseNotFoundException(int id) : base($"The course with id : {id} could not found.")
        {
        }
    }
}
