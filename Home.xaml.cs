﻿using Microsoft.Win32;
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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management.Automation;

namespace MCSE_Editor_for_Wii_U
{
    /// <summary>
    /// Home.xaml の相互作用ロジック
    /// </summary>
    public partial class Home : Window
    {

        public Home()
        {
            InitializeComponent();
            MouseLeftButtonDown += (sender, e) => this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void openFileButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.FileName = "Minecraft.msscmp";
            ofd.Filter = "msscmpファイル(*.msscmp)|*.msscmp|すべてのファイル(*.*)|*.*";
            ofd.Title = "ファイルを選択してください";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Variables.openFilePath = ofd.FileName;
                Close();
            }
        }

        private void createFileButton_Click(object sender, RoutedEventArgs e)
        {
            Variables.openFilePath = "Minecraft.msscmp";
            Close();
        }

        private void developerButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("powershell_ise");
        }
    }
}
