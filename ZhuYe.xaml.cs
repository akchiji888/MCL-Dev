using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Panuon.UI.Silver;
using ProjBobcat.Class.Model;
using ProjBobcat.Class.Model.LauncherProfile;
using ProjBobcat.DefaultComponent.Authenticator;
using ProjBobcat.DefaultComponent.Launch;
using ProjBobcat.DefaultComponent.Launch.GameCore;

namespace MCL_Dev
{
    /// <summary>
    /// ZhuYe.xaml 的交互逻辑
    /// </summary>
    public partial class ZhuYe : Page
    {
        public static DefaultGameCore core;
        public static void InitLauncherCore()
        {
            var clientToken = new Guid("88888888-8888-8888-8888-888888888888");
            //var rootPath = Path.GetFullPath(".minecraft\");
            var rootPath = ".minecraft";
            core = new DefaultGameCore
            {
                ClientToken = clientToken,
                RootPath = rootPath,
                VersionLocator = new DefaultVersionLocator(rootPath, clientToken)
                {
                    LauncherProfileParser = new DefaultLauncherProfileParser(rootPath, clientToken)
                }
            };
        }
        

        public ZhuYe()
        {
            ServicePointManager.DefaultConnectionLimit = 512;
            InitializeComponent();  
        }

        private async void start_Click(object sender, RoutedEventArgs e)
        {
            ZhuYe zhuye = new ZhuYe();
            test test = new test();
            SheZhi shezhi = new SheZhi();
            #region launchSetting
            var launchSettings = new LaunchSettings
            {
                Version = versionCombo.Text, // 需要启动的游戏ID
                VersionInsulation = false, // 版本隔离
                GameResourcePath = core.RootPath, // 资源根目录
                GamePath = core.RootPath, // 游戏根目录，如果有版本隔离则应该改为GamePathHelper.GetGamePath(Core.RootPath, versionId)
                VersionLocator = core.VersionLocator, // 游戏定位器
                GameArguments = new GameArguments // （可选）具体游戏启动参数
                {
                    JavaExecutable = shezhi.javaCombo.Text, // JAVA路径
                },
                Authenticator = new OfflineAuthenticator //离线认证
                {
                    Username = "test", //离线用户名
                    LauncherAccountParser = core.VersionLocator.LauncherAccountParser
                }
            };

            


                
            #endregion
            var result = await core.LaunchTaskAsync(launchSettings).ConfigureAwait(true); // 返回游戏启动结果，以及异常信息（如果存在）
        }
    }
}
