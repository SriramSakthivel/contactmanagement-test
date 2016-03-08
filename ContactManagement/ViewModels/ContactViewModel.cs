using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement.Models;

namespace ContactManagement.ViewModels
{
    public class ContactViewModel : ContactViewModelBase
    {
        public ContactViewModel(Contact contact)
            : base(contact)
        {

        }
    }
}
