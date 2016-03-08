using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement.Models;
using ContactManagement.ViewModels;

namespace ContactManagement.Services
{
    public class ContactViewModelAddService : IContactViewModelModifyService
    {
        private readonly ContactsListViewModel contactsListViewModel;
        public ContactViewModelAddService(ContactsListViewModel contactsListViewModel)
        {
            this.contactsListViewModel = contactsListViewModel;
        }

        public void AddContactViewModel(Contact contact)
        {
            contactsListViewModel.AddNewContactViewModel(contact);
        }

        public void AddContactViewModel(ContactViewModel viewModel)
        {
            contactsListViewModel.AddContactViewModel(viewModel);
        }

        public void DeleteContactViewModel(ContactViewModel viewModel)
        {
            contactsListViewModel.DeleteContactViewModel(viewModel);
        }
    }
}
