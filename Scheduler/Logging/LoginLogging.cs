using System;
using System.IO;
using System.Reflection;

namespace Scheduler.Logging
{
    internal class LoginLogging
    {
        public static void LogUserLogin(string logMessage)
        {
            try
            {
                // Get the directory where the assembly is located
                string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // Go up two directories from the assembly location
                string parentDirectory = Path.Combine(assemblyLocation, "..", "..");

                // Set the path to the Logs folder within the parent directory.
                string logFolderPath = Path.Combine(parentDirectory, "Logs");

                // Ensure that the directory exists, create if it doesn't.
                Directory.CreateDirectory(logFolderPath);

                // Set the path for the log file within the Logs folder.
                string logFilePath = Path.Combine(logFolderPath, "Login_History.txt");

                // Print out the paths for diagnostics.
                Console.WriteLine($"Log Folder Path: {logFolderPath}");
                Console.WriteLine($"Log File Path: {logFilePath}");

                // Write the log message to the file.
                using (StreamWriter outputFile = new StreamWriter(logFilePath, true))
                {
                    outputFile.WriteLine($"{DateTime.UtcNow.ToString()} (UTC) - {logMessage}");
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the logging process.
                Console.WriteLine($"Error while logging: {ex.Message}");
            }
        }
    }
}
