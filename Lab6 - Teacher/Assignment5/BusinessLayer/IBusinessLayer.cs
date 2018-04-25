using DataAccessLayer;
using System.Collections.Generic;

namespace Business
{
    public interface IBusinessLayer
    {
        #region Standard
        IEnumerable<Standard> GetAllStandards();

        Standard GetStandardByID(int id);

        Standard GetStandardByName(string name);

        void AddStandard(Standard standard);

        void UpdateStandard(Standard standard);

        void RemoveStandard(Standard standard);
        #endregion

        #region Student
        IList<Student> getAllStudents();
        Student GetStudentByID(int id);
        void addStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);

        #endregion

        #region Teachers
        IEnumerable<Teacher> getAllTeachers();
        Teacher GetTeacherByID(int id);
        void AddTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void RemoveTeacher(Teacher teacher);
        #endregion
    }
}