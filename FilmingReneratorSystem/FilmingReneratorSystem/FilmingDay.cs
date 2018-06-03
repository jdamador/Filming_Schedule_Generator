using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class FilmingDay
    {
        //Filming day are all day available to film this movie

        /**************All variables declaration here**************/
        public int numDia;
        public bool isDay;                     /*day or night*/
        public String id;
        public int maxHour;

        public FilmingDay(int id, bool dia)
        {
            this.numDia = id;
        }
        public FilmingDay()
        {

        }
        public void setIsDay(bool isDay)
        {
            this.isDay = isDay;
            if (isDay)
            {
                maxHour = 8;
                id = "D" + numDia + "-D";
            }
            else
            {
                maxHour = 6;
                id = "D"+numDia+"-N";
            }
               
        }
    }
}
