using System;
using System.Diagnostics.Eventing.Reader;
using ContactManagement.Factories;
using ContactManagement.Models;
using ContactManagement.ViewModels;
using System.Windows;

namespace ContactManagement.Services
{
    public class ModifyContactService : IModifyContactService
    {
        private readonly IFactory<IDialogWindow> modifyContactDialogFactory;
        private readonly IModifyContactModelFactory contactModelFactory;
        private readonly IContactViewModelModifyService contactModifyService;

        public ModifyContactService(IFactory<IDialogWindow> modifyContactDialogFactory, IModifyContactModelFactory contactModelFactory,
            IContactViewModelModifyService contactModifyService)
        {
            this.modifyContactDialogFactory = modifyContactDialogFactory;
            this.contactModelFactory = contactModelFactory;
            this.contactModifyService = contactModifyService;
        }

        public void AddContact(Contact contact)
        {
            var viewModel = contactModelFactory.Create(contact, EditType.CreateNew);
            bool? addSucceeded = DoModifyContact(contact, viewModel);
            if (addSucceeded.HasValue && addSucceeded.Value)
            {
                contactModifyService.AddContactViewModel(contact);
            }
        }

        public void EditContact(Contact contact)
        {
            var viewModel = contactModelFactory.Create(contact, EditType.Modify);
            viewModel.BeginEdit();
            bool? editSucceeded = null;
            try
            {
                editSucceeded = DoModifyContact(contact, viewModel);
            }
            finally
            {
                if (editSucceeded.HasValue && editSucceeded.Value)
                {
                    viewModel.EndEdit();
                }
                else
                {
                    viewModel.CancelEdit();
                }
            }
        }

        public void DeleteContact(ContactViewModel contactViewModel)
        {
            contactModifyService.DeleteContactViewModel(contactViewModel);
        }

        private bool? DoModifyContact(Contact contact, ModifyContactViewModel viewModel)
        {
            var window = modifyContactDialogFactory.Create();
            window.Owner = Application.Current.MainWindow;
            window.DataContext = viewModel;
            return window.ShowDialog();
        }
    }
}