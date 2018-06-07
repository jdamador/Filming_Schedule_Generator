using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class Ox_Crossover
    {

        public Ox_Crossover() {

        }
        #region OX CROOSOVER
        public List<List<Scene>> oxCroosover(List<Scene> parent1, List<Scene> parent2) {
            int rank = (2 % parent1.Count)+1;
            List<Scene> sonOne = new List<Scene>(); List<Scene> sonTwo = new List<Scene>();
            #region Region to Croosover
            for (int i = 0; i < parent1.Count; i++) {
                if (i>0 & i<rank) {
                    //Agrega al hijo2
                 
                    sonTwo.Add(parent1[i]);
                }
                else { sonOne.Add(parent1[i]); }
                
            }
            for (int i = 0; i < parent2.Count; i++)
            {
                if (i == 0) {
                    sonTwo.Insert(0, parent2[i]);
                }
                else{
                    if (i > 0 & i < rank)
                    {
                        //Agrega al hijo2
                        sonOne.Insert(i, parent2[i]);
                    }
                    else
                    { sonTwo.Add(parent2[i]); }
                }
            }
            #endregion
            return (checkSons(sonOne, sonTwo,parent1,parent2));

        }
        #endregion
        #region CheckSons
        public List<List<Scene>> checkSons(List<Scene> sonOne, List<Scene> sonTwo, List<Scene> parent1, List<Scene> parent2) {
            Scene auxOne;
            Scene auxTwo;
            List<List<Scene>> list = new List<List<Scene>>();
            
            for (int i = 0; i < parent1.Count; i++) {
                auxOne = sonOne[i];
                auxTwo = sonTwo[i];
                for (int j = 0; j < parent2.Count; j++)
                {
                    if (auxOne.Equals(parent1[j])) {
                        sonOne = parent1;
                    }
                    if (auxTwo.Equals(parent2[j])) {
                        sonTwo = parent2;
                    }
                }
            }
            list.Add(sonOne); list.Add(sonTwo);
            return list;
        }
        #endregion
    }
}
