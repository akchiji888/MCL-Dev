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
using FastX.Core;
using FastX.Class.Models;
using FastX.Core.Launch;

namespace MCL_Dev
{
    /// <summary>
    /// ZhuYe.xaml 的交互逻辑
    /// </summary>
    public partial class ZhuYe : Page
    {


       
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
            LaunchAsyncs launch = new LaunchAsyncs();
            var settings = new LaunchModel()//启动参数配置类
            {
                Authenticator = LaunchTypeModel.Offline,//选择验证模式为离线验证(此外还可以外置验证，微软验证)
                Height = 500,//设置游戏窗口高度
                Width = 500,//设置游戏窗口宽度
                Maxmemory = Convert.ToInt32(shezhi.maxMem.Text),//设置游戏最大内存
                Minimemory = 900,//设置游戏最小内存
                Version = "1.16.5",//游戏名为你.minecraft里的游戏版本
                JavaExecutable = @"C:\Program Files\Java\jre1.8.0_333\bin\javaw.exe",
                LauncherName = "FastX",//自定义的启动水印，启动后可在屏幕左下角看到
                Name = "西路Baka",//你的用户名
            };
            await launch.LaunchTaskAsync(settings);//调用启动方法，注：该方法为异步

        }
    }
}
