using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public interface IOperationWindow
    {
        void BindViewModel<T>(T viewModel);
        void Show();
    }
}
