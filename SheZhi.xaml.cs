using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using ProjBobcat.Class.Helper;
using SquareMinecraftLauncher.Core;

namespace MCL_Dev
{
    /// <summary>
    /// SheZhi.xaml 的交互逻辑
    /// </summary>
    public partial class SheZhi : Page
    {
        public SheZhi()
        {
            SquareMinecraftLauncher.Minecraft.Tools tools = new SquareMinecraftLauncher.Minecraft.Tools(); 
            InitializeComponent();
            javaCombo.ItemsSource = tools.GetJavaPath();
        }
    }
}
