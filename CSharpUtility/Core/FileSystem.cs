using System;
using System.IO;

namespace CSharpUtility
{
    //!文件系统帮助类
    public static partial class Helper
    {
        /// <summary>
        /// 去文件或目录只读属性
        /// </summary>
        /// <param name="sPath">文件或目录路径</param>
        public static void RemoveReadonlyAttr(String sPath)
        {
            RemoveFileReadonlyAttr(sPath);
        }

        /// <summary>
        /// 去文件只读属性
        /// </summary>
        /// <param name="sFilePath">文件路径</param>
        public static void RemoveFileReadonlyAttr(String sFilePath)
        {
            if (File.Exists(sFilePath))
            {
                File.SetAttributes(sFilePath, FileAttributes.Normal);
            }
        }

        /// <summary>
        /// 去目录只读属性
        /// </summary>
        /// <param name="sDirPath">目录路径</param>
        public static void RemoveDirReadonlyAttr(String sDirPath)
        {

        }
    }
}