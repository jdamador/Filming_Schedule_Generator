using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FilmingReneratorSystem
{
    class GeneticAlgorithm
    {
        /*All varables declaration  here*/
        private List<Scene> father;
        private List<Scene> mother;
        private Stage stage;
        private Calendar bestOne= new Calendar();
        private Evaluating evaluating;
        //Recieve a stage to calculate the best cost
        public GeneticAlgorithm(Stage stage)
        {
            this.stage = stage;
            generateStartPopulation();
         
        }
      
        /********************** All methods here *************************/

        /****************** Generar la población inicial***********************/
        public void generateStartPopulation()
        {
            father = stage.scenes;
            List<Scene> aux = evaluating.shallowClone(stage.scenes); //pasar evaluating
            aux.Reverse();
            mother = aux; 
        }
       
        /************************** Evaluacion*************************************/
        //Seteo de costos padres e hijos (not null) 
        // Verificación si se encontro el mejor costo
          
        /************************** Seleccion  ************************************/
        // Verificar cuales dos de  los cuatro descendientes tienen el mejor costo

       /***************************  Crossover    **********************************/
       //Envia padres, retorna dos hijos.

       /******************************   Mutación ***********************************/
       //Se intercambia una posición con otra

       /*^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^*/
       //evaluar;
    }
}