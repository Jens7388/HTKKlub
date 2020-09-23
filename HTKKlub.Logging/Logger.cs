using HTKKlub.Utilities;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace HTKKlub.Logging
{
    public static class Logger
    {
        /// <summary>
        /// Path to the logging file
        /// </summary>
        private static string logFilePath;

        /// <summary>
        /// Calls configure to load <see cref="logFilePath"/>
        /// </summary>
        static Logger()
        {
            Configure();
        }

        /// <summary>
        /// Loads the path from the config file,
        /// and assigns it to <see cref="logFilePath"/>
        /// </summary>
        private static void Configure()
        {
            // Retrives the logging file path from the configuration file
            logFilePath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
        }

        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            // Log Message
            WriteLog(message);
        }

        /// <summary>
        /// Logs a message asynchronously
        /// </summary>
        /// <param name="message"></param>
        public static async Task LogAsync(string message)
        {
            // Log Message
            await WriteLogAsync(message);
        }

        /// <summary>
        /// Logs an exception
        /// </summary>
        /// <param name="ex"></param>
        public static void Log(Exception ex)
        {
            // Get original Exception
            Exception original = ex.GetOriginalException();

            WriteLog(
                $"Exception: {ex.Message}\n" +
                $"Stacktrace:\n{ex.StackTrace}\n" +
                $"Source: {ex.Source}\n" +
                $"InnerException: {original.Message} \n" +
                $"Stracktrace\n{original.StackTrace}\n" +
                $"Source: {original.Source}\n");
        }

        /// <summary>
        /// Logs an exception asynchronously
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static async Task LogAsync(Exception exception)
        {
            // Get original Exception
            Exception innerException = exception.GetOriginalException();

            await WriteLogAsync(
                $"Exception: {exception.Message}\n" +
                $"Stacktrace:\n{exception.StackTrace}\n" +
                $"Source: {exception.Source}\n" +
                $"InnerException: {innerException.Message} \n" +
                $"Stracktrace\n{innerException.StackTrace}\n" +
                $"Source: {innerException.Source}\n");
        }

        /// <summary>
        /// Logs the <see cref="string"/> parameter value
        /// to the logging file in <see cref="logFilePath"/>
        /// </summary>
        /// <param name="logMessage"></param>
        private static void WriteLog(string logMessage)
        {
            // Append log message with a timestamp to the log file
            File.AppendAllText(
                logFilePath,
                $"[{DateTime.UtcNow}]\n" +
                $"{logMessage}");
        }

        /// <summary>
        /// Logs the <see cref="string"/> parameter value asynchronously
        /// to the logging file in <see cref="logFilePath"/>
        /// </summary>
        /// <param name="logMessage"></param>
        private static async Task WriteLogAsync(string logMessage)
        {
            // Append log message with a timestamp to the log file asynchronously
            await File.AppendAllTextAsync(
                logFilePath,
                $"[{DateTime.Now}]\n" +
                $"{logMessage}\n");
        }
    }
}
