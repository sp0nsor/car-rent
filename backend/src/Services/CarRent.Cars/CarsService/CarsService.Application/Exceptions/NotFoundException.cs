namespace CarsService.Application.Exceptions
{
    public class NotFoundException(string message)
        : Exception(message);
}
