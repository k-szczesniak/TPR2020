using System;
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
using System.Windows.Shapes;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window, IWindow
    {
        public DetailWindow()
        {
            InitializeComponent();
        }

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    this.Visibility = Visibility.Hidden;
        //    e.Cancel = true;
        //}
    }
}
