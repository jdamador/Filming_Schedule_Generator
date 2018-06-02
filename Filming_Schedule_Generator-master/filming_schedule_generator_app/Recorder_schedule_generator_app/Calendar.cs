using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder_schedule_generator_app
{
    class Calendar
    {
        public List<Scene> listScenes = new List<Scene>(); 
        public int bestCost =0; // Cost 

        /// <summary>
        /// Get the cost of Calendar
        /// </summary>
        /// <param name="listScene"></param>
        /// <returns></returns>
        public int getCost(List<Scene> listScene) {
            int finalCostCalendar = 0;
            for (int i = 0; i < listScene.Count; i++)
            { // Run Scenes
                for (int j = 0; j < listScene[i].listActors.Count; j++)
                { // Run Actors in Scenes
                    finalCostCalendar += (listScene[i].listActors[j].lastDay.idFilmingDay - listScene[i].listActors[j].firstDay.idFilmingDay)*listScene[i].listActors[j].costXDay + 1; // Sums in the finalCost of calendar
                }
            }
            return finalCostCalendar;
        }
    }
}
