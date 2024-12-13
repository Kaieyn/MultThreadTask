namespace ConsoleApp1.FileServices.Control;

public interface IFileService
{
    Task Do<T>(T parameters);
    void Do<T>(T parameters, out List<int> numbers);
}