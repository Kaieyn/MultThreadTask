namespace ConsoleApp1.FileServices.Control;

public class FileServiceManager
{
    public static IFileService GetService<T>() where T : IFileService, new()
    {
        return new T();
    }
}