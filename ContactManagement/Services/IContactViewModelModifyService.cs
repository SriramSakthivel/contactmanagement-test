using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement.Models;
using ContactManagement.ViewModels;

namespace ContactManagement.Services
{
    public interface IContactViewModelModifyService
    {
        void AddContactViewModel(Contact contact);
        void AddContactViewModel(ContactViewModel viewModel);
        void DeleteContactViewModel(ContactViewModel viewModel);
    }
}
