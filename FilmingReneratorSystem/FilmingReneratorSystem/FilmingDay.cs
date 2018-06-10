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
    public class FilmingDay
    {
        //Filming day are all day available to film this movie

        /**************All variables declaration here**************/
        public String id;
        public int numDia;
        public int maxHour;
        public bool isDay;
        public int valueMemory=0;
        public FilmingDay(bool isDay, int num)
        {
            numDia = num;
            this.isDay = isDay;
            setId();
            valueMemory += 32;//numDia
            valueMemory += 32;//maxHour
            valueMemory += 1;//isDay
            valueMemory += id.Length * 16;//string ID

        }
        /// <summary>
        /// Set if time is morning or night
        /// </summary>
        public void setId()
        {
            if (isDay)
                id = "D" + numDia + "-M";
            else
                id = "D" + numDia + "-N";
        }
    }
}
