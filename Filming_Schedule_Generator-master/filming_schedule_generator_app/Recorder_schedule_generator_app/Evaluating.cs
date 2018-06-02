using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder_schedule_generator_app
{
    class Evaluating
    {
        List<Actor> listActorModifiedDay = new List<Actor>(); // List to know which actors already modified
        Stage stage;
        public Evaluating(Stage stage) {
            this.stage = stage;
        }
        /// <summary>
        /// Check if scenes are factible and set Actors 
        /// </summary>
        /// <param name="listScenes"></param>
        /// <returns></returns>
        /// 
        public bool isFactible(List<Scene> listScenes) {
            FilmingDay time;
            bool isGood = false;
            for (int i = 0; i < listScenes.Count; i++) { // Scenes
                for (int j = 0; j < listScenes[i].listActors.Count; j++) { // Actors 
                    for (int k = 0; k < listScenes[i].listActors[j].available.Count; k++) { // Time

                        if (listScenes[i].listActors[j].available[k].idFilmingDay == i + 1) {   
                            time = listScenes[i].listActors[j].available[k];
                            if (!checkLocalitation(listScenes[i], time))
                            {
                                return false;
                            }
                            else {
                                isGood= true;
                                break;
                            }
                        }
                    }
                    if (isGood == false) return false;
                    isGood = false;
                }
            }
            setCostScenes(listScenes); // Set cost of Scenes
            return true; // Is good 
        }

        /// <summary>
        /// Check if the time is in localization
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private bool checkLocalitation(Scene scene,FilmingDay time) {
            if (scene.localizationScene.times.Contains(time))
                return true;
            return false;
        }

        public void setCostScenes(List<Scene> listScenes) {

            setCostActors(listScenes); // Saca el costo de cada actor por dia

            // Costo por cada escena
            for (int i = 0; i < listScenes.Count; i++)
            {
                for (int k = 0; k < listScenes[i].listActors.Count; k++)
                {
                    listScenes[i].totalCost += listScenes[i].listActors[k].costXDay;
                }
            }
        }
        /// <summary>
        /// Set Cost for Actor 
        /// </summary>
        /// <param name="listScenes"></param>
        public void setCostActors(List<Scene> listScenes) {
            for (int i = 0; i < listScenes.Count; i++)
            {
                for (int k = 0; k < listScenes[i].listActors.Count; k++)
                {
                    if (!listActorModifiedDay.Contains(listScenes[i].listActors[k]))
                    { // Actual Actor
                        listScenes[i].listActors[k].firstDay = stage.filmingDays[i]; // La i es el dia ya que es donde esta colocada la escena
                        listActorModifiedDay.Add(listScenes[i].listActors[k]);
                    }
                    else
                    { // Si ya esta en la lista es por que ya se le asigno el primer dia de contratacion
                        listScenes[i].listActors[k].lastDay = stage.filmingDays[i];

                        listScenes[i].listActors[k].costXDay = ((listScenes[i].listActors[k].lastDay.idFilmingDay - listScenes[i].listActors[k].firstDay.idFilmingDay) + 1)* listScenes[i].listActors[k].cost; // Establece el costo a cada actor
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
            int finalCostCalendar = 0;
            for (int i = 0; i < listScene.Count; i++)
            { // Run Scenes
                for (int j = 0; j < listScene[i].listActors.Count; j++)
                { // Run Actors in Scenes
                    finalCostCalendar += listScene[i].listActors[j].costXDay; // Sums in the finalCost of calendar
                }
            }
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
                finalCostScene += scene.listActors[i].costXDay; // Sums in the finalCost of calendar
            }
            return finalCostScene;
        }
    }
}
