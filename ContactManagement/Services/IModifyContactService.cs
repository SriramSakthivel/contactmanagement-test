using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement.Models;
using ContactManagement.ViewModels;

namespace ContactManagement.Services
{
    public interface IModifyContactService
    {
        void AddContact(Contact contact);
        void EditContact(Contact contact);
        void DeleteContact(ContactViewModel contactViewModel);
    }
}
