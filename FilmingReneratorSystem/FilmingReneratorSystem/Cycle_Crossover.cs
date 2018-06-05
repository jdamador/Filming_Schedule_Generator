using FilmingReneratorSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace FilmingReneratorSystem
{

    public class CycleCrossover
    {
        public CycleCrossover()
        {

        }
        public List<List<Scene>> PerformCross(List<Scene> parent1, List<Scene> parent2)
        {
            if (false)
            {
                //if repeat genes
            }
            var cycles = new List<List<int>>();
            List<Scene> offspring1 = createNew(parent1.Count);
            List<Scene> offspring2 = createNew(parent1.Count);
            // Search for the cycles.
            for (int i = 0; i < parent1.Count; i++)
            {
                if (!cycles.SelectMany(p => p).Contains(i))
                {
                    var cycle = new List<int>();
                    CreateCycle(parent1, parent2, i, cycle);
                    cycles.Add(cycle);
                }
            }
            // Copy the cycles to the offpring.
            for (int i = 0; i < cycles.Count; i++)
            {
                var cycle = cycles[i];

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
            return new List<List<Scene>>() { offspring1, offspring2 };

        }

        private List<Scene> createNew(int length)
        {
            List<Scene> list = new List<Scene>();
            for (int i = 0; i < length; i++)
                list[i] = null;
            return list;
        }

        private void CopyCycleIndexPair(IList<int> cycle, List<Scene> fromParent1Genes, List<Scene> toOffspring1, List<Scene> fromParent2Genes, List<Scene> toOffspring2)
        {
            int geneCycleIndex = 0;

            for (int j = 0; j < cycle.Count; j++)
            {
                geneCycleIndex = cycle[j];
                ReplaceGene(geneCycleIndex, fromParent1Genes[geneCycleIndex], toOffspring1);
                ReplaceGene(geneCycleIndex, fromParent2Genes[geneCycleIndex], toOffspring2);
            }
        }

        private void CreateCycle(List<Scene> parent1Genes, List<Scene> parent2Genes, int geneIndex, List<int> cycle)
        {
            if (!cycle.Contains(geneIndex))
            {
                var parent2Gene = parent2Genes[geneIndex];
                cycle.Add(geneIndex);
                var newGeneIndex = parent1Genes.Select((g, i) => new { Value = g.id, Index = i }).First(g => g.Value.Equals(parent2Gene.id));

                if (geneIndex != newGeneIndex.Index)
                {
                    CreateCycle(parent1Genes, parent2Genes, newGeneIndex.Index, cycle);
                }
            }
        }
        public bool AnyHasRepeatedGene(List<Scene> chromosomes)
        {
            foreach (var p in chromosomes)
            {
                var notRepeatedGenesLength = chromosomes.Distinct().Count();

                if (notRepeatedGenesLength < chromosomes.Count)
                {
                    return true;
                }
            }

            return false;
        }
        public void ReplaceGene(int index, Scene gene, List<Scene> scenes)
        {
            scenes[index] = gene;
        }
    }
}

