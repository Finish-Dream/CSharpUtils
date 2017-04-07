/**
 * 目录操作类
 * ncepuhxh
 * ncpepuhxh@qq.com
 * 2017-2-20
 */
using System;
using System.Collections;
using System.IO;

namespace CSharpUtils
{
    /// <summary>
    /// 目录操作类
    /// </summary>
    public class DirectoryUtil
    {
        private static ArrayList fileList = new ArrayList();

        /// <summary>
        /// 遍历指定文件夹中的所有文件 
        /// </summary>
        /// <param name="dirPath">父文件夹</param>
        /// <returns></returns>
        public static FileInfo[] foreachAllFile(string dirPath)
        {
            try
            {
                //判断传入路径是否存在
                if (Directory.Exists(dirPath))
                {
                    _foreachAllFile(dirPath);
                    FileInfo[] fileInfo = (FileInfo[])fileList.ToArray(typeof(FileInfo));              
                    return fileInfo;
                }
                else
                {
                    throw new Exception("文件路径无效\n ErrorLocation:CSharpUtils.DirectoryUtil.foreachAllFile");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n ErrorLocation:CSharpUtils.DirectoryUtil.foreachAllFile");
            }
        }

        /// <summary>
        /// _遍历指定文件夹中的所有文件 
        /// </summary>
        /// <param name="dirPath">父文件夹</param>
        private static void _foreachAllFile(string dirPath)
        {
            DirectoryInfo baseDirInfo = new DirectoryInfo(dirPath);
            //将该层目录下文件存入fileList
            FileInfo[] fileInfo = baseDirInfo.GetFiles();
            foreach (FileInfo file in fileInfo)
            {
                fileList.Add(file);
            }
            //判断是否存在子目录（如果存在递归调用）
            DirectoryInfo[] dirInfo = baseDirInfo.GetDirectories();
            foreach (DirectoryInfo dir in dirInfo)
            {
                _foreachAllFile(dir.FullName);
            }
        }

    }
}
