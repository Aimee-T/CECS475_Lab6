﻿using DataAccessLayer;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Program
    {
        static void Add(BusinessLayer myBusinessLayer, LayerType layerType)
        {

            Console.WriteLine("Name:");
            string Name = Console.ReadLine();
            switch(layerType)
            {
                case LayerType.STANDARD:
                    Standard newStandard = new Standard() { StandardName = Name };
                    myBusinessLayer.AddStandard(newStandard);
                    Console.WriteLine("Standard: " + Name + " created.");
                    break;
                case LayerType.STUDENT:
                    Student newStudent = new Student() { StudentName = Name };
                    myBusinessLayer.AddStudent(newStudent);
                    Console.WriteLine("Student: " + Name + " created.");
                    break;
                case LayerType.TEACHER:
                    Teacher newTeacher = new Teacher() { TeacherName = Name };
                    myBusinessLayer.AddTeacher(newTeacher);
                    Console.WriteLine("Teacher: " + Name + " created.");
                    break;
                case LayerType.COURSE:
                    Course newCourse = new Course() { CourseName = Name };
                    myBusinessLayer.AddCourse(newCourse);
                    Console.WriteLine("Course: " + Name + " created.");
                    break;
                default:
                    break;
            }
        }

        static void Update(BusinessLayer myBusinessLayer, LayerType layerType)
        {

            Console.WriteLine("Name or Id:");
            string Name = Console.ReadLine();
            switch (layerType)
            {
                case LayerType.STANDARD:

                    break;
                case LayerType.STUDENT:

                    break;
                case LayerType.TEACHER:
  
                    break;
                case LayerType.COURSE:

                    break;
                default:
                    break;
            }
        }

        static void Delete(BusinessLayer myBusinessLayer, LayerType layerType)
        {

            Console.WriteLine("Id to delete:");
            int Id = Int32.Parse(Console.ReadLine());
            switch (layerType)
            {
                case LayerType.STANDARD:
                   
                    if (myBusinessLayer.GetStandardByID(Id) == null)
                        Console.WriteLine("No standard by that ID or Name was found.");
                    else
                        Console.WriteLine("Standard: " + myBusinessLayer.GetStandardByID(Id).StandardName + " has been deleted");
                        myBusinessLayer.RemoveStandard(myBusinessLayer.GetStandardByID(Id));
                    break;
                case LayerType.STUDENT:
                    if (myBusinessLayer.GetStudentByID(Id) == null)
                        Console.WriteLine("No student by that ID or Name was found. Returning to main menu");
                    else
                    {
                        Console.WriteLine("Student: " + myBusinessLayer.GetStudentByID(Id).StudentName + " has been deleted");
                        myBusinessLayer.RemoveStudent(myBusinessLayer.GetStudentByID(Id));
                    }
                    break;
                case LayerType.TEACHER:
                    if (myBusinessLayer.GetTeacherByID(Id) == null)
                        Console.WriteLine("No teacher by that ID or Name was found. Returning to main menu");
                    else
                    {
                        Console.WriteLine("Teacher: " + myBusinessLayer.GetTeacherByID(Id).TeacherName + " has been deleted");
                        myBusinessLayer.RemoveTeacher(myBusinessLayer.GetTeacherByID(Id));
                    }
                    break;
                case LayerType.COURSE:
                    if (myBusinessLayer.GetCourseByID(Id) == null)
                        Console.WriteLine("No Course by that ID or Name was found. Returning to main menu");
                    else
                    {
                        Console.WriteLine("Course: " + myBusinessLayer.GetCourseByID(Id).CourseName + " has been deleted");
                        myBusinessLayer.RemoveCourse(myBusinessLayer.GetCourseByID(Id));
                    }
                    break;
                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            int choice = -1;
            do
            {
                Console.WriteLine
                   (
                   "\n 0. Exit Program \n 1. Add Teacher \n 2. Update Teacher \n" +
                   " 3. Delete Teacher \n 4. Get Teacher's courses \n 5. Display all standards \n" +
                   " 6. Add Course \n 7. Update Course \n" +
                   " 8. Delete Course \n 9. Display all courses\n"
                   );
                try {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch {
                    Console.WriteLine("Selection invalid\n");
                }

                BusinessLayer myBusinessLayer = new BusinessLayer();

                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Add(myBusinessLayer, LayerType.TEACHER);
                        break;
                    case 2:
                       //Update Teacher
                        break;
                    case 3:
                        Delete(myBusinessLayer, LayerType.COURSE);
                        break;
                    case 4:
                        //get all teacher's courses
                        break;
                    case 5:
                        foreach (var b in myBusinessLayer.GetAllStandards())
                        {
                            Console.WriteLine(b.StandardId + " " + b.StandardName + " " + b.Description);
                        }
                        break;
                    case 6:
                        Add(myBusinessLayer, LayerType.COURSE);
                        break;
                    case 7:
                        //Update Course
                        break;
                    case 8:
                        Delete(myBusinessLayer, LayerType.COURSE);
                        break;
                    case 9:
                        var allCoursesPrint = myBusinessLayer.GetAllCourses().GroupBy(c => c.CourseId).Select(t => t.First());
                        foreach (var course in allCoursesPrint)
                        {
                            Console.WriteLine(course.CourseId + " " + course.CourseName + " ");
                        }
                        break;

                    default:
                        Console.WriteLine("Please select a valid Menu Option");
                        break;
                }
            }
            while ((choice >= 0) & (choice < 10));
        }
    }

    enum LayerType
    {
        STANDARD,
        STUDENT,
        TEACHER,
        COURSE
    }
}


/*
 *  Console.WriteLine("Enter Student ID: ");
                        int nx = int.Parse(Console.ReadLine());
                        if (myBusinessLayer.getAllStudents().Where(s => s.StudentID == nx).FirstOrDefault() == null)
                        {
                            Console.WriteLine("Student not found. Returning to main menu.");
                        }
                        else
                        {
                            Console.WriteLine("\n1.Update Student Name \n2.Add to existing Standard");

                            int menuOption = Int32.Parse(Console.ReadLine());
                            if (menuOption == 1)
                            {

                                Console.WriteLine("Enter New Name for Student: ");
                                myBusinessLayer.GetStudentByID(nx).StudentName = Console.ReadLine();
                                myBusinessLayer.UpdateStudent(myBusinessLayer.GetStudentByID(nx));
                                Console.WriteLine("Student Updated");

                            }
                            else if (menuOption == 2)
                            {
                                Console.WriteLine("Enter Standard ID:");
                                int stanID = Int32.Parse(Console.ReadLine());

                                if (myBusinessLayer.GetAllStandards().Where(s => s.StandardId == stanID).FirstOrDefault() != null)
                                {
                                    myBusinessLayer.GetStudentByID(nx).StandardId = myBusinessLayer.GetStandardByID(stanID).StandardId;
                                    myBusinessLayer.UpdateStudent(myBusinessLayer.GetStudentByID(nx));
                                    myBusinessLayer.UpdateStandard(myBusinessLayer.GetStandardByID(stanID));
                                }
                                else
                                {
                                    Console.WriteLine("No Standard was found with that ID");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No valid menu option selected. Returning to main menu");
                            }
                        }
*/