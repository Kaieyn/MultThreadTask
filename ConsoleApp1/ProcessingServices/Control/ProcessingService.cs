namespace ConsoleApp1.ProcessingServices.Control;

public interface IProcessingService
{
    public void Processing<T>(T parameters);
}