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
    class Evaluating
    {
        Stage stage;
        public int asig, comp;
        public int memory;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stage"></param>
        public Evaluating(Stage stage)
        {
            this.stage = stage;
        }
        /// <summary>
        /// Cloning List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<T> shallowClone<T>(List<T> items)
        {
            return new List<T>(items);
        }
        /// <summary>
        /// Check if combination is correct
        /// </summary>
        /// <param name="listScenes"></param>
        /// <returns></returns>
        public bool isFactible(List<Scene> listScenes)
        {
            asig = 0; comp = 0;
            memory = 0;
            comp++;asig++;
            memory += 32;
            for (int i = 0; i < listScenes.Count; i++)
            {
                comp++; asig++;
                listScenes[i].dayF = stage.filmingDays[i]; asig++;
            }
            asig++;
            memory += new Actor(0, 0).valueMemory;
            foreach (Actor a in stage.actors)
            {
                asig++; comp++; asig++;
                memory += 32;
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
        /// <summary>
        /// see combination
        /// </summary>
        /// <param name="list"></param>
        public void seeCombination(List<Scene> list)
        {
            Console.WriteLine("");
            
            string line = "";
          
            foreach (Scene scene in list)
            {
                line += scene.id + " ";
            }
            Console.Write("COMBINACION: ");
            Console.Write(line);
            Console.Write("==> ");
            Console.WriteLine("COSTO: "+getCostCalendar(list));
        }
        /// <summary>
        /// get cost calendar
        /// </summary>
        /// <param name="scenes"></param>
        /// <returns></returns>
        public int getCostCalendar(List<Scene> scenes)
        {
            asig = 0; comp = 0;
            asig++; comp++;
            /****************************************/
            memory = 0;
            memory += 32;
            for (int i = 0; i < scenes.Count; i++)
            {
                asig += 2; comp++;
                scenes[i].dayF = stage.filmingDays[i];
            }
            memory += 32;
            int totalCost = 0; asig++;
            setCostActores(scenes);
            asig++;
            memory += new Actor(0, 0).valueMemory;
            foreach (Actor a in stage.actors)
            {
                totalCost += a.costTotal; asig++;
            }
            asig++;
            return totalCost;
        }
        /// <summary>
        /// set cost actor
        /// </summary>
        /// <param name="scenes"></param>
        private void setCostActores(List<Scene> scenes)
        {
            memory = 0;
            asig++;

            memory += new Actor(0, 0).valueMemory;

            foreach (Actor a in stage.actors)
            {
                asig++;
                bool asigned=false; asig++;
                memory += 1;
              
                memory += new Scene(0).valueMemory;
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
        /// <summary>
        /// get cost of scenes
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public int getCostScene(Scene e)
        {   
            return e.listActors[0].costTotal + e.listActors[1].costTotal;
        }
    }
}
