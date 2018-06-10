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
   public class Actor
    {
        /***********All variable declarations here********/
        public int id { get; set; }                 /* Identificator*/
        public FilmingDay firstDay = null; /* First day to start work*/
        public FilmingDay  lastDay = null;    /* Last day to end work*/
        public int costTotal { get; set; }           
        public int costXDay { get; set; }           /* Pay per day*/
        public List<FilmingDay> available = new List<FilmingDay>();
        public int valueMemory=0;
        /// <summary>
        /// Create an  instance from actor and set their values of memory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cost"></param>
        public Actor(int id, int cost)
        {
            this.id = id;
            costXDay = cost;
            valueMemory += 32;//id memory
            valueMemory += 32;//costTotal
            valueMemory += 32;//costXday
        }
        /// <summary>
        /// Set memory value
        /// </summary>
        public void setMemory()
        {
            foreach (FilmingDay item in available)
                valueMemory += item.valueMemory;
            valueMemory += available[0].valueMemory * 2;
        }
    }
}
