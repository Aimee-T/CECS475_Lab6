using DataAccessLayer;
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
        static void Main(string[] args)
        {
            int a = -1;
            do
            {
                Console.WriteLine
                   (
                   "\n 0. Exit Program \n 1. Add Standard \n 2. Update Standard \n" +
                   " 3. Delete Standard \n 4. Get All Standards \n 5. Add Student \n" +
                   " 6. Update Student \n 7. Delete Student \n" +
                   " 8. Get All Students \n"
                   );
                try { a = Int32.Parse(Console.ReadLine()); } catch { Console.WriteLine("Not Valid Menu Selection"); }
                Console.WriteLine("\n");

                BusinessLayer myBusinessLayer = new BusinessLayer();

                switch (a)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.WriteLine("Standard Name:");
                        string sName = Console.ReadLine();
                        Console.WriteLine();
                        DataAccessLayer.Standard newStandard = new DataAccessLayer.Standard() { StandardName = sName };
                        myBusinessLayer.AddStandard(newStandard);
                        Console.WriteLine("Standard: " + sName + " created.");
                        break;
                    case 2:
                        Console.WriteLine("Enter Standard Id:");
                        int nameStan = Int32.Parse(Console.ReadLine());
                        if (myBusinessLayer.GetStandardByID(nameStan) != null)
                        {
                            Console.WriteLine("\n1.Update Standard Name 2. Get All Teachers in Standard \n 3. Get All Students in Standard \n");
                            int menuOption = Int32.Parse(Console.ReadLine());
                            if (menuOption == 1)
                            {
                                Console.WriteLine("Enter New Name For Standard");
                                myBusinessLayer.GetStandardByID(nameStan).StandardName = Console.ReadLine();
                                myBusinessLayer.UpdateStandard(myBusinessLayer.GetStandardByID(nameStan));
                                Console.WriteLine("Standard Name has been updated to: " + myBusinessLayer.GetStandardByID(nameStan).StandardName);
                            }
                            if (menuOption == 2)
                            {
                                var b = myBusinessLayer.GetStandardByID(nameStan).Teachers;
                                if (b != null)
                                {
                                    Console.WriteLine("Teachers in standard :" + myBusinessLayer.GetStandardByID(nameStan).StandardName + "\n");
                                    foreach (var c in b)
                                    {
                                        Console.WriteLine("ID:" + c.TeacherId + " Name:" + c.TeacherName + "\n");
                                    }

                                }

                            }
                            else if (menuOption == 3)
                            {

                                var b = myBusinessLayer.GetStandardByID(nameStan).Students;
                                if (b != null)
                                {
                                    Console.WriteLine("Students in standard :" + myBusinessLayer.GetStandardByID(nameStan).StandardName + "\n");
                                    foreach (var c in b)
                                    {
                                        Console.WriteLine("ID: " + c.StudentID + " " + c.StudentName + "\n");
                                    }

                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Standard by that ID wasnt found");
                        }
                        break;
                    case 3:
                        Console.WriteLine("ID of Standard to Delete");
                        int idStud = Int32.Parse(Console.ReadLine());
                        if (myBusinessLayer.GetStandardByID(idStud) == null)
                        {
                            Console.WriteLine("No standard by that ID or Name was found. Returning to main menu");
                        }
                        else
                        {
                            Console.WriteLine("Standard: " + myBusinessLayer.GetStandardByID(idStud).StandardName + " has been deleted");
                            myBusinessLayer.RemoveStandard(myBusinessLayer.GetStandardByID(idStud));
                        }
                        break;
                    case 4:

                        foreach (var b in myBusinessLayer.GetAllStandards())
                        {
                            Console.WriteLine(b.StandardId + " " + b.StandardName + " " + b.Description);
                        }

                        break;
                    case 5:
                        Console.WriteLine("Student Name:");
                        string sName1 = Console.ReadLine();
                        DataAccessLayer.Student newStudenttoAdd = new DataAccessLayer.Student();
                        newStudenttoAdd.StudentName = sName1;
                        myBusinessLayer.addStudent(newStudenttoAdd);
                        Console.WriteLine("Student Created: " + newStudenttoAdd.StudentName + " created.");
                        break;
                    case 6:
                        Console.WriteLine("Enter Student ID: ");
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
                        break;
                    case 7:
                        Console.WriteLine("ID of Student to Delete");
                        int idDeleteStud = Int32.Parse(Console.ReadLine());
                        if (myBusinessLayer.GetStudentByID(idDeleteStud) == null)
                        {
                            Console.WriteLine("No student by that ID or Name was found. Returning to main menu");
                        }
                        else
                        {
                            Console.WriteLine("Student: " + myBusinessLayer.GetStudentByID(idDeleteStud).StudentName + " has been deleted");
                            myBusinessLayer.RemoveStudent(myBusinessLayer.GetStudentByID(idDeleteStud));
                        }
                        break;
                    case 8:
                        var allStudentsPrint = myBusinessLayer.getAllStudents().GroupBy(s => s.StudentID).Select(t => t.First());
                        foreach (var b in allStudentsPrint)
                        {
                            Console.WriteLine(b.StudentID + " " + b.StudentName + " ");
                        }
                        break;

                    default:
                        Console.WriteLine("Please select a valid Menu Option");
                        break;
                }
            }
            while ((a >= 0) & (a < 12));
        }
    }
}
