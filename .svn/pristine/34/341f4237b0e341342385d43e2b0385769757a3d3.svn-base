using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Tools.Encrypt
{
    /// <summary>
    /// MD5加密
    /// </summary>
    internal class MD5
    {
        /// <summary>
        /// 位移的范围
        /// </summary>
        private static int Displacement = 5;

        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="EncryptString">待加密字符串</param>
        /// <returns></returns>
        public static string Encode(string EncryptString) {
            byte[] InputByteArray = Encoding.UTF8.GetBytes(EncryptString);

            for (int i = 0; i < InputByteArray.Length; i++) {
                int tmp = (int)InputByteArray[i] + Displacement;
                InputByteArray[i] = Convert.ToByte(tmp);
            }

            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Convert.ToBase64String(InputByteArray), "MD5");
        }
    }
}
