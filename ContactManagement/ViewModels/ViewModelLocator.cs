using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement.Factories;
using ContactManagement.Models;
using ContactManagement.Persistance;
using ContactManagement.Services;

namespace ContactManagement.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            this.ContactsList = new ContactsListViewModel();

            var modifyContactService = new ModifyContactService(new ModifyContactDialogFactory(),
                new ModifyContactModelFactory(),
                new ContactViewModelAddService(ContactsList));

            this.Main = new MainViewModel(modifyContactService,
                new XmlPersistanceService<Contact>(new ConsoleLogService()),
                ContactsList);
        }

        public MainViewModel Main { get; private set; }

        public ContactsListViewModel ContactsList { get; private set; }

        public static void Cleanup()
        {
        }
    }
}
