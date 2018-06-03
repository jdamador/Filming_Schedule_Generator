using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FilmingReneratorSystem
{
    class GeneticAlgorithm
    {
        private List<Scene> father;
        private List<Scene> mother;
        private Stage stage;

        public GeneticAlgorithm(Stage stage)
        {
            this.stage = stage;
            generateStartPopulation();
            orderOne_crossover();
        }
        /// <summary>
        /// Generate start population
        /// </summary>
        public void generateStartPopulation()
        {
            father = stage.scenes;
            List<Scene> aux = ShallowClone(stage.scenes);
            aux.Reverse();
            mother = aux;
        }
        public void orderOne_crossover()
        {
            OrderOne_Crossover orderOne = new OrderOne_Crossover();
            List<Scene> child = orderOne.orderOneCrossover(father, mother);
            Evaluating evaluator = new Evaluating(stage);
            if (evaluator.isFactible(child))
            {

            }
        }
        private List<T> ShallowClone<T>(List<T> items)
        {
            return new List<T>(items);

        }
    }
}