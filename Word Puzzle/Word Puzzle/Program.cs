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

        //Sorting Prosedure
        public static IList<string> SortStringLength(IList<string> stringList)
        {
            string[] wordDict = stringList.ToArray<string>();
            Array.Sort(wordDict, new Comparison<string>(delegate (string word1, string word2)
            {
                if (word1.Length < word2.Length)
                    return -1; //shorter string before longer string
                else if (word1.Length > word2.Length)
                    return 1; //longer string after shorter string
                else
                    return word1.CompareTo(word2); //alphabetical order
            }));
            return wordDict;
        }

        public static string[] puzzleText;


        static void PrintPuzzle(int wordCounterPrec, string[] puzzleTextPrec, string[] wordsPrec)
        {
            //to write word counter
            Console.Clear();
            Console.WriteLine("WORD = " + wordCounterPrec);






            //messages
            Console.SetCursorPosition(0, puzzleTextPrec.GetLength(0) + 2);
            if (wordCounterPrec == 0)
            {
                Console.WriteLine("Press \"ENTER\" to start.");
            }
            else
            {
                //write the message when word counter is not 0
            }








            //Printing left side of screen puzzle table 
            for (int i = 0; i < puzzleTextPrec[0].Length; i++)
            {
                Console.SetCursorPosition(2 + i, 1);
                Console.Write(i % 10);
            }
            for (int i = 0; i < puzzleTextPrec.Length; i++)
            {

                Console.SetCursorPosition(1, 2 + i);
                Console.Write(i % 10);
                Console.Write(puzzleTextPrec[i]);
            }

            //Printing right side of screen

            // row number
            int row = wordsPrec.Length / puzzleTextPrec.Length + 1;
            //table
            Console.SetCursorPosition(puzzleTextPrec[0].Length + 6, 1);
            Console.Write("+-WORD-LIST");

            for (int i = 0; i < row; i++)
            {
                Console.Write("---------");

            }
            Console.Write("-+");



            for (int i = 0; i < puzzleTextPrec.Length - 1; i++)
            {
                Console.SetCursorPosition(puzzleTextPrec[0].Length + 6, i + 2);
                Console.Write("|");

                Console.SetCursorPosition(puzzleTextPrec[0].Length + 18 + (row * 9

                    ), i + 2);
                Console.Write("|");

            }

            Console.SetCursorPosition(puzzleTextPrec[0].Length + 6, puzzleTextPrec.Length + 1);
            Console.Write("+-");
            for (int i = 0; i < row + 1; i++)
            {
                Console.Write("---------");

            }
            Console.Write("-+");

            //words
            for (int r = 0; r < row; r++)
            {
                int i = 0;
                int xList = 0, yList = 0;
                xList = puzzleTextPrec[0].Length + 7 + (r * 14);

                for (i = (r * (puzzleTextPrec.Length - 1)); i < wordsPrec.Length; i++)
                {
                    if (i < (r + 1) * puzzleTextPrec.Length - 1)
                    {
                        yList = (i % (puzzleTextPrec.Length - 1)) + 2;
                        Console.SetCursorPosition(xList, yList);
                        Console.Write("[ ]" + wordsPrec[i]);
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }




        static void Main(string[] args)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////INPUT FILES START
            //to define paths
            string path = Directory.GetCurrentDirectory();
            string pathDictionary = path + "\\dictionary.txt";
            string pathPuzzle = path + "\\puzzle.txt";

            //to import .txt files
            string[] words = System.IO.File.ReadAllLines(@pathDictionary);
            string[] puzzleText = System.IO.File.ReadAllLines(@pathPuzzle);
            ///////////////////////////////////////////////////////////////////////////////////////INPUT FILES END









            ///////////////////////////////////////////////////////////////////////////////////////VARIABLES START
            bool application = true; ;
            int menu_in = 0;
            bool[] vertical = new bool[words.GetLength(0)];
            int[] boxCoorX = new int[words.GetLength(0)];
            int[] boxCoorY = new int[words.GetLength(0)];
            string[] box = new string[words.GetLength(0)];
            bool[] specExist = new bool[words.GetLength(0)];
            bool[] boxCompleted = new bool[words.GetLength(0)];
            bool[] wordUsed = new bool[words.GetLength(0)];
            ///////////////////////////////////////////////////////////////////////////////////////VARIABLES END









            ///////////////////////////////////////////////////////////////////////////////////////PREPARE VARIABLES START
            words = (string[])SortStringLength(words);

            //to make empty variables
            for (int i = 0; i < words.GetLength(0); i++)
            {
                box[i] = "";
            }


            //to empty wordUsed
            for (int i = 0; i < words.GetLength(0); i++)
            {
                wordUsed[i] = false;
            }


            //to make false all of boxCompleted variables
            for (int i = 0; i < boxCompleted.GetLength(0); i++)
            {
                boxCompleted[i] = false;
            }



            ////////////TO GET BOXES STRING
            int counterBox = 0;

            //control all of points
            for (int i = 1; i < puzzleText.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < puzzleText[0].Length - 1; j++)
                {
                    if (puzzleText[i][j] != '█')
                    {
                        //if left of point is wall and the right of point is not wall this point is a start point of a box which horizontal
                        if (puzzleText[i][j - 1] == '█' && puzzleText[i][j + 1] != '█')
                        {
                            //define reqıuired variables
                            vertical[counterBox] = false;
                            boxCoorY[counterBox] = i;
                            boxCoorX[counterBox] = j;

                            //to add points at the right of start point
                            int count = 0;
                            while (puzzleText[i][j + count] != '█')
                            {
                                box[counterBox] += puzzleText[i][j + count];
                                count++;
                            }

                            counterBox++;//to next box

                        }

                        //if top of the point is wall and under the point is not wall this point is a start point of a box which vertical
                        if (puzzleText[i - 1][j] == '█' && puzzleText[i + 1][j] != '█')
                        {
                            //define reqıuired variables
                            vertical[counterBox] = true;
                            boxCoorY[counterBox] = i;
                            boxCoorX[counterBox] = j;

                            //to add points at the right of start point
                            int count = 0;
                            while (puzzleText[i + count][j] != '█')
                            {
                                box[counterBox] += puzzleText[i + count][j];
                                count++;
                            }

                            counterBox++;//to next box

                        }
                    }

                }
            }



            //to get spec exist bool variable
            for (int i = 0; i < box.GetLength(0); i++)//to scan all words
            {
                specExist[i] = false;
                for (int j = 0; j < box[i].Length; j++)// to scan all characters
                {
                    if (box[i][j] != ' ')
                    {
                        specExist[i] = true;
                    }
                }
            }

            








            ///////////////////////////////////////////////////////////////////////////////////////PREPARE VARIABLES END



            //////APPLICATION LOOP START
            while (application)
            {
                bool gameFinished = false;





                /////START SCREEN START
                ///
                Console.Clear();
                Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------|");
                Console.Write("|                      "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("__          __  ______   _        _____    ____    __  __   ______                           "); Console.ResetColor(); Console.WriteLine(" |");
                Console.Write("|                      "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\\ \\        / / |  ____| | |      / ____|  / __ \\  |  \\/  | |  ____|                          "); Console.ResetColor(); Console.WriteLine(" | ");
                Console.Write("|                       "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\\ \\  /\\  / /  | |__ |  | |     | |      | |  | | | \\  / | | |__                             "); Console.ResetColor(); Console.WriteLine(" | ");
                Console.Write("|                        "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\\ \\//  \\/ /  |  __|   | |     | |      | |  | | | |\\/| | |  __|                            "); Console.ResetColor(); Console.WriteLine(" | ");
                Console.Write("|                         "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\\  /\\  /    | |____  | |____ | |____  | |__| | | |  | | | |____                           "); Console.ResetColor(); Console.WriteLine(" | ");
                Console.Write("|                          "); Console.ForegroundColor = ConsoleColor.DarkCyan; Console.Write("\\//  \\//   |______| |______| \\_____|  \\____/  |_|  |_| |______|                          "); Console.ResetColor(); Console.WriteLine(" | ");
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
                    int wordCounter = 0;









                    //////TURN LOOP START
                    while (!gameFinished)
                    {
                        bool boxFound = false;
                        int whichBox = -1;
                        int whichWord = -1;


                        ////////////////////////////////////////////////////////////////////////////////////////PRINT GAME SCREEN START


                        PrintPuzzle(wordCounter, puzzleText, words);

                        wordCounter++;

                        //////////////////////////////////////////////////////////////////////////////////////////PRINT GAME SCREEN END






                        ////////////////////////////////////SCAN BOXES START


                        //specify loop START
                        while (!boxFound)
                        {
                            for (int i = 0; i < box.GetLength(0); i++)
                            {
                                int matchCounter = 0;

                                if (!boxCompleted[i] && specExist[i])
                                {

                                    for (int j = 0; j < words.GetLength(0); j++)
                                    {
                                        if (words[j].Length == box[i].Length)
                                        {
                                            //MATCH CONTROL START
                                            bool matched = true;

                                            for (int k = 0; k < words[j].Length; k++)
                                            {
                                                if (box[i][k] != ' ' && box[i][k] != words[j][k])
                                                {
                                                    matched = false;
                                                }
                                            }
                                            if (matched)
                                            {
                                                matchCounter++;
                                                whichWord = j;
                                            }
                                        }
                                    }
                                    if (matchCounter == 1)
                                    {
                                        boxFound = true;
                                        whichBox = i;
                                        break;
                                    }
                                }
                            }
                        }
                        
                        
                        //specify loop end
                        Console.SetCursorPosition(25, 0);
                        Console.WriteLine(whichWord + " " + whichBox + " " + boxFound);
                        Console.Read();




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
                        gameFinished = true;
                        for (int i = 0; i < puzzleText.GetLength(0); i++)
                        {
                            for (int j = 0; j < puzzleText[0].Length; j++)
                            {
                                if (puzzleText[i][j] == ' ')
                                {
                                    gameFinished = false;
                                }
                            }
                        }
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
