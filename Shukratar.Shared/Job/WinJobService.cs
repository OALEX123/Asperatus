using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Shukratar.Shared.Job
{
    /// <summary>
    /// Job service runner (hosted on win)
    /// </summary>
    public class WinJobService : IJobService
    {
        private readonly string _serviceProcessName;
        private readonly string _serviceExecutionPath;
        private readonly Logger logger = new Logger();

        public WinJobService(string serviceProcessName, string serviceExecutionPath)
        {
            _serviceProcessName = serviceProcessName;
            _serviceExecutionPath = serviceExecutionPath;
        }

        public Job GetState()
        {
            bool isRunning = Process.GetProcessesByName(_serviceProcessName).Any();

            return new Job
            {
                RunState = isRunning ? JobRunState.Running : JobRunState.Stopped
            };
        }

        public void Run()
        {
            try
            {
                using (var process = new Process { EnableRaisingEvents = false })
                {
                    string executionFilePath = $"{Path.Combine(_serviceExecutionPath, _serviceProcessName)}.exe";
                    logger.Log($"Starting crawler process with params: {executionFilePath}");
                    process.StartInfo.FileName = executionFilePath;
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Process failed with error {ex.GetBaseException().Message}");
                throw ex;
            }
        }

        public class Logger
        {
            private const string Path = @"D:\123.txt";

            public void Log(string message)
            {
                Write($"Message: {message}");
            }

            public void Error(string message)
            {
                Write($"Error: {message}");
            }

            private void Write(string message)
            {
                using (var writer = new StreamWriter(Path, true))
                {
                    writer.WriteLine($"{DateTime.Now} {message}");
                }
            }
        }
    }
}