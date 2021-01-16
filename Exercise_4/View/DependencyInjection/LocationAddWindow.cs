using ViewModel;

namespace View
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
