using System.Diagnostics;

namespace ConsoleApp1;

class SWD : IDisposable
{
    private readonly Stopwatch _sw = new Stopwatch();
    private readonly string _work;

    public SWD(string work)
    {
        _work = work;
        Console.WriteLine("Начинается:" + _work + "\n");
        _sw.Start();
    }

    public void Dispose()
    {
        _sw.Stop();
        Console.WriteLine(_work + " закончилась за " + _sw.ElapsedMilliseconds + " мс.");
        Console.WriteLine("-------------------------------------------------------------------------------------");
    }
}