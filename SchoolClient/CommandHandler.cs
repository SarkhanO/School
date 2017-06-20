using System;
using System.Linq;
using SchoolViewModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SchoolClient
{
    class CommandHandler : IDisposable
    {
        private const string helpFilePath = "Help.txt";

        private Action<string> OutputData { get; }
        private Func<string> GetCommand { get; }

        private DataManager DataManager { get; }

        /// <summary>
        /// Initializes a new command handler
        /// </summary>
        /// <param name="getCommand">Method that returns a command to process</param>
        /// <param name="outputData">Method for data output</param>
        public CommandHandler(Func<string> getCommand, Action<string> outputData)
        {
            //do NOT show list of available commands in help at command handler start
            GetCommand = getCommand;
            OutputData = outputData;

            DataManager = new DataManager();
        }
        
        public void ProcessNextCommand() //input string parameter, no getCommand?
        {
            string command = GetCommand().ToLower();

            string[] tokens = command.Split(' ');

            Dictionary<string, string> parametersValues = ParseCommand(tokens);

            switch (tokens.First())
            {
                case "help":
                    OutputData(System.IO.File.ReadAllText(helpFilePath)); //Load text from file once, do not store help in memory for a long time
                    break;
                case "show-all":
                    ShowAll();
                    break;
                case "add-teacher":
                    AddTeacher(parametersValues["teachername"], parametersValues["teachersurname"], parametersValues["teacherpatronymic"]);
                    break;
                case "add-classroom":
                    AddClassroom(parametersValues["teachername"], parametersValues["teachersurname"], parametersValues["classroomnumber"], parametersValues["classroomname"]);
                    break;
                case "edit-teacher-data":
                    EditTeacherData(parametersValues["teachername"], parametersValues["teachersurname"], parametersValues["teacherpatronymic"], parametersValues["classroomnumber"], parametersValues["classroomname"]);
                    break;
                case "edit-classroom-data":
                    EditClassroomData(parametersValues["classroomnumber"], parametersValues["classroomname"]);
                    break;
                case "remove-teacher-and-classroom-data":
                    RemoveTeacherAndClassroomData(parametersValues["teachername"], parametersValues["teachernurname"]);
                    break;
                case "remove-classroom-data":
                    RemoveClassroomData(parametersValues["classroomnumber"]);
                    break;
                default:
                    OutputData("Wrong command, use 'help' command to get list of available commands");
                    break;
            }
        }

        private Dictionary<string, string> ParseCommand(string[] tokens)
        {
            Regex keySearchRegex = new Regex("^--(.*)?=");
            Regex valueSearchRegex = new Regex("=?\"(.*?)\"$");

            Dictionary<string, string> parametersValues = new Dictionary<string, string>();
            foreach(string tocken in tokens)
            {
                parametersValues.Add(keySearchRegex.Match(tocken).Groups[1].Value, valueSearchRegex.Match(tocken).Groups[1].Value);
            }

            return parametersValues;
        }

        private void ShowAll()
        {
            OutputData("TeacherName\tTeacherSurname\tTeacherPatronymic\tClassroomNumber\tClassroomName");
            foreach(List<string> row in DataManager.GetTeachersClassrooms())
            {
                foreach(string cell in row)
                {
                    OutputData(cell + "\t");
                }
                OutputData(System.Environment.NewLine);
            }
        }

        private void AddTeacher(string name, string surname, string patronymic)
        {
            DataManager.AddTeacher(name, surname, patronymic);
        }

        /// <summary>
        /// creates a new teacher AND a classroom, as classroom cannot exist without a teacher
        /// </summary>
        private void AddClassroom(string teacherName, string teacherSurname, string classroomNumber, string classroomName)
        {
            DataManager.AddClassroom(teacherName, teacherSurname, classroomNumber, classroomName);
        }

        private void EditTeacherData(string name, string surname, string patronymic, string classroomNumber, string classroomName)
        {
            DataManager.EditTeacherData(name, surname, patronymic, classroomNumber, classroomName);
        }

        private void EditClassroomData(string classroomNumber, string classroomName)
        {
            DataManager.EditClassroomData(classroomNumber, classroomName);
        }

        private void RemoveTeacherAndClassroomData(string name, string surname)
        {
            DataManager.RemoveTeacherAndClassroomData(name, surname);
        }

        private void RemoveClassroomData(string classroomNumber)
        {
            DataManager.RemoveClassroomData(classroomNumber);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        public void Dispose()
        {
            if (!disposedValue)
            {
                DisposeManagedResources();
                disposedValue = true;
            }
        }

        protected virtual void DisposeManagedResources()
        {
            DataManager.Dispose();
        }
        #endregion
    }
}
