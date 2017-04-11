/**
* 客户端上传文件操作类
* ncepuhxh
* ncpepuhxh@qq.com
* 2017-2-22
*/
using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtils
{
    /// <summary>
    /// 压缩文件操作类
    /// </summary>
    public class RARUtil
    {
        // WinRAR安装注册表key    
        private const string WinRAR_KEY = @"WinRAR.ZIP\shell\open\command";
        /// <summary>
        /// 利用 WinRAR 进行压缩     
        /// </summary>
        /// <param name="savePath">文件的存放目录（绝对路径，压缩前）</param>
        /// <param name="rarPath">文件的存放目录（绝对路径,压缩后）</param>
        /// <param name="rarName">文件的名称（包括后缀，压缩后）</param>
        /// <returns>true 或 false。压缩成功返回 true，反之，false。</returns>    
        public static bool RAR(string savePath, string rarPath, string rarName)
        {
            bool flag = false;
            string rarexe;       //WinRAR.exe 的完整路径      
            RegistryKey regkey;  //注册表键      
            Object regvalue;     //键值   
            string cmd;          //WinRAR 命令参数  
            ProcessStartInfo startinfo;
            Process process;
            try
            {
                regkey = Registry.ClassesRoot.OpenSubKey(WinRAR_KEY);
                regvalue = regkey.GetValue("");  // 键值为 "d:\Program Files\WinRAR\WinRAR.exe" "%1"      
                rarexe = regvalue.ToString();
                regkey.Close();
                rarexe = rarexe.Substring(1, rarexe.Length - 7);  // d:\Program Files\WinRAR\WinRAR.exe   
                Directory.CreateDirectory(savePath);             //压缩命令，相当于在要压缩的文件夹(savePath)上点右键->WinRAR->添加到压缩文件->输入压缩文件名(rarName)  
                cmd = string.Format("a {0} {1} -r", rarName, savePath);
                startinfo = new ProcessStartInfo();
                startinfo.FileName = rarexe;
                startinfo.Arguments = cmd;        //设置命令参数    
                startinfo.WindowStyle = ProcessWindowStyle.Hidden;  //隐藏 WinRAR 窗口        
                startinfo.WorkingDirectory = rarPath;
                process = new Process();
                process.StartInfo = startinfo;
                process.Start();
                process.WaitForExit(); //无限期等待进程 winrar.exe 退出      
                if (process.HasExited)
                {
                    flag = true;
                }
                process.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }

        /// <summary>
        /// 利用 WinRAR 进行解压缩     
        /// </summary>
        /// <param name="rarPath">文件的存放路径（绝对路径，解压前）</param>
        /// <param name="rarName">文件名（包括后缀，解压前）</param>
        /// <param name="savePath">文件的存放路径（绝对路径，解压后）</param>
        /// <returns>true 或 false。解压缩成功返回 true，反之，false。</returns>  
        public static Boolean UnRAR(string rarPath, string rarName, string savePath)
        {
            //标识解压是否成功
            bool flag = false;
            try
            {
                //获取WinRAR应用程序路径        
                RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(WinRAR_KEY);
                Object regValue = regKey.GetValue("");
                regKey.Close();
                string WinRARPath = regValue.ToString();
                WinRARPath = WinRARPath.Substring(1, WinRARPath.Length - 7);
                //启动进程
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                Directory.CreateDirectory(savePath);
                //解压缩命令，相当于在要压缩文件(rarName)上点右键->WinRAR->解压到当前文件夹       
                string cmd = string.Format("x {0} {1} -y", rarName, savePath);
                //调用WinRAR
                startInfo.FileName = WinRARPath;
                startInfo.Arguments = cmd;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.WorkingDirectory = rarPath;

                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                if (process.HasExited)
                {
                    flag = true;
                }
                process.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }
    }
}
