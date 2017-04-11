/**
 * 日志操作类
 * ncepuhxh
 * ncpepuhxh@qq.com
 * 2017/4/7
 */
using System;
using System.IO;

namespace CSharpUtils
{
    public class WriteLog
    {
        public static void writeLog(String message)
        {
            StreamWriter sw;
            try
            {
                DateTime _nowTime = DateTime.Now;
                String path = System.AppDomain.CurrentDomain.BaseDirectory + "log";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                String logPath = path + "\\" + _nowTime.Year + "." + _nowTime.Month + "." + _nowTime.Day + ".txt";
                if (!File.Exists(logPath))
                {
                    File.Create(logPath);
                }
                sw = new StreamWriter(logPath, true);
                
                sw.WriteLine(message + "\n");     //log
                sw.Close();
                //System.Threading.Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                //sw.Write(ex.Message + "\n");     //log
                //sw.Close();
            }
            
        }
    }
}
