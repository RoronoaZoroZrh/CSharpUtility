using System;
using System.IO;

namespace UnitTest
{
    public class RemoveFileReadonlyAttrUnitTest : BaseUnitTest
    {
        //!运行测试用例
        public override Boolean RunUnitTest()
        {
            //!测试资源
            String sTestFile = "./UnitTestDir/LocTestFile.txt";
            String sTestDir  = "./UnitTestDir/";
            if (!Directory.Exists(sTestDir)) Directory.CreateDirectory(sTestDir);
            if (!File.Exists(sTestFile)) File.Create(sTestFile).Close();

            //!设置文件只读属性
            FileInfo vFileInfo = new FileInfo(sTestFile) { IsReadOnly = true };

            //!调用接口，正确情况
            CSharpUtility.Helper.RemoveFileReadonlyAttr(sTestFile);
            Boolean bExpectResult = true;
            Boolean bActualResult = vFileInfo.IsReadOnly == false;

            //!调用接口，传入非法参数
            CSharpUtility.Helper.RemoveFileReadonlyAttr(null);
            CSharpUtility.Helper.RemoveFileReadonlyAttr("");

            //!清理测试资源
            if (File.Exists(sTestFile)) File.Delete(sTestFile);
            if (Directory.Exists(sTestDir)) Directory.Delete(sTestDir);

            //!返回测试结果
            return bExpectResult == bActualResult;
        }
    }
}