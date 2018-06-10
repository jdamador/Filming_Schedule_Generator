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
    public class Location
    {
        /***********All variable declarations here********/
        public int id { get; set; }
        public List<FilmingDay> times = new List<FilmingDay>();
        public int valueMemory=0;
        public Location(int id)
        {
            valueMemory += 32;
            this.id = id;
        }
        /// <summary>
        /// set memory cost from times
        /// </summary>
        public void setMemory()
        {
            valueMemory += times.Count * times[0].valueMemory;//times
        }
    }
}
