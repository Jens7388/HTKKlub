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
            logFilePath = "C:/Users/jens7388/Desktop/log.txt";
        }

        /// <summary>
        /// Logs a message asynchronously
        /// </summary>
        /// <param name="message"></param>
        public static async Task LogAsync(string message)
        {
            await WriteLogAsync(message);
        }

        /// <summary>
        /// Logs an exception asynchronously
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static async Task LogAsync(Exception exception)
        {
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
        /// Logs the <see cref="string"/> parameter value asynchronously
        /// to the logging file in <see cref="logFilePath"/>
        /// </summary>
        /// <param name="logMessage"></param>
        private static async Task WriteLogAsync(string logMessage)
        {
            await File.AppendAllTextAsync(
                logFilePath,
                $"[{DateTime.Now}]\n" +
                $"{logMessage}\n");
        }
    }
}