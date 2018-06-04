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
            Console.WriteLine("COSTO: "+bestCalendar.bestCost);
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
                // Imprime rama
                seeCombination(visited);
                Console.WriteLine("COSTO: " + evaluation.getCostScenes(visited));

                if (evaluation.getCostScenes(visited) < bestCalendar.bestCost || bestCalendar.bestCost == 0) // Check si la rama actual es mejor
                {
                    Console.WriteLine("Entro");
                    //seeCombination(bestCalendar.listScenes);
                    changeBestCalendar(visited);//cambia
                }
            }
            else
            {
                foreach (Scene scene in notVisited)
                {

                    // Impletation LC-FIFO
                    if (evaluation.isFactible(visited))
                    {
                        //if (evaluation.getCostScenes(visited) > bestCalendar.bestCost)
                      //  {
                            // Generate Combination
                            this.visited.Remove(scene); this.visited.Add(scene);

                            List<Scene> auxScene = ShallowClone(notVisited);
                            auxScene.Remove(scene);
                            goAlgorithm(auxScene);
                        
                        //else {
                        //    continue;
                        //}

                    }
                        else // Poda
                        {
                            return;
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
            //Console.WriteLine("Mejor escenas");

            this.bestCalendar.listScenes = ShallowClone(listScenes);
            //seeCombination(bestCalendar.listScenes);
            this.bestCalendar.bestCost = evaluation.getCostScenes(bestCalendar.listScenes);
            Console.WriteLine("Costo Mejor Escenas: "+bestCalendar.bestCost);
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
            Console.WriteLine("");
            Console.WriteLine("$$$$$$$$ CALENDARIO $$$$$$$$");
            string var = "";
            for (int i = 0; i < list.Count; i++)
            {
                var += " - " + list[i].id;
            }
            Console.WriteLine(var);
            

        }

    }
}
