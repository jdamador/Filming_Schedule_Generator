using FilmingReneratorSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmingReneratorSystem
{
    class Movie
    {
        //Movies contain a list of stage that need to film

        /*********All variable declaration here***********/
        public List<Stage> stages = new List<Stage>(); /*Stage List*/

        public Movie()
        {
            createStage();
            createScenes();
            createActores();
            createLocalidades();
            createFilmingDay();
            setStage1();
            setStage2();
            setStage3();
            setStage4();
            //imprimir();

        }
        /**************************** CREATE LISTS **************************************/
        /// <summary>
        /// Crea 4 escenarios
        /// </summary>
        public void createStage()
        {
            for (int i = 1; i <= 5; i++)
            {
                stages.Add(new Stage(i ));
            }
        }
        /// <summary>
        /// Creaa las escenas que seran grabadas
        /// </summary>
        public void createScenes()
        {
            int[] list = { 4, 5, 6, 7 };
            for (int i = 0; i <4; i++)
                for (int j = 0; j < list[i]; j++)
                {
                    stages[i].scenes.Add(new Scene(j+1));
                }

        }
        /// <summary>
        /// Crea los recursos que se utiizaran en la grabacion
        /// </summary>
        public void createActores()
        {
            int[] list = { 5, 6, 7, 8};
            int[] precios = { 200, 50, 100, 500,125,75,150,125,175,250,275,24};
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < list[i]; j++)
                {
                    stages[i].actors.Add(new Actor(j + 1, precios[j]));
                }
        }
        /// <summary>
        /// Crea las localidade que se utilizaran en la grabacion
        /// </summary>
        public void createLocalidades()
        {
            int[] list = {4,5,6,7};
            for (int i = 0; i < 4; i++)
                for (int j = 0; j <list[i]; j++)
                {
                    stages[i].locations.Add(new Location(j + 1));
                }
        }
        /// <summary>
        /// Crea los dias de filmacion
        /// </summary>
        public void createFilmingDay()
        {
            /********************** Stage Number 1*********************/
            bool[] daysA = { true, false, false, true, true, false, false, true, true, false, false };
            int[] days = { 4, 5, 6, 7 };
            for (int i = 0; i < days.Length; i++)
            {
                for (int j = 1; j <= days[i]; j++)
                {
                    stages[i].filmingDays.Add(new FilmingDay(daysA[j], j));
                }
            }


        }
        /******************** SET  INFORMATION ********************************/
        public void setStage1()
        {
            #region Asignar dias de filmacion
            foreach (Actor item in stages[0].actors)
            {
                item.available = stages[0].filmingDays;
            }
            #endregion

            #region Asignar dias localidades
            foreach (Location item in stages[0].locations)
            {
                item.times = stages[0].filmingDays;
            }
            #endregion

            #region Asignar actores y Localidades
            /***************** Localidades en escenas ****************/
            stages[0].scenes[0].localizationScene = stages[0].locations[3];
            stages[0].scenes[1].localizationScene = stages[0].locations[2];
            stages[0].scenes[2].localizationScene = stages[0].locations[1];
            stages[0].scenes[3].localizationScene = stages[0].locations[0];
            /******************* Actores en escenas ******************/
            //Escenea 1
            stages[0].scenes[0].listActors.Add(stages[0].actors[0]);
            stages[0].scenes[0].listActors.Add(stages[0].actors[1]);
            //Escenea 2
            stages[0].scenes[1].listActors.Add(stages[0].actors[2]);
            stages[0].scenes[1].listActors.Add(stages[0].actors[3]);
            //Escenea 3
            stages[0].scenes[2].listActors.Add(stages[0].actors[2]);
            stages[0].scenes[2].listActors.Add(stages[0].actors[4]);
            //Escenea 4
            stages[0].scenes[3].listActors.Add(stages[0].actors[0]);
            stages[0].scenes[3].listActors.Add(stages[0].actors[4]);
            #endregion
        }
        public void setStage2()
        {
            #region Asignar dias de filmacion
            foreach (Actor item in stages[1].actors)
            {
                item.available = stages[1].filmingDays;
            }
            #endregion

            #region Asignar dias localidades
            foreach (Location item in stages[1].locations)
            {
                item.times = stages[1].filmingDays;
            }
            #endregion

            /***************** Localidades en escenas ****************/
            stages[1].scenes[0].localizationScene = stages[1].locations[3];
            stages[1].scenes[1].localizationScene = stages[1].locations[2];
            stages[1].scenes[2].localizationScene = stages[1].locations[1];
            stages[1].scenes[3].localizationScene = stages[1].locations[0];
            stages[1].scenes[4].localizationScene = stages[1].locations[4];
            /******************* Actores en escenas ******************/
            //Escenea 1
            stages[1].scenes[0].listActors.Add(stages[1].actors[0]);
            stages[1].scenes[0].listActors.Add(stages[1].actors[2]);
            //Escenea 2
            stages[1].scenes[1].listActors.Add(stages[1].actors[2]);
            stages[1].scenes[1].listActors.Add(stages[1].actors[3]);
            //Escenea 3
            stages[1].scenes[2].listActors.Add(stages[1].actors[1]);
            stages[1].scenes[2].listActors.Add(stages[1].actors[4]);
            //Escenea 4
            stages[1].scenes[3].listActors.Add(stages[1].actors[0]);
            stages[1].scenes[3].listActors.Add(stages[1].actors[4]);
            //Escenea 5
            stages[1].scenes[4].listActors.Add(stages[1].actors[3]);
            stages[1].scenes[4].listActors.Add(stages[1].actors[5]);
        }
        public void setStage3()
        {
            #region Asignar dias de filmacion
            foreach (Actor item in stages[2].actors)
            {
                item.available = stages[2].filmingDays;
            }
            #endregion

            #region Asignar dias localidades
            foreach (Location item in stages[2].locations)
            {
                item.times = stages[2].filmingDays;
            }
            #endregion

            /***************** Localidades en escenas ****************/
            stages[2].scenes[0].localizationScene = stages[2].locations[3];
            stages[2].scenes[1].localizationScene = stages[2].locations[2];
            stages[2].scenes[2].localizationScene = stages[2].locations[1];
            stages[2].scenes[3].localizationScene = stages[2].locations[0];
            stages[2].scenes[4].localizationScene = stages[2].locations[5];
            stages[2].scenes[5].localizationScene = stages[2].locations[4];
            /******************* Actores en escenas ******************/
            //Escenea 1
            stages[2].scenes[0].listActors.Add(stages[2].actors[0]);
            stages[2].scenes[0].listActors.Add(stages[2].actors[2]);
            //Escenea 2
            stages[2].scenes[1].listActors.Add(stages[2].actors[2]);
            stages[2].scenes[1].listActors.Add(stages[2].actors[3]);
            //Escenea 3
            stages[2].scenes[2].listActors.Add(stages[2].actors[1]);
            stages[2].scenes[2].listActors.Add(stages[2].actors[4]);
            //Escenea 4
            stages[2].scenes[3].listActors.Add(stages[2].actors[0]);
            stages[2].scenes[3].listActors.Add(stages[2].actors[4]);
            //Escenea 5
            stages[2].scenes[4].listActors.Add(stages[2].actors[3]);
            stages[2].scenes[4].listActors.Add(stages[2].actors[5]);
            //Escenea 6
            stages[2].scenes[5].listActors.Add(stages[2].actors[6]);
            stages[2].scenes[5].listActors.Add(stages[2].actors[1]);

        }
        public void setStage4()
        {
            #region Asignar dias de filmacion
            foreach (Actor item in stages[3].actors)
            {
                item.available = stages[3].filmingDays;
            }
            #endregion

            #region Asignar dias localidades
            foreach (Location item in stages[3].locations)
            {
                item.times = stages[3].filmingDays;
            }
            #endregion

            /***************** Localidades en escenas ****************/
            stages[3].scenes[0].localizationScene = stages[3].locations[3];
            stages[3].scenes[1].localizationScene = stages[3].locations[2];
            stages[3].scenes[2].localizationScene = stages[3].locations[1];
            stages[3].scenes[3].localizationScene = stages[3].locations[0];
            stages[3].scenes[4].localizationScene = stages[3].locations[5];
            stages[3].scenes[5].localizationScene = stages[3].locations[4];
            stages[3].scenes[6].localizationScene = stages[3].locations[6];
            /******************* Actores en escenas ******************/
            //Escenea 1
            stages[3].scenes[0].listActors.Add(stages[3].actors[0]);
            stages[3].scenes[0].listActors.Add(stages[3].actors[2]);
            //Escenea 2
            stages[3].scenes[1].listActors.Add(stages[3].actors[2]);
            stages[3].scenes[1].listActors.Add(stages[3].actors[3]);
            //Escenea 
            stages[3].scenes[2].listActors.Add(stages[3].actors[1]);
            stages[3].scenes[2].listActors.Add(stages[3].actors[4]);
            //Escenea 4
            stages[3].scenes[3].listActors.Add(stages[3].actors[0]);
            stages[3].scenes[3].listActors.Add(stages[3].actors[7]);
            //Escenea 5
            stages[3].scenes[4].listActors.Add(stages[3].actors[3]);
            stages[3].scenes[4].listActors.Add(stages[3].actors[5]);
            //Escenea 6
            stages[3].scenes[5].listActors.Add(stages[3].actors[6]);
            stages[3].scenes[5].listActors.Add(stages[3].actors[1]);
            //Escenea 6
            stages[3].scenes[5].listActors.Add(stages[3].actors[7]);
            stages[3].scenes[5].listActors.Add(stages[3].actors[4]);
        }
        public void imprimir()
        {
            //foreach (Stage a in stages)
            //{
            Stage a = stages[0];
                Console.WriteLine("*********************** Escenario #" + a.idStage + "***********************");
                foreach (Scene b in a.scenes)
                {
                    Console.WriteLine("********************************* Escena # " + b.id + " >>");
                    foreach (Actor c in b.listActors)
                    {
                        Console.WriteLine("********************** Actor # " + c.id + " >>");
                        foreach (FilmingDay d in c.available)
                        {
                            Console.WriteLine("************ Dia # " + d.id + " >>");
                        }
                    }
                    Console.WriteLine("******** Localizacion # " + b.localizationScene.id + " >>");
                    foreach (FilmingDay f in b.localizationScene.times)
                    {
                        Console.WriteLine("**** Dia # " + f.id + " >>");
                    }


                }
           // }


        }


    }
}