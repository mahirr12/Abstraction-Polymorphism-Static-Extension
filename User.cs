using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction__Polymorphism__Static__Extension
{
    //    User class (IAccount-u implement edir)
    //- Id
    //- Fullname
    //- Email
    //- Password
    //ps: Id dəyəri hər dəfə bir user obyekti yaranan zaman avtomatik artmalıdır və qıraqdan id dəyərini dəyişmək olmamalıdı ancaq get etmək olar.User yarandığı zaman email və password təyin edilməsi məcburidir.User-ə şifrə təyin edilərkən şifrənin PasswordChecker methodunun şərtlərini ödəməsi lazımdır.
    public class User : IAccount
    {
        private static int _count = 0;
        public int Id { get; private set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        private string _pass;
        public string Password
        {
            get => _pass;
            set
            {
                if (PasswordChecher(value))
                {
                    _pass = value;
                }else Console.WriteLine("Password must contain at least 1 uppercase 1 lowercase and 1 number.\nPassword's minimum length must be 8.");
            }
        }

        public User(string email, string pass)
        {
            _count++;
            Id = _count;
            Email = email;
            Password = pass;
        }


        public bool PasswordChecher(string password)
        {
            //- PasswordChecker() - PasswordChecker methodu - gələn string password dəyərinin şərtləri ödəyib ödəmədiyini yoxlayıb true/false dəyər qaytarir.Şərtlər:
            //                        + şifrədə minimum 8 character olmalıdır
            //                        + şifrədə ən az 1 böyük hərf olmalıdır
            //                        + şifrədə ən az 1 kiçik hərf olmalıdır
            //                        + şifrədə ən az 1 rəqəm olmalıdır
            bool result = true;
            bool thereIsUpper = false;
            bool thereIsLower = false;
            bool thereIsDigit = false;

            foreach (char c in password)
            {
                if (Char.IsUpper(c))
                {
                    thereIsUpper = true; break;
                }
            }
            foreach (char c in password)
            {
                if (Char.IsLower(c))
                {
                    thereIsLower = true; break;
                }
            }
            foreach (char c in password)
            {
                if (Char.IsDigit(c))
                {
                    thereIsDigit = true; break;
                }
            }
            if (!thereIsLower || !thereIsUpper || !thereIsDigit || password.Length < 8) result = false;
            return result;
        }

        public void ShowInfo()
        {
            //- ShowInfo() - bu method console-a user-in Id, Fullname və email dəyərlərini yazdırır
            Console.WriteLine($"Id: {Id}\r\nFullname: {Fullname}\r\nEmail: {Email}");
        }
    }
}
