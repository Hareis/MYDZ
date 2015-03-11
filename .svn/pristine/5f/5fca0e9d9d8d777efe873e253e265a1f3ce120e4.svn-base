using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MYDZ.Config.Provider;
using System.IO;
using MYDZ.Config.IConfig;

namespace MYDZ.Config.Theme
{
    /// <summary>
    /// 皮肤管理类
    /// </summary>
    public class ThemeConfigFileManager : DefaultConfigFileManager
    {
        private static ThemeConfig configinfo;
        private static DateTime fileoldchange;                                                                                                  //文件修改时间
        public static string filename = null;                                                                                                   //配置文件所在路径

        /// <summary>
        /// 初始化文件修改时间和对象实例
        /// </summary>
        static ThemeConfigFileManager() {
            if (File.Exists(ConfigFilePath)) {
                fileoldchange = File.GetLastWriteTime(ConfigFilePath);
                configinfo = (ThemeConfig)DefaultConfigFileManager.DeserializeInfo(ConfigFilePath, typeof(ThemeConfig));
            }
        }

        /// <summary>
        /// 当前的配置类实例
        /// </summary>
        public new static IConfigInfo ConfigInfo {
            get { return configinfo; }
            set { configinfo = (ThemeConfig)value; }
        }


        /// <summary>
        /// 获取配置文件所在路径
        /// </summary>
        public new static string ConfigFilePath {
            get {
                if (filename == null) {
                    filename = PathConfig.ThemePath;
                }
                return filename;
            }
        }

        /// <summary>
        /// 返回配置类实例
        /// </summary>
        /// <returns></returns>
        public static ThemeConfig LoadConfig() {
            if (File.Exists(ConfigFilePath)) {
                ConfigInfo = DefaultConfigFileManager.LoadConfig(ref fileoldchange, ConfigFilePath, ConfigInfo);
                return ConfigInfo as ThemeConfig;
            } else { 
                return null; 
            }
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <returns></returns>
        public override bool SaveConfig() {
            return base.SaveConfig(ConfigFilePath, ConfigInfo);
        }
    }
}
