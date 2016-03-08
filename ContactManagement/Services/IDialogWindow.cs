using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ContactManagement.Services
{
    public interface IDialogWindow
    {
        object DataContext { get; set; }
        Window Owner { get; set; }
        bool? ShowDialog();
    }
}
