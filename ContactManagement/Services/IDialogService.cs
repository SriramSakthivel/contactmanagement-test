using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ContactManagement.Services
{
    public interface IDialogService<TView,TViewModel>
    {
        //void Register(FrameworkElement view);
        //void Unregister(FrameworkElement view);

        bool? ShowDialog(TView view, TViewModel viewModel);
    }
}
