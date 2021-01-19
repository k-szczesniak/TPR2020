namespace ViewModel
{
    public interface IOperationWindow
    {
        void BindViewModel<T>(T viewModel);
        void Show();
    }
}
