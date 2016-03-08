using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContactManagement.Services;

namespace ContactManagement.Views
{
    /// <summary>
    /// Interaction logic for ModifyContactView.xaml
    /// </summary>
    public partial class ModifyContactView : Window, IDialogWindow
    {
        public ModifyContactView()
        {
            InitializeComponent();
        }
    }
}
