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
        Console.WriteLine("__   __ __    __  ___   ____ __    _____\r\n||\\ /|| ||    || //    //    ||    ||\r\n||\\V/|| ||    || \\\\__  ||    ||    ||__\r\n|| V || ||    ||    \\\\ ||    ||    ||\r\n||   ||  \\\\__//   __// \\\\___ ||___ ||___\r\n__   __\t  ____  __   __ __   __ _____ __   __\r\n||\\ /||   //\\\\   \\\\ //  ||   || ||    ||\\ /||\r\n||\\V/||  //  \\\\   \\V/   ||===|| ||__  ||\\V/||\r\n|| V || ||====||   V    ||   || ||    || V ||\r\n||   || ||    ||   |    ||   || ||___ ||   ||\r\n");
        Console.WriteLine("=== Menü ===");
        Console.WriteLine("1. Játék");
        Console.WriteLine("2. Tutorial");
        Console.WriteLine("3. Irányítás");
        Console.WriteLine("4. Kilépés");
        Console.Write("Válassz egy lehetőséget: ");

        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                StartGame();
                break;
            case "2":
                StartTutorial();
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

    static void ShowControls()
    {
        Console.Clear();
        Console.WriteLine("=== Irányítás ===");
        Console.WriteLine("Mozgás: WASD");
        Console.WriteLine("Interakció: Enter");
        Console.WriteLine("Nyomj egy billentyűt a visszalépéshez a menübe...");
        Console.ReadKey();
        MainMenu();
    }

    static void StartTutorial()
    {
        Console.WriteLine("tutorial szoba");

        int startX = 4;
        int startY = 9;
        int currentX = startX;
        int currentY = startY;

        int width = 10;
        int height = 10;
        char[,] map = new char[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i == 0 && (j == 4 || j == 5))
                {
                    map[i, j] = '■';
                }
                else if (j == 0 && (i == 4 || i == 5))
                {
                    map[i, j] = '■';
                }
                else if (j == 9 && ( i == 4 || i == 5))
                {
                    map[i, j] = '■';
                }
                else
                {
                    map[i, j] = '·';
                }
            }
        }

        map[currentY, currentX] = 'O';

        DrawMap(map, width, height);

        Console.WriteLine("Ez a tutorial szoba.\nJobb oldalt van a bolt, ahol itemeket tudsz venni.\nBal oldalt van az edzőtér, ahol harcolhatsz egy ellenféllel.\nFent van a folyosó a következő szobához, ahol egy bossal harcolatsz.");

        int szoba = 0;

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    if (currentY > 0)
                    {
                        if ((currentY == 0 && currentX == 4) || (currentY == 0 && currentX == 5) || (currentY == 4 && currentX == 0) || (currentY == 5 && currentX == 0) || (currentY == 4 && currentX == 9) || (currentY == 5 && currentX == 9))
                        {
                            map[currentY, currentX] = '■';
                        }
                        else
                        {
                            map[currentY, currentX] = '·';
                        }
                        currentY--;
                    }
                    break;
                case ConsoleKey.S:
                    if (currentY < height - 1)
                    {
                        if ((currentY == 0 && currentX == 4) || (currentY == 0 && currentX == 5) || (currentY == 4 && currentX == 0) || (currentY == 5 && currentX == 0) || (currentY == 4 && currentX == 9) || (currentY == 5 && currentX == 9))
                        {
                            map[currentY, currentX] = '■';
                        }
                        else
                        {
                            map[currentY, currentX] = '·';
                        }
                        currentY++;
                    }
                    break;
                case ConsoleKey.A:
                    if (currentX > 0)
                    {
                        if ((currentY == 0 && currentX == 4) || (currentY == 0 && currentX == 5) || (currentY == 4 && currentX == 0) || (currentY == 5 && currentX == 0) || (currentY == 4 && currentX == 9) || (currentY == 5 && currentX == 9))
                        {
                            map[currentY, currentX] = '■';
                        }
                        else
                        {
                            map[currentY, currentX] = '·';
                        }
                        currentX--;
                    }
                    break;
                case ConsoleKey.D:
                    if (currentX < width - 1)
                    {
                        if ((currentY == 0 && currentX == 4) || (currentY == 0 && currentX == 5) || (currentY == 4 && currentX == 0) || (currentY == 5 && currentX == 0) || (currentY == 4 && currentX == 9) || (currentY == 5 && currentX == 9))
                        {
                            map[currentY, currentX] = '■';
                        }
                        else
                        {
                            map[currentY, currentX] = '·';
                        }
                        currentX++;
                    }
                    break;
                case ConsoleKey.Enter:
                    if (currentY == 0 && (currentX == 4 || currentX == 5))
                    {
                        szoba = 1;
                    }
                    else if (currentX == 0 && (currentY == 4 || currentY == 5))
                    {
                        szoba = 2;
                    }
                    else if (currentX == 9 && (currentY == 4 || currentY == 5)){
                        szoba = 3;
                    }
                    break;
                case ConsoleKey.Escape:
                    MainMenu();
                    break;
            }

            map[currentY, currentX] = 'O';

            DrawMap(map, width, height);

            Console.WriteLine("Ez a tutorial szoba\nJobb oldalt van a bolt, ahol itemeket tudsz venni.\nBal oldalt van az edzőtér, ahol harcolhatsz egy ellenféllel.\nFent van a folyosó a következő szobához, ahol egy bossal harcolatsz.");

            switch (szoba)
            {
                case 1:
                    CombatBoss();
                    break;
                case 2:
                    ShopMenu();
                    break;
                case 3:
                    CombatEnemy();
                    break;
            }
        }
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
                map[i, j] = '·';
            }
        }

        map[startY, startX] = 'O';

        DrawMap(map, width, height);

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentY > 0)
                    {
                        map[currentY, currentX] = '·';
                        currentY--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (currentY < height - 1)
                    {
                        map[currentY, currentX] = '·';
                        currentY++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentX > 0)
                    {
                        map[currentY, currentX] = '·';
                        currentX--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (currentX < width - 1)
                    {
                        map[currentY, currentX] = '·';
                        currentX++;
                    }
                    break;
                case ConsoleKey.W:
                    if (currentY > 0)
                    {
                        map[currentY, currentX] = '·';
                        currentY--;
                    }
                    break;
                case ConsoleKey.S:
                    if (currentY < height - 1)
                    {
                        map[currentY, currentX] = '·';
                        currentY++;
                    }
                    break;
                case ConsoleKey.A:
                    if (currentX > 0)
                    {
                        map[currentY, currentX] = '·';
                        currentX--;
                    }
                    break;
                case ConsoleKey.D:
                    if (currentX < width - 1)
                    {
                        map[currentY, currentX] = '·';
                        currentX++;
                    }
                    break;
                case ConsoleKey.Enter:
                    if (currentX == 0 && (currentY == 4 || currentY == 5))
                    {
                        ShopMenu();
                    }
                    else if (currentX == 9 && (currentY == 4 || currentY == 5))
                    {
                        CombatEnemy();
                    }
                    else if (currentY == 0 && (currentX == 4 || currentX == 5))
                    {
                        CombatBoss();
                    }
                    break;
                case ConsoleKey.Escape:
                    return;
            }

            map[currentY, currentX] = 'O';

            DrawMap(map, width, height);
        }
    }

    static void ShopMenu()
    {
        Console.Clear();
        Console.WriteLine("bolt");
    }

    static void CombatEnemy()
    {
        Console.Clear();
        Console.WriteLine("enemy");
    }

    static void CombatBoss()
    {
        Console.Clear();
        Console.WriteLine("boss");
    }

    static void DrawMap(char[,] map, int width, int height)
    {
        Console.Clear();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (map[i, j] == '■')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($" {map[i, j]}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write($" {map[i, j]}");
                }
            }
            Console.WriteLine();
        }
    }
}