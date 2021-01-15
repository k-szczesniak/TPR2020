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
        public event VoidHandler OnClose;

        public LocationAddWindow()
        {
            this.view = new AddWindow();
        }

        public void BindViewModel<T>(T viewModel) where T : IViewModel
        {
            view.DataContext = viewModel;
            viewModel.CloseWindow = () =>
            {
                OnClose?.Invoke();
                view.Close();
            };
        }

        public void Show()
        {
            view.Show();
        }
    }
}
