using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction__Polymorphism__Static__Extension
{
//    IAccount(interface):
//- PasswordChecker() - parametr olaraq string password qəbul edir.
//- ShowInfo()
    public interface IAccount
    {
        bool PasswordChecher(string password);
        void ShowInfo();
    }
}
