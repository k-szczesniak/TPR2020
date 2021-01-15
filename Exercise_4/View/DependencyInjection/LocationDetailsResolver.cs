using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace View.DependencyInjection
{
    public class LocationDetailsResolver : IWindowResolver
    {
        public IOperationWindow GetWindow()
        {
            return new LocationDetailsWindow();
        }
    }
}
