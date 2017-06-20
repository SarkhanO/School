using System;
using System.Linq;
using SchoolModel;
using System.Collections.Generic;

namespace SchoolViewModel
{
    /// <summary>
    /// Mediator between model and client app, used to get and set data to database
    /// </summary>
    public class DataManager : IDisposable
    {
        private SchoolContext SchoolContext { get; }

        public DataManager()
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
        public void AddTeacher(string name, string surname, string patronymic)
        {
            AddTeacher(name, surname, patronymic, null, null);
        }

        /// <summary>
        /// Creates a new teacher and a new classroom
        /// </summary>
        public void AddTeacher(string name, string surname, string patronymic, string classroomNumber, string classroomName)
        {
            Teacher newTeacher = new Teacher(name, surname, patronymic);
            if (classroomNumber != null && classroomName != null)
            {
                AddClassroom(newTeacher, classroomNumber, classroomName);
            }
            newTeacher.TeacherId = 1;
            SchoolContext.Teachers.Add(newTeacher);

            SchoolContext.SaveChanges();
        }

        public void AddClassroom(string teacherName, string teacherSurname, string classroomNumber, string classroomName)
        {
            //TODO: find teacher
            //AddClassroom(teacher, classroomNumber, classroomName);
            SchoolContext.SaveChanges();
        }

        public void EditTeacherData(string name, string surname, string patronymic, string classroomNumber, string classroomName)
        {
            //TODO: get teacher by name and surname
            //      check if teacher has only one classroom
            //SchoolContext.Teachers.
        }

        public void EditClassroomData(string classroomNumber, string classroomName)
        {
            //TODO: get classroom by number
        }

        public void RemoveTeacherAndClassroomData(string name, string surname)
        {
            //TODO: remove teacher AND classroom data from database, use RemoveClassroomData
        }

        public void RemoveClassroomData(string classroomNumber)
        {
            //TODO: remove classroomData
        }

        private void AddClassroom(Teacher teacher, string classroomNumber, string classroomName)
        {
            //check if class already exists
            Classroom newClassroom = new Classroom(classroomNumber, classroomName);
            newClassroom.Teacher = teacher;
            SchoolContext.Classrooms.Add(newClassroom); //do not save changes in database
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
