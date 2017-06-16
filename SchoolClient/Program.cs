using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolModel;

namespace SchoolClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //console.write type help for availableCommands;

            //string availableCommands from file;



            using (SchoolContext schoolContext = new SchoolContext())
            {
                while (!exitRequired)
                {
                    string command = Console.ReadLine();

                    string[] tokens = command.Split(' ');

                    switch (tokens.First())
                    {
                        case "help":
                            Console.WriteLine(availableCommands);
                            break;
                        case "show-all":
                            ShowAll(schoolContext);
                                break;
                        case "new-teacher":
                            CreateNewTeacher(schoolContext, tokens[1], )
                            break;
                        case "new-classroom":
                            break;
                        case "edit-teacher data":
                            break;
                        case "edit-classroom data":
                            break;
                        case "remove-teacher data":
                            break;
                        case "remove-classroom data":
                            break;
                        case "exit":
                            break;
                        default:
                            Console.WriteLine("Wrong command, enter 'help' to get list of available commands");
                            break;
                    }
                }



                Teacher teacher1 = new Teacher() { Name = "name1", Surname = "surname1", Patronymic = "Patronymic1" };
                schoolContext.Teachers.Add(teacher1);
                schoolContext.SaveChanges();
            }
        }

        private static void ShowAll(SchoolContext schoolContext)
        {
            foreach (Teacher teacher in schoolContext.Teachers)
            {
                Console.WriteLine("Teacher name\tTeachersurname\tTeacher");
                Console.WriteLine(teacher.Name + "\t" + teacher.Surname + "\t" + teacher.Patronymic + "\t" + teacher.Classroom == null? teacher.Classroom.ClassroomNumber + "\t" + teacher.Classroom.Name : string.Empty);
                
            }
        }

        private static void CreateNewTeacher(SchoolContext schoolContext, string name, string surmane)
        {

        }
    }
}
