using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Word_Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            /////INPUT FILES START
            string path = Directory.GetCurrentDirectory();
            string pathDictionary = path + "\\dictionary";
            string pathPuzzle = path + "\\puzzle";
            /////INPUT FILES END
            ///


            /////VARIABLES START
            bool application = true;
            int menu_in = 0;
            
            ////VARIABLES END
            



            /////PREPARE VARIABLES START

            /////PREPARE VARIABLES END


            
            //////APPLICATION LOOP START
            while (application)
            {
                bool gameFinished = true;

                /////START SCREEN START
                ///

                Console.Clear();
                
                Console.WriteLine("|---------------------------------------------------------------------------------------------------------------------|");
                Console.WriteLine("|                                                  Welcome                                                            |");
                Console.WriteLine("|- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -|");
                Console.WriteLine("|                |                                   Menu                                            |                |");
                Console.WriteLine("|                |- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -|                |");
                Console.WriteLine("|                | 1- If you want to continue and see your results please press 1.                   |                |");
                Console.WriteLine("|                | 2- If you want to see tutorials and informations about program please press 2.    |                |");
                Console.WriteLine("|                | 3- If you want to exit please press 3.                                            |                |");
                Console.WriteLine("|                |- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -|                |");
                Console.WriteLine("|---------------------------------------------------------------------------------------------------------------------|");
                
                menu_in = Convert.ToInt16(Console.ReadLine());//get input



                //////START SCREEN END
                ///


                //////TUTORIAL START

                if (menu_in == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Pragram will solve ");
                    Console.WriteLine("Program will solve your puzzle step by step and give you results both in program and as .txt file.Please enter and wait. ");
                    Console.ReadLine();
                    continue;
                }

                /////TUTORIAL END


                ///////GAME LOOP START
                if (menu_in == 1)
                {
                    

                    //////TURN LOOP START
                    while (!gameFinished)
                    {
                        bool boxFound = false;


                        /////PRINT PUZZLE START

                        /////PRINT PUZZLE END






                        ////////////////////////////////////SCAN BOXES START


                        //specify loop START
                        while (!boxFound)
                        {

                        }
                        //specify loop end


                        //box anaysis loop start
                        while (!boxFound)
                        {

                        }
                        // box alaysis loop end


                        //step by step loop start
                        while (!boxFound)
                        {

                        }
                        //step by step loop end

                        ///////////////////////////////////SCAN BOXES END







                        ///////FIT WORD START

                        ///////FIT WORD END



                        ///////CONTROL PUZZLE FISINHED START

                        ///////CONTROL PUZZLE FINISHED END
                    }
                    ///////TURN LOOP END
                    
                }
                ////////GAME LOOP END


                //////CREATE SOLUTION ARRAY START

                //TO TEXT

                ////////CREATE SOLUTION ARRAY END



                //////END SCREEN START

                //////END SCREEN END


            }
            ///////APPLICATION LOOP END



        }
    }
}
