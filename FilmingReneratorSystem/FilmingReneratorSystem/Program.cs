using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FilmingReneratorSystem
{
    class Program
    {
        //Call new movie that contains all stages to filming
        static Movie movie;
        static void Main(String[] ar)
        {
                movie = new Movie();
                stimateCosts();
                stimateCosts();
        }
        private static void stimateCosts()
        {
            /*Estimacion de soluciones para los diferentes escenarios*/
            Console.WriteLine("                        ♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦\n" +
                              "                        ♦   Bienvenido al sistema de optimizacion de horarios de filmación     ♦\n" +
                              "                        ♦                                                                      ♦\n" +
                              "                        ♦         1) Ver mediciones (Memoria)                                  ♦\n" +
                              "                        ♦         2) Imprimir combinaciones para tamaños pequeños              ♦\n" +
                              "                        ♦         3) Imprimir cruces geneticos y sus mutaciones                ♦\n" +
                              "                        ♦         4) Ver Ramificación y Poda                                   ♦\n" +
                              "                        ♦         5) Salir                                                     ♦\n" +
                              "                        ♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦\n");
            switch (Console.Read())
            {
                case '1':
                    showDataTest(); break;
                case '2':
                    ShowCombinations(); break;
                case '3':
                    printCrossovers(); break;
                case '4':
                    showRamificacionPoda(); break;
                default:
                    stimateCosts();
                    break;


            }
            Console.ReadKey();

        }


        private static void showRamificacionPoda() {
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n" +
                              "■                       Ramificación y Poda                       ■\n" +
                              "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");
            for (int i = 0; i < movie.stages.Count; i++)
            {
                Console.WriteLine("♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦ ESCENARIO " + (i + 1) + "♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
                new BranchAndBound(movie.stages[i]);
            }

            
        }
        private static void printCrossovers()
        {
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n" +
                              "■■                                            IMPRIMIENDO CROSSOVERS                                                  ■■\n" +
                              "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            foreach (Stage item in movie.stages)
            {
                new GeneticAlgorithm(item);
            }

        }

        private static void ShowCombinations()
        {
         
        }

        private static void showDataTest()
        {
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n" +
                              "■               TEST DE MEMORIA DE LOS ALGORITMOS              ■\n" +
                              "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");
        }
    }
}
