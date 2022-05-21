﻿using System;
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
using Panuon.UI.Silver;

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
            page.Content = new Frame()
            {
                Content = zhuye
            };
            Color color = (Color)ColorConverter.ConvertFromString("#FF0067FF");

            banner.Background = new SolidColorBrush(color);
            zhuye.start.BorderBrush = new SolidColorBrush(color);
            zhuye.start.Foreground = new SolidColorBrush(color);
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