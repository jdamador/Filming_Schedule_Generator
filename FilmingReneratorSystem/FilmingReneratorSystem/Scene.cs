using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class Scene
    {
        /***********All variable declarations here********/
        public int id;
        public List<Actor> listActors = new List<Actor>(); // List of actors that work in the scene
        public Location localizationScene; // unique localization to fill scene
   
        public int totalCost = 0;
        public int hourFilming = 3;    /*filming duration*/
        public FilmingDay dayF;
        public Scene(int id)
        {
            this.id = id;
        }
    }
}
