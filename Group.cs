using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Abstraction__Polymorphism__Static__Extension
{
    //    Group class
    //- GroupNo
    //- StudentLimit - qrupda ola biləcək tələbə sayını göstərir minumum 5 maximum 18 ola bilər.
    //- Students - Student tipindən bir array-dir özündə student obyektləri saxlayacaq və private olacaq.

    //ps: GroupNo və StudentLimit dəyərləri olmadan Group Obyekti yaratmaq olmaz.
    public class Group
    {
        public string GroupNo { get; set; }
        private int _studentLimit;
        public int StudentLimit
        {
            get => _studentLimit;
            set
            {
                if (value>=5 && value<=18)
                {
                    _studentLimit = value;
                }
            }
        }
        private Student[] Students = Array.Empty<Student>();

        public Group(string groupNo, int studentLimit)
        {
            GroupNo = groupNo;
            StudentLimit = studentLimit;
        }

        public bool CheckGroupNo(string groupNo)
        {
            //- CheckGroupNo() - parametr olaraq string bir groupNo dəyəri alır və qrupun nömrəsini yoxlayır geriyə true/false dəyərləri qaytarır.

            // Şərtlər: 2 böyük hərf əvvəldə və 3 rəqəmdən ibarət olmalıdır
            bool result = true;
            if (groupNo.Length != 5 || !Char.IsUpper(groupNo[0]) || !Char.IsUpper(groupNo[1]) ||
                !Char.IsDigit(groupNo[2]) || !Char.IsDigit(groupNo[3]) || !Char.IsDigit(groupNo[4]))
                result = false;
            return result;
        }

        public void AddStudent(Student student)
        {
            //- AddStudent() - parametr olaraq Student obyekti qəbul edir və gələn student obyektini Group class-ında olan Students arrayinə əlavə edir əgər arrayin uzuluğu StudentLimit-i keçirsə əlavə etməməlidi.
            if (Students.Length < StudentLimit)
            {
                Array.Resize(ref Students, Students.Length + 1);
                Students[^1] = student;
            }
            else Console.WriteLine("Groud has reached student limit");
        }
        public Student GetStudent(int? id)
        {
            //- GetStudent() - parametr olaraq nullable int tipindən bir id dəyəri alacaq və həmin id-li Student obyektini tapıb geriyə qaytaracaq.

            foreach (Student student in Students)
            {
                if (student.Id == id) return student;
            }
            return null;
        }

        //- GetAllStudents() - geriyə Student arrayi qaytaracaq.
        public Student[] GetAllStudents() => Students;
    }
}
