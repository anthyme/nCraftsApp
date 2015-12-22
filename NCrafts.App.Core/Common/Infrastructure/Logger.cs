using System;
using System.Diagnostics;

namespace NCrafts.App.Core.Common.Infrastructure
{
    public delegate void Log(string message);
    public delegate void LogError(Exception exepction);

    public class Logger
    {
        public static Log CreateLog()
        {
            return message => Debug.WriteLine(message);
        }

        public static LogError CreateLogError(Log log)
        {
            return ex => log($"{ex.Message}\n{ex.StackTrace}");
        }
    }
}
