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

namespace MCL_Dev
{
    /// <summary>
    /// ZhuYe.xaml 的交互逻辑
    /// </summary>
    public partial class ZhuYe : Page
    {
        SquareMinecraftLauncher.Minecraft.Tools tools = new SquareMinecraftLauncher.Minecraft.Tools();
        SquareMinecraftLauncher.Minecraft.Game game = new SquareMinecraftLauncher.Minecraft.Game();//声明对象
        public ZhuYe()
        {
            ServicePointManager.DefaultConnectionLimit = 512;
            InitializeComponent();           
            SheZhi shezhi = new SheZhi();
            var version = tools.GetAllTheExistingVersion();
            versionCombo.ItemsSource = version;

        }

        private async void start_Click(object sender, RoutedEventArgs e)
        {
            SheZhi shezhi = new SheZhi();
            await game.StartGame(versionCombo.Text, shezhi.javaCombo.Text , 4096, "114514");
        }
    }
}
