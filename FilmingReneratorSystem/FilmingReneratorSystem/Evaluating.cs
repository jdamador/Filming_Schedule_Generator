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
            Console.WriteLine(listScenes.Count);
            //Asignar el dia en que se coloco la escena
            //Asigne the day where has put the scene 
            for (int i = 0; i < listScenes.Count; i++)
                listScenes[i].dayF = stage.filmingDays[i];
            for (int i = 1; i < listScenes.Count - 1; i++)
            {
                if (listScenes[i].dayF.isDay)
                    if (!listScenes[i - 1].dayF.isDay)
                        return false;
                    else
                     if (listScenes[i + 1].dayF.isDay)
                        return false;
            }
            setCostScenes(listScenes);
            return true;
        }





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
                foreach (Actor actor in scene.listActors)
                {
                    scene.totalCost += actor.costTotal;
                }
            }
        }
        /// <summary>
        /// Set Cost for Actor 
        /// </summary>
        /// <param name="listScenes"></param>
        public void setCostActors(List<Scene> listScenes)
        {
<<<<<<< Updated upstream
            
            foreach (Actor a in stage.actors)
            {
                foreach (Scene s in listScenes)
                {
                    if (s.listActors.Contains(a))
=======
            List<Actor> isSetActor = new List<Actor>();
            for (int i = 0; i < listScenes.Count; i++)
            { // Scenes
                foreach (Actor actor in listScenes[i].listActors)
                { // Actors
                    if (isSetActor.Contains(actor)) // if contain,is the first day
                    { 

                        actor.lastDay = stage.filmingDays[i]; 
                        actor.costTotal = ((actor.lastDay.numDia - actor.firstDay.numDia) + 1) * actor.costXDay; // Set cost
                        //Console.WriteLine(actor.lastDay.numDia + " Last day");
                        //Console.WriteLine("Costo:"+ actor.costXDay);
                    }
                    else
>>>>>>> Stashed changes
                    {
                        if (a.firstDay == null)
                        {
                            a.firstDay = s.dayF;
                        }
                        a.lastDay = s.dayF;
                        
                    }       
                }
                Console.WriteLine("Actor: " + a.id);
                a.costTotal = ((a.lastDay.numDia - a.firstDay.numDia) + 1) * a.costXDay; // Set cost
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
