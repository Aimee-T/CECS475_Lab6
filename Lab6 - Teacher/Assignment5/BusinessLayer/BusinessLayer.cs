using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Business
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IStandardRepository _standardRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public BusinessLayer()
        {
            _standardRepository = new StandardRepository();
            _studentRepository = new StudentRepository(); 

        }

        #region Standard
        public IEnumerable<Standard> GetAllStandards()
        {
            return _standardRepository.GetAll();
        }

        public Standard GetStandardByID(int id)
        {
            return _standardRepository.GetById(id);
        }

        public Standard GetStandardByName(string name)
        {
            return _standardRepository.GetSingle(
                s => s.StandardName.Equals(name),
                s => s.Students);
        }

        public void AddStandard(Standard standard)
        {
            _standardRepository.Insert(standard);
        }

        public void UpdateStandard(Standard standard)
        {
            _standardRepository.Update(standard);
        }

        public void RemoveStandard(Standard standard)
        {
            _standardRepository.Delete(standard);
        }
        #endregion

        #region Student
        public IList<Student> getAllStudents()
        {
            return _studentRepository.GetAll().ToList<Student>();
        }

        public Student GetStudentByID(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void addStudent(Student student)
        {
            _studentRepository.Insert(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public void RemoveStudent(Student student)
        {
            _studentRepository.Delete(student);
        }
        #endregion

        #region Teacher
        public IEnumerable<Teacher> getAllTeachers()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetTeacherByID(int id)
        {
            return _teacherRepository.GetById(id);
         }

        public void AddTeacher(Teacher teacher)
        {
            _teacherRepository.Insert(teacher);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            _teacherRepository.Delete(teacher);
        }
        #endregion


    }
}