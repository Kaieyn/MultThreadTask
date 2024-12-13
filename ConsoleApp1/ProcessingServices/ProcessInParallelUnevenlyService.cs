using ConsoleApp1.ProcessingServices.Control;

namespace ConsoleApp1.ProcessingServices;

public class ProcessInParallelUnevenlyService : IProcessingService
{
    public void Processing<T>(T parameters)
    {
        if (parameters is ValueTuple<List<int>, int> tuple)
        {
            var (numbers, m) = tuple;
            var threads = new Thread[m];
            var totalSize = numbers.Count;
            var random = new Random();

            if (m > 1)
            {
                var ranges = new (int Start, int End)[m];
                var processed = 0;

                for (var i = 0; i < m - 1; i++)
                {
                    var remaining = totalSize - processed;
                    var taskSize = random.Next(1, remaining / (m - i));
                    ranges[i] = (processed, processed + taskSize);
                    processed += taskSize;
                }

                ranges[m - 1] = (processed, totalSize);

                for (var i = 0; i < m; i++)
                {
                    var start = ranges[i].Start;
                    var end = ranges[i].End;
                    threads[i] = new Thread(() =>
                        ProcessingServiceManager.GetService<ProcessChunkService>()
                            .Processing((numbers, start, end, new int?())));
                    threads[i].Start();
                }

                foreach (var thread in threads) thread.Join();
            }
            else
            {
                ProcessingServiceManager.GetService<ProcessChunkService>()
                    .Processing((numbers, 0, totalSize, new int?()));
            }
        }
        else
        {
            throw new ArgumentException("Переданы неправильные параметры");
        }
    }
}