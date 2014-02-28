namespace AcademyMaze
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.Text;
    using System.Threading;

    public class GameMenu
    {
        // Coordinates of our cursor at the start menu
        private static int cursorX = Console.WindowWidth / 2;
        private static int cursorY;
        private static byte optionCursorPosition = 0;
        private static PlayerType selectedPlayerType;

        static GameMenu()
        {
            GameMenu.selectedPlayerType = PlayerType.Stubborn;
        }

        public static PlayerType SelectedPlayerType
        {
            get
            {
                return selectedPlayerType;
            }

            private set
            {
                selectedPlayerType = value;
            }
        }

        // Menu method itself
        public static void StartMenuPrint()
        {
            optionCursorPosition = 0; // in case of reload

            Console.Title = "Academy Maze";
            Console.CursorVisible = false; // Make cursor invisible
            Console.SetWindowSize(50, 30);
            Console.SetBufferSize(50, 30);

            Console.SetCursorPosition(0, 1);

            // Read our Start Game Logo and print it to the console         
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

            // Set coordinates where our start menu options will be printed
            cursorX = (Console.WindowWidth / 2) - 8;
            cursorY = (Console.WindowHeight / 2) + 5;

            // Methods call
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
            Console.WriteLine("Select Hero");
            Console.SetCursorPosition(cursorX + 3, cursorY + 2);
            Console.WriteLine("Game Mode");
            Console.SetCursorPosition(cursorX + 3, cursorY + 3);
            Console.WriteLine("Exit Game");
        }

        public static void RenderCursor(int coordX, int coordY)
        {
            Console.SetCursorPosition(coordX, coordY);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write('#');
        }

        public static void MoveCursor()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (key.Key != ConsoleKey.Enter)
            {
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow && optionCursorPosition <= 2)
                {
                    Console.Beep(); // Make beep when move cursor
                    Console.SetCursorPosition(cursorX, cursorY);
                    Console.Write(' '); // Delete the previous cursor symbol at the respective coords
                    cursorY++;
                    optionCursorPosition++;
                    RenderCursor(cursorX, cursorY);
                }
                else if (key.Key == ConsoleKey.UpArrow && optionCursorPosition >= 1)
                {
                    Console.Beep(); // Make beep when move cursor
                    Console.SetCursorPosition(cursorX, cursorY);
                    Console.Write(' '); // Delete the previous cursor symbol at the respective coords
                    cursorY--;
                    optionCursorPosition--;
                    RenderCursor(cursorX, cursorY);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    OptionSelected();
                }
                else
                {
                    RenderCursor(cursorX, cursorY);
                }
            }
        }

        public static void OptionSelected()
        {
            if (optionCursorPosition == 3)
            {
                Console.Clear();
                Environment.Exit(0);
            }
            else if (optionCursorPosition == 2) 
            {
                Console.Clear();

                // Print Load Menu options
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition((Console.WindowWidth / 2) - 18, 3);
                Console.WriteLine("Choose Game Mode and press \"Enter\"");

                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.SetCursorPosition(14, 6);
                Console.WriteLine("Easy   - type \"1\"");

                Console.SetCursorPosition(14, 7);
                Console.WriteLine("Medium - type \"2\"");

                Console.SetCursorPosition(14, 8);
                Console.WriteLine("Hard   - type \"3\"");

                Console.SetCursorPosition(7, 10);
                Console.WriteLine("Return to Main Menu - type \"back\"");

                // Command section printing
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(14, 15);
                Console.WriteLine(new string('=', 20));
                Console.SetCursorPosition(18, 16);
                Console.Write("Command: ");
                Console.SetCursorPosition(14, 17);
                Console.WriteLine(new string('=', 20));

                Console.CursorVisible = true; // Make cursor visible

                CheckForValidCommand();
            }
            else if (optionCursorPosition == 1)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition((Console.WindowWidth / 2) - 18, 5);
                Console.WriteLine("Select a hero and press Enter");

                Console.SetCursorPosition(14, 8);
                Console.WriteLine("STUBBORN   - type \"1\"");

                Console.SetCursorPosition(14, 9);
                Console.WriteLine("NERD       - type \"2\"");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(14, 15);
                Console.WriteLine(new string('=', 20));
                Console.SetCursorPosition(18, 16);
                Console.Write("Command: ");
                Console.SetCursorPosition(14, 17);
                Console.WriteLine(new string('=', 20));

                Console.CursorVisible = true; // Make cursor visible

                bool correctInput = false;

                while (!correctInput)
                {
                    Console.SetCursorPosition(27, 16);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int userInput = int.Parse(Console.ReadLine());

                    if (userInput == 1)
                    {
                        SelectedPlayerType = PlayerType.Stubborn;
                    }
                    else if (userInput == 2)
                    {
                        SelectedPlayerType = PlayerType.Nerd;
                    }
                    else
                    {
                        Console.SetCursorPosition(6, 20);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Command is NOT VALID! Please try again!");
                    }

                    correctInput = true;
                    Console.Clear();
                    StartMenuPrint();
                }
            }
            else if (optionCursorPosition == 0) 
            {
                return;
            }
        }

        private static void CheckForValidCommand()
        {
            bool isValidCommand = false;

            while (isValidCommand == false)
            {
                Console.SetCursorPosition(27, 16);
                Console.ForegroundColor = ConsoleColor.Cyan;
                string userCommand = Console.ReadLine().ToLower();

                if (userCommand == "1")
                {
                    isValidCommand = true;
                    SimulateLoading();
                    Console.Clear();
                    Map someMap = new Map(MapType.Easy);
                    someMap.DrawMap();
                }
                else if (userCommand == "2")
                {
                    isValidCommand = true;
                    SimulateLoading();
                    Console.Clear();
                    Map someMap = new Map(MapType.Medium);
                    someMap.DrawMap();
                }
                else if (userCommand == "3")
                {
                    isValidCommand = true;
                    SimulateLoading();
                    Console.Clear();
                    Map someMap = new Map(MapType.Hard);
                    someMap.DrawMap();
                }
                else if (userCommand == "back")
                {
                    isValidCommand = true;
                    optionCursorPosition = 0;
                    Console.Clear();
                    StartMenuPrint();
                }
                else
                {
                    Console.SetCursorPosition(6, 20);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Command is NOT VALID! Please try again!");

                    InvalidCommandRemove(userCommand);
                }
            }
        }

        // It removes the wrong inputted command and places the cursor in the right place for the new command
        private static void InvalidCommandRemove(string userCommand)
        {
            for (int i = 0; i < userCommand.Length; i++)
            {
                Console.SetCursorPosition(27 + i, 16);
                Console.WriteLine(" ");
            }
        }

        private static void SimulateLoading()
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight - 6);
            Console.Write("Loading");
            for (int i = 0; i < 14; i++)
            {
                Console.Write(".");
                Thread.Sleep(120);
            }

            Console.WriteLine();
        }
    }
}
