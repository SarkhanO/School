using System;
using System.Linq;
using SchoolModel;
using System.Collections.Generic;

namespace SchoolViewModel
{
    public class DbHandler : IDisposable
    {
        private SchoolContext SchoolContext { get; }

        public DbHandler()
        {
            SchoolContext = new SchoolContext();
        }

        /// <summary>
        /// Gets information about the teachers and the classrooms in the database
        /// </summary>
        /// <returns></returns>
        public List<List<string>> GetTeachersClassrooms()
        {
            List<List<string>> teachersClassrooms = new List<List<string>>();
            foreach(Teacher teacher in SchoolContext.Teachers)
            {
                List<string> teacherInfo = new List<string> { teacher.Name, teacher.Surname, teacher.Patronymic };

                if (teacher.Classroom != null)
                {
                    teacherInfo.Add(teacher.Classroom.Number);
                    teacherInfo.Add(teacher.Classroom.Name);
                }
                teachersClassrooms.Add(teacherInfo);
            }
            return teachersClassrooms;
        }

        /// <summary>
        /// Creates a new teacher without a classroom
        /// </summary>
        public void AddNewTeacher(string name, string surname, string patronymic)
        {
            AddNewTeacher(name, surname, patronymic);
        }

        /// <summary>
        /// Creates a new teacher and a new classroom
        /// </summary>
        public void AddNewTeacher(string name, string surname, string patronymic, string classroomNumber, string classroomName)
        {
            Teacher newTeacher = new Teacher(name, surname, patronymic);
            if (classroomNumber != null && classroomName != null)
            {
                Classroom newClassroom = new Classroom(classroomNumber, classroomName);
                SchoolContext.Classrooms.Add(newClassroom);
            }
            SchoolContext.Teachers.Add(newTeacher);

            SchoolContext.SaveChanges();
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
            SchoolContext.Dispose();
        }
        #endregion
    }
}
