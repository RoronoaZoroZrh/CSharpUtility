using System;
using System.IO;

namespace UnitTest
{
    public class RemoveReadonlyAttrUnitTest : BaseUnitTest
    {
        //!运行测试用例
        public override Boolean RunUnitTest()
        {
            //!测试资源
            String sTestFile1 = "./UnitTestDir/LocTestFile1.txt";
            String sTestFile2 = "./UnitTestDir/SubDir/LocTestFile2.txt";
            String sTestDir1  = "./UnitTestDir/";
            String sTestDir2  = "./UnitTestDir/SubDir/";
            if (!Directory.Exists(sTestDir1)) Directory.CreateDirectory(sTestDir1);
            if (!Directory.Exists(sTestDir2)) Directory.CreateDirectory(sTestDir2);
            if (!File.Exists(sTestFile1)) File.Create(sTestFile1).Close();
            if (!File.Exists(sTestFile2)) File.Create(sTestFile2).Close();

            //!设置文件只读属性
            FileInfo vFileInfo1 = new FileInfo(sTestFile1) { IsReadOnly = true };
            FileInfo vFileInfo2 = new FileInfo(sTestFile2) { IsReadOnly = true };

            //!调用接口，正确情况
            CSharpUtility.Helper.RemoveReadonlyAttr(sTestFile1);
            Boolean bExpectResult1 = true;
            Boolean bActualResult1 = vFileInfo1.IsReadOnly == false;

            //!调用接口，正确情况
            CSharpUtility.Helper.RemoveReadonlyAttr(sTestDir1);
            Boolean bExpectResult2 = true;
            Boolean bActualResult2 = vFileInfo1.IsReadOnly == false && vFileInfo2.IsReadOnly == false;

            //!调用接口，传入非法参数
            CSharpUtility.Helper.RemoveReadonlyAttr(null);
            CSharpUtility.Helper.RemoveReadonlyAttr("");

            //!清理测试资源
            if (File.Exists(sTestFile1)) File.Delete(sTestFile1);
            if (File.Exists(sTestFile2)) File.Delete(sTestFile2);
            if (Directory.Exists(sTestDir1)) Directory.Delete(sTestDir1, true);
            if (Directory.Exists(sTestDir2)) Directory.Delete(sTestDir2, true);

            //!返回测试结果
            return bExpectResult1 == bActualResult1 &&
                bExpectResult2 == bActualResult2;
        }
    }
}