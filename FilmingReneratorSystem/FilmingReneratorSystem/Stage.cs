using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class Stage
    {
        //Contains all information to film this movie

        /*All variable declarations here*/
        public int idStage;
        public List<Calendar> calendars;

        public List<FilmingDay> filmingDays = new List<FilmingDay>();   /*all filming day for this movie*/
        public List<Actor> actors = new List<Actor>();                  /*All actor that take part in this filming*/
        public List<Location> locations = new List<Location>();         /*All locations available to film for this movie*/
        public List<Scene> scenes = new List<Scene>();                  /*All scenes that have to film*/

        //Missing add the best option and options list
        public Stage(int id)
        {
            this.idStage = id;
        }
    }
}
