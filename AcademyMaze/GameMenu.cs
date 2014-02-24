namespace AcademyMaze
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;

    public class GameMenu
    {
        //Coordinates of our cursor at the start menu
        static int cursorX = Console.WindowWidth / 2;
        static int cursorY;
        static byte optionCursorPosition = 0;

        //Menu method itself
        public static void StartMenuPrint()
        {
            optionCursorPosition = 0; // in case of reload

            Console.Title = "Academy Maze";
            Console.CursorVisible = false; //Make cursor invisible
            Console.SetWindowSize(50, 30);
            Console.SetBufferSize(50, 30);
                
            Console.SetCursorPosition(0, 1);
            //Read our Start Game Logo and print it to the console         
            try
            {
                StreamReader welcomeLogo = new StreamReader("../../LogoGame/AcademyMazeLogo.txt", Encoding.GetEncoding("UTF-8"));

                using (welcomeLogo)
                {
                    string currentLine = welcomeLogo.ReadLine();

                    while (currentLine != null)
                    {
                        for (int i = 0; i < currentLine.Length; i++)
                        {
                            if (currentLine[i] != '=')
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(currentLine[i]);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(currentLine[i]);
                            }
                        }

                        Console.WriteLine();
                        currentLine = welcomeLogo.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Logo visualization error!\nThe file specified in path was not found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Logo visualization error!\nThe specified path is invalid (for example, it is on an unmapped drive).");
            }
            catch (ArgumentNullException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Logo visualization error!\nThe given path is NULL\n and some method received a null argument!");
            }
            catch (ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Logo visualization error!\nPath is a zero-length string, contains only white space, or contains one or more invalid characters.");
            }
            catch (PathTooLongException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Logo visualization error!\nThe specified path, file name, or both exceed\n the system-defined maximum length." +
                    "Path must be\n less than 248 characters, and file names\n must be less than 260 characters.");
            }
            catch (NotSupportedException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Logo visualization error!\nThe given path is in an invalid format.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Logo visualization error!\nUnauthorizedAccesException detected! The reasons may be the following:\n" +
                    " - Path specified a file that is read-only.\n - This operation is not supported on the current platform.\n" +
                    " - The caller does not have the required permission.");
            }
            catch (SecurityException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Logo visualization error!\nSorry, but you does not have the required permission.");
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Logo visualization error!.\nAn I/O (Input/Output) error occurred while opening the file.");
            }

            //Set coordinates where our start menu options will be printed
            cursorX = Console.WindowWidth / 2 - 8;
            cursorY = Console.WindowHeight / 2 + 5; 

            //Methods call
            MenuOptionsPrint();
            RenderCursor(cursorX, cursorY);
            MoveCursor();
        }

        public static void MenuOptionsPrint()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(cursorX + 3, cursorY);
            Console.WriteLine("Start Game");
            Console.SetCursorPosition(cursorX + 3, cursorY + 1);
            Console.WriteLine("Game Mode");
            Console.SetCursorPosition(cursorX + 3, cursorY + 2);
            Console.WriteLine("Exit Game");
        }      

        public static void RenderCursor(int xCoord, int yCoord)
        {
            Console.SetCursorPosition(xCoord, yCoord);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write('#');
        }

        public static void MoveCursor()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (key.Key != ConsoleKey.Enter)
            {
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow && optionCursorPosition <= 1)
                {
                    Console.Beep(); //Make beep when move cursor
                    Console.SetCursorPosition(cursorX, cursorY);
                    Console.Write(' '); //Delete the previous cursor symbol at the respective coords
                    cursorY++;
                    optionCursorPosition++;
                    RenderCursor(cursorX, cursorY);
                }
                else if (key.Key == ConsoleKey.UpArrow && optionCursorPosition >= 1)
                {
                    Console.Beep(); //Make beep when move cursor
                    Console.SetCursorPosition(cursorX, cursorY);
                    Console.Write(' ');//Delete the previous cursor symbol at the respective coords
                    cursorY--;
                    optionCursorPosition--;
                    RenderCursor(cursorX, cursorY);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                }
                else
                {
                    RenderCursor(cursorX, cursorY);
                }
            }
        }
    }
}
