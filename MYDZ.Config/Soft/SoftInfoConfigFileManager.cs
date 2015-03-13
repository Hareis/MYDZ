using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Config.Provider;
using System.IO;

namespace MYDZ.Config.Soft
{
    public class SoftInfoConfigFileManager : DefaultConfigFileManager
    {
        private static SoftInfoConfig configinfo;
        private static DateTime fileoldchange;                                                                                                  //文件修改时间
        public static string filename = null;                                                                                                   //配置文件所在路径

        /// <summary>
        /// 初始化文件修改时间和对象实例
        /// </summary>
        static SoftInfoConfigFileManager()
        {
            if (File.Exists(ConfigFilePath))
            {
                fileoldchange = File.GetLastWriteTime(ConfigFilePath);
                configinfo = (SoftInfoConfig)DefaultConfigFileManager.DeserializeInfo(ConfigFilePath, typeof(SoftInfoConfig));
            }
        }

        /// <summary>
        /// 当前的配置类实例
        /// </summary>
        public new static SoftInfoConfig ConfigInfo
        {
            get { return configinfo; }
            set { configinfo = (SoftInfoConfig)value; }
        }


        /// <summary>
        /// 获取配置文件所在路径
        /// </summary>
        public new static string ConfigFilePath
        {
            get
            {
                if (filename == null)
                {
                    filename = PathConfig.AuthorizePath;
                }
                return filename;
            }
        }

        /// <summary>
        /// 返回配置类实例
        /// </summary>
        /// <returns></returns>
        public static SoftInfoConfig LoadConfig()
        {
            if (File.Exists(ConfigFilePath))
            {
                ConfigInfo = DefaultConfigFileManager.LoadConfig(ref fileoldchange, ConfigFilePath, ConfigInfo) as SoftInfoConfig;
                return ConfigInfo;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <returns></returns>
        public override bool SaveConfig()
        {
            return base.SaveConfig(ConfigFilePath, ConfigInfo);
        }
    }
}
