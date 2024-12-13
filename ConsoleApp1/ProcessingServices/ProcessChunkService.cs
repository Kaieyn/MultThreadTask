using ConsoleApp1.ProcessingServices.Control;

namespace ConsoleApp1.ProcessingServices;

public class ProcessChunkService : IProcessingService
{
    public void Processing<T>(T parameters)
    {
        if (parameters is ValueTuple<List<int>, int, int, int?> tuple)
        {
            var (numbers, start, end, mult) = tuple;
            mult ??= 2;
            for (var i = start; i < end; i++)
            {
                var sqrtResult = Math.Sqrt(numbers[i]);
                //numbers[i] * Mult;
            }
        }
        else
        {
            throw new ArgumentException("Переданы неправильные параметры");
        }
    }
}