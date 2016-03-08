using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ContactManagement.Models;

namespace ContactManagement.ViewModels
{
    public class ContactsListViewModel : ViewModelBase
    {
        private ObservableCollection<ContactViewModel> contacts = new ObservableCollection<ContactViewModel>();
        public ObservableCollection<ContactViewModel> Contacts
        {
            get { return contacts; }
        }

        public ContactViewModel SelectedContact { get; set; }

        public ContactViewModel NewContactViewModel(Contact contact)
        {
            return new ContactViewModel(contact);
        }

        public void AddContactViewModel(ContactViewModel viewModel)
        {
            if (viewModel == null || contacts.Contains(viewModel))
            {
                return;
            }
            contacts.Add(viewModel);
        }

        public void AddNewContactViewModel(Contact contact)
        {
            if (contact == null)
            {
                return;
            }
            contacts.Add(NewContactViewModel(contact));
        }

        public void DeleteContactViewModel(ContactViewModel viewModel)
        {
            if (viewModel == null || !contacts.Contains(viewModel))
            {
                return;
            }
            contacts.Remove(viewModel);
        }
    }
}
