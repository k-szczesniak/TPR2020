using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace View.DependencyInjection
{
    public class LocationDetailsWindow : IOperationWindow
    {
        private DetailWindow view;

        public LocationDetailsWindow()
        {
            this.view = new DetailWindow();
        }

        public void BindViewModel<T>(T viewModel)
        {
            view.DataContext = viewModel;
        }

        public void Show()
        {
            view.Show();
        }
    }
}
