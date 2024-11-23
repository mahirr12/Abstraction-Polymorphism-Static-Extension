using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction__Polymorphism__Static__Extension
{
//Student class
//- Id
//- Fullname
//- Point
//- StudentInfo() - Student-in bütün məlumatlarını ekrana console-a yazdırır


//ps: Id dəyəri hər dəfə bir student obyekti yaranan zaman avtomatik artmalıdır və qıraqdan id dəyərini dəyişmək olmamalıdı ancaq get etmək olar.Fullname və point olmadan student obyekti yaratmaq olmaz.
    public class Student
    {
        private static int _count = 0;
        public int Id { get; private set; }
        public string Fullname { get; set; }
        public int Point { get; set; }

        public Student(string fullname, int point)
        {
            _count++;
            Id=_count;
            Fullname = fullname;
            Point = point;
        }

        public void StudentInfo()
        {
            Console.WriteLine($"Id: {Id}\r\nFullname: {Fullname}\r\nPoint: {Point}");
        }
    }
}
