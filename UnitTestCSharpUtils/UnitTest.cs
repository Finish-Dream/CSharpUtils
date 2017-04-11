using CSharpUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.IO;
using System.Web;

namespace UnitTestCSharpUtils
{
    [TestClass]
    public class DirectoryUtilTest
    {
        [TestMethod]
        public void TestForeachAllFile()
        {
            DirectoryUtil.foreachAllFile("D:\\报表");
        }
    }
    [TestClass]
    public class ExcelUtilTest
    {
        [TestMethod]
        public void TestGetExcelData()
        {
            FileInfo file = new FileInfo("E:\\hzzh\\test.xlsx");
            DataTable dt = ExcelUtil.GetExcelData(file, "DESKTOP-5562VN5");
        }
    }
    [TestClass]
    public class HttpFileUtilTest
    {
        [TestMethod]
        public void TestSavaFile1()
        {
            //FileInfo file = new FileInfo("E:\\hzzh\\test.xlsx");
            //HttpPostedFile httpFile=new H
            //HttpFileUtil.SaveFile(file)
        }
    }
    [TestClass]
    public class RARUtilTest
    {
        [TestMethod]
        public void TestRAR()
        {
            RARUtil.RAR("G:\\haha\\Desktop\\OPC", "D:\\", "OPC.rar");
        }
        [TestMethod]
        public void TestUnRAR()
        {
            RARUtil.UnRAR("D:\\我的安装包", "VPN安装包.rar", "D:\\");
        }
    }
    [TestClass]
    public class WriteLogTest
    {
        [TestMethod]
        public void TestWriteLog()
        {
            WriteLog.writeLog("test");
        }
    }
}
