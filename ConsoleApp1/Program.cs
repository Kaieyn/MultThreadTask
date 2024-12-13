using ConsoleApp1.FileServices;
using ConsoleApp1.FileServices.Control;
using ConsoleApp1.ProcessingServices;
using ConsoleApp1.ProcessingServices.Control;

namespace ConsoleApp1;

internal class Program
{
    public static async Task Main()
    {
        Console.Write("Введите число N: ");
        var tryN = int.TryParse(Console.ReadLine(), out var n);

        Console.Write("Введите количество потоков M: ");
        var tryM = int.TryParse(Console.ReadLine(), out var m);

        if (!(tryN && tryM))
        {
            Console.WriteLine("\nВведены некорректные данные ;(");
            return;
        }

        Console.WriteLine("-------------------------------------------------------------------------------------");

        var filePath = "numbers.txt";
        int? mult = 4;
        List<int> numbers;

        Console.WriteLine("Начинается генерация файла");
        await FileServiceManager.GetService<GenerateFileService>().Do((n, filePath));

        FileServiceManager.GetService<ReadDataService>().Do(filePath, out numbers);

        using (_ = new SWD("Последовательная обработка"))
        {
            ProcessingServiceManager.GetService<ProcessSequentiallyService>().Processing((numbers, mult));
        }

        using (_ = new SWD("Многопоточная обработка"))
        {
            ProcessingServiceManager.GetService<MultithreadedProcessingService>().Processing((n, m, numbers));
        }

        using (_ = new SWD("Многопоточная обработка с неравномерным распределением"))
        {
            ProcessingServiceManager.GetService<ProcessInParallelUnevenlyService>().Processing((numbers, m));
        }
    }
}