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
        private List<Scene> father;
        private List<Scene> mother;
        private List<Scene> sonOne;
        private List<Scene> sonTwo;
        private List<Scene> newFather = new List<Scene>(); //New father in Selection
        private List<Scene> newMother = new List<Scene>(); //New Mother in Selection
        private Stage stage;
        private Calendar bestOne= new Calendar();
        private Evaluating evaluating;
        #endregion
        #region Constructor
        //Recieve a stage to calculate the best cost
        public GeneticAlgorithm(Stage stage)
        {
            this.stage = stage;
            generateStartPopulation();
            
        }
        #endregion
        #region Region of all methods 

        #region Generate Start Population
        /****************** Generar la población inicial***********************/
        private void generateStartPopulation()
        {
            father = stage.scenes;
            List<Scene> aux = evaluating.shallowClone(stage.scenes); //pasar evaluating
            aux.Reverse();
            mother = aux;
            setCost();
        }
        #endregion
        #region Evaluating
        /************************** Evaluacion*************************************/
        //Seteo de costos padres e hijos (not null) 
        private void setCost() {
            evaluating.setCostScenes(father); // Set Cost Father
            evaluating.setCostScenes(mother); // Set Cost Mother
            if (sonOne != null || sonTwo != null) {
                evaluating.setCostScenes(sonOne); evaluating.setCostScenes(sonTwo); // Set Cost Sons
            }
            getBestCost();
        }
        // Verificación si se encontro el mejor costo
        private void getBestCost() {
            // Set default data
           

            bestOne.listScenes = evaluating.shallowClone(father);
            bestOne.bestCost = evaluating.getCostScenes(father);
            List<List<Scene>> family = new List<List<Scene>>();
            family.Add(father);family.Add(mother);
            if (sonOne != null || sonTwo != null) { family.Add(sonOne); family.Add(sonTwo);}
            foreach (List<Scene> actual in family) {
                if (evaluating.getCostScenes(actual) < bestOne.bestCost){
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
                if (!bestOne.listScenes.Equals(actual))
                    foreach(List<Scene> parent in family) {
                        if (evaluating.getCostScenes(actual) < evaluating.getCostScenes(parent)) {
                            if (newMother.Count == 0 || evaluating.getCostScenes(actual) < evaluating.getCostScenes(newMother))
                                newMother = evaluating.shallowClone(actual);
                        }
                    }
        }
        #endregion








        /***************************  Crossover    **********************************/
        //Envia padres, retorna dos hijos.

        #region Mutation
        public List<Scene> mutation(List<Scene> listMutation) {
            Scene worst = null;
            foreach (Scene scene in listMutation) {
                if (worst == null || evaluating.getCostScene(scene) > evaluating.getCostScene(worst)) {
                    worst = scene;
                }
            }
            listMutation.Remove(worst);listMutation.Add(worst); // Mutation
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
            bestOne.bestCost = evaluating.getCostScenes(bestOne.listScenes);
        }
        #endregion
        #endregion
    }
}