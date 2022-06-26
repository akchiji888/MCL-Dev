using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Win32;
using Panuon.UI.Silver;
using ProjBobcat.Class.Helper.SystemInfo;
using ProjBobcat.DefaultComponent.Launch.GameCore;
using ProjBobcat.Class.Helper;
using ProjBobcat.Class.Model;
using ProjBobcat.Class.Model.LauncherProfile;
using ProjBobcat.DefaultComponent.Launch;
using ProjBobcat.Event;
using ProjBobcat.DefaultComponent.Authenticator;
using ProjBobcat.DefaultComponent.Logging;
using FastX.Core.Launch;//启动类的命名空间
using FastX.Core.Helpers;

namespace MCL_Dev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowX
    {
        public MainWindow()
        {
            InitializeComponent();
            ZhuYe zhuye = new ZhuYe();
            test test = new test();
            SheZhi shezhi = new SheZhi();
            LaunchAsyncs launch = new LaunchAsyncs();
            page.Content = new Frame()
            {
                Content = zhuye
            };
            SettingHelper setting = new SettingHelper();
            settingControl.Content = new Frame()
            {
                Content = shezhi
            };
            Color color = (Color)ColorConverter.ConvertFromString("#FF0067FF");
            banner.Background = new SolidColorBrush(color);
            #region 主页版图颜色
            zhuye.start.BorderBrush = new SolidColorBrush(color);
            zhuye.start.Foreground = new SolidColorBrush(color);
            zhuye.versionCombo.Foreground = new SolidColorBrush(color);
            zhuye.gameVersion.Foreground = new SolidColorBrush(color);  
            #endregion
            #region 设置主题色
            shezhi.javaBanBen.Foreground = new SolidColorBrush(color);
            shezhi.javaCombo.Foreground = new SolidColorBrush(color);
            #endregion

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZhuYe zhuye = new ZhuYe();
            page.Content = new Frame()
            {
                Content = zhuye
            };
        }
        private void Button_Click_setting(object sender, RoutedEventArgs e)
        {
            SheZhi shezhi = new SheZhi();
            page.Content = new Frame()
            {
                Content = shezhi
            };

        }
    }
}
