using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class Program
    {
        static void Main(String[] ar)
        {
            Movie movie = new Movie();
            new GeneticAlgorithm(movie.stages[1]);


            // Call Branch and Bound
            for (int i = 0; i < movie.stages.Count; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o| ESCENARIO " + (i + 1) + " |o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|");
                new BranchAndBound(movie.stages[i]);
            }
            Console.ReadKey();
        }
    }
}
