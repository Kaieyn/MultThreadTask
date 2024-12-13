namespace ConsoleApp1.ProcessingServices.Control;

public class ProcessingServiceManager
{
    public static IProcessingService GetService<T>() where T : IProcessingService, new()
    {
        return new T();
    }
}