using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ContactManagement.Models;

namespace ContactManagement.ViewModels
{
    public class ModifyContactViewModel : ContactViewModelBase, IEditableObject
    {
        private Contact contactBeforeEdit;
        private readonly RelayCommand saveCommand;
        private bool? dialogResult;

        public ModifyContactViewModel(Contact contact, EditType editType)
            : base(contact)
        {
            this.EditType = editType;
            this.saveCommand = new RelayCommand(OnSaveCommand, CanSave);
        }

        public EditType EditType { get; set; }


        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public bool? DialogResult
        {
            get { return dialogResult; }
            set
            {
                dialogResult = value;
                OnPropertyChanged("DialogResult");
            }
        }

        private bool CanSave(object parameter)
        {
            return TypeDescriptor.GetProperties(this.GetType())
                .Cast<PropertyDescriptor>()
                .All(x => string.IsNullOrEmpty(Contact[x.Name]));
        }

        private void OnSaveCommand(object parameter)
        {
            if (CanSave(parameter))
            {
                this.DialogResult = true;
            }
        }

        #region IEditableObject Members...

        public void BeginEdit()
        {
            this.contactBeforeEdit = (Contact)this.Contact.Clone();
        }

        public void CancelEdit()
        {
            if (contactBeforeEdit != null)
            {
                contactBeforeEdit.Assign(this.Contact);
                contactBeforeEdit = null;
            }
        }

        public void EndEdit()
        {
            this.contactBeforeEdit = null;
        }

        #endregion
    }
}
