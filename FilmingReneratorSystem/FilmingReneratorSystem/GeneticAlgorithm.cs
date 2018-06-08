using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FilmingReneratorSystem
{
    class GeneticAlgorithm
    {
        #region Region of all varables declaration  here
        /*Population*/
        private List<Scene> father;
        private List<Scene> mother;
        private List<Scene> sonOne;
        private List<Scene> sonTwo;
        private List<Scene> newFather = new List<Scene>(); //New father in Selection
        private List<Scene> newMother = new List<Scene>(); //New Mother in Selection
        private int contC=0;
        /*Stage that  we have to film*/
        private Stage stage;

        private Calendar bestOne= new Calendar();
        private Evaluating evaluating;
        private List<List<Scene>> family = new List<List<Scene>>(); //List with all family members
        public bool onCycle = true;
        public bool showType = true;
        #endregion
        #region Constructor
        /// <summary>
        /// Recieve a stage to calculate the best cost
        /// </summary>
        /// <param name="stage"></param>
        public GeneticAlgorithm(Stage stage)
        {
            this.stage = stage;
            evaluating = new Evaluating(stage);
            comenzar_Prueba();
        }
        /// <summary>
        /// Start a test
        /// </summary>
        public void comenzar_Prueba()
        {
            Console.WriteLine("                               [Stage #" + stage.idStage + "]                         ");
            generateStartPopulation();
            evaluation();     
        }
        #endregion
        #region Region of all methods 

        #region Generate Start Population
        /********************************************* Generar la población inicial***********************************/
        private void generateStartPopulation()
        {
            father = stage.scenes;
            List<Scene> aux = evaluating.shallowClone(stage.scenes); //pasar evaluating
            aux.Reverse();
            mother = aux;
            
           evaluation();
        }
        #endregion
        
        #region Evaluating
        public void evaluation() {
            if (contC != stage.scenes.Count)
                setCost();
        }
        /************************************************ Evaluacion**************************************************/
        //Seteo de costos padres e hijos (not null) 
        private void setCost() {
            evaluating.getCostCalendar(father); // Set Cost Father
            evaluating.getCostCalendar(mother); // Set Cost Mother
            if (sonOne != null || sonTwo != null) {
                evaluating.getCostCalendar(sonOne); evaluating.getCostCalendar(sonTwo); // Set Cost Sons
            }
            getBestCost();
        }
        // Verificación si se encontro el mejor costo
        private void getBestCost() {
            // Set default data
            bestOne.listScenes = evaluating.shallowClone(father);
            bestOne.bestCost = evaluating.getCostCalendar(father);
            List<List<Scene>> family = new List<List<Scene>>();
            family.Add(father);family.Add(mother);
            if (sonOne != null || sonTwo != null) { family.Add(sonOne); family.Add(sonTwo);}
            foreach (List<Scene> actual in family) {
                if (evaluating.getCostCalendar(actual) <= bestOne.bestCost){
                    changeBestOne(actual);
                    newFather = evaluating.shallowClone(bestOne.listScenes);    
                }
            }
           
            selection(family);
            // Cruces 
        }
        #endregion
        #region Selection
        /************************** Seleccion  ************************************/
        /// <summary>
        /// Selection
        /// </summary>
        private void selection(List<List<Scene>> family){
            foreach(List<Scene> actual in family)
                if (!bestOne.listScenes.Equals(actual)) { 

                    if (newMother.Count == 0 || evaluating.getCostCalendar(actual) < evaluating.getCostCalendar(newMother))
                        newMother = evaluating.shallowClone(actual);
                }
            if(onCycle)
                Crossover1();
            else
                Crossover2();
        }   
        #endregion
        /***************************  Crossover    **********************************/
        //Envia padres, retorna dos hijos.
        private void Crossover1()
        {
            List<List<Scene>> aux = new CycleCrossover().PerformCross(newFather, newMother);
            sonOne = aux[0];
            sonTwo = aux[1];
            if (showType)
            {
                Console.WriteLine("*****************************Nueva Generacion****************************");
                printCrossover(newFather, "Padre");
                printCrossover(newMother, "Madre");
                printCrossover(sonOne, "Hijo #1");
                printCrossover(sonTwo, "Hijo #2");
            }
            sonOne = mutation(sonOne);
            sonTwo = mutation(sonTwo);
            family.Add(sonOne); family.Add(sonTwo); family.Add(newFather); family.Add(newMother);
            
        }
        private void Crossover2()
        {
            List<List<Scene>> aux = new PMX_Crossover().oxCroosover(newFather, newMother);
            sonOne = mutation(aux[0]);
            sonTwo = mutation(aux[1]);
            family.Add(sonOne);
            family.Add(sonTwo);
            family.Add(newFather);
            family.Add(newMother);
          
        }
        #region Mutation
        public List<Scene> mutation(List<Scene> listMutation) {
            
            if (family.Contains(listMutation))
            {
                
                Scene worst = null;
                foreach (Scene scene in listMutation)
                {
                    //if (worst == null || evaluating.getCostScene(scene) > evaluating.getCostScene(worst))
                    //{
                    //    worst = scene;
                    //}
                }
                listMutation.Remove(worst); listMutation.Add(worst); // Mutation
                if (showType)
                {
                    Console.Write("--------------------------Mutacion Aplicada-----------------------");
                    foreach (Scene e in listMutation)
                    {
                        Console.Write(e.id + "-");
                    }
                }
            }
            return listMutation;
        }
        #endregion
        /*^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^*/
        //evaluar;
        #region Change Best
        /// <summary>
        /// Change Best One
        /// </summary>
        /// <param name="list"></param>
        public void changeBestOne(List<Scene> list) {
            bestOne.listScenes = evaluating.shallowClone(list);
            bestOne.bestCost = evaluating.getCostCalendar(bestOne.listScenes);
        }
        #endregion
        #endregion
        public void printCrossover(List<Scene> scenes, String text)
        {
            Console.WriteLine(text);
            foreach (Scene item in scenes)
            {
                Console.Write(item.id + "-");
            }
            Console.WriteLine();
        }
    }
}