using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class BranchAndBound
    {
        #region Region to create Information
        public List<Scene> visited = new List<Scene>();    // Lista de nodos visitados
        public List<Scene> notVisited = new List<Scene>(); // Lista de nodos vivos        
        public Calendar bestCalendar = new Calendar();
        public Evaluating evaluation; // Contiene algunos metodos para validar
        #endregion
        #region Region to start B&B
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stage"></param>
        public BranchAndBound(Stage stage)
        {
            evaluation = new Evaluating(stage);
            notVisited = evaluation.shallowClone(stage.scenes);
            visited = evaluation.shallowClone(stage.scenes);
            runBB();
            
        }

        /// <summary>
        /// Start Algorithm
        /// </summary>
        public void runBB()
        {

            
            goAlgorithm(notVisited); // Go B&B

            seeBestCalendar(); // see Best Calendar
           
            Console.ReadKey();

        }
        #endregion
        #region Region Branch and Bound
        /// <summary>
        /// Run Algorithm
        /// </summary>
        /// <param name="NotVisited"></param>
        public void goAlgorithm(List<Scene> notVisited)
        {
            if (notVisited.Count == 0)
            {
                evaluation.seeCombination(visited);
                Console.WriteLine("Costo: "+evaluation.getCostScenes(visited));
                if(evaluation.isFactible(visited))
                    if (evaluation.getCostScenes(visited) < bestCalendar.bestCost ) 
                    {
                        changeBestCalendar(visited); 
                    }
            }
            else
            {
                foreach(Scene scene in notVisited)
                {
                    evaluation.seeCombination(visited);
                    Console.WriteLine("Costo: " + evaluation.getCostScenes(visited));
                    // Impletation LC-FIFO
                    if (evaluation.getCostScenes(visited) > bestCalendar.bestCost)
                        return;

                    // Generate Combination
                    this.visited.Remove(scene); this.visited.Add(scene);

                    List<Scene> auxScene = evaluation.shallowClone(notVisited);
                    auxScene.Remove(scene);
                    goAlgorithm(auxScene);
                }
            }
        }
        #endregion
        #region Change Best Calendar
        /// <summary>
        /// Change Best Calendar
        /// </summary>
        /// <param name="listScenes"></param>
        public void changeBestCalendar(List<Scene> listScenes)
        {
            this.bestCalendar.listScenes = evaluation.shallowClone(listScenes);
            this.bestCalendar.bestCost = evaluation.getCostScenes(bestCalendar.listScenes);
 
        }
        #endregion
        #region seeBestCalendar
        public void seeBestCalendar()
        {
            Console.WriteLine("========= Mejor Calendario ========= ");
            evaluation.seeCombination(bestCalendar.listScenes);
            Console.WriteLine("COSTO: " + bestCalendar.bestCost);
        }
        #endregion

    }
}
