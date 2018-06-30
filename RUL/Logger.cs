using System;
using System.IO;

namespace RUL
{
    public class Logger
    {   private static object WriterLocker = new object();
        public static readonly object FileWriterLocker = new object();

        private static string LogPath = $"{Directory.GetCurrentDirectory().ToString()}/Logs/{GetDate()}.log";

        const ConsoleColor InfoColor = ConsoleColor.White;
        const ConsoleColor WarnColor = ConsoleColor.Yellow;
        const ConsoleColor ErrorColor = ConsoleColor.Red;
        const ConsoleColor DebugColor = ConsoleColor.Cyan;

        /// <summary>
        /// 初始化Logger
        /// </summary>
        public static void Init()
        {
            Logger.Info($"Logs will be saved in \"{LogPath}\"");
        }

        /// <summary>
        /// 输出Info类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Info(string msg)
        {
            msg = $"{GetTime()}[Info]{msg}";
            Writer(InfoColor, msg);
        }

        /// <summary>
        /// 输出Warn类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Warn(string msg)
        {
            msg = $"{GetTime()}[Warn]{msg}";
            Writer(WarnColor, msg);
        }

        /// <summary>
        /// 输出Error类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Error(string msg)
        {
            msg = $"{GetTime()}[Error]{msg}";
            Writer(ErrorColor, msg);
        }
        /// <summary>
        /// 输出Debug类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Debug(string msg)
        {
            msg = $"{GetTime()}[Debug]{msg}";
            Writer(DebugColor, msg);
        }

        /// <summary>
        /// 直接把日志写入文件而不展示给用户
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void WriteToFile(string msg)
        {
            msg = $">{msg}";
            FileWriter(msg);
        }

        private static void Writer(ConsoleColor color, string msg)
        {
            lock (WriterLocker)
            {
                var srcColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.WriteLine(msg);
                Console.ForegroundColor = srcColor;
                FileWriter(msg);
            }
        }

        private static void FileWriter(string msg)
        {
            if (!Directory.Exists($"{Directory.GetCurrentDirectory().ToString()}/Logs/"))
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory().ToString()}/Logs/");
                Logger.Warn("Logs directory is missing, will create now.");
            }

            lock (FileWriterLocker)
            {
                StreamWriter sw = new StreamWriter(LogPath, true);
                sw.WriteLine(msg);
                sw.Flush();
                sw.Close();
            }
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <returns>目前时间，格式：[YYYY-MM-DD hh:mm:ss]</returns>
        public static string GetTime()
        {
            string Year = DateTime.Now.Year.ToString();
            string Month = DateTime.Now.Month.ToString();
            string Day = DateTime.Now.Day.ToString();
            string Hour = DateTime.Now.Hour.ToString();
            string Minute = DateTime.Now.Minute.ToString();
            string Second = DateTime.Now.Second.ToString();

            switch (Month)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Month = "0" + Month;
                    break;
                default:
                    break;
            }

            switch (Day)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Day = "0" + Day;
                    break;
                default:
                    break;
            }

            switch (Hour)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Hour = "0" + Hour;
                    break;
                default:
                    break;
            }

            switch (Minute)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Minute = "0" + Minute;
                    break;
                default:
                    break;
            }

            switch (Second)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Second = "0" + Second;
                    break;
                default:
                    break;
            }

            return $"[{Year}-{Month}-{Day} {Hour}:{Minute}:{Second}]";
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <returns>目前日期，格式：YYYY-MM-DD</returns>
        public static string GetDate()
        {
            string Year = DateTime.Now.Year.ToString();
            string Month = DateTime.Now.Month.ToString();
            string Day = DateTime.Now.Day.ToString();

            switch (Month)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Month = "0" + Month;
                    break;
                default:
                    break;
            }

            switch (Day)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Day = "0" + Day;
                    break;
                default:
                    break;
            }
            return $"{Year}-{Month}-{Day}";
        }
    }
}
