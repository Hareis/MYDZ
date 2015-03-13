using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Config.Encrypt;

namespace MYDZ.Tools.Encrypt
{
    /// <summary>
    /// 加密管理类
    /// </summary>
    public class Encrypting
    {
        /// <summary>
        /// 加密字符串（失败返回空）
        /// </summary>
        /// <param name="EncryptString">待加密字符串</param>
        /// <param name="Mode">加密模式</param>
        /// <returns></returns>
        public static string Encode(string EncryptString, EncryptMode Mode) {
            string ReturnString = "";
            List<EncryptInfo> EncryptList = EncryptConfigs.GetConfig().EncryptInfo;

            try {
                foreach (EncryptInfo el in EncryptList) {
                    EncryptMode TempMode = Utils.GetEnum<EncryptMode>(el.EncryptName.Trim(), EncryptMode.Default);

                    if (Mode.Equals(TempMode)) {
                        ReturnString = EncryptString;

                        //正向加密
                        foreach (EncryptType ei in el.EncryptType) {
                            switch (ei.Type) {
                                case EncryptEnum.AES:
                                    ReturnString = AES.Encode(ReturnString, ei.Key);
                                    break;
                                case EncryptEnum.DES:
                                    ReturnString = DES.Encode(ReturnString, ei.Key);
                                    break;
                                case EncryptEnum.MD5:
                                    ReturnString = MD5.Encode(ReturnString);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                }
            }
            catch { ReturnString = ""; }

            return ReturnString;
        }

        /// <summary>
        /// 解密字符串（失败返回空）
        /// </summary>
        /// <param name="DecryptString">待解密字符串</param>
        /// <param name="Mode">加密模式</param>
        /// <returns></returns>
        public static string Decode(string DecryptString, EncryptMode Mode) {
            string ReturnString = "";

            if (Mode == EncryptMode.Cipher) {
                return ReturnString;
            }

            List<EncryptInfo> EncryptList = EncryptConfigs.GetConfig().EncryptInfo ;

            try {
                foreach (EncryptInfo el in EncryptList) {
                    EncryptMode TempMode = Utils.GetEnum<EncryptMode>(el.EncryptName.Trim(), EncryptMode.Default);

                    if (Mode.Equals(TempMode)) {
                        ReturnString = DecryptString;

                        //反向解密
                        for (int i = el.EncryptType.Count - 1; i >= 0; i--) {
                            EncryptType ei = el.EncryptType[i];

                            switch (ei.Type) {
                                case EncryptEnum.AES:
                                    ReturnString = AES.Decode(ReturnString, ei.Key);
                                    break;
                                case EncryptEnum.DES:
                                    ReturnString = DES.Decode(ReturnString, ei.Key);
                                    break;
                                default:
                                    break;
                            }
                        }

                        break;
                    }
                }
            }
            catch { ReturnString = ""; }

            return ReturnString;
        }
    }
}
