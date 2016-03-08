using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement.Models;
using ContactManagement.ViewModels;

namespace ContactManagement.Factories
{
    public interface IModifyContactModelFactory : IFactory<ModifyContactViewModel, Contact, EditType>
    {

    }
}
