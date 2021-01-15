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
        public event VoidHandler OnClose;

        public LocationDetailsWindow()
        {
            this.view = new DetailWindow();
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
