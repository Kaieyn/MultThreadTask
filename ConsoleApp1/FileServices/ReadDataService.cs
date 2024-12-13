using ConsoleApp1.FileServices.Control;

namespace ConsoleApp1.FileServices;

public class ReadDataService : IFileService
{
    public Task Do<T>(T parameters)
    {
        throw new NotImplementedException();
    }

    public void Do<T>(T parameters, out List<int> numbers)
    {
        numbers = [];
        if (parameters is string filePath)
        {
            Console.WriteLine("Начинается чтение файла");
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null) numbers.Add(int.Parse(line));
            }

            Console.WriteLine("Чтение завершено");
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }
        else
        {
            throw new ArgumentException("Переданы неправильные параметры");
        }
    }
}