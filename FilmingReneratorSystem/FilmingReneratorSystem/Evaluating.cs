using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class Evaluating
    {
     

      
        Stage stage;
        public int asig, comp;
        public Evaluating(Stage stage)
        {
            this.stage = stage;
        }
        public List<T> shallowClone<T>(List<T> items)
        {

            return new List<T>(items);
        }
        public bool isFactible(List<Scene> listScenes)
        {
            for (int i = 0; i < listScenes.Count; i++)
            {
                listScenes[i].dayF = stage.filmingDays[i];
            }
            foreach (Actor a in stage.actors)
            {
                for (int i = 1; i < listScenes.Count-1; i++)
                {
                    if (listScenes[i].listActors.Contains(a))
                    {
                        if (listScenes[i - 1].listActors.Contains(a))
                        {
                            if (listScenes[i].dayF.isDay) {
                                if (!listScenes[i - 1].dayF.isDay)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (listScenes[i - 1].dayF.id.Equals(listScenes[i].dayF.id))
                                    return false;
                            }
                        }

                        if (listScenes[i + 1].listActors.Contains(a))
                        {
                            if (listScenes[i].dayF.isDay)
                            {
                                if (listScenes[i + 1].dayF.id.Equals(listScenes[i].dayF.id))
                                    return false;
                            }
                            else
                            {
                                if (listScenes[i + 1].dayF.isDay)
                                    return false;
                            }
                        }

                    }
                }
            }
           
            return true;
        }
        public void seeCombination(List<Scene> list)
        {
            Console.WriteLine("");
            // Console.WriteLine("#-#-#-#-#-#-#-#-#-# CALENDARIO #-#-#-#-#-#-#-#-#-#");
            string line = "";
            foreach (Scene scene in list)
            {
                line += scene.id + " ";
            }
            Console.WriteLine(line);
        }
        public int getCostCalendar(List<Scene> scenes)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                scenes[i].dayF = stage.filmingDays[i];
            }
            int totalCost = 0;
            setCostActores( scenes);
            foreach (Actor a in stage.actors)
            {
                totalCost += a.costTotal;
            }
            return totalCost;
        }

        private void setCostActores(List<Scene> scenes)
        {
            foreach (Actor a in stage.actors)
            { 
                 bool asigned=false;
                foreach (Scene e in scenes)
                {
                    
                    if (e.listActors.Contains(a) )
                    {
                        if (!asigned) {
                            a.firstDay = e.dayF;
                            asigned = true;
                        }
                        a.lastDay = e.dayF;
                    }
                }
                a.costTotal = ((a.lastDay.numDia - a.firstDay.numDia) + 1) * a.costXDay;
            }
        }
    }
}
