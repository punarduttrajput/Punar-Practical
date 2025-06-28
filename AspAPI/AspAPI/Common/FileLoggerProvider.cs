namespace AspAPI.Common
{
    using Microsoft.Extensions.Logging;

    /// <summary>  
    /// Provides a mechanism to log messages to a file.  
    /// Implements the <see cref="ILoggerProvider"/> interface.  
    /// </summary>  
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _filePath;

        /// <summary>  
        /// Initializes a new instance of the <see cref="FileLoggerProvider"/> class with the specified file path.  
        /// </summary>  
        /// <param name="filePath">The path of the file where logs will be written.</param>  
        public FileLoggerProvider(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>  
        /// Creates a logger instance for the specified category name.  
        /// </summary>  
        /// <param name="categoryName">The category name for the logger.</param>  
        /// <returns>An instance of <see cref="FileLogger"/>.</returns>  
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName, _filePath);
        }

        /// <summary>  
        /// Disposes resources used by the <see cref="FileLoggerProvider"/>.  
        /// </summary>  
        public void Dispose() { }
    }

    /// <summary>  
    /// Provides extension methods for adding file-based logging to the logging builder.  
    /// </summary>  
    public static class FileLoggerExtensions
    {
        /// <summary>  
        /// Adds a file logger provider to the logging builder.  
        /// </summary>  
        /// <param name="builder">The logging builder to which the file logger provider will be added.</param>  
        /// <param name="filePath">The path of the file where logs will be written.</param>  
        /// <returns>The updated <see cref="ILoggingBuilder"/> instance.</returns>  
        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, string filePath)
        {
            builder.AddProvider(new FileLoggerProvider(filePath));
            return builder;
        }
    }
}
