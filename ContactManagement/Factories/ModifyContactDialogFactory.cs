using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement.Services;
using ContactManagement.Views;

namespace ContactManagement.Factories
{
    public class ModifyContactDialogFactory : IFactory<IDialogWindow>
    {
        public IDialogWindow Create()
        {
            return new ModifyContactView();
        }
    }
}
