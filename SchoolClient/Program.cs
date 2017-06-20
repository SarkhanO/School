using System;

namespace SchoolClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CommandHandler commandHandler = new CommandHandler(Console.ReadLine, Console.WriteLine)) //(File.Read(), FileWrite())?
            {
                Console.WriteLine("Type 'help' to get list of available commands"); //(Show message before ProcessNextCommand, NOT in commandHandler)
                while (true)
                {
                    commandHandler.ProcessNextCommand();
                }
            }
        }
    }
}
