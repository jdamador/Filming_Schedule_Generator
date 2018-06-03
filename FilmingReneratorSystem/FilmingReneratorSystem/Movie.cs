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

        }
        /**************************** CREATE LISTS **************************************/
        /// <summary>
        /// Crea 4 escenarios
        /// </summary>
        public void createStage()
        {
            for (int i = 0; i < 4; i++)
            {
                stages.Add(new Stage(i + 1));
            }
        }
        /// <summary>
        /// Creaa las escenas que seran grabadas
        /// </summary>
        public void createScenes()
        {
            int[] list = { 3, 4, 5, 6 };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < list[i]; j++)
                {
                    stages[i].scenes.Add(new Scene(j + 1));
                }

        }
        /// <summary>
        /// Crea los recursos que se utiizaran en la grabacion
        /// </summary>
        public void createActores()
        {
            int[] list = { 3, 3, 4, 5 };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < list[i]; j++)
                {
                    stages[i].actors.Add(new Actor(j + 1, j+50));
                }
        }
        /// <summary>
        /// Crea las localidade que se utilizaran en la grabacion
        /// </summary>
        public void createLocalidades()
        {
            int[] list = { 3, 4, 5, 6 };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 
                    list[i]; j++)
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
            String[] days1 = {"D", "D", "N", "D"};
            int[] num1 =     { 1 ,  2 ,  2 ,  3};
            for (int i = 0; i < 4; i++)
                stages[0].filmingDays.Add(new FilmingDay(days1[i], num1[i]));
            /********************** Stage Number 2*********************/
            String[] days2 = { "D", "N", "N", "N", "D"};
            int[] num2 =     {  1,   1,   2,   3,   4, }; 
            for (int i = 0; i < 4; i++)
                stages[0].filmingDays.Add(new FilmingDay(days2[i], num2[i]));
            /********************** Stage Number 3*********************/
            String[] days3 = { "D", "D", "N", "N", "D", "N"};
            int[] num3 =     {  1,   2,   3,   4,   5,   5};
            for (int i = 0; i < 4; i++)
                stages[0].filmingDays.Add(new FilmingDay(days3[i], num3[i]));
            /********************** Stage Number 4*********************/
            String[] days4 = { "D", "D", "N", "N", "D", "N", "N" };
            int[] num4 = { 1, 2, 3, 4, 5, 5, 6 };
            for (int i = 0; i < 4; i++)
                stages[0].filmingDays.Add(new FilmingDay(days4[i], num4[i]));


        }
        /******************** SET  INFORMATION ********************************/
        public void setStage1()
        {
            /******************* Dias en Actores **********************/
            //Actor 1
            stages[0].actors[0].available = stages[0].filmingDays;
            //Actor 2
            stages[0].actors[1].available = stages[0].filmingDays;
            //Actor 3
            stages[0].actors[2].available = stages[0].filmingDays;

            //*************** Dias en Localidades**********************/
            //Localidad 1
            stages[0].locations[0].times = stages[0].filmingDays;
            //Localidad 2
            stages[0].locations[1].times = stages[0].filmingDays;
            //Localidad 3
            stages[0].locations[2].times = stages[0].filmingDays;

            /***************** Localidades en escenas ****************/
            stages[0].scenes[0].localizationScene = stages[0].locations[2];
            stages[0].scenes[1].localizationScene = stages[0].locations[1];
            stages[0].scenes[2].localizationScene = stages[0].locations[0];
            /******************* Actores en escenas ******************/
            //Escenea 1
            stages[0].scenes[0].listActors.Add(stages[0].actors[0]);
            stages[0].scenes[0].listActors.Add(stages[0].actors[1]);
            //Escenea 2
            stages[0].scenes[1].listActors.Add(stages[0].actors[0]);
            stages[0].scenes[1].listActors.Add(stages[0].actors[2]);
            //Escenea 3
            stages[0].scenes[2].listActors.Add(stages[0].actors[1]);
            stages[0].scenes[2].listActors.Add(stages[0].actors[2]);
        }
        public void setStage2()
        {
            /******************* Dias en Actores **********************/
            //Actor 1
            stages[1].actors[0].available = stages[0].filmingDays;
            //Actor 2
            stages[1].actors[1].available = stages[0].filmingDays;
            //Actor 3
            stages[1].actors[2].available = stages[0].filmingDays;

            //*************** Dias en Localidades**********************/
            //Localidad 1
            stages[1].locations[0].times = stages[0].filmingDays;
            //Localidad 2
            stages[1].locations[1].times = stages[0].filmingDays;
            //Localidad 3
            stages[1].locations[2].times = stages[0].filmingDays;
            //Localidad 4
            stages[1].locations[3].times = stages[0].filmingDays;
            /******************* Actores en escenas ******************/
            //Escenea 1
            stages[1].scenes[0].listActors.Add(stages[1].actors[0]);
            stages[1].scenes[0].listActors.Add(stages[1].actors[2]);
            //Escenea 2
            stages[1].scenes[1].listActors.Add(stages[1].actors[0]);
            stages[1].scenes[1].listActors.Add(stages[1].actors[1]);
            //Escenea 3
            stages[1].scenes[2].listActors.Add(stages[1].actors[2]);
            stages[1].scenes[2].listActors.Add(stages[1].actors[1]);
            //Escenea 4
            stages[1].scenes[2].listActors.Add(stages[1].actors[1]);
            stages[1].scenes[2].listActors.Add(stages[1].actors[2]);
        }
        public void setStage3()
        {
            /******************* Dias en Actores **********************/
            //Actor 1
            stages[2].actors[0].available = stages[2].filmingDays;
            //Actor 2
            stages[2].actors[1].available = stages[2].filmingDays;
            //Actor 3
            stages[2].actors[2].available = stages[2].filmingDays;
            //Actor 4
            stages[2].actors[3].available = stages[2].filmingDays;

            //*************** Dias en Localidades**********************/
            //Localidad 1
            stages[2].locations[0].times = stages[2].filmingDays;
            //Localidad 2
            stages[2].locations[1].times = stages[2].filmingDays;
            //Localidad 3
            stages[2].locations[2].times = stages[2].filmingDays;
            //Localidad 4
            stages[2].locations[3].times = stages[2].filmingDays;
            //Localidad 5
            stages[2].locations[4].times = stages[2].filmingDays;
            /***************** Localidades en escenas ****************/
            stages[2].scenes[0].localizationScene = stages[2].locations[0];
            stages[2].scenes[1].localizationScene = stages[2].locations[1];
            stages[2].scenes[2].localizationScene = stages[2].locations[2];
            stages[2].scenes[3].localizationScene = stages[2].locations[3];
            stages[2].scenes[4].localizationScene = stages[2].locations[4];
            /******************* Actores en escenas ******************/
            //Escenea 1
            stages[2].scenes[0].listActors.Add(stages[2].actors[0]);
            stages[2].scenes[0].listActors.Add(stages[2].actors[1]);
            //Escenea 2
            stages[2].scenes[1].listActors.Add(stages[2].actors[1]);
            stages[2].scenes[1].listActors.Add(stages[2].actors[2]);
            //Escenea 3
            stages[2].scenes[2].listActors.Add(stages[2].actors[2]);
            stages[2].scenes[2].listActors.Add(stages[2].actors[3]);
            //Escenea 4
            stages[2].scenes[2].listActors.Add(stages[2].actors[1]);
            stages[2].scenes[2].listActors.Add(stages[2].actors[3]);
            //Escenea 5
            stages[2].scenes[2].listActors.Add(stages[2].actors[2]);
            stages[2].scenes[2].listActors.Add(stages[2].actors[3]);
        }
        public void setStage4()
        {
            /******************* Dias en Actores **********************/
            //Actor 1
            stages[3].actors[0].available = stages[3].filmingDays;
            //Actor 2
            stages[3].actors[1].available = stages[3].filmingDays;
            //Actor 3
            stages[3].actors[2].available = stages[3].filmingDays;
            //Actor 4
            stages[3].actors[3].available = stages[3].filmingDays;
            //Actor 5
            stages[3].actors[3].available = stages[3].filmingDays;
            //*************** Dias en Localidades**********************/
            //Localidad 1
            stages[3].locations[0].times = stages[2].filmingDays;
            //Localidad 2
            stages[3].locations[1].times = stages[2].filmingDays;
            //Localidad 3
            stages[3].locations[2].times = stages[2].filmingDays;
            //Localidad 4
            stages[3].locations[3].times = stages[2].filmingDays;
            //Localidad 5
            stages[3].locations[4].times = stages[2].filmingDays;
            //Localidad 6
            stages[3].locations[5].times = stages[2].filmingDays;
            //******************* Actores en escenas ******************/
            //Escenea 1
            stages[3].scenes[0].listActors.Add(stages[3].actors[0]);
            stages[3].scenes[0].listActors.Add(stages[3].actors[1]);
            //Escenea 2
            stages[3].scenes[1].listActors.Add(stages[3].actors[0]);
            stages[3].scenes[1].listActors.Add(stages[3].actors[2]);
            //Escenea 3
            stages[3].scenes[2].listActors.Add(stages[3].actors[2]);
            stages[3].scenes[2].listActors.Add(stages[3].actors[3]);
            //Escenea 4
            stages[3].scenes[2].listActors.Add(stages[3].actors[1]);
            stages[3].scenes[2].listActors.Add(stages[3].actors[4]);
            //Escenea 5
            stages[3].scenes[2].listActors.Add(stages[3].actors[2]);
            stages[3].scenes[2].listActors.Add(stages[3].actors[4]);
            //Escenea 6
            stages[3].scenes[2].listActors.Add(stages[3].actors[2]);
            stages[3].scenes[2].listActors.Add(stages[3].actors[3]);
        }


    }
}