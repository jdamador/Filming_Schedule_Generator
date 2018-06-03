using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class Evaluating
    {
        List<Actor> listActorModifiedDay = new List<Actor>(); // List to know which actors already modified
        Stage stage;
        public Evaluating(Stage stage)
        {
            this.stage = stage;
        }
        /// <summary>
        /// Check if scenes are factible and set Actors 
        /// </summary>
        /// <param name="listScenes"></param>
        /// <returns></returns>
        /// 
        public bool isFactible(List<Scene> listScenes)
        {
            for (int k = 0; k < listScenes.Count; k++)
            {
              
                
                for (int i = 0; i < listScenes[k].listActors[0].available.Count; i++)
                {
                    FilmingDay day= listScenes[k].listActors[0].available[i];
                    if (listScenes[k].listActors[1].available.Contains(day))
                        if (listScenes[k].localizationScene.times.Contains(day))
                            if(!listScenes[k].listActors[0].workedDays.Contains(day) && !listScenes[k].listActors[1].workedDays.Contains(day))
                            {
                                bool flag = true;
                                for (int j = 0; j < listScenes[k].listActors[0].workedDays.Count; j++)
                                {
                                    FilmingDay a = listScenes[k].listActors[0].workedDays[j];
                                    if(day.numDia==i + 1|| day.numDia == i + 2)
                                        if (day.numDia==a.numDia + 1 || day.numDia == a.numDia - 1)
                                            if (day.id != a.id)
                                                flag = false;
                                    
                                }
                                for (int j = 0; j < listScenes[k].listActors[1].workedDays.Count; j++)
                                {
                                    FilmingDay a = listScenes[k].listActors[1].workedDays[j];
                                    if (day.numDia == i + 1 || day.numDia == i + 2)
                                        if (day.numDia == a.numDia + 1 || day.numDia == a.numDia - 1)
                                            if (day.id != a.id)
                                                flag = false;
                                }
                                if (flag)
                                {

                                    // Falta chequear los dias si entra aqui 
                                    listScenes[k].listActors[0].workedDays.Add(day);
                                    listScenes[k].listActors[1].workedDays.Add(day);
                                }
                                else {
                                     return false; }      
                            }
                }
            }
           // setCostScenes(); // Set cost of Scenes
            return true; // Is good 
        }
        
       

    
    
    /// <summary>
    /// Set Cost all Scenes of calendar
    /// </summary>
    /// <param name="listScenes"></param>
    public void setCostScenes()
    {

        setCostActors(); // Saca el costo de cada actor por dia

        // Costo por cada escena
        foreach(Scene scene in stage.scenes)
            {
                foreach(Actor actor in scene.listActors) { 
                scene.totalCost += actor.costXDay;
            }
        }
    }
    /// <summary>
    /// Set Cost for Actor 
    /// </summary>
    /// <param name="listScenes"></param>
    public void setCostActors()
    {
        
        foreach(Actor actor in stage.actors) {
                int max = 0;
                
                int min = actor.workedDays[0].numDia;
                

            foreach (FilmingDay day in actor.workedDays) {
                    if (day.numDia > max) {
                        max = day.numDia;
                        actor.lastDay = day;
                    }
                    if (day.numDia < min) {
                        min = day.numDia;
                        actor.firstDay = day;
                    }
            }
            actor.costXDay = ((max - min) + 1) * actor.cost;

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
