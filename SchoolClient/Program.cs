using System;
using System.Linq;
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
                            break;
                        case "show-all":
                                break;
                        case "new-teacher":
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
            }
        }
    }
}
