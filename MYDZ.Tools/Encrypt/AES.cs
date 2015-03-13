using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MYDZ.Tools.Encrypt
{
    /// <summary>
    /// AES加密解密
    /// </summary>
    internal sealed class AES
    {
        /// <summary>
        /// 默认密钥向量
        /// </summary>
        private static byte[] Keys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79, 0x53, 0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };

        /// <summary>
        /// AES加密字符串
        /// </summary>
        /// <param name="EncryptString">待加密的字符串</param>
        /// <param name="EncryptKey">加密密钥，要求为32位</param>
        /// <returns>加密成功返回加密后的字符串</returns>
        public static string Encode(string EncryptString, string EncryptKey) {
            EncryptKey = Utils.GetSubString(EncryptKey, 32, "");
            EncryptKey = EncryptKey.PadRight(32, ' ');

            RijndaelManaged RijndaelProvider = new RijndaelManaged();
            RijndaelProvider.Key = Encoding.UTF8.GetBytes(EncryptKey.Substring(0, 32));
            RijndaelProvider.IV = Keys;
            ICryptoTransform RijndaelEncrypt = RijndaelProvider.CreateEncryptor();

            byte[] InputData = Encoding.UTF8.GetBytes(EncryptString);
            byte[] EncryptedData = RijndaelEncrypt.TransformFinalBlock(InputData, 0, InputData.Length);

            return Convert.ToBase64String(EncryptedData);
        }

        /// <summary>
        /// AES解密字符串
        /// </summary>
        /// <param name="DecryptString">待解密的字符串</param>
        /// <param name="DecryptKey">解密密钥，要求为32位</param>
        /// <returns>解密成功返回解密后的字符串，失败返回空</returns>
        public static string Decode(string DecryptString, string DecryptKey) {
            try {
                DecryptKey = Utils.GetSubString(DecryptKey, 32, "");
                DecryptKey = DecryptKey.PadRight(32, ' ');

                RijndaelManaged RijndaelProvider = new RijndaelManaged();
                RijndaelProvider.Key = Encoding.UTF8.GetBytes(DecryptKey);
                RijndaelProvider.IV = Keys;
                ICryptoTransform RijndaelEncrypt = RijndaelProvider.CreateDecryptor();

                byte[] InputData = Convert.FromBase64String(DecryptString);
                byte[] DecryptedData = RijndaelEncrypt.TransformFinalBlock(InputData, 0, InputData.Length);

                return Encoding.UTF8.GetString(DecryptedData);
            } catch {
                return "";
            }
        }
    }
}
