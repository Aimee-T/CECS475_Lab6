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
            do {
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

                var allStudentsPrint = myBusinessLayer.getAllStudents().GroupBy(s => s.StudentID).Select(t => t.First());
                foreach (var b in allStudentsPrint)
                {
                    Console.WriteLine(b.StudentID + " " + b.StudentName + " ");
                }
                break;
            }
            while ((a >= 0) & (a < 12));
        }
    }
}
