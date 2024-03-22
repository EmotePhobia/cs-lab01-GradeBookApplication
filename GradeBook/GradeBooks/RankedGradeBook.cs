using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name) 
        {
            Type = Enums.GradeBookType.Ranked;
        }
        
        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires minimum 5 students");
            }
         
            var grades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();
            int threshold20 = (int)Math.Ceiling(Students.Count * 0.2);
            int threshold40 = (int)Math.Ceiling(Students.Count * 0.4);
            int threshold60 = (int)Math.Ceiling(Students.Count * 0.6);
            int threshold80 = (int)Math.Ceiling(Students.Count * 0.8);
            int index = grades.FindIndex(g => g == averageGrade);

            if(index < 0)
            {
                throw new InvalidOperationException("Student grade not found.");
            }
            
            if(index < threshold20 )
            {
                return 'A';
            }
            else if (index < threshold40) 
            {
                return 'B';
            }
            else if(index < threshold60)
            {
                return 'C';
            }
            else if(index < threshold80)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }

        }
    }
}
