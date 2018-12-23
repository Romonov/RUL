using System;
using System.IO;

namespace RUL
{
    /// <summary>
    /// Logger
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Logger实例化方法
        /// </summary>
        /// <param name="logName">Logger实例名</param>
        public Logger(string logName)
        {
            LogName = logName;
        }

        private string LogName { get; }

        private static object WriterLocker = new object();
        private static object FileWriterLocker = new object();

        private static string NowDate = GetDate();

        private static string LogPath = $"{Directory.GetCurrentDirectory().ToString()}\\Logs\\{GetDate()}.log";

        const ConsoleColor InfoColor = ConsoleColor.White;
        const ConsoleColor WarnColor = ConsoleColor.Yellow;
        const ConsoleColor ErrorColor = ConsoleColor.Red;
        const ConsoleColor FatalColor = ConsoleColor.DarkRed;
        const ConsoleColor DebugColor = ConsoleColor.Cyan;

        /// <summary>
        /// 输出Info类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public void Info<T>(T str)
        {
            string msg = $"{GetTime()}[{LogName}][Info]{str.ToString()}";
            Writer(InfoColor, msg.ToString());
        }

        /// <summary>
        /// 输出Warn类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public void Warn<T>(T str)
        {
            string msg = $"{GetTime()}[{LogName}][Warn]{str.ToString()}";
            Writer(WarnColor, msg.ToString());
        }

        /// <summary>
        /// 输出Error类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public void Error<T>(T str)
        {
            string msg = $"{GetTime()}[{LogName}][Error]{str.ToString()}";
            Writer(ErrorColor, msg);
        }

        /// <summary>
        /// 输出Fatal类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public void Fatal<T>(T str)
        {
            string msg = $"{GetTime()}[{LogName}][Error]{str.ToString()}";
            Writer(FatalColor, msg);
        }

        /// <summary>
        /// 输出Debug类型的日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        public void Debug<T>(T str)
        {
            string msg = $"{GetTime()}[{LogName}][Debug]{str.ToString()}";
            Writer(DebugColor, msg);
        }

        /// <summary>
        /// 直接把日志写入文件而不展示给用户
        /// </summary>
        /// <param name="msg">日志内容</param>
        public void WriteToFile<T>(T str)
        {
            string msg = $"{str.ToString()}";
            FileWriter(msg);
        }

        /// <summary>
        /// 写入控制台方法
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="msg">信息</param>
        private void Writer(ConsoleColor color, string msg)
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


        /// <summary>
        /// 写文件方法
        /// </summary>
        /// <param name="msg">信息</param>
        private void FileWriter(string msg)
        {
            // Todo: 当文件大于2M时更换文件

            if (!Directory.Exists($"{Directory.GetCurrentDirectory().ToString()}/Logs/"))
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory().ToString()}/Logs/");
                Warn("Logs directory is missing, will create now.");
            }

            if (NowDate != GetDate())
            {
                LogPath = $"{Directory.GetCurrentDirectory().ToString()}/Logs/{GetDate()}.log";
                NowDate = GetDate();
                Info("System date was changed, log file will change.");
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
        private static string GetTime()
        {
            return DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <returns>目前日期，格式：YYYY-MM-DD</returns>
        private static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
