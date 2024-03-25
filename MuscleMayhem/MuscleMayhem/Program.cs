using System;
using System.Net;

class Game
{
    static void Main()
    {
        Console.Title = "Game";

        MainMenu();
    }

    static bool Tutorial;
    static int Room;
    static int Item1;
    static int Item2;
    static int Item3;
    static int Item4;
    static int Item5;
    static int Item6;
    static bool hasItem;

    static void MainMenu()
    {
        string[,] menu = new string[,] { { " ", "Játék" }, { " ", "Tutorial" }, { " ", "Irányítás" }, { " ", "Kilépés" } };
        int menuPoint = 0;
        int menuChoice = 0;
        menu[menuPoint, 0] = ">";

        while (true)
        {
            bool Tutorial = false;
            int Room = 0;
            int Item1 = 0;
            int Item2 = 0;
            int Item3 = 0;
            int Item4 = 0;
            int Item5 = 0;
            int Item6 = 0;
            bool hasItem = false;

            Console.Clear();
            Console.WriteLine("| __   __ __    __  ___   ____ __    _____\t\r\n| ||\\ /|| ||    || //    //    ||    ||\t\t\r\n| ||\\V/|| ||    || \\\\__  ||    ||    ||==\t    ,--.--._\r\n| || V || ||    ||    \\\\ ||    ||    ||\t\t  -\" _, \\___)\r\n| ||   ||  \\\\__//   __// \\\\___ ||___ ||___\t     / _/____)\r\n| __   __   ____  __    __ __   __ _____ __   __     \\//(____)\r\n| ||\\ /||   //\\\\   \\\\  //  ||   || ||    ||\\ /||  -\\     (__)\r\n| ||\\V/||  //  \\\\   \\\\//   ||===|| ||==  ||\\V/||    `-----\"\r\n| || V || ||====||   ||    ||   || ||    || V || \r\n| ||   || ||    ||   ||    ||   || ||___ ||   || \r\n|\t\t\t\t\t\t");
            Console.WriteLine("============================|Menü|============================");         

            DrawMenu(4, menu);

            Console.WriteLine("==============================================================");

            ConsoleKeyInfo menuSelect = Console.ReadKey(true);
            switch (menuSelect.Key)
            {
                case ConsoleKey.W:
                    menu[menuPoint, 0] = " ";
                    if (menuPoint == 0)
                    {
                        menuPoint = 3;
                    }
                    else
                    {
                        menuPoint--;
                    }
                    break;
                case ConsoleKey.S:
                    menu[menuPoint, 0] = " ";
                    if (menuPoint == 3)
                    {
                        menuPoint = 0;
                    }
                    else
                    {
                        menuPoint++;
                    }
                    break;
                case ConsoleKey.Enter:
                    menuChoice = menuPoint+1;
                    break;

            }

            menu[menuPoint, 0] = ">";

            switch (menuChoice)
            {
                case 1:
                    Cutscene1();
                    break;
                case 2:
                    StartTutorial();
                    break;
                case 3:
                    ShowControls();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }

        }
    }

    static void Cutscene1()
    {
        Console.Clear();
        Console.WriteLine("==============================================================");
        Console.WriteLine(" \t _______\t  |         |          _______     |\r\n \t |  |  |\t  |G   Y   M|\t       |  |  |     |\r\n \t |--+--|          |_________|          |--+--|     |\r\n \t |__|__|\t\t\t       |__|__|     |\r\n \t\t\t    _______\t\t\t   |\r\n \t\t\t   |   |   |\t\t___|__     |\r\n      _____ ___|___\t   | · | · |\t\t_|___|___  |\r\n_____/     \\_|_____________|___|___|___________________|___|_ \r\n     |     |\r\n     \\_____/\r\n        |");
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("Tegnap erősebben edzettél mint ebmer valaha edzett, viszont m-\negirigyelt az edzőterem tulaja, és visszavonta a tagságodat.\nIlyen bűn személyes bosszút követel. Megmutatod neki, hogy m-\nilyen erős vagy, és nem hagyod hogy bárki az utadba álljon.");
        Console.WriteLine("Nyomj egy billentyűt a folytatáshoz...");
        Console.WriteLine("==============================================================");
        Console.ReadKey();
        StartGame();
    }

    static void ShowControls()
    {
        Console.Clear();
        Console.WriteLine("============================|Irányítás|============================");
        Console.WriteLine("Mozgás: WASD");
        Console.WriteLine("Interakció, kiválasztás: Enter");
        Console.WriteLine("Főmenü: Esc");
        Console.WriteLine("Nyomj egy billentyűt a visszalépéshez a menübe...");
        Console.WriteLine("===================================================================");
        Console.ReadKey();
        MainMenu();
    }

    static void StartTutorial()
    {
        Tutorial = true;
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

        Room = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Szoba: tutorial");
            Console.WriteLine("---------------------");
            DrawMap(map, width, height);
            Console.WriteLine("---------------------");
            Console.WriteLine("Ez a tutorial szoba.\nJobb oldalt van a bolt, ahol itemeket tudsz venni.\nBal oldalt van az edzőtér, ahol harcolhatsz egy ellenféllel.\nFent van a folyosó a következő szobához, ahol egy bossal harcolatsz.");
            ConsoleKeyInfo tutorialControl = Console.ReadKey(true);
            switch (tutorialControl.Key)
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
                        Room = 1;
                    }
                    else if (currentX == 0 && (currentY == 4 || currentY == 5))
                    {
                        Room = 2;
                    }
                    else if (currentX == 9 && (currentY == 4 || currentY == 5)){
                        Room = 3;
                    }
                    break;
                case ConsoleKey.Escape:
                    MainMenu();
                    break;
            }

            map[currentY, currentX] = 'O';

            DrawMap(map, width, height);

            Console.WriteLine("Ez a tutorial szoba.\nJobb oldalt van a bolt, ahol itemeket tudsz venni.\nBal oldalt van az edzőtér, ahol harcolhatsz egy ellenféllel.\nFent van a folyosó a következő szobához, ahol egy bossal harcolatsz.");

            switch (Room)
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
        
    }

    static void ShopMenu()
    {
        string[,] shop = new string[,] { { " ", "Súllyozott boxkesztyűk (ütés bónusz)" }, { " ", "Kar védők (blokk bónusz)" }, { " ", "Edző cipők (kitérés bónusz)" }, { " ", "Testépítő olaj (flex bónusz)" }, { " ", "Étrendkiegészítők (életerő bónusz)" }, { " ", "Energiaital (energia bónusz))" }, { " ", "Vissza" } };
        int shopPoint = 0;
        int shopChoice = 0;
        shop[shopPoint, 0] = ">";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("===================================================================");
            if (hasItem)
            {
                Console.WriteLine("Már van egy itemed, többet nem bír a szervezeted.");
            }
            else
            {
                Console.WriteLine("Mivel nincs pénzed, az ilyedt kasszás megengedi neked hogy elvigyél\negy itemet ingyen.");
            }                

            Console.WriteLine();

            DrawMenu(7, shop);

            if (Tutorial)
            {
                Console.WriteLine();
                Console.WriteLine("Ez a bolt. Itt tudsz itemeket venni, amik bónuszt adnak a statiszt-\nikáidhoz. A szervezeted viszont egyszerre csak egy itemet bír, ami-\nnek a hatása a következő szobáig tart.");
            }
            Console.WriteLine("===================================================================");

            ConsoleKeyInfo shopSelect = Console.ReadKey(true);
            switch (shopSelect.Key)
            {
                case ConsoleKey.W:
                    shop[shopPoint, 0] = " ";
                    if (shopPoint == 0)
                    {
                        shopPoint = 6;
                    }
                    else
                    {
                        shopPoint--;
                    }
                    break;
                case ConsoleKey.S:
                    shop[shopPoint, 0] = " ";
                    if (shopPoint == 6)
                    {
                        shopPoint = 0;
                    }
                    else
                    {
                        shopPoint++;
                    }
                    break;
                case ConsoleKey.Enter:
                    shopChoice = shopPoint + 1;
                    break;
                case ConsoleKey.Escape:
                    MainMenu();
                    break;
            }

            shop[shopPoint, 0] = ">";

            switch (shopChoice)
            {
                case 1:
                    if (!hasItem)
                    {
                        Item1 = 2;
                        hasItem = true;
                    }
                    break;
                case 2:
                    if (!hasItem)
                    { 
                        Item2 = 2;
                        hasItem = true;
                    }
                    break;
                case 3:
                    if (!hasItem)
                    {
                        Item3 = 2;
                        hasItem = true;
                    }
                    break;
                case 4:
                    if (!hasItem)
                    {
                        Item4 = 2;
                        hasItem = true;
                    }
                    break;
                case 5:
                    if (!hasItem)
                    {
                        Item5 = 10;
                        hasItem = true;
                    }
                    break;
                case 6:
                    if (!hasItem)
                    {
                        Item6 = 2;
                        hasItem = true;
                    }
                    break;
                case 7:
                    Room = 0;
                    hasItem = true;
                    return;
            }
        }
    }

    static void CombatEnemy()
    {
        
    }

    static void CombatBoss()
    {
        Console.Clear();
        Console.WriteLine("boss");
    }

    static void DrawMap(char[,] map, int width, int height)
    {
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

    static void DrawMenu(int length, string[,] menu)
    {
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine($"{menu[i, 0]}\t{menu[i, 1]}");
        }
    }
}