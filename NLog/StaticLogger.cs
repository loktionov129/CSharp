using System;
using NLog;

namespace NetRore.Csharp.Cmd
{
    public static class StaticLogger
    {
        public static void LogException(Type type, string message, Exception exception)
        {
            LogManager.GetLogger(type.FullName).Error(exception);
        }

        public static void LogInfo(Type type, string message)
        {
            LogManager.GetLogger(type.FullName).Info(message);
        }
    }
}