using System.Threading.Channels;

namespace Abstraction__Polymorphism__Static__Extension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Program run olduqda:
            //1) Bir user yaradılmalıdı bunun üçün console-dan user -in bütün dəyərləri götürülüb yeni   bir user   yaradılır.
            User user1 = new User("", "Aa123456");
            Console.WriteLine("Enter Fullname:");
            string fullname = Console.ReadLine();
            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();
            do
            {
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();
                user1 = new User(email, password);
                if (fullname != null) user1.Fullname = fullname;
            } while (user1.Password == null);
            //2) Bir menu gəlir:
            //    1.Show info
            //    2.Create new group

            Console.WriteLine("1.Show info \r\n2.Create new group");
            switch (Console.ReadLine())
            {
                case "1":
                    //Əgər console-dan 1 göndərilsə user-in bütün məlumatları ekrana çıxmalıdı,
                    user1.ShowInfo();
                    break;
                case "2":
                    //2 göndərildiyi halda console - dan group - un bütün məlumatları göndərilməli və yeni bir qrup obyekti yaradılmalıdır.
                    Console.WriteLine("Enter groupNo: (XX000)");
                    string groupNo = Console.ReadLine();
                    Console.WriteLine("Enter student limit: (5-18)");
                    int studentLimit = Convert.ToInt32(Console.ReadLine());
                    Group group1 = new Group(groupNo, studentLimit);
                    //3) Group obyekti yaradildiqdan sona bir Menu gəlməlidi və menu - da aşağıdakı əməliyyatlar olmalıdı:
                    string input;
                    do
                    {
                        Console.WriteLine("1.Show all students\r\n2.Get student by id\r\n3.Add student\r\n0.Quit");
                        input = Console.ReadLine();

                        switch (input)
                        {
                            //Əgər console-dan 1 göndərilsə ekrana bütün student-lərin məlumatları çıxamlıdı, 2 göndərilsə console-dan bir id istənməlidir və həmin id-li Student obyekti tapılıb onun bütün məlumatları console - a yazdırılmalıdır, 3 göndərilsə console-dan Student -in bütün məlumatları istənib yeni bir Student yaranmalıdır, 0 göndərilərsə program sonlanmalıdır.
                            case "1":
                                var arr = group1.GetAllStudents();
                                foreach (var s in arr) s.StudentInfo();
                                break;
                            case "2":
                                Console.WriteLine("Enter id:");
                                var id = Convert.ToInt32(Console.ReadLine());
                                var student = group1.GetStudent(id);
                                if (student != null) student.StudentInfo();
                                else Console.WriteLine("Not found");
                                break;
                            case "3":
                                Console.WriteLine("Enter Fullname:");
                                string fullname2 = Console.ReadLine();
                                Console.WriteLine("Enter point:");
                                int point = Convert.ToInt32(Console.ReadLine());
                                Student student1 = new Student(fullname2, point);
                                group1.AddStudent(student1);
                                break;
                            case "0":
                                Console.WriteLine("Exit");
                                break;
                            default:
                                Console.WriteLine("Input is not correct");
                                break;
                        }
                    } while (input != "0");
                    break;
                default:
                    Console.WriteLine("Input is not correct");
                    break;
            }
        }
    }
}

