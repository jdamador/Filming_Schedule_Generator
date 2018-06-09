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
        public List<Scene> visited = new List<Scene>();    // List visited
        public List<Scene> notVisited = new List<Scene>(); // List notVisited   
        public Calendar bestCalendar = new Calendar();
        int cantNodes = 0;
        public int asig=0;public int comp=0; //Asig and Comp
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
            //visited = evaluation.shallowClone(stage.scenes);
            runBB();
            
        }

        /// <summary>
        /// Start Algorithm
        /// </summary>
        public void runBB()
        {

            cantNodes = 0;
            goAlgorithm(notVisited); // Go B&B
            
            seeBestCalendar(); // see Best Calendar
           
            seeEmpirical();

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
            comp++;
            if (notVisited.Count == 0) 
            {
                // Poda
                comp++;
                if (evaluation.isFactible(visited))
                {

                    evaluation.seeCombination(visited);
                    Console.WriteLine("Costo: " + evaluation.getCostCalendar(visited));
                    
                    comp++;
                    if (evaluation.getCostCalendar(visited) <= bestCalendar.bestCost) {
                        changeBestCalendar(visited);
                    }
                    asig += evaluation.asig; comp += evaluation.comp;
                }
                asig += evaluation.asig; comp += evaluation.comp;
            }
            else {
                asig++;
                foreach (Scene scene in notVisited)
                {
                
                    asig++;
                    this.visited.Remove(scene); this.visited.Add(scene); asig += 2;
                    
                    List<Scene> auxScene = evaluation.shallowClone(notVisited); asig++;
                    auxScene.Remove(scene); asig++;


                    cantNodes++;
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
            asig += 2;
            this.bestCalendar.listScenes = evaluation.shallowClone(listScenes);
            this.bestCalendar.bestCost = evaluation.getCostCalendar(bestCalendar.listScenes);
 
        }
        #endregion
        #region seeBestCalendar
        public void seeBestCalendar()
        {
            Console.WriteLine("========= Mejor Calendario ========= ");
            evaluation.seeCombination(bestCalendar.listScenes);
            Console.WriteLine("COSTO: " + bestCalendar.bestCost);
            Console.WriteLine("Cantidad de nodos creados: "+cantNodes);
        }
        /// <summary>
        /// See Measurement Empirical 
        /// </summary>
        public void seeEmpirical() {
            Console.WriteLine("Cantidad de Asignaciones: " + asig);
            Console.WriteLine("Cantidad de Comparaciones: "+comp);
            asig = 0; comp = 0;
        }
        #endregion

    }
}
