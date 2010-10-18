﻿using System.Windows;

namespace MVPtoMVVM.mvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new Bootstrap().Execute();
        }
    }
}