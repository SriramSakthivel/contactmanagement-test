using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ContactManagement.Models;

namespace ContactManagement.ViewModels
{
    public abstract class ContactViewModelBase : ViewModelBase, IDataErrorInfo
    {
        private Contact contact;
        private bool isDirty;
        protected ContactViewModelBase(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException("contact");
            }
            this.contact = contact;

            contact.PropertyChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
        }

        public Contact Contact
        {
            get { return contact; }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (object.ReferenceEquals(contact, value))
                {
                    return;//Same reference
                }
                contact = value;

                OnPropertyChanged("Contact");
            }
        }

        public string FirstName
        {
            get
            {
                return contact.FirstName;
            }
            set
            {
                contact.FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return contact.LastName;
            }
            set
            {
                contact.LastName = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return contact.Gender;
            }
            set
            {
                contact.Gender = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return contact.DateOfBirth;
            }
            set
            {
                contact.DateOfBirth = value;
            }
        }

        public string Phone
        {
            get
            {
                return contact.Phone;
            }
            set
            {
                contact.Phone = value;
            }
        }

        public string Country
        {
            get
            {
                return contact.Country;
            }
            set
            {
                contact.Country = value;
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            isDirty = true;
        }

        #region IDataErrorInfo members...
        public string this[string columnName]
        {
            get
            {
                return !isDirty ? string.Empty : contact[columnName];
            }
        }

        public string Error
        {
            get { return contact.Error; }
        }
        #endregion
    }
}
