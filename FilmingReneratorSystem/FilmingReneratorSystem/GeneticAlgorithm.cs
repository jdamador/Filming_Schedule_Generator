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
        private List<List<Scene>> family = new List<List<Scene>>(); //List with all family members
        private Calendar bestOne = new Calendar();
        private Evaluating evaluating;
        private Stage stage;
        public bool onCycle = true;
        public bool showType = true;
        public int runner = 0;
        public int asig, comp;
       
        /// <summary>
        /// Generate a new instance of this class
        /// </summary>
        /// <param name="stage"></param>
        public GeneticAlgorithm(Stage stage)
        { 
            this.stage = stage;
            evaluating = new Evaluating(stage); ;
            startTest();

        }
       /// <summary>
       /// Start all test with this stage
       /// </summary>
        public void startTest()
        {
            Console.WriteLine("***                                           RESULTADOS [CYCLE CROSSOVER]                                           ***");
            Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦ [Stage #" + stage.idStage + "] ♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
            generateStartPopulation();
            evaluation();
            onCycle = false;
            family.Clear();
            sonOne = sonTwo = father = mother = null;
            runner = 0;
            bestOne= new Calendar();
            Console.WriteLine("***                                         RESULTADOS [ORDER ONER CROSSOVER]                                       ***");
            Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦ [Stage #" + stage.idStage + "] ♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
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
        }
        #endregion
        /************************************************ Evaluacion**************************************************/
        #region Evaluating
        public void evaluation()
        {
            
                /******************************************/
                int cost = evaluating.getCostCalendar(father);
                asig++;
                asig += evaluating.asig;
                comp += evaluating.comp;
                if (cost < bestOne.bestCost)
                {
                    comp++;
                    if (evaluating.isFactible(father))
                    {
                        bestOne.listScenes = evaluating.shallowClone(father);
                        bestOne.bestCost = cost;
                        asig += 2;
                    }
                    comp = evaluating.comp;
                    asig = evaluating.asig;
                }
                comp++;
                /********************************************/
                cost = evaluating.getCostCalendar(mother);
                asig++;
                asig += evaluating.asig;
                comp += evaluating.comp;
                if (cost < bestOne.bestCost)
                {
                    if (evaluating.isFactible(mother))
                    {
                        bestOne.listScenes = evaluating.shallowClone(mother);
                        bestOne.bestCost = cost;
                        asig += 2;
                    }
                    comp = evaluating.comp;
                    asig = evaluating.asig;
                    comp++;
                }
                comp ++;

                comp+=2;
                if (sonOne != null && sonTwo != null)
                {
                    cost = evaluating.getCostCalendar(mother);
                    asig++;
                    asig += evaluating.asig;
                    comp += evaluating.comp;

                    if (cost < bestOne.bestCost)
                        comp++;

                    cost = evaluating.getCostCalendar(sonTwo);
                    asig++;
                    asig += evaluating.asig;
                    comp += evaluating.comp;
                    if (cost < bestOne.bestCost)
                    {
                        if (evaluating.isFactible(sonTwo))
                        {
                            bestOne.listScenes = evaluating.shallowClone(sonTwo);
                            bestOne.bestCost = cost;
                            asig += 2;
                        }
                        comp = evaluating.comp;
                        asig = evaluating.asig;
                        comp++;
                    }
                    comp++;
                }
                
            if (runner != 3)
            {
                runner += 1;
                selection();
            }

            else
            {
                Console.Write("====================================" +
                                    "\n| Mejor Combinacion: ");
                foreach (Scene item in bestOne.listScenes)
                {
                    Console.Write(item.id + "-");
                }
                Console.WriteLine("\n costo => "+bestOne.bestCost);
                Console.WriteLine("====================================\n");
            }

            
            

        }

        /************************** Seleccion  ************************************/
        /// <summary>
        /// Selection
        /// </summary>
        private void selection()
        {
            if (sonTwo != null) {
                asig += 2;
                father = evaluating.shallowClone(sonOne);
                mother = evaluating.shallowClone(sonTwo);
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
            List<List<Scene>> aux = new CycleCrossover().PerformCross(father, mother); asig++;
            sonOne = aux[0]; asig++;
            sonTwo = aux[1]; asig++;

            if (showType)
            {
                Console.WriteLine("\n<-------------------------------------------------- Nueva Generacion -------------------------------------------------->");
                printCrossover(father, "Padre  ");
                printCrossover(mother, "Madre  ");
                printCrossover(sonOne, "Hijo #1");
                printCrossover(sonTwo, "Hijo #2");
                
            }
            family.Add(father); asig++;
            family.Add(mother); asig++;
            sonOne = evaluating.shallowClone(mutation(sonOne, "Hijo #1")); asig++;
            sonTwo = evaluating.shallowClone(mutation(sonTwo, "Hijo #2")); ; asig++;
            family.Add(sonOne); asig++;
            family.Add(sonTwo); asig++;
            evaluation();

        }
        private void Crossover2()
        {

            sonOne = new OrderOne().OrderOneCrossover(father, mother);
            sonTwo = new OrderOne().OrderOneCrossover(mother, father);

            if (showType)
            {
                Console.WriteLine("\n<-------------------------------------------------- Nueva Generacion -------------------------------------------------->");
                printCrossover(father, "Padre  ");
                printCrossover(mother, "Madre  ");
                printCrossover(sonOne, "Hijo #1");
                printCrossover(sonTwo, "Hijo #2");

            }
            family.Add(father); asig++;
            family.Add(mother); asig++;
            sonOne = evaluating.shallowClone(mutation(sonOne, "Hijo #1")); asig++;
            sonTwo = evaluating.shallowClone(mutation(sonTwo, "Hijo #2")); ; asig++;
            family.Add(sonOne); asig++;
            family.Add(sonTwo); asig++;
            evaluation();
        }
        #region Mutation
        public List<Scene> mutation(List<Scene> listMutation,String text)
        {
            comp++;
            foreach (List<Scene> f in family)
            {
                if(evaluating.getCostCalendar(f)== evaluating.getCostCalendar(listMutation))
                {
                    if (showType)
                    {
                        Console.Write("Mutaciones:    " + text + ": [");
                        foreach (Scene item in listMutation)
                        {
                            Console.Write(item.id + "-");
                        }
                        Console.Write("]  ===>  [");
                    }
                    int index = listMutation.Count / 2;
                    Scene s = listMutation[index];
                    listMutation.Remove(listMutation[index]);
                    listMutation.Add(s);
                    if (showType)
                    {
                        foreach (Scene item in listMutation)
                        {
                            Console.Write(item.id + "-");
                        }
                        Console.Write("]\n");
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
        public void changeBestOne(List<Scene> list)
        {
            bestOne.listScenes = evaluating.shallowClone(list);
            bestOne.bestCost = evaluating.getCostCalendar(bestOne.listScenes);
        }
        #endregion
        #endregion
        public void printCrossover(List<Scene> scenes, String text)
        {
            Console.Write("                     |"+text+"     : [");
            foreach (Scene item in scenes)
            {
                Console.Write(item.id + "-");
            }
            Console.Write("]|=====> Costo: {"+evaluating.getCostCalendar(scenes)+"}   ¿Es factible? "+evaluating.isFactible(scenes)+ "\n");
        }

    }
}