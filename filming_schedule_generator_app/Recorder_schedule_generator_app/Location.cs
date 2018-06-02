using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder_schedule_generator_app
{
    class Location
    {
        /***********All variable declarations here********/
        public int id { get; set; }
        public bool isUsed; // Look if is in use
        public List<FilmingDay> times = new List<FilmingDay>();
        public Location(int id)
        {
            this.id = id;
        }
    }
}
