using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;

namespace PredicateBuilderSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = Student.GetStudents();


            var predicate = PredicateBuilder.New<Student>(true);
            predicate.And(x => x.Year < 2000);
            predicate.And(x => x.Name.ToLower().Contains("a"));

            var result = students.Where(predicate);
                    

            foreach (var i in result)
                Console.WriteLine($"{i.Name,-20}\t{i.Year}");

                
        }
    }
}
