 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class OrderOne
    {

        public OrderOne() {

        }
       
        public List<Scene> OrderOneCrossover(List<Scene> parent1, List<Scene> parent2)
        {
            List<Scene> aux = shallowClone(parent2);
           int c1 = (parent1.Count/2)- 1;
            int c2 = c1 + 1;
            aux.Remove(parent1[c1]);
            aux.Remove(parent1[c2]);
            List<Scene> offspring = new List<Scene>();
            offspring.Add(parent1[c1]);
            offspring.Add(parent1[c2]);
            foreach (Scene item in aux)
            {
                offspring.Add(item);
            }
            return offspring;
        }
        public List<T> shallowClone<T>(List<T> items)
        {

            return new List<T>(items);
        }
    }
}
