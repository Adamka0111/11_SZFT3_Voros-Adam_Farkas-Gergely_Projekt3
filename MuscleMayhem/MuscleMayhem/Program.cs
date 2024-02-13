using System;

class Program
{
    static void Main()
    {
        Console.Title = "Game";

        MainMenu();
    }

    static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Menü ===");
        Console.WriteLine("1. Játék");
        Console.WriteLine("2. Tutorial");
        Console.WriteLine("3. Controls");
        Console.WriteLine("4. Kilépés");
        Console.Write("Válassz egy lehetőséget: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                StartGame();
                break;
            case "2":
                ShowTutorial();
                break;
            case "3":
                ShowControls();
                break;
            case "4":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Érvénytelen választás. Kérlek, próbáld újra.");
                Console.ReadKey();
                MainMenu();
                break;
        }
    }

    static void ShowTutorial()
    {
        Console.Clear();
        Console.WriteLine("=== Tutorial ===");
        Console.WriteLine("Ez lenne a játék tutorial-ja.");
        Console.WriteLine("Nyomj egy billentyűt a visszalépéshez a menübe...");
        Console.ReadKey();
        MainMenu();
    }

    static void ShowControls()
    {
        Console.Clear();
        Console.WriteLine("=== Controls ===");
        Console.WriteLine("Mozgás: WASD vagy Nyilakí");
        Console.WriteLine("Nyomj egy billentyűt a visszalépéshez a menübe...");
        Console.ReadKey();
        MainMenu();
    }
    static void StartGame()
    {
        int startX = 0;
        int startY = 0;
        int currentX = startX;
        int currentY = startY;
        
        int width = 10;
        int height = 10;
        char[,] map = new char[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                map[i, j] = '.';
            }
        }

        map[startY, startX] = 'O';

        DrawMap(map, width, height);

        // Mozgások
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentY > 0)
                    {
                        map[currentY, currentX] = '.';
                        currentY--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (currentY < height - 1)
                    {
                        map[currentY, currentX] = '.';
                        currentY++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentX > 0)
                    {
                        map[currentY, currentX] = '.';
                        currentX--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (currentX < width - 1)
                    {
                        map[currentY, currentX] = '.';
                        currentX++;
                    }
                    break;
                case ConsoleKey.W:
                    if (currentY > 0)
                    {
                        map[currentY, currentX] = '.';
                        currentY--;
                    }
                    break;
                case ConsoleKey.S:
                    if (currentY < height - 1)
                    {
                        map[currentY, currentX] = '.';
                        currentY++;
                    }
                    break;
                case ConsoleKey.A:
                    if (currentX > 0)
                    {
                        map[currentY, currentX] = '.';
                        currentX--;
                    }
                    break;
                case ConsoleKey.D:
                    if (currentX < width - 1)
                    {
                        map[currentY, currentX] = '.';
                        currentX++;
                    }
                    break;
                case ConsoleKey.Escape:
                    return;
            }

            map[currentY, currentX] = 'O';

            DrawMap(map, width, height);
        }
    }
    static void DrawMap(char[,] map, int width, int height)
    {
        Console.Clear();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write($" {map[i, j] }");
            }
            Console.WriteLine();
        }
    }
}