using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder_schedule_generator_app
{
    class Movie
    {
        //Movies contain a list of stage that need to film

        /*********All variable declaration here***********/
        List<Stage> stages = new List<Stage>(); /*Stage List*/

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
                for (int j = 0; j <= list[i]; j++)
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
                for (int j = 0; j <= list[i]; j++)
                {
                    stages[i].actors.Add(new Actor(j+1,(i+2500*2)/3));
                }
        }
        /// <summary>
        /// Crea las localidade que se utilizaran en la grabacion
        /// </summary>
        public void createLocalidades()
        {
            int[] list = { 3, 4, 5, 6};
            for (int i = 0; i < 4; i++)
                for (int j = 0; j <= list[i]; j++)
                {
                    stages[i].locations.Add(new Location(j + 1));
                }
        }
        /// <summary>
        /// Crea los dias de filmacion
        /// </summary>
        public void createFilmingDay()
        {
            int[] list = { 3, 4, 4, 5 };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j <= list[i]; j++)
                {
                    stages[i].filmingDays.Add(new FilmingDay(j+1,true));
                    stages[i].filmingDays.Add(new FilmingDay(j+1, false));
                }
        }
        /******************** SET  INFORMATION ********************************/
        public void setStage1()
        {
            /******************* Dias en Actores **********************/
            //Actor 1
            stages[0].actors[0].available.Add(stages[0].filmingDays[1]);
            stages[0].actors[0].available.Add(stages[0].filmingDays[2]);
            stages[0].actors[0].available.Add(stages[0].filmingDays[4]);
            stages[0].actors[0].available.Add(stages[0].filmingDays[5]);
            //Actor 2
            stages[0].actors[1].available.Add(stages[0].filmingDays[2]);
            stages[0].actors[1].available.Add(stages[0].filmingDays[3]);
            stages[0].actors[1].available.Add(stages[0].filmingDays[4]);
            //Actor 3
            stages[0].actors[2].available.Add(stages[0].filmingDays[0]);
            stages[0].actors[2].available.Add(stages[0].filmingDays[1]);
            stages[0].actors[2].available.Add(stages[0].filmingDays[3]);
            stages[0].actors[2].available.Add(stages[0].filmingDays[5]);
            /**************** Dias en localidades *********************/
            //Localidad 1
            stages[0].locations[0].times.Add(stages[0].filmingDays[3]);
            stages[0].locations[0].times.Add(stages[0].filmingDays[5]);
            stages[0].locations[0].times.Add(stages[0].filmingDays[4]);
            //Localidad 2
            stages[0].locations[1].times.Add(stages[0].filmingDays[1]);
            stages[0].locations[1].times.Add(stages[0].filmingDays[2]);
            stages[0].locations[1].times.Add(stages[0].filmingDays[5]);
            //Localidad 3
            stages[0].locations[2].times.Add(stages[0].filmingDays[1]);
            stages[0].locations[2].times.Add(stages[0].filmingDays[2]);
            stages[0].locations[2].times.Add(stages[0].filmingDays[3]);
            stages[0].locations[2].times.Add(stages[0].filmingDays[5]);
            /***************** Localidades en escenas ****************/
            stages[0].scenes[0].localizationScene = stages[0].locations[2];
            stages[0].scenes[1].localizationScene = stages[0].locations[1];
            stages[0].scenes[2].localizationScene = stages[0].locations[0];
            /******************* Actores en escenas ******************/
            //Escenea 1
            stages[0].scenes[0].listActors.Add( stages[0].actors[0]);
            stages[0].scenes[0].listActors.Add( stages[0].actors[1]);
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
            stages[1].actors[0].available.Add(stages[1].filmingDays[1]);
            stages[1].actors[0].available.Add(stages[1].filmingDays[2]);
            stages[1].actors[0].available.Add(stages[1].filmingDays[5]);
            stages[1].actors[0].available.Add(stages[1].filmingDays[6]);
            //Actor 2
            stages[1].actors[1].available.Add(stages[1].filmingDays[1]);
            stages[1].actors[1].available.Add(stages[1].filmingDays[3]);
            stages[1].actors[1].available.Add(stages[1].filmingDays[4]);
            stages[1].actors[1].available.Add(stages[1].filmingDays[6]);
            //Actor 3
            stages[1].actors[2].available.Add(stages[1].filmingDays[2]);
            stages[1].actors[2].available.Add(stages[1].filmingDays[0]);
            stages[1].actors[2].available.Add(stages[1].filmingDays[4]);
            stages[1].actors[2].available.Add(stages[1].filmingDays[6]);
            /**************** Dias en localidades *********************/
            //Localidad 1
            stages[1].locations[0].times.Add(stages[1].filmingDays[4]);
            stages[1].locations[0].times.Add(stages[1].filmingDays[6]);
            stages[1].locations[0].times.Add(stages[1].filmingDays[7]);
            //Localidad 2
            stages[1].locations[1].times.Add(stages[1].filmingDays[6]);
            stages[1].locations[1].times.Add(stages[1].filmingDays[3]);
            stages[1].locations[1].times.Add(stages[1].filmingDays[1]);
            //Localidad 3
            stages[1].locations[2].times.Add(stages[1].filmingDays[1]);
            stages[1].locations[2].times.Add(stages[1].filmingDays[3]);
            stages[1].locations[2].times.Add(stages[1].filmingDays[2]);
            stages[1].locations[2].times.Add(stages[1].filmingDays[4]);
            /***************** Localidades en escenas ****************/
            stages[1].scenes[0].localizationScene = stages[1].locations[3];
            stages[1].scenes[1].localizationScene = stages[1].locations[2];
            stages[1].scenes[2].localizationScene = stages[1].locations[0];
            stages[1].scenes[3].localizationScene = stages[1].locations[1];
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
        }
        public void setStage3()
        {
            /******************* Dias en Actores **********************/
            //Actor 1
            stages[2].actors[0].available.Add(stages[2].filmingDays[1]);
            stages[2].actors[0].available.Add(stages[2].filmingDays[2]);
            stages[2].actors[0].available.Add(stages[2].filmingDays[7]);
            stages[2].actors[0].available.Add(stages[2].filmingDays[4]);
            //Actor 2
            stages[2].actors[1].available.Add(stages[2].filmingDays[2]);
            stages[2].actors[1].available.Add(stages[2].filmingDays[7]);
            stages[2].actors[1].available.Add(stages[2].filmingDays[3]);
            stages[2].actors[1].available.Add(stages[2].filmingDays[0]);
            //Actor 3
            stages[2].actors[2].available.Add(stages[2].filmingDays[3]);
            stages[2].actors[2].available.Add(stages[2].filmingDays[0]);
            stages[2].actors[2].available.Add(stages[2].filmingDays[2]);
            stages[2].actors[2].available.Add(stages[2].filmingDays[6]);
            //Actor 4
            stages[2].actors[3].available.Add(stages[2].filmingDays[2]);
            stages[2].actors[3].available.Add(stages[2].filmingDays[1]);
            stages[2].actors[3].available.Add(stages[2].filmingDays[4]);
            stages[2].actors[3].available.Add(stages[2].filmingDays[6]);
            /**************** Dias en localidades *********************/
            //Localidad 1
            stages[2].locations[0].times.Add(stages[2].filmingDays[2]);
            stages[2].locations[0].times.Add(stages[2].filmingDays[7]);
            stages[2].locations[0].times.Add(stages[2].filmingDays[1]);
            //Localidad 2
            stages[2].locations[1].times.Add(stages[2].filmingDays[0]);
            stages[2].locations[1].times.Add(stages[2].filmingDays[3]);
            stages[2].locations[1].times.Add(stages[2].filmingDays[1]);
            //Localidad 3
            stages[2].locations[2].times.Add(stages[2].filmingDays[2]);
            stages[2].locations[2].times.Add(stages[2].filmingDays[6]);
            stages[2].locations[2].times.Add(stages[2].filmingDays[4]);
            //Localidad 4
            stages[2].locations[2].times.Add(stages[2].filmingDays[4]);
            stages[2].locations[2].times.Add(stages[2].filmingDays[0]);
            stages[2].locations[2].times.Add(stages[2].filmingDays[1]);
            //Localidad 5
            stages[2].locations[2].times.Add(stages[2].filmingDays[2]);
            stages[2].locations[2].times.Add(stages[2].filmingDays[6]);
            stages[2].locations[2].times.Add(stages[2].filmingDays[4]);
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
            stages[3].actors[0].available.Add(stages[3].filmingDays[0]);
            stages[3].actors[0].available.Add(stages[3].filmingDays[3]);
            stages[3].actors[0].available.Add(stages[3].filmingDays[5]);
            stages[3].actors[0].available.Add(stages[3].filmingDays[6]);
            //Actor 2
            stages[3].actors[1].available.Add(stages[3].filmingDays[1]);
            stages[3].actors[1].available.Add(stages[3].filmingDays[2]);
            stages[3].actors[1].available.Add(stages[3].filmingDays[5]);
            stages[3].actors[1].available.Add(stages[3].filmingDays[6]);
            //Actor 3
            stages[3].actors[2].available.Add(stages[3].filmingDays[0]);
            stages[3].actors[2].available.Add(stages[3].filmingDays[3]);
            stages[3].actors[2].available.Add(stages[3].filmingDays[4]);
            stages[3].actors[2].available.Add(stages[3].filmingDays[8]);
            //Actor 4
            stages[3].actors[3].available.Add(stages[3].filmingDays[3]);
            stages[3].actors[3].available.Add(stages[3].filmingDays[4]);
            stages[3].actors[3].available.Add(stages[3].filmingDays[7]);
            stages[3].actors[3].available.Add(stages[3].filmingDays[9]);
            //Actor 5
            stages[3].actors[3].available.Add(stages[3].filmingDays[1]);
            stages[3].actors[3].available.Add(stages[3].filmingDays[2]);
            stages[3].actors[3].available.Add(stages[3].filmingDays[4]);
            stages[3].actors[3].available.Add(stages[3].filmingDays[8]);
            /**************** Dias en localidades *********************/
            //Localidad 1
            stages[3].locations[0].times.Add(stages[3].filmingDays[5]);
            stages[3].locations[0].times.Add(stages[3].filmingDays[6]);
            stages[3].locations[0].times.Add(stages[3].filmingDays[1]);
            //Localidad 2
            stages[3].locations[1].times.Add(stages[3].filmingDays[0]);
            stages[3].locations[1].times.Add(stages[3].filmingDays[3]);
            stages[3].locations[1].times.Add(stages[3].filmingDays[1]);
            //Localidad 3
            stages[3].locations[2].times.Add(stages[3].filmingDays[3]);
            stages[3].locations[2].times.Add(stages[3].filmingDays[4]);
            stages[3].locations[2].times.Add(stages[3].filmingDays[1]);
            //Localidad 4
            stages[3].locations[0].times.Add(stages[3].filmingDays[1]);
            stages[3].locations[0].times.Add(stages[3].filmingDays[2]);
            stages[3].locations[0].times.Add(stages[3].filmingDays[8]);
            //Localidad 5
            stages[3].locations[1].times.Add(stages[3].filmingDays[4]);
            stages[3].locations[1].times.Add(stages[3].filmingDays[8]);
            stages[3].locations[1].times.Add(stages[3].filmingDays[1]);
            //Localidad 6
            stages[3].locations[2].times.Add(stages[3].filmingDays[3]);
            stages[3].locations[2].times.Add(stages[3].filmingDays[6]);
            stages[3].locations[2].times.Add(stages[3].filmingDays[4]);

            /***************** Localidades en escenas ****************/
            stages[3].scenes[0].localizationScene = stages[3].locations[0];
            stages[3].scenes[1].localizationScene = stages[3].locations[1];
            stages[3].scenes[2].localizationScene = stages[3].locations[2];
            stages[3].scenes[3].localizationScene = stages[3].locations[3];
            stages[3].scenes[4].localizationScene = stages[3].locations[4];
            stages[3].scenes[5].localizationScene = stages[3].locations[5];
            /******************* Actores en escenas ******************/
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