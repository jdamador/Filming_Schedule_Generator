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
            new BranchAndBound(movie.stages[0]);
        }
    }
}
