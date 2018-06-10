/********************************************
 * Autores: Daniel Amador Salas
 *          Pablo Brenes Alfaro
 * Fecha de Inicio: 27/05/2018
 * Fecha de última modificación: 09/06/2018
 * ******************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class OrderOne
    {
        public int memory;
        public int asig = 0; public int comp = 0;
        public OrderOne() {
            memory = 0;
        }
        /// <summary>
        /// Start One Order Crossover 
        /// </summary>
        /// <param name="parent1"></param>
        /// <param name="parent2"></param>
        /// <returns></returns>
        public List<Scene> OrderOneCrossover(List<Scene> parent1, List<Scene> parent2)
        {
            memory = 0;
            asig = 0; comp = 0;
            List<Scene> aux = shallowClone(parent2); asig++;
            memory += aux.Count * new Scene(0).valueMemory;
            int c1 = (parent1.Count/2)- 1; asig++; // Point to cross one
            memory += 32;
            int c2 = c1 + 1; asig++;// Point to cross two
            memory += 32;
            aux.Remove(parent1[c1]); asig++;
            aux.Remove(parent1[c2]); asig++;
            List<Scene> offspring = new List<Scene>(); asig++; 
            // Crossover
            offspring.Add(parent1[c1]); asig++;
            offspring.Add(parent1[c2]); asig++;
            comp++; asig++;
            foreach (Scene item in aux)
            {
                asig++;
                offspring.Add(item); asig++;
            }
            memory += offspring.Count * new Scene(0).valueMemory; ;
            return offspring;
        }
        /// <summary>
        /// Cloning List 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<T> shallowClone<T>(List<T> items)
        {
            return new List<T>(items);
        }
    }
}
