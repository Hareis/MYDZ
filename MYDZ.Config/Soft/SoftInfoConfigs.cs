using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYDZ.Config.Soft
{
    public class SoftInfoConfigs
    {
        /// <summary>
        /// 间隔为60分钟
        /// </summary>
        private static System.Timers.Timer EncryptConfigTimer = new System.Timers.Timer(600000);
        public static SoftInfoConfig configinfo;

        static SoftInfoConfigs()
        {
            configinfo = SoftInfoConfigFileManager.LoadConfig();
            EncryptConfigTimer.AutoReset = true;
            EncryptConfigTimer.Enabled = true;
            EncryptConfigTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            EncryptConfigTimer.Start();
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ResetConfig();
        }

        /// <summary>
        /// 重设配置类实例
        /// </summary>
        public static void ResetConfig()
        {
            configinfo = SoftInfoConfigFileManager.LoadConfig();
        }

        /// <summary>
        /// 获取配置类实例
        /// </summary>
        /// <returns></returns>
        public static SoftInfoConfig GetConfig()
        {
            return configinfo;
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <param name="configinfo"></param>
        /// <returns></returns>
        public static bool SaveConfig(SoftInfoConfig configinfo)
        {
            SoftInfoConfigFileManager rcfm = new SoftInfoConfigFileManager();
            SoftInfoConfigFileManager.ConfigInfo = configinfo;
            return rcfm.SaveConfig();
        }
    }
}
