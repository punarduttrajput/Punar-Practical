namespace AspAPI.Common
{
    using Microsoft.Extensions.Logging;

    /// <summary>  
    /// A logger implementation that writes log messages to a specified file.  
    /// </summary>  
    public class FileLogger : ILogger
    {
        private readonly string _filePath;
        private readonly string _categoryName;

        /// <summary>  
        /// Initializes a new instance of the <see cref="FileLogger"/> class.  
        /// </summary>  
        /// <param name="categoryName">The category name for the logger.</param>  
        /// <param name="filePath">The file path where log messages will be written.</param>  
        public FileLogger(string categoryName, string filePath)
        {
            _categoryName = categoryName;
            _filePath = filePath;
        }

        /// <summary>  
        /// Begins a logical operation scope.  
        /// </summary>  
        /// <typeparam name="TState">The type of the state.</typeparam>  
        /// <param name="state">The state to begin scope for.</param>  
        /// <returns>An IDisposable that ends the scope on disposal.</returns>  
        public IDisposable? BeginScope<TState>(TState state) => null;

        /// <summary>  
        /// Checks if the logger is enabled for the specified log level.  
        /// </summary>  
        /// <param name="logLevel">The log level to check.</param>  
        /// <returns>True if the logger is enabled; otherwise, false.</returns>  
        public bool IsEnabled(LogLevel logLevel) => true;

        /// <summary>  
        /// Logs a message with the specified log level and other details.  
        /// </summary>  
        /// <typeparam name="TState">The type of the state.</typeparam>  
        /// <param name="logLevel">The log level of the message.</param>  
        /// <param name="eventId">The event ID associated with the log message.</param>  
        /// <param name="state">The state associated with the log message.</param>  
        /// <param name="exception">The exception related to the log message, if any.</param>  
        /// <param name="formatter">A function to format the log message.</param>  
        public void Log<TState>(LogLevel logLevel, EventId eventId,
            TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            var message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {_categoryName}: {formatter(state, exception)}";
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}
