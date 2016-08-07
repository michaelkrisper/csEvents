using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var c = new Client();
            c.Finished += () => Console.WriteLine("Finished.");
            c.DoWork();
        }
    }

    public class Client
    {
        public event Action Finished;
        public void DoWork()
        {
            Console.WriteLine("Doing work.");
            Finished();
        }
    }
}
