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
            asig = 0; comp = 0;
            comp++;asig++;
            for (int i = 0; i < listScenes.Count; i++)
            {
                comp++; asig++;
                listScenes[i].dayF = stage.filmingDays[i]; asig++;
            }
            asig++;
            foreach (Actor a in stage.actors)
            {
                asig++; comp++; asig++;
                for (int i = 1; i < listScenes.Count-1; i++)
                {
                    comp++; asig++;
                    comp++;
                    if (listScenes[i].listActors.Contains(a))
                    {
                        comp++;
                        if (listScenes[i - 1].listActors.Contains(a))
                        {
                            comp++;
                            if (listScenes[i].dayF.isDay) {
                                comp++;
                                if (!listScenes[i - 1].dayF.isDay)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                comp++;
                                if (listScenes[i - 1].dayF.id.Equals(listScenes[i].dayF.id))
                                    return false;
                            }
                        }
                        comp++;
                        if (listScenes[i + 1].listActors.Contains(a))
                        {
                            comp++;
                            if (listScenes[i].dayF.isDay)
                            {
                                comp++;
                                if (listScenes[i + 1].dayF.id.Equals(listScenes[i].dayF.id))
                                    return false;
                            }
                            else
                            {
                                comp++;
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
            asig = 0; comp = 0;
            asig++; comp++;
            for (int i = 0; i < scenes.Count; i++)
            {
                asig+=2; comp++;
                scenes[i].dayF = stage.filmingDays[i];
            }
            int totalCost = 0; asig++;
            setCostActores(scenes);
            asig++;
            foreach (Actor a in stage.actors)
            {
                totalCost += a.costTotal; asig++;
            }
            asig++;
            return totalCost; 
        }

        private void setCostActores(List<Scene> scenes)
        {
            asig++;
            foreach (Actor a in stage.actors)
            {
                asig++;
                bool asigned=false; asig++;
                asig++;
                foreach (Scene e in scenes)
                {
                    asig++; comp++;
                    if (e.listActors.Contains(a) )
                    {
                        comp++;
                        if (!asigned) {
                            a.firstDay = e.dayF; asig++;
                            asigned = true; asig++;
                        }
                        a.lastDay = e.dayF; asig++;
                    }
                }
                if (a.lastDay != null && a.firstDay !=null)
                    a.costTotal = ((a.lastDay.numDia - a.firstDay.numDia) + 1) * a.costXDay; asig++;
            }
        }
    }
}
