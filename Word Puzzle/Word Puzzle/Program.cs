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
            
            string[] words = System.IO.File.ReadAllLines(@pathDictionary);
            string[] puzzleText = System.IO.File.ReadAllLines(@pathPuzzle);

            

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (words[i].Length != words[i + 1].Length)
                    Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));

                else if (string.Compare(words[i], words[i + 1]) > 0) //if first number is greater then second then swap
                {
                    //swap
                    string temp = words[i];
                    words[i] = words[i + 1];
                    words[i + 1] = temp;
                }
            }


            
            

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
                Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------|");
                Console.Write("|                      "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("_          _  __   _        __    __    _  _   ___                           "); Console.ResetColor(); Console.WriteLine(" |");
                Console.Write("|                      "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\\ \\        / / |  _| | |      / __|  / _ \\  |  \\/  | |  __|                          "); Console.ResetColor(); Console.WriteLine(" | ");
                Console.Write("|                       "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\\ \\  /\\  / /  | |_ |  | |     | |      | |  | | | \\  / | | |_                             "); Console.ResetColor(); Console.WriteLine(" | ");
                Console.Write("|                        "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\\ \\//  \\/ /  |  _|   | |     | |      | |  | | | |\\/| | |  _|                            "); Console.ResetColor(); Console.WriteLine(" | ");
                Console.Write("|                         "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\\  /\\  /    | |__  | |__ | |__  | |_| | | |  | | | |_                           "); Console.ResetColor(); Console.WriteLine(" | ");
                Console.Write("|                          "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\\//  \\//   |__| |__| \\__|  \\_/  ||  || |__|                          "); Console.ResetColor(); Console.WriteLine(" | ");
                Console.WriteLine("|                                                                                                                    | ");
                
                
                //Console.WriteLine("|  Please upload your puzzle and words as two seperate .txt file and open program again.If you uploaded files ignore this message and continue.|");
                Console.WriteLine("| - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -|");
                Console.Write("|               |                                   "); Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("Menu"); Console.ResetColor(); Console.WriteLine("                                            |                |");
                Console.WriteLine("|               |- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -|                |");
                Console.Write("|               | "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("1 - If you want to continue and see your solutions please press 1."); Console.ResetColor(); Console.WriteLine("                |                |");
                Console.Write("|               | "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("2 - If you want to see tutorials and informations about program please press 2."); Console.ResetColor(); Console.WriteLine("   |                |");
                Console.Write("|               | "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("3 - If you want to exit please press 3."); Console.ResetColor(); Console.WriteLine("                                           |                |");
                Console.WriteLine("|               |- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -|                |");
                Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------|");
                
                
                //if 
                menu_in = Convert.ToInt16(Console.ReadLine());
                
                //////START SCREEN END


                
                
                
                
                
                
                //////TUTORIAL START

                if (menu_in == 2)
                {
                    Console.Clear();

                    Console.WriteLine("| - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - |");
                    Console.Write("|  |                                                "); Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("Tutorial"); Console.ResetColor(); Console.WriteLine("                                                       |  |");
                    Console.WriteLine("|  |- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -|  |");
                    Console.Write("|  | "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("- Program needs compatible puzzle matrix and a word list which we describe as dictionary both in .txt files."); Console.ResetColor(); Console.WriteLine("  |  |");
                    Console.Write("|  | "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("- Program will draw a puzzle with given matrix and solve your puzzle step by step while filling blanks with "); Console.ResetColor(); Console.WriteLine("  |  |");
                    Console.Write("|  | "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("  words in the dictionary.                                                                                  "); Console.ResetColor(); Console.WriteLine("  |  |");
                    Console.Write("|  | "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("                                                                                                            "); Console.ResetColor(); Console.WriteLine("  |  |");
                    Console.Write("|  | "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("- Your solution will be given to you both in the end of program and as .txt file in the program folder.     "); Console.ResetColor(); Console.WriteLine("  |  |");
                    Console.Write("|  | "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("- Please enter and wait.                                                                                    "); Console.ResetColor(); Console.WriteLine("  |  |");
                    Console.WriteLine("|  |- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -|  |");
                    Console.WriteLine("|---------------------------------------------------------------------------------------------------------------------|");
                    //other alternative word for compatible -congruent- 

                    Console.ReadLine();
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
