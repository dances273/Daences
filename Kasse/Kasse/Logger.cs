﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Kasse
{
   static class Logger
    {
            public static void Error(string message, string module)
            {
                WriteEntry(message, "error", module);
            }

            public static void Error(Exception ex, string module)
            {
                WriteEntry(ex.Message, "error", module);
            }

            public static void Warning(string message, string module)
            {
                WriteEntry(message, "warning", module);
            }

            public static void Info(string message, string module)
            {
                WriteEntry(message, "info", module);
            }

        private static void WriteEntry(string message, string type, string module)
        {
            string mappa = @"D:\Log";
            Directory.CreateDirectory(mappa);
            string LogFilePath = Path.Combine(mappa, "Kassa Log.txt");
      
            if (!File.Exists(LogFilePath))
                File.Create(LogFilePath);

                Trace.Listeners.Add(new TextWriterTraceListener(@"D:\Log\Kassa log.txt"));
                Trace.WriteLine(
                            string.Format("{0}\t,{1}\t,{2}\t,{3}",
                                          DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                          type,
                                          module,
                                          message));
                Trace.AutoFlush = true;
                Trace.Flush();
                //Trace.Close();
            }
        

    }
}
