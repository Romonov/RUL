/**
 * RUL.Win32
 * Ver: 1.0.0
 * Date: 2018.7.1
 */

using System;
using System.Runtime.InteropServices;

namespace RUL
{
    class Win32
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(
            string lpClassName,
            string lpWindowName
        );

        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        private static extern int SetWindowText(
           IntPtr hwnd,
           string lpString
        );

        /// <summary>
        /// 更改窗口标题
        /// </summary>
        /// <param name="processName">进程名</param>
        /// <param name="className">类型名</param>
        /// <param name="proposeTitle">目标窗口标题</param>
        public static void ChangeTitle(string processName, string className, string proposeTitle)
        {
            IntPtr GameWindow = FindWindow(className, processName);
            SetWindowText(GameWindow, proposeTitle);
        }
    }
}
