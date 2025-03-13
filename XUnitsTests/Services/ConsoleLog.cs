namespace XUnitsTests.Services
{
    public class ConsoleLog : IConsoleLog
    {
        public void Log(string message)
        {
          Console.WriteLine(message);
        }

        public void Warn(string message)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
        }
    }

}