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
        public int asig, comp;
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
            asig = 0; comp = 0;
            asig += 7;
            this.stage = stage; asig++;
            evaluating = new Evaluating(stage); asig+=2;
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
            father = stage.scenes; asig++;
            List<Scene> aux = evaluating.shallowClone(stage.scenes); asig++; //pasar evaluating
            aux.Reverse(); asig++;
            mother = aux; asig++;

            evaluation();
        }
        #endregion
        
        #region Evaluating
        public void evaluation() {
            comp++;
            if (contC != stage.scenes.Count)
                setCost();
        }
        /************************************************ Evaluacion**************************************************/
        //Seteo de costos padres e hijos (not null) 
        private void setCost() {

            evaluating.getCostCalendar(father); // Set Cost Father
            asig += evaluating.asig; comp += evaluating.comp;
            evaluating.getCostCalendar(mother); // Set Cost Mother
            asig += evaluating.asig; comp += evaluating.comp;
            comp += 2;
            if (sonOne != null || sonTwo != null) {
                evaluating.getCostCalendar(sonOne);
                asig += evaluating.asig; comp += evaluating.comp;
                evaluating.getCostCalendar(sonTwo); // Set Cost Sons
                asig += evaluating.asig; comp += evaluating.comp;
            }
            getBestCost();
        }
        // Verificación si se encontro el mejor costo
        private void getBestCost() {
            // Set default data
            bestOne.listScenes = evaluating.shallowClone(father); asig++;
            bestOne.bestCost = evaluating.getCostCalendar(father); asig++;
            List<List<Scene>> family = new List<List<Scene>>(); asig++;
            family.Add(father);family.Add(mother); asig+=2;
            comp += 2;
            if (sonOne != null || sonTwo != null) { family.Add(sonOne); asig++; family.Add(sonTwo); asig++; }
            
            foreach (List<Scene> actual in family) {
                asig++;
                comp++;
                if (evaluating.getCostCalendar(actual) <= bestOne.bestCost){
                    changeBestOne(actual);
                    newFather = evaluating.shallowClone(bestOne.listScenes); asig++;
                }
                asig += evaluating.asig; comp += evaluating.comp;
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
            foreach(List<Scene> actual in family) {
                asig++; comp++;
                if (!bestOne.listScenes.Equals(actual)) {
                    comp+=2; 
                    if (newMother.Count == 0 || evaluating.getCostCalendar(actual) < evaluating.getCostCalendar(newMother)) {
                        asig++;
                        newMother = evaluating.shallowClone(actual);
                    }
                    asig += evaluating.asig; comp += evaluating.comp;
                }
            }
            comp++;
            if (onCycle)
                Crossover1();
            else
                Crossover2();
        }   
        #endregion
        /***************************  Crossover    **********************************/
        //Envia padres, retorna dos hijos.
        private void Crossover1()
        {
            List<List<Scene>> aux = new CycleCrossover().PerformCross(newFather, newMother); asig++;
            sonOne = aux[0]; asig++;
            sonTwo = aux[1]; asig++;
            
            if (showType)
            {
                Console.WriteLine("*****************************Nueva Generacion****************************");
                printCrossover(newFather, "Padre");
                printCrossover(newMother, "Madre");
                printCrossover(sonOne, "Hijo #1");
                printCrossover(sonTwo, "Hijo #2");
            }
            sonOne = mutation(sonOne); asig++;
            sonTwo = mutation(sonTwo); asig++;
            family.Add(sonOne); family.Add(sonTwo); family.Add(newFather); family.Add(newMother); asig += 4;
            
        }
        private void Crossover2()
        {
            List<List<Scene>> aux = new PMX_Crossover().oxCroosover(newFather, newMother); asig++;
            sonOne = mutation(aux[0]); asig++;
            sonTwo = mutation(aux[1]); asig++;
            family.Add(sonOne); asig++;
            family.Add(sonTwo); asig++;
            family.Add(newFather); asig++;
            family.Add(newMother); asig++;

        }
        #region Mutation
        public List<Scene> mutation(List<Scene> listMutation) {
            comp++;
            if (family.Contains(listMutation))
            {
                
                Scene worst = null; asig++;
                foreach (Scene scene in listMutation)
                {
                    //if (worst == null || evaluating.getCostScene(scene) > evaluating.getCostScene(worst))
                    //{
                    //    worst = scene;
                    //}
                }
                listMutation.Remove(worst); listMutation.Add(worst); asig+=2;// Mutation

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