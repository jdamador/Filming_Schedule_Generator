using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class BranchAndBound
    {
        public List<Scene> visited = new List<Scene>();
        public List<Scene> notVisited = new List<Scene>(); // Lista de nodos vivos
        public List<Scene> listScenes = new List<Scene>(); //List of scenes for default
        public Calendar bestCalendar = new Calendar();
        public Evaluating evaluation;

        public BranchAndBound(Stage stage)
        {
            evaluation = new Evaluating(stage);
            listScenes = ShallowClone(stage.scenes); // get all calendars in this stage
           

            runBB();
            Console.ReadKey();
        }
        /// <summary>
        /// Start Algorithm
        /// </summary>
        public void runBB()
        {

            this.notVisited = ShallowClone(listScenes);

            goAlgorithm(notVisited);
            Console.WriteLine("======== Mejor Escena ======== ");
            seeCombination(bestCalendar.listScenes);
            Console.WriteLine("Costo: "+bestCalendar.bestCost);
            Console.ReadKey();

        }
        /// <summary>
        /// Run Algorithm
        /// </summary>
        /// <param name="NotVisited"></param>
        public void goAlgorithm(List<Scene> notVisited)
        {
            if (notVisited.Count == 0)
            {
                Console.WriteLine("======= Combinacion ======= ");
                seeCombination(visited);
                Console.WriteLine("Costo: " + evaluation.getCostScenes(visited));
                if (bestCalendar.listScenes.Count == 0)
                {// no tiene el mejor calendario
               
                    changeBestCalendar(visited);
                    
                }
                if (evaluation.getCostScenes(visited) < bestCalendar.bestCost) // Get Cost
                {
                    changeBestCalendar(visited);
                }
            }
            else
            {
                foreach (Scene scene in notVisited)
                {
                    
                    // Impletation LC-FIFO
                    if (evaluation.isFactible(visited) == false)
                    {
                        return;
                    }
                    else
                    {
                        // Generate Combination
                        this.visited.Remove(scene); this.visited.Add(scene);

                        List<Scene> auxScene = ShallowClone(notVisited);
                        auxScene.Remove(scene);
                        goAlgorithm(auxScene);
                    }

                }
            }
        }
       

        /// <summary>
        /// Change Best Calendar
        /// </summary>
        /// <param name="listScenes"></param>
        public void changeBestCalendar(List<Scene> listScenes)
        {
            this.bestCalendar.listScenes = listScenes;
            this.bestCalendar.bestCost = evaluation.getCostScenes(listScenes);
        }
        /// <summary>
        /// Return clone of the list 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        private List<T> ShallowClone<T>(List<T> items)
        {
            return new List<T>(items);
        }



        public bool isWorkable(Scene scene)
        {
            for (int i = 0; i < scene.listActors.Count; i++)
            {
                for (int j = 0; j < 10; j++) { }
            }
            return false;
        }
        /// <summary>
        /// See Combination 
        /// </summary>
        /// <param name="list"></param>
        public void seeCombination(List<Scene> list)
        {
            Console.WriteLine("$$$$$$$$ ORDENAMIENTO $$$$$$$$");
            string var = "";
            for (int i = 0; i < list.Count; i++)
            {
                var += list[i].id + " -- ";
            }
            Console.WriteLine(var);

        }
        
    }
}
