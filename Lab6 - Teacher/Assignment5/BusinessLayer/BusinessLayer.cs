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
        private readonly ICourseRepository _courseRepository;

        public BusinessLayer()
        {
            _standardRepository = new StandardRepository();
            _studentRepository = new StudentRepository();
            _teacherRepository = new TeacherRepository();
            _courseRepository = new CourseRepository();
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

        public void AddStudent(Student student)
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
            var courses = GetAllCourses().Where(c => c.TeacherId == teacher.TeacherId);
            foreach (Course course in courses)
            {
                course.TeacherId = null;
                UpdateCourse(course);
            }
            _teacherRepository.Delete(teacher);
        }
        #endregion

        #region Courses
        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }

        public Course GetCourseByID(int id)
        {
            return _courseRepository.GetById(id);
        }

        public void AddCourse(Course course)
        {
            _courseRepository.Insert(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }

        public void RemoveCourse(Course course)
        {
            _courseRepository.Delete(course);
        }
        #endregion


    }
}