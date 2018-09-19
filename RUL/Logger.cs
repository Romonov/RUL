/**
 * RUL.Logger
 * Ver: 1.0.3
 * Date: 2018.7.1
 */

using System;
using System.IO;

namespace RUL
{
    /// <summary>
    /// Logger
    /// </summary>
    public class Logger
    {   private static object WriterLocker = new object();
        public static readonly object FileWriterLocker = new object();

        private static string NowDate = GetDate();

        private static string LogPath = $"{Directory.GetCurrentDirectory().ToString()}\\Logs\\{GetDate()}.log";

        const ConsoleColor InfoColor = ConsoleColor.White;
        const ConsoleColor WarnColor = ConsoleColor.Yellow;
        const ConsoleColor ErrorColor = ConsoleColor.Red;
        const ConsoleColor DebugColor = ConsoleColor.Cyan;

        /// <summary>
        /// 初始化Logger
        /// </summary>
        public static void Init()
        {
            Info($"Logs will be saved in \"{LogPath}\"");
        }

        /// <summary>
        /// 输出Info类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Info<T>(T str)
        {
            string msg = $"{GetTime()}[Info]{str.ToString()}";
            Writer(InfoColor, msg.ToString());
        }

        /// <summary>
        /// 输出Warn类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Warn<T>(T str)
        {
            string msg = $"{GetTime()}[Warn]{str.ToString()}";
            Writer(WarnColor, msg.ToString());
        }

        /// <summary>
        /// 输出Error类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Error<T>(T str)
        {
            string msg = $"{GetTime()}[Error]{str.ToString()}";
            Writer(ErrorColor, msg);
        }

        /// <summary>
        /// 输出Debug类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void Debug<T>(T str)
        {
            string msg = $"{GetTime()}[Debug]{str.ToString()}";
            Writer(DebugColor, msg);
        }

        /// <summary>
        /// 直接把日志写入文件而不展示给用户
        /// </summary>
        /// <param name="msg">日志内容</param>
        public static void WriteToFile<T>(T str)
        {
            string msg = $"{str.ToString()}";
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

        // Todo: 当文件大于2M时更换文件
        private static void FileWriter(string msg)
        {
            if (!Directory.Exists($"{Directory.GetCurrentDirectory().ToString()}/Logs/"))
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory().ToString()}/Logs/");
                Warn("Logs directory is missing, will create now.");
            }


            if (NowDate != GetDate())
            {
                LogPath = $"{Directory.GetCurrentDirectory().ToString()}/Logs/{GetDate()}.log";
                NowDate = GetDate();
                Init();
                Info("System date was changed, the time might be tomorrow.");
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
