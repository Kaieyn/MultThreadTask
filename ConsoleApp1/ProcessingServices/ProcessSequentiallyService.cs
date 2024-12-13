using ConsoleApp1.ProcessingServices.Control;

namespace ConsoleApp1;

public class ProcessSequentiallyService : IProcessingService
{
    public void Processing<T>(T parameters)
    {
        if (parameters is ValueTuple<List<int>, int?> tuple)
        {
            var (numbers, mult) = tuple;
            mult ??= 2;
            foreach (var number in numbers)
            {
                var result = Math.Sqrt(number);
                //number * mult;
            }
        }
        else
        {
            throw new ArgumentException("Переданы неправильные параметры");
        }
    }
}