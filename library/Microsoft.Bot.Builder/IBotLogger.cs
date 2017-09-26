﻿using System;

namespace Microsoft.Bot.Builder
{
    public interface IBotLogger
    {
        void Information(string message);
        void Error(string message);
    }

    public class NullLogger : IBotLogger
    {
        public void Information(string message) { }
        public void Error(string message) { }
    }

    public class TraceLogger : IBotLogger
    {
        public void Information(string message)
        {
            System.Diagnostics.Trace.TraceInformation(message);
        }

        public void Error(string message)
        {
            System.Diagnostics.Trace.TraceError(message);
        }
    }

    public class ConsoleLogger : IBotLogger
    {
        public bool LoggingEnabled { get; set; } = false;

        public void Information(string message)
        {
            if (!LoggingEnabled)
                return;

            Console.WriteLine("Trace Info:" + message);
        }

        public void Error(string message)
        {
            if (!LoggingEnabled)
                return;

            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            try
            {
                Console.WriteLine("Trace Error:" + message);
            }
            finally
            {
                Console.ForegroundColor = originalColor;
            }
            
        }
    }
}
