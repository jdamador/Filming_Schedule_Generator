using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class Evaluating
    {
        #region Region to create Information
        public int asig = 0; public int comp = 0;
        List<Actor> listActorModifiedDay = new List<Actor>(); // List to know which actors already modified
        Stage stage;
        
        public Evaluating(Stage stage)
        {
            this.stage = stage;
        }
        #endregion
        #region Region to Check if is Factible
        /// <summary>
        /// Check if scenes are factible and set Actors 
        /// </summary>
        /// <param name="listScenes"></param>
        /// <returns></returns>
        /// 
        public bool isFactible(List<Scene> listScenes)
        {
            asig = 0; comp = 0;
            //Asignar el dia en que se coloco la escena
            //Asigne the day where has put the scene 
            asig++; comp++;
            for (int i = 0; i < listScenes.Count; i++) {
                comp++; asig++;
                listScenes[i].dayF = stage.filmingDays[i];asig++;
            }
            asig++; comp++;
            for (int i = 1; i < listScenes.Count - 1; i++)
            {
                asig++; comp++;
                comp++;
                if (listScenes[i].dayF.isDay) {
                    comp++;
                    if (!listScenes[i - 1].dayF.isDay)
                        return false;
                    else {
                        comp++;
                     if (listScenes[i + 1].dayF.isDay)
                        return false;
                    }
                }
            }
            //setCostScenes(listScenes);
            return true;
        }
        #endregion
        #region Region to set and get CostScenes or CostScene
        /// <summary>
        /// Set Cost all Scenes of calendar
        /// </summary>
        /// <param name="listScenes"></param>
        public void setCostScenes(List<Scene> listScenes)
        {
            setCostActors(listScenes); // Saca el costo de cada actor por dia
            // Costo por cada escena
            foreach (Scene scene in stage.scenes)
            {
                asig++;
                foreach (Actor actor in scene.listActors)
                {
                    asig++;
                    scene.totalCost += actor.costTotal; asig++;
                }
            }
        }

        /// <summary>
        /// Set Cost for Actor 
        /// </summary>
        /// <param name="listScenes"></param>
        
        public void setCostActors(List<Scene> listScenes)
        {
            List<Actor> isSetActor = new List<Actor>();  asig++;
            asig++;
            comp++;
            for (int i = 0; i < listScenes.Count; i++)
            { // Scenes
                comp++;asig++;

                foreach (Actor actor in listScenes[i].listActors)
                { // Actors
                    asig++;
                    comp++;
                    if (isSetActor.Contains(actor)) // if contain,is the first day
                    {

                        actor.lastDay = stage.filmingDays[i]; asig++;
                        actor.costTotal = ((actor.lastDay.numDia - actor.firstDay.numDia) + 1) * actor.costXDay;asig++; // Set cost
                       
                    }
                    else
                    {

                        actor.firstDay = actor.lastDay = stage.filmingDays[i];asig++; // may be get last day 
                        isSetActor.Add(actor); asig++;
                        
                    }
                }
            }
        }


        /// <summary>
        /// Get the cost of Scenes
        /// </summary>
        /// <param name="listScene"></param>
        /// <returns></returns>

        public int getCostScenes(List<Scene> listScene)
        {
            asig = 0;comp = 0;
            setCostScenes(listScene);
            int finalCostCalendar = 0; asig++;
            asig++; comp++;
            for (int i = 0; i < stage.actors.Count; i++)
            { // Run Scenes
                asig++;
                foreach(Scene scene in listScene) {
                    asig++;
                    finalCostCalendar += stage.actors[i].costTotal; asig++;
                }

            }
            asig++;
            return finalCostCalendar;
        }
        /// <summary>
        /// Get the cost of Scene
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        public int getCostScene(Scene scene)
        {
            int finalCostScene = 0;

            for (int i = 0; i < scene.listActors.Count; i++)
            { // Run Actors in Scenes
                finalCostScene += scene.listActors[i].costTotal; // Sums in the finalCost of calendar
            }
            return finalCostScene;
        }
        #endregion
        #region Region to clone list
        /// <summary>
        /// Return clone of the list 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<T> shallowClone<T>(List<T> items)
        {
            asig++;
            return new List<T>(items);
        }
        #endregion
        #region See Calendar
        /// <summary>
        /// See Combination 
        /// </summary>
        /// <param name="list"></param>
        public void seeCombination(List<Scene> list)
        {
            Console.WriteLine("");
            Console.WriteLine("#-#-#-#-#-#-#-#-#-# CALENDARIO #-#-#-#-#-#-#-#-#-#");
            string line = "";
            foreach (Scene scene in list)
            {
                line += scene.id + " ";
            }
            Console.WriteLine(line);

        }

        
        #endregion
    }
} 
