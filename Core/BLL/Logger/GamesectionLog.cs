using System;
using System.IO;

namespace Core.BLL.Logger
{
    public static class GamesectionLog
    {
        public static void LogAdd(string message, LogType logType)
        {
            FileStream fileStream = new FileStream("GamesectionLogs.txt", FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(message);
            writer.Flush();
            writer.Close();
        }
    }
    public enum LogType
    {
        Insert,
        Update,
        Delete,
        Error,
        Notfound,
        NonValidation,
        Warning
    }
}
