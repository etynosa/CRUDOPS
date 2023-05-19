namespace CRUDOPS.Infastructure.Extensions
{
    public class ConsoleLogger: ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null; // Not implemented for this example
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true; // Enable logging for all levels
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                string message = formatter(state, exception);
                Console.WriteLine($"[{DateTime.Now}] [{logLevel}] {message}");
            }
        }
    }
}
