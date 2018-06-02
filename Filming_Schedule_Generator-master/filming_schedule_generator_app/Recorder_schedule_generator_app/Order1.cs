using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder_schedule_generator_app
{
    class Order1
    {
        /*Varibles*/

        public Order1()
        {
          
        }
        /**
	 * performs Order 1 crossover on two arrays of ints
	 * two arrays must be of same length!
	 * @param parent1 the 1st int array
	 * @param parent2 the 2nd int array
	 * @return child the new int array created after Order 1 crossover
	 */
        public List<Scene> orderOneCrossover(List<Scene> parent1, List<Scene> parent2)
        {
            int l = parent1.Count;
            //get 2 random ints between 0 and size of array
            int r1 = l / 2 - 2;
            int r2 = l / 2 + 2;
            //to make sure the r1 < r2

            //create the child .. initial elements are -1
            List<Scene> child = new List<Scene>();
            fillList(child, l);

            //copy elements between r1, r2 from parent1 into child
            for (int i = r1; i <= r2; i++)
            {
                child[i] = parent1[i];
            }

            //array to hold elements of parent1 which are not in child yet
            List<Scene> y = new List<Scene>();
                fillList( y,l- (r2 - r1) - 1);
            int j = 0;
            for (int i = 0; i < l; i++)
            {
                if (!child.Contains( parent1[i]))
                {
                    y[j] = parent1[i];
                    j++;
                }
            }
            //rotate parent2 
            //number of places is the same as the number of elements after r2
            List<Scene> copy = ShallowClone(parent2);
            rotate(copy, l - r2 - 1);

            //now order the elements in y according to their order in parent2
            List<Scene> y1 = new List<Scene>();
            fillList(y1, l - (r2 - r1) - 1);
            j = 0;
            for (int i = 0; i < l; i++)
            {
                if (y.Contains( copy[i]))
                {
                    y1[j] = copy[i];
                    j++;
                }
            }
            //now copy the remaining elements (i.e. remaining in parent1) into child
            //according to their order in parent2 .. starting after r2!
            j = 0;
            for (int i = 0; i < y1.Count; i++)
            {
                int ci = (r2 + i + 1) % l;// current index
                child[ci] = y1[i];
            }
            return child;
        }
        /// <summary>
        /// LLena un array de nulls
        /// </summary>
        /// <param name="l"></param>
        public void fillList(List<Scene> l, int length)
        {
            for (int i = 0; i < length; i++)
               l.Add(null);
            
        }
        private List<T> ShallowClone<T>(List<T> items)
        {
            return new List<T>(items);

        }

        public void rotate(List<Scene> items, int places)
        {
            int rotate = places;
            List<Scene> results = new List<Scene>();
            fillList(results, items.Count);
            for (int i = 0; i < items.Count; i++)
            {
                results[i] = items[(i + rotate) % items.Count];
            }
        }

    }
}
