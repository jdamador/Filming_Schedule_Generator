/********************************************
 * Autores: Daniel Amador Salas
 *          Pablo Brenes Alfaro
 * Fecha de Inicio: 27/05/2018
 * Fecha de última modificación: 09/06/2018
 * ******************************************/
using FilmingReneratorSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace FilmingReneratorSystem
{
    
    public class CycleCrossover
    {
        public int memory = 0;
        public int asig = 0; public int comp = 0;
        public CycleCrossover()
        {

        }
        /// <summary>
        /// The mutation process begins. It creates the cycle of alleles and generates the offspring
        /// </summary>
        /// <param name="parent1"></param>
        /// <param name="parent2"></param>
        /// <returns></returns>
        public List<List<Scene>> PerformCross(List<Scene> parent1, List<Scene> parent2)
        {
            asig = 0; comp = 0;
            var cycles = new List<List<int>>(); asig++;
            
            List<Scene> offspring1 = createNew(parent1.Count); asig++;
           
            List<Scene> offspring2 = createNew(parent1.Count); asig++;
         
            // Search for the cycles.
            memory += 32;
            comp++; asig++;
            for (int i = 0; i < parent1.Count; i++)
            {
                asig++; comp++;
                if (!cycles.SelectMany(p => p).Contains(i))
                {
                    var cycle = new List<int>(); asig++;
                    CreateCycle(parent1, parent2, i, cycle);
                    memory += cycle.Count * 32;
                    cycles.Add(cycle);asig++;
                }
            }
            // Copy the cycles to the offpring.
            memory += cycles.Count * 32;
            memory += 32;
            comp++; asig++;
            for (int i = 0; i < cycles.Count; i++)
            {
                asig++;
                var cycle = cycles[i]; asig++;
                memory += cycle.Count * 32;
                comp++;
                if (i % 2 == 0)
                {
                    // Copy cycle index pair: values from Parent 1 and copied to Child 1, and values from Parent 2 will be copied to Child 2.
                    CopyCycleIndexPair(cycle, parent1, offspring1, parent2, offspring2); 
                }
                else
                {
                    // Copy cycle index odd: values from Parent 1 will be copied to Child 2, and values from Parent 1 will be copied to Child 1.
                    CopyCycleIndexPair(cycle, parent1, offspring2, parent2, offspring1);
                }
            }
            asig++;
            return new List<List<Scene>>() { offspring1, offspring2 };

        }
        /// <summary>
        /// Create a list fill with null values
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private List<Scene> createNew(int length)
        {
            List<Scene> list = new List<Scene>(); asig++;
            comp++; asig++;
            for (int i = 0; i < length; i++) {
                asig += 2;
                list.Add(null); 
            }
            memory += list.Count * new Scene(0).valueMemory; asig++;
            return list;
        }
        /// <summary>
        /// Compy a cycle into the new child and remplace doubles genes
        /// </summary>
        /// <param name="cycle"></param>
        /// <param name="fromParent1Genes"></param>
        /// <param name="toOffspring1"></param>
        /// <param name="fromParent2Genes"></param>
        /// <param name="toOffspring2"></param>
        private void CopyCycleIndexPair(IList<int> cycle, List<Scene> fromParent1Genes, List<Scene> toOffspring1, List<Scene> fromParent2Genes, List<Scene> toOffspring2)
        {
            int geneCycleIndex = 0; asig++;
            memory += 32;
            memory += 32;
            comp++; asig++;
            for (int j = 0; j < cycle.Count; j++)
            {
                asig++;
                geneCycleIndex = cycle[j]; asig++;
                ReplaceGene(geneCycleIndex, fromParent1Genes[geneCycleIndex], toOffspring1);
                ReplaceGene(geneCycleIndex, fromParent2Genes[geneCycleIndex], toOffspring2);
            }
        }
        /// <summary>
        /// Generate a new cycle
        /// </summary>
        /// <param name="parent1Genes"></param>
        /// <param name="parent2Genes"></param>
        /// <param name="geneIndex"></param>
        /// <param name="cycle"></param>
        private void CreateCycle(List<Scene> parent1Genes, List<Scene> parent2Genes, int geneIndex, List<int> cycle)
        {
            comp++;
            if (!cycle.Contains(geneIndex))
            {
                var parent2Gene = parent2Genes[geneIndex]; asig++;
                memory += parent2Gene.valueMemory;
                cycle.Add(geneIndex); asig++;
                asig += 4;
                var newGeneIndex = parent1Genes.Select((g, i) => new { Value = g.id, Index = i }).First(g => g.Value.Equals(parent2Gene.id));
                memory += 32;
                comp++;
                if (geneIndex != newGeneIndex.Index)
                {
                    CreateCycle(parent1Genes, parent2Genes, newGeneIndex.Index, cycle);
                }
            }
        }
        /// <summary>
        /// remplace a gene into the chromosome
        /// </summary>
        /// <param name="index"></param>
        /// <param name="gene"></param>
        /// <param name="scenes"></param>
        public void ReplaceGene(int index, Scene gene, List<Scene> scenes)
        {
            scenes[index] = gene; asig++;
        }
    }
}

