using System;

namespace UnitTest
{
    public class BaseUnitTest
    {
        //!运行测试用例
        public virtual Boolean RunUnitTest()
        {
            //!返回测试结果
            return true;
        }

        //!获取用例名称
        public virtual String Name()
        {
            String sName = GetType().ToString();
            if (sName.Contains("."))
            {
                sName = sName.Substring(sName.LastIndexOf('.') + 1);
            }
            return sName;
        }
    }
}