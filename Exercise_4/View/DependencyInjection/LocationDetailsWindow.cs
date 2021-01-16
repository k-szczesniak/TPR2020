using ViewModel;

namespace View
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
