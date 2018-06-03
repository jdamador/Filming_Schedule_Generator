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
        public int idFilmingDay;
        public bool isDay;                     /*day or night*/
        public int maxHour;

        public FilmingDay(int id, bool dia)
        {
            this.idFilmingDay = id;
        }
        public FilmingDay()
        {

        }
        public void setIsDay(bool isDay)
        {
            this.isDay = isDay;
            if (isDay)
                maxHour = 8;
            else
                maxHour = 6;
        }
    }
}
