using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ContactManagement.Models;
using ContactManagement.Persistance;
using ContactManagement.Services;
using System.IO;

namespace ContactManagement.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IModifyContactService modifyContactService;
        private readonly IPersistanceService<Contact> persistanceService;

        private readonly RelayCommand newContactCommand;
        private readonly RelayCommand editContactCommand;
        private readonly RelayCommand deleteContactCommand;
        private readonly RelayCommand loadSavedContactsCommand;
        private readonly RelayCommand saveStateCommand;
        private ContactsListViewModel contactsListViewModel;
        public MainViewModel(IModifyContactService modifyContactService, IPersistanceService<Contact> persistanceService, ContactsListViewModel contactsListViewModel)
        {
            this.modifyContactService = modifyContactService;
            this.persistanceService = persistanceService;
            this.contactsListViewModel = contactsListViewModel;

            this.newContactCommand = new RelayCommand(NewContact);
            this.editContactCommand = new RelayCommand(EditContact);
            this.loadSavedContactsCommand = new RelayCommand(LoadSavedContacts);
            this.saveStateCommand = new RelayCommand(SaveCurrentState);
            this.deleteContactCommand = new RelayCommand(DeleteContact);
        }

        public ObservableCollection<ContactViewModel> Contacts
        {
            get { return contactsListViewModel.Contacts; }
        }

        public ContactViewModel SelectedContact
        {
            get
            {
                return contactsListViewModel.SelectedContact;
            }
            set
            {
                contactsListViewModel.SelectedContact = value;
            }
        }

        public RelayCommand NewContactCommand
        {
            get { return newContactCommand; }
        }

        public RelayCommand EditContactCommand
        {
            get { return editContactCommand; }
        }

        public RelayCommand LoadSavedContactsCommand
        {
            get { return loadSavedContactsCommand; }
        }

        public RelayCommand SaveStateCommand
        {
            get { return saveStateCommand; }
        }

        private string FilePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    System.Reflection.Assembly.GetEntryAssembly().GetName().Name, "Contacts.xml");
            }
        }

        public RelayCommand DeleteContactCommand
        {
            get { return deleteContactCommand; }
        }

        private void NewContact(object parameter)
        {
            modifyContactService.AddContact(new Contact());
        }

        private void EditContact(object parameter)
        {
            ContactViewModel contactModel = parameter as ContactViewModel;
            if (contactModel == null)
            {
                return;
            }
            modifyContactService.EditContact(contactModel.Contact);
        }

        private void DeleteContact(object parameter)
        {
            ContactViewModel contactModel = parameter as ContactViewModel;
            if (contactModel == null)
            {
                return;
            }
            modifyContactService.DeleteContact(contactModel);
        }

        private void LoadSavedContacts(object parameter)
        {
            var contacts = persistanceService.Load(FilePath);
            if (contacts != null)
            {
                foreach (var contact in contacts)
                {
                    contactsListViewModel.AddNewContactViewModel(contact);
                }
            }
        }

        private void SaveCurrentState(object parameter)
        {
            if (Contacts.Count <= 0)
            {
                return;
            }
            persistanceService.Save(FilePath, Contacts
                .Select(x => x.Contact)
                .ToList());
        }
    }
}
