using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Popups;
using System.Linq;
using Microsoft.UI.Xaml;
using myMediaCollection2.Model;
using myMediaCollection2.Enums;
using myMediaCollection2.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace myMediaCollection2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        public MainViewModel ViewModel => App.ViewModel;
    }
}

