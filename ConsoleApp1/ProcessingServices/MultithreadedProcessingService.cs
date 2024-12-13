using ConsoleApp1.ProcessingServices.Control;

namespace ConsoleApp1.ProcessingServices;

public class MultithreadedProcessingService : IProcessingService
{
    public void Processing<T>(T parameters)
    {
        if (parameters is ValueTuple<int, int, List<int>> tuple)
        {
            var (n, m, numbers) = tuple;
            var chunkSize = n / m;
            var threads = new Thread[m];

            for (var i = 0; i < m; i++)
            {
                var start = i * chunkSize;
                var end = i == m - 1 ? n : start + chunkSize;

                threads[i] = new Thread(() =>
                    ProcessingServiceManager.GetService<ProcessChunkService>()
                        .Processing((numbers, start, end, new int?())));
                threads[i].Start();
            }

            foreach (var thread in threads) thread.Join();
        }
        else
        {
            throw new ArgumentException("Переданы неправильные параметры");
        }
    }
}