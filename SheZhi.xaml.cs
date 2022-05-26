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
using SquareMinecraftLauncher.Minecraft;

namespace MCL_Dev
{
    /// <summary>
    /// SheZhi.xaml 的交互逻辑
    /// </summary>
    public partial class SheZhi : Page
    {
        public static class DeepJavaSearcher
        {
            static IEnumerable<string> GetLogicalDrives()
            {
                return Environment.GetLogicalDrives();
            }

            public static async IAsyncEnumerable<string> DeepSearch(string drive, string fileName)
            {
                var result = new HashSet<string>();
                var psi = new ProcessStartInfo("where")
                {
                    ArgumentList =
            {
                "/R",
                $"{drive}\\",
                fileName
            },
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                };

                var process = Process.Start(psi);
                var isFailed = false;

                if (process == null)
                    yield break;

                process.ErrorDataReceived += (_, args) =>
                {
                    if (string.IsNullOrEmpty(args.Data)) return;

                    isFailed = true;
                };

                process.OutputDataReceived += (_, args) =>
                {
                    if (string.IsNullOrEmpty(args.Data)) return;
                    if (File.Exists(args.Data))
                        result.Add(args.Data);
                };

                process.BeginErrorReadLine();
                process.BeginOutputReadLine();

                await process.WaitForExitAsync();

                if (isFailed || process.ExitCode != 0)
                    yield break;

                foreach (var path in result)
                {
                    yield return path;
                }
            }

            public static async IAsyncEnumerable<string> DeepSearch()
            {
                var result = new HashSet<string>();
                var drives = GetLogicalDrives();

                foreach (var drive in drives)
                {
                    await foreach (var path in DeepSearch(drive, "javaw.exe"))
                        yield return path;
                }
            }
        }
        public SheZhi()
        {
            InitializeComponent();
            SquareMinecraftLauncher.Minecraft.Tools tools = new SquareMinecraftLauncher.Minecraft.Tools();
            javaCombo.ItemsSource = tools.GetJavaPath();
        }
    }
}
