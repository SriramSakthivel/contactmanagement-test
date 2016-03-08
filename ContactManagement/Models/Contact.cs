using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ContactManagement.Models
{
    public class Contact : IDataErrorInfo, ICloneable, IAssignable<Contact>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string firstName;
        private string lastName;
        private Gender gender;
        private DateTime dateOfBirth;
        private string phone;
        private string country;

        public Contact()
        {

        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                if (dateOfBirth == value)
                {
                    return;
                }
                dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        #region INotifyPropertyChanged Members...
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion

        #region IDataErrorInfo Members...
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "FirstName":
                    case "LastName":
                        {
                            string propertyToCheck = columnName == "FirstName"
                                ? FirstName
                                : LastName;
                            if (string.IsNullOrWhiteSpace(propertyToCheck))
                            {
                                return string.Format("{0} cannot be empty", columnName);
                            }
                            break;
                        }
                    case "Phone":
                        {
                            if (!string.IsNullOrEmpty(Phone) && !Phone.All(char.IsNumber))
                            {
                                return "Please enter valid phone number";
                            }
                            break;
                        }
                    case "DateOfBirth":
                        {
                            var today = DateTime.Today;
                            var dob = dateOfBirth;
                            int currentYear = today.Year;
                            int age = currentYear - dob.Year;
                            if (dob > today.AddYears(-age))
                            {
                                age--;
                            }
                            if (age < 18 || age > 100)
                            {
                                return "Age should be between 18 and 100";
                            }
                            break;
                        }
                }

                return string.Empty;
            }
        }
        #endregion

        #region INotifyPropertyChanged Members...
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region IAssignable Members...
        public void Assign(Contact other)
        {
            if (other == null)
            {
                return;
            }
            other.Country = this.country;
            other.DateOfBirth = this.dateOfBirth;
            other.FirstName = this.firstName;
            other.Gender = this.gender;
            other.LastName = this.lastName;
            other.Phone = this.phone;
        }
        #endregion
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }
}
