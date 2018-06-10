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
    public class Scene
    {
        /***********All variable declarations here********/
        public int id;
        public List<Actor> listActors = new List<Actor>(); // List of actors that work in the scene
        public Location localizationScene; // unique localization to fill scene
        public int totalCost = 0;
        public int hourFilming = 3;    /*filming duration*/
        public FilmingDay dayF;
        public int valueMemory=0;
        public Scene(int id)
        {
            this.id = id;
            valueMemory += 32; //id
            valueMemory += 32; //totalCost
            valueMemory += 32; //hourFilming

        }
        /// <summary>
        /// Set memory cost from actors
        /// </summary>
        public void setMemory()
        {
            valueMemory += listActors.Count * listActors[0].valueMemory;//actors
            valueMemory += localizationScene.valueMemory;//Location
            valueMemory += listActors[0].available[0].valueMemory; //filming Day
        }
    }
}
