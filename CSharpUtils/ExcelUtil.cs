/**
 * 客户端上传文件操作类
 * ncepuhxh
 * ncpepuhxh@qq.com
 * 2017-2-20
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtils
{
    /// <summary>
    /// Excel操作类
    /// </summary>
    public class ExcelUtil
    {
        /// <summary>
        /// 获取Excel中数据
        /// </summary>
        /// <param name="fileInfo">文件所在路径</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static DataTable GetExcelData(FileInfo fileInfo, string tableName)
        {
            //定义变量            
            String strConn = "Provider=Microsoft.Ace.OleDb.12.0;" +
                "data source=" + fileInfo.FullName + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
            String strExcel = "select * from [" + tableName + "$]";
            OleDbDataAdapter myCommand = null;
            DataTable dt = new DataTable();

            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            myCommand.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}
