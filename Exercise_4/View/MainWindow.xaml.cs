﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using View.DependencyInjection;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MainWindowActions _vm = (MainWindowActions)DataContext;
            //_vm.AddWindow = new Lazy<IWindow>(() => new AddWindow());
            //_vm.WindowAddResolver = new LocationAddResolver();
            //_vm.WindowDetailResolver = new LocationDetailsResolver();

            _vm.WindowAddResolver = new Lazy<IOperationWindow>(() => new LocationAddWindow());
            _vm.WindowDetailResolver = new Lazy<IOperationWindow>(() => new LocationDetailsWindow());
        }
    }
}
