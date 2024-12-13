using ConsoleApp1.FileServices.Control;

namespace ConsoleApp1.FileServices;

public class GenerateFileService : IFileService
{
    public async Task Do<T>(T parameters)
    {
        if (parameters is ValueTuple<int, string> tuple)
        {
            var (n, filePath) = tuple;
            using (var writer = new StreamWriter(filePath))
            {
                for (var i = 1; i <= n; i++) await writer.WriteLineAsync(i.ToString());
            }

            Console.WriteLine($"Файл с числами от 1 до {n} сгенерирован");
        }
    }

    public void Do<T>(T parameters, out List<int> numbers)
    {
        throw new NotImplementedException();
    }
}