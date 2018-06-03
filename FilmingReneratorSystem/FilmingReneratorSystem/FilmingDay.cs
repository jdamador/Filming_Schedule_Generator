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
        public String id;
        public int numDia;                  /*day or night*/
        public int maxHour;

        public FilmingDay(String id, int num)
        {
            numDia = num;
            this.id = id;
        }
        public void setIsDay(bool isDay)
        {
        }
    }
}
