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
        public int memoryOrder;
        public int memoryCycle;
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
            comp= asig = 0;
            /***********************************************************************/
            Console.WriteLine("***                                           RESULTADOS [CYCLE CROSSOVER]                                           ***");
            Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦ [Stage #" + stage.idStage + "] ♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
            memoryCycle = 0;
            generateStartPopulation();
            evaluation();
            memoryCycle += stage.valueMemory;
            Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦ Memoria Consumida en KB: " + memoryCycle / 8 / 1024);
            /*******************************************************************************************/
            comp = asig = 0;
            onCycle = false;
            family.Clear();
            sonOne = sonTwo = father = mother = null;
            runner = 0;
            bestOne = new Calendar();

            Console.WriteLine("***                                         RESULTADOS [ORDER ONER CROSSOVER]                                       ***");
            Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦ [Stage #" + stage.idStage + "] ♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
            memoryOrder = 0;
            generateStartPopulation();
            evaluation();
            memoryOrder += stage.valueMemory;
            Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦ Memoria Consumida en KB: " + memoryOrder / 8 / 1024);
           

        }
        #endregion
        #region Region of all methods 

        #region Generate Start Population
        /********************************************* Generar la población inicial***********************************/
        /// <summary>
        /// Generate a start population. Create a father with the original list an 
        /// the mother with the list reverse
        /// </summary>
        private void generateStartPopulation()
        {
            father = stage.scenes; asig++;
            List<Scene> aux = evaluating.shallowClone(stage.scenes); asig++; //pasar evaluating
            aux.Reverse(); asig++;
            mother = aux; asig++;

            memoryCycle += (father.Count * father[0].valueMemory) * 4;
            memoryOrder += (father.Count * father[0].valueMemory) * 4;

        }
        #endregion
        /************************************************ Evaluacion**************************************************/
        #region Evaluating
        /// <summary>
        /// Check if the calendar is factible or not factible and search the best cost
        /// </summary>
        public void evaluation()
        {

            int cost = evaluating.getCostCalendar(father);
            memoryOrder += evaluating.memory+32;
            memoryCycle += evaluating.memory+32;
            asig++;
            asig += evaluating.asig;
            comp += evaluating.comp;
            if (cost < bestOne.bestCost)
            {
                comp++;
                if (evaluating.isFactible(father))
                {
                    bestOne.listScenes = evaluating.shallowClone(father);
                    memoryOrder += new Scene(0).valueMemory*father.Count;
                    memoryCycle += new Scene(0).valueMemory*father.Count;
                    bestOne.bestCost = cost;
                    asig += 2;
                }
                comp = evaluating.comp;
                asig = evaluating.asig;
                memoryOrder += evaluating.memory;
                memoryCycle += evaluating.memory;
            }
            comp++;
            /********************************************/
            cost = evaluating.getCostCalendar(mother);
            memoryOrder += evaluating.memory;
            memoryCycle += evaluating.memory;
            asig++;
            asig += evaluating.asig;
            comp += evaluating.comp;
            if (cost < bestOne.bestCost)
            {
                if (evaluating.isFactible(mother))
                {
                    bestOne.listScenes = evaluating.shallowClone(mother);
                    bestOne.bestCost = cost;
                    memoryOrder += new Scene(0).valueMemory*mother.Count;
                    memoryCycle += new Scene(0).valueMemory*mother.Count;
                    asig += 2;
                }
                comp = evaluating.comp;
                asig = evaluating.asig;
                comp++;
                memoryOrder += evaluating.memory;
                memoryCycle += evaluating.memory;
            }
            comp++;
            comp += 2;

            if (sonOne != null && sonTwo != null)
            {
                cost = evaluating.getCostCalendar(sonOne);
                asig++;
                asig += evaluating.asig;
                comp += evaluating.comp;
                memoryOrder += evaluating.memory;
                memoryCycle += evaluating.memory;
                if (cost < bestOne.bestCost)
                {
                    if (evaluating.isFactible(sonOne))
                    {
                        bestOne.listScenes = evaluating.shallowClone(sonOne);
                        bestOne.bestCost = cost;
                        memoryOrder += new Scene(0).valueMemory*sonOne.Count;
                        memoryCycle += new Scene(0).valueMemory*sonOne.Count;
                        asig += 2;
                    }
                    comp = evaluating.comp;
                    asig = evaluating.asig;
                    comp++;
                    memoryOrder += evaluating.memory;
                    memoryCycle += evaluating.memory;
                }
                comp++;
                comp += 2;
                cost = evaluating.getCostCalendar(sonTwo);
                asig++;
                asig += evaluating.asig;
                comp += evaluating.comp;
                memoryOrder += evaluating.memory;
                memoryCycle += evaluating.memory;
                if (cost < bestOne.bestCost)
                {
                    if (evaluating.isFactible(sonTwo))
                    {
                        bestOne.listScenes = evaluating.shallowClone(sonTwo);
                        bestOne.bestCost = cost;
                        memoryOrder += new Scene(0).valueMemory*sonTwo.Count;
                        memoryCycle += new Scene(0).valueMemory*sonTwo.Count;
                        asig += 2;
                    }
                    comp = evaluating.comp;
                    asig = evaluating.asig;
                    comp++;
                    memoryOrder += evaluating.memory;
                    memoryCycle += evaluating.memory;
                }
                comp++;
                comp += 2;
            }

            if (runner != 10)
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
                Console.WriteLine("\n costo => " + bestOne.bestCost);
                Console.WriteLine("Asinaciones: " + asig);
                Console.WriteLine("Comparaciones: " + comp);
                Console.WriteLine("====================================\n");
            }




        }

        /************************** Seleccion  ************************************/
        /// <summary>
        /// Select which son is the best to crossover with other chromosome 
        /// </summary>
        private void selection()
        {
            if (sonTwo != null)
            {
                asig += 2;
                father = evaluating.shallowClone(sonOne);
                mother = evaluating.shallowClone(sonTwo);
                memoryOrder += (new Scene(0).valueMemory*father.Count)*2;
                memoryCycle += (new Scene(0).valueMemory*father.Count)*2;
            }
            comp++;

            if (onCycle)
                Crossover1();
            else
                Crossover2();
        }

        #endregion
        /***************************  Crossover    **********************************/
        /// <summary>
        /// Create new child with the parents
        /// Use the cycle crossover to procreate offpprings
        /// </summary>
        private void Crossover1()
        {
            CycleCrossover cy = new CycleCrossover();
            List<List<Scene>> aux = cy.PerformCross(father, mother); asig++;
            asig += cy.asig; comp += cy.comp;
            memoryCycle += new Scene(0).valueMemory*aux[0].Count;
            memoryCycle += new Scene(0).valueMemory*aux[0].Count;
            memoryCycle += cy.memory;

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
            //call mutation to check if it already exist and mutate this
            sonOne = evaluating.shallowClone(mutation(sonOne, "Hijo #1")); asig++;
            memoryCycle += new Scene(0).valueMemory*sonOne.Count;
            sonTwo = evaluating.shallowClone(mutation(sonTwo, "Hijo #2")); ; asig++;
            memoryCycle += new Scene(0).valueMemory * sonOne.Count;
            family.Add(sonOne); asig++;
            family.Add(sonTwo); asig++;
            evaluation();

        }
        /// <summary>
        /// Create new child with the parents
        /// Use the order one crossover to procreate offpprings
        /// </summary>
        private void Crossover2()
        {

            OrderOne oo = new OrderOne();
            sonOne = oo.OrderOneCrossover(father, mother); asig++;
            asig += oo.asig; comp += oo.comp;
            memoryOrder += oo.memory;
            sonTwo = oo.OrderOneCrossover(mother, father); asig++;
            memoryOrder += oo.memory;
            comp++;
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
            //call mutation to check if it already exist and mutate this
            sonOne = evaluating.shallowClone(mutation(sonOne, "Hijo #1")); asig++;
            sonTwo = evaluating.shallowClone(mutation(sonTwo, "Hijo #2")); ; asig++;
            memoryOrder += new Scene(0).valueMemory*sonOne.Count; asig++;
            memoryOrder += new Scene(0).valueMemory * sonTwo.Count; asig++;
            family.Add(sonOne); asig++;
            family.Add(sonTwo); asig++;
            evaluation();
        }
        #region Mutation
        /// <summary>
        /// Mutate the list you receive if it already exists in past generations
        /// </summary>
        /// <param name="listMutation"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<Scene> mutation(List<Scene> listMutation, String text)
        {
            comp++;
            memoryCycle += new Scene(0).valueMemory;
            memoryOrder += new Scene(0).valueMemory;
            foreach (List<Scene> f in family)
            {
                comp++;
                if (evaluating.getCostCalendar(f) == evaluating.getCostCalendar(listMutation))
                {
                    comp++;
                    memoryCycle += evaluating.memory * 2;
                    memoryOrder += evaluating.memory * 2;
                    if (showType)
                    {
                        Console.Write("Mutaciones:    " + text + ": [");
                        foreach (Scene item in listMutation)
                        {
                            Console.Write(item.id + "-");
                        }
                        Console.Write("]  ===>  [");
                    }
                    memoryOrder += 32;
                    memoryCycle += 32;
                    int index = listMutation.Count / 2; asig++;
                    Scene s = listMutation[index]; asig++;
                    memoryCycle += s.valueMemory;
                    memoryOrder += s.valueMemory;
                    listMutation.Remove(listMutation[index]); asig++;
                    listMutation.Add(s); asig++;
                   
                    if (showType)
                    {
                        
                        foreach (Scene item in listMutation)
                        {
                            Console.Write(item.id + "-");
                        }
                        Console.Write("]\n");
                    }


                }
                else
                {
                    memoryCycle += evaluating.memory * 2;
                    memoryOrder += evaluating.memory * 2;
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
        /// <summary>
        /// Print information about genetic algorithm combinations
        /// </summary>
        /// <param name="scenes"></param>
        /// <param name="text"></param>
        public void printCrossover(List<Scene> scenes, String text)
        {
            Console.Write("                     |" + text + "     : [");
            foreach (Scene item in scenes)
            {
                Console.Write(item.id + "-");
            }
            Console.Write("]|=====> Costo: {" + evaluating.getCostCalendar(scenes) + "}   ¿Es factible? " + evaluating.isFactible(scenes) + "\n");
        }

    }
}