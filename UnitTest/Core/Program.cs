using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    //!单元测试
    class Program
    {
        //!程序入口
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("                 UnitTest Begin                 ");
            Console.WriteLine("------------------------------------------------");

            //!执行测试用例
            List<BaseUnitTest> vUnitTestList = TestManager.GetAllUnitTest();
            for (int i = 0; i < vUnitTestList.Count; i++)
            {
                BaseUnitTest vCurUnitTest = vUnitTestList.ElementAt(i);
                Boolean bResult = vCurUnitTest.RunUnitTest();
                if (bResult)
                {
                    ConsoleColor vDefaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(vCurUnitTest.Name() + " Success");
                    Console.ForegroundColor = vDefaultColor;
                }
                else
                {
                    ConsoleColor vDefaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(vCurUnitTest.Name() + " Fail");
                    Console.ForegroundColor = vDefaultColor;
                }
            }

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("                 UnitTest End                   ");
            Console.WriteLine("------------------------------------------------");
            Console.ReadLine();
        }
    }
}