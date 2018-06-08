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
        public int numDia;                  /*day or night*/
        public int maxHour;
        public bool isDay;
        public FilmingDay(bool isDay, int num)
        {
            numDia = num;
           this.isDay = isDay;
            setId();
        }
        public void setId()
        {
            if (isDay)
                id = "D" + numDia + "-M";
            else
                id = "D" + numDia + "-N";
        }
    }
}
