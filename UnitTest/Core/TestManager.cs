using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnitTest
{
    //!单元测试管理类
    public static class TestManager
    {
        //!获取所有单元测试
        public static List<BaseUnitTest> GetAllUnitTest()
        {
            //!单元测试列表
            List<BaseUnitTest> vUnitTestList = new List<BaseUnitTest>();

            //!获取单元测试基类类型
            Type vType = typeof(BaseUnitTest);

            //!利用反射找到所有子类
            foreach (Type vTypeItr in Assembly.GetAssembly(vType).GetTypes())
            {
                if (vTypeItr.BaseType == vType)
                {
                    vUnitTestList.Add(vTypeItr.Assembly.CreateInstance(vTypeItr.ToString()) as BaseUnitTest);
                }
            }

            //!返回单元测试列表
            return vUnitTestList;
        }
    }
}