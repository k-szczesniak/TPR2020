using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace View.DependencyInjection
{
    public class LocationAddWindow : IOperationWindow
    {
        private AddWindow view;

        public LocationAddWindow()
        {
            this.view = new AddWindow();
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
