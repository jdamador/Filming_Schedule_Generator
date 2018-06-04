using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class Actor
    {
        /***********All variable declarations here********/
        public int id { get; set; }                 /* Identificator*/
        public FilmingDay firstDay = null;   /* First day to start work*/
        public FilmingDay lastDay = null;    /* Last day to end work*/
        public int costTotal { get; set; }           
        public int costXDay { get; set; }           /* Pay per day*/
        public List<FilmingDay> available = new List<FilmingDay>();
        public List<FilmingDay> workedDays = new List<FilmingDay>();
        public Actor(int id, int cost)
        {
            this.id = id;
            this.costXDay = cost;
        }
        public void setDate()
        {
            firstDay = available[0];
            lastDay = available[available.Count - 1];
        }


    }
}
