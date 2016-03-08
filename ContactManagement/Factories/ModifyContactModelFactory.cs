using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement.Models;
using ContactManagement.ViewModels;
using ContactManagement.Views;

namespace ContactManagement.Factories
{
    public class ModifyContactModelFactory : IModifyContactModelFactory
    {
        public ModifyContactViewModel Create(Contact contact, EditType editType)
        {
            return new ModifyContactViewModel(contact, editType);
        }
    }
}
