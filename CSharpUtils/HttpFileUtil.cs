/**
 * 客户端上传文件操作类
 * ncepuhxh
 * ncpepuhxh@qq.com
 * 2017-2-20
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace CSharpUtils
{
    /// <summary>
    /// 客户端上传文件操作类
    /// </summary>
    public class HttpFileUtil
    {
        /// <summary>
        /// 保存单独文件到指定路径
        /// </summary>
        /// <param name="file">待保存文件</param>
        /// <param name="savePath">文件保存路径(包括文件名和扩展名)</param>
        /// <returns></returns>
        public static Boolean SaveFile(HttpPostedFile file, string savePath)
        {
            Boolean flag = true;
            try
            {
                file.SaveAs(savePath);
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }
            return flag;
        }

        /// <summary>
        /// 保存单独文件到指定路径
        /// </summary>
        /// <param name="file">待保存文件</param>
        /// <param name="savePath">文件保存路径(不包括文件名和扩展名)</param>
        /// <param name="fileName">文件名（包含扩展名）</param>
        /// <returns></returns>
        public static Boolean SaveFile(HttpPostedFile file, string savePath, string fileName)
        {
            Boolean flag = true;
            try
            {
                if (savePath != null)
                {
                    if (fileName != null)
                    {
                        file.SaveAs(savePath + fileName);
                    }
                    else
                    {
                        throw new Exception("fileName不能为空！\n ErrorLocation:CSharpUtils.HttpFileUtil.SaveFile");
                    }
                }
                else
                {
                    throw new Exception("savePath不能为空！\n ErrorLocation:CSharpUtils.HttpFileUtil.SaveFile");
                }

            }
            catch (Exception ex)
            {
                flag = false;
                throw new Exception(ex.Message + "\n ErrorLocation:CSharpUtils.HttpFileUtil.SaveFile");
            }
            return flag;
        }

        /// <summary>
        /// 保存所有文件到指定目录
        /// </summary>
        /// <param name="files">所有待保存文件</param>
        /// <param name="savePath">文件保存路径（不包含文件名和扩展名）</param>
        /// <returns></returns>
        public static Boolean SaveFiles(HttpFileCollection files, string savePath)
        {
            Boolean flag = true;
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string saveAbsolutePath = savePath + Path.GetFileName(files.Get(i).FileName);
                    files.Get(i).SaveAs(saveAbsolutePath);
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }
            return flag;
        }
    }
}
