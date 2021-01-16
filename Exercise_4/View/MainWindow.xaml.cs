using System;
using System.Windows;
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
            _vm.AddWindow = new Lazy<IOperationWindow>(() => new LocationAddWindow());
            _vm.DetailWindow = new Lazy<IOperationWindow>(() => new LocationDetailsWindow());
        }
    }
}
