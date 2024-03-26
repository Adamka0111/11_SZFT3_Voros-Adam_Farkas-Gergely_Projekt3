using System;
using System.Net;
using System.Reflection.Emit;

class Game
{
    static void Main()
    {
        Console.Title = "MuscleMayhem";

        MainMenu();
    }

    static bool Tutorial;
    static int Stage;
    static int Room;
    static bool Boss;
    static Random random = new Random();

    static int Item1;
    static int Item2;
    static int Item3;
    static int Item4;
    static int Item5;
    static int Item6;
    static int ItemCurrent;
    static bool HasItem;

    static int Health;
    static int Energy;
    static int PunchLVL;
    static int BlockLVL;
    static int DodgeLVL;
    static int FlexLVL;
    static int HealthLVL;
    static int EnergyLVL;
    static int FlexBonus;

    static int OppHealth;
    static int OppEnergy;
    static int OppPunchLVL;
    static int OppBlockLVL;
    static int OppDodgeLVL;
    static int OppFlexLVL;
    static int OppFlexBonus;

    static void MainMenu()
    {
        string[,] menu = new string[,] { { " ", "Játék" }, { " ", "Tutorial" }, { " ", "Irányítás" }, { " ", "Kilépés" } };
        int menuPoint = 0;
        int menuChoice = 0;
        menu[menuPoint, 0] = ">";

        Tutorial = false;
        Stage = 0;
        Room = 0;
        Boss = false;

        Item1 = 0;
        Item2 = 0;
        Item3 = 0;
        Item4 = 0;
        Item5 = 0;
        Item6 = 0;
        ItemCurrent = 0;
        HasItem = false;

        Health = 100;
        Energy = 20;
        PunchLVL = 0;
        BlockLVL = 0;
        DodgeLVL = 0;
        FlexLVL = 0;
        HealthLVL = 0;
        EnergyLVL = 0;
        FlexBonus = 0;

        OppHealth = 100;
        OppEnergy = 20;
        OppPunchLVL = 0;
        OppBlockLVL = 0;
        OppDodgeLVL = 0;
        OppFlexLVL = 0;
        OppFlexBonus = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("| __   __ __    __  ___   ____ __    _____\t\r\n| ||\\ /|| ||    || //    //    ||    ||\t\t\r\n| ||\\V/|| ||    || \\\\__  ||    ||    ||==\t    ,--.--._\r\n| || V || ||    ||    \\\\ ||    ||    ||\t\t  -\" _, \\___)\r\n| ||   ||  \\\\__//   __// \\\\___ ||___ ||___\t     / _/____)\r\n| __   __   ____  __    __ __   __ _____ __   __     \\//(____)\r\n| ||\\ /||   //\\\\   \\\\  //  ||   || ||    ||\\ /||  -\\     (__)\r\n| ||\\V/||  //  \\\\   \\\\//   ||===|| ||==  ||\\V/||    `-----\"\r\n| || V || ||====||   ||    ||   || ||    || V || \r\n| ||   || ||    ||   ||    ||   || ||___ ||   || \r\n|\t\t\t\t\t\t");
            Console.WriteLine("============================|Menü|============================");         

            DrawMenu(4, menu);

            Console.WriteLine("==============================================================");
            Console.WriteLine();
            Console.WriteLine("Készítette: Vörrös Ádám, Farkas Gergely");

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
        ClassSelect();
    }

    static void Cutscene2()
    {
        Console.Clear();
        Console.WriteLine("==============================================================");
        Console.WriteLine("A biztonsági őr elintézése után tovább mész leverni\na menedzsert.");
        Console.WriteLine("Nyomj egy billentyűt a folytatáshoz...");
        Console.WriteLine("==============================================================");
        Console.ReadKey();
        LevelUp();
    }

    static void Cutscene3()
    {
        Console.Clear();
        Console.WriteLine("==============================================================");
        Console.WriteLine("A menedzsert is elverted, idelye legyőzni a tulajt.");
        Console.WriteLine("Nyomj egy billentyűt a folytatáshoz...");
        Console.WriteLine("==============================================================");
        Console.ReadKey();
        LevelUp();
    }

    static void Cutscene4()
    {
        Console.Clear();
        Console.WriteLine("==============================================================");
        Console.WriteLine("Gratulálunk! Legyőzted a tulajt, és szégyenében odaadta neked\naz egész edzőtermet. Mostantól te vagy a tulaj.");
        Console.WriteLine("Nyomj egy billentyűt a folytatáshoz...");
        Console.WriteLine("==============================================================");
        Console.ReadKey();
        MainMenu();
    }

    static void ClassSelect()
    {
        Console.Clear();
        string[,] charclass = new string[,]{ { " ", "Nehéz öklű" }, { " ", "Vas bőrű" }, { " ", "Gyors lábú" }, { " ", "Izompacsirta"}, { " ", "Erőberő" }, { " ", "Mitugrász" } };
        int classPoint = 0;
        int classChoice = 0;
        charclass[classPoint, 0] = ">";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============================================================");
            Console.WriteLine("Válassz egy karakter osztályt:");
            Console.WriteLine();

            DrawMenu(6, charclass);

            Console.WriteLine("==============================================================");

            ConsoleKeyInfo classSelect = Console.ReadKey(true);
            switch (classSelect.Key)
            {
                case ConsoleKey.W:
                    charclass[classPoint, 0] = " ";
                    if (classPoint == 0)
                    {
                        classPoint = 5;
                    }
                    else
                    {
                        classPoint--;
                    }
                    break;
                case ConsoleKey.S:
                    charclass[classPoint, 0] = " ";
                    if (classPoint == 5)
                    {
                        classPoint = 0;
                    }
                    else
                    {
                        classPoint++;
                    }
                    break;
                case ConsoleKey.Enter:
                    classChoice = classPoint + 1;
                    break;
            }

            charclass[classPoint, 0] = ">";

            switch (classChoice)
            {
                case 1:
                    PunchLVL++;
                    Stage = 1;
                    StartGame();
                    break;
                case 2:
                    BlockLVL++;
                    Stage = 1;
                    StartGame();
                    break;
                case 3:
                    DodgeLVL++;
                    Stage = 1;
                    StartGame();
                    break;
                case 4:
                    FlexLVL++;
                    Stage = 1;
                    StartGame();
                    break;
                case 5:
                    HealthLVL++;
                    Stage = 1;
                    StartGame();
                    break;
                case 6:
                    EnergyLVL++;
                    Stage = 1;
                    StartGame();
                    break;
            }

        }
    }

    static void LevelUp()
    {
        Console.Clear();
        string[,] charlvl = new string[,] { { " ", "Ütés" }, { " ", "Blokk" }, { " ", "Kitérés" }, { " ", "Flex" }, { " ", "Élet" }, { " ", "Energia" } };
        int lvlPoint = 0;
        int lvlChoice = 0;
        charlvl[lvlPoint, 0] = ">";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============================================================");
            Console.WriteLine("Szintet léptél! Fejlessz egy képességet:");
            Console.WriteLine();

            DrawMenu(6, charlvl);

            Console.WriteLine("==============================================================");

            ConsoleKeyInfo lvlSelect = Console.ReadKey(true);
            switch (lvlSelect.Key)
            {
                case ConsoleKey.W:
                    charlvl[lvlPoint, 0] = " ";
                    if (lvlPoint == 0)
                    {
                        lvlPoint = 5;
                    }
                    else
                    {
                        lvlPoint--;
                    }
                    break;
                case ConsoleKey.S:
                    charlvl[lvlPoint, 0] = " ";
                    if (lvlPoint == 5)
                    {
                        lvlPoint = 0;
                    }
                    else
                    {
                        lvlPoint++;
                    }
                    break;
                case ConsoleKey.Enter:
                    lvlChoice = lvlPoint + 1;
                    break;
            }

            charlvl[lvlPoint, 0] = ">";

            switch (lvlChoice)
            {
                case 1:
                    PunchLVL++;
                    StartGame();
                    break;
                case 2:
                    BlockLVL++;
                    StartGame();
                    break;
                case 3:
                    DodgeLVL++;
                    StartGame();
                    break;
                case 4:
                    FlexLVL++;
                    StartGame();
                    break;
                case 5:
                    HealthLVL++;
                    StartGame();
                    break;
                case 6:
                    EnergyLVL++;
                    StartGame();
                    break;
            }

        }
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
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("...P: instakill...");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
        MainMenu();
    }

    static void StartTutorial()
    {
        Tutorial = true;
        Stage = 0;
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
            Console.WriteLine("Ez a tutorial szoba.\nJobb oldalt van a bolt, ahol itemeket tudsz venni.\nBal oldalt van az edzőtér, ahol harcolhatsz egy ellenféllel.\nFent van a folyosó a következő szobához, ahol egy bossal harcolatsz.\nAhhoz, hogy harcolhass a bossal, lekell győznöd előbb az ellenfelet.");
            if (Boss)
            {
                Console.WriteLine("Az ellenfél legyőzésével megnyílt az út a bosshoz");
            }
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
                    if (currentY == 0 && (currentX == 4 || currentX == 5) && Boss)
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
        switch (Stage)
        {
            case 1:
                Console.Clear();
                Tutorial = false;
                HasItem = false;
                Boss = false;
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
                        else if (j == 9 && (i == 4 || i == 5))
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
                    Console.WriteLine($"Szoba: {Stage}");
                    Console.WriteLine("---------------------");
                    DrawMap(map, width, height);
                    Console.WriteLine("---------------------");
                    if (Boss)
                    {
                        Console.WriteLine("Az ellenfél legyőzésével megnyílt az út a bosshoz");
                    }
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
                            if (currentY == 0 && (currentX == 4 || currentX == 5) && Boss)
                            {
                                Room = 1;
                            }
                            else if (currentX == 0 && (currentY == 4 || currentY == 5))
                            {
                                Room = 2;
                            }
                            else if (currentX == 9 && (currentY == 4 || currentY == 5))
                            {
                                Room = 3;
                            }
                            break;
                        case ConsoleKey.Escape:
                            MainMenu();
                            break;
                    }

                    map[currentY, currentX] = 'O';

                    DrawMap(map, width, height);

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
            case 2:
                Console.Clear();
                Tutorial = false;
                HasItem = false;
                Boss = false;
                int startX2 = 4;
                int startY2 = 9;
                int currentX2 = startX2;
                int currentY2 = startY2;

                int width2 = 10;
                int height2 = 10;
                char[,] map2 = new char[height2, width2];
                for (int i = 0; i < height2; i++)
                {
                    for (int j = 0; j < width2; j++)
                    {
                        if (i == 0 && (j == 4 || j == 5))
                        {
                            map2[i, j] = '■';
                        }
                        else if (j == 0 && (i == 4 || i == 5))
                        {
                            map2[i, j] = '■';
                        }
                        else if (j == 9 && (i == 4 || i == 5))
                        {
                            map2[i, j] = '■';
                        }
                        else
                        {
                            map2[i, j] = '·';
                        }
                    }
                }

                map2[currentY2, currentX2] = 'O';

                Room = 0;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Szoba: {Stage}");
                    Console.WriteLine("---------------------");
                    DrawMap(map2, width2, height2);
                    Console.WriteLine("---------------------");
                    if (Boss)
                    {
                        Console.WriteLine("Az ellenfél legyőzésével megnyílt az út a bosshoz");
                    }
                    ConsoleKeyInfo tutorialControl = Console.ReadKey(true);
                    switch (tutorialControl.Key)
                    {
                        case ConsoleKey.W:
                            if (currentY2 > 0)
                            {
                                if ((currentY2 == 0 && currentX2 == 4) || (currentY2 == 0 && currentX2 == 5) || (currentY2 == 4 && currentX2 == 0) || (currentY2 == 5 && currentX2 == 0) || (currentY2 == 4 && currentX2 == 9) || (currentY2 == 5 && currentX2 == 9))
                                {
                                    map2[currentY2, currentX2] = '■';
                                }
                                else
                                {
                                    map2[currentY2, currentX2] = '·';
                                }
                                currentY2--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (currentY2 < height2 - 1)
                            {
                                if ((currentY2 == 0 && currentX2 == 4) || (currentY2 == 0 && currentX2 == 5) || (currentY2 == 4 && currentX2 == 0) || (currentY2 == 5 && currentX2 == 0) || (currentY2 == 4 && currentX2 == 9) || (currentY2 == 5 && currentX2 == 9))
                                {
                                    map2[currentY2, currentX2] = '■';
                                }
                                else
                                {
                                    map2[currentY2, currentX2] = '·';
                                }
                                currentY2++;
                            }
                            break;
                        case ConsoleKey.A:
                            if (currentX2 > 0)
                            {
                                if ((currentY2 == 0 && currentX2 == 4) || (currentY2 == 0 && currentX2 == 5) || (currentY2 == 4 && currentX2 == 0) || (currentY2 == 5 && currentX2 == 0) || (currentY2 == 4 && currentX2 == 9) || (currentY2 == 5 && currentX2 == 9))
                                {
                                    map2[currentY2, currentX2] = '■';
                                }
                                else
                                {
                                    map2[currentY2, currentX2] = '·';
                                }
                                currentX2--;
                            }
                            break;
                        case ConsoleKey.D:
                            if (currentX2 < width2 - 1)
                            {
                                if ((currentY2 == 0 && currentX2 == 4) || (currentY2 == 0 && currentX2 == 5) || (currentY2 == 4 && currentX2 == 0) || (currentY2 == 5 && currentX2 == 0) || (currentY2 == 4 && currentX2 == 9) || (currentY2 == 5 && currentX2 == 9))
                                {
                                    map2[currentY2, currentX2] = '■';
                                }
                                else
                                {
                                    map2[currentY2, currentX2] = '·';
                                }
                                currentX2++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            if (currentY2 == 0 && (currentX2 == 4 || currentX2 == 5) && Boss)
                            {
                                Room = 1;
                            }
                            else if (currentX2 == 0 && (currentY2 == 4 || currentY2 == 5))
                            {
                                Room = 2;
                            }
                            else if (currentX2 == 9 && (currentY2 == 4 || currentY2 == 5))
                            {
                                Room = 3;
                            }
                            break;
                        case ConsoleKey.Escape:
                            MainMenu();
                            break;
                    }

                    map2[currentY2, currentX2] = 'O';

                    DrawMap(map2, width2, height2);

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
            case 3:
                Console.Clear();
                Tutorial = false;
                HasItem = false;
                Boss = false;
                int startX3 = 4;
                int startY3 = 9;
                int currentX3 = startX3;
                int currentY3 = startY3;

                int width3 = 10;
                int height3 = 10;
                char[,] map3 = new char[height3, width3];
                for (int i = 0; i < height3; i++)
                {
                    for (int j = 0; j < width3; j++)
                    {
                        if (i == 0 && (j == 4 || j == 5))
                        {
                            map3[i, j] = '■';
                        }
                        else if (j == 0 && (i == 4 || i == 5))
                        {
                            map3[i, j] = '■';
                        }
                        else if (j == 9 && (i == 4 || i == 5))
                        {
                            map3[i, j] = '■';
                        }
                        else
                        {
                            map3[i, j] = '·';
                        }
                    }
                }

                map3[currentY3, currentX3] = 'O';

                Room = 0;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Szoba: {Stage}");
                    Console.WriteLine("---------------------");
                    DrawMap(map3, width3, height3);
                    Console.WriteLine("---------------------");
                    if (Boss)
                    {
                        Console.WriteLine("Az ellenfél legyőzésével megnyílt az út a bosshoz");
                    }
                    ConsoleKeyInfo tutorialControl = Console.ReadKey(true);
                    switch (tutorialControl.Key)
                    {
                        case ConsoleKey.W:
                            if (currentY3 > 0)
                            {
                                if ((currentY3 == 0 && currentX3 == 4) || (currentY3 == 0 && currentX3 == 5) || (currentY3 == 4 && currentX3 == 0) || (currentY3 == 5 && currentX3 == 0) || (currentY3 == 4 && currentX3 == 9) || (currentY3 == 5 && currentX3 == 9))
                                {
                                    map3[currentY3, currentX3] = '■';
                                }
                                else
                                {
                                    map3[currentY3, currentX3] = '·';
                                }
                                currentY3--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (currentY3 < height3 - 1)
                            {
                                if ((currentY3 == 0 && currentX3 == 4) || (currentY3 == 0 && currentX3 == 5) || (currentY3 == 4 && currentX3 == 0) || (currentY3 == 5 && currentX3 == 0) || (currentY3 == 4 && currentX3 == 9) || (currentY3 == 5 && currentX3 == 9))
                                {
                                    map3[currentY3, currentX3] = '■';
                                }
                                else
                                {
                                    map3[currentY3, currentX3] = '·';
                                }
                                currentY3++;
                            }
                            break;
                        case ConsoleKey.A:
                            if (currentX3 > 0)
                            {
                                if ((currentY3 == 0 && currentX3 == 4) || (currentY3 == 0 && currentX3 == 5) || (currentY3 == 4 && currentX3 == 0) || (currentY3 == 5 && currentX3 == 0) || (currentY3 == 4 && currentX3 == 9) || (currentY3 == 5 && currentX3 == 9))
                                {
                                    map3[currentY3, currentX3] = '■';
                                }
                                else
                                {
                                    map3[currentY3, currentX3] = '·';
                                }
                                currentX3--;
                            }
                            break;
                        case ConsoleKey.D:
                            if (currentX3 < width3 - 1)
                            {
                                if ((currentY3 == 0 && currentX3 == 4) || (currentY3 == 0 && currentX3 == 5) || (currentY3 == 4 && currentX3 == 0) || (currentY3 == 5 && currentX3 == 0) || (currentY3 == 4 && currentX3 == 9) || (currentY3 == 5 && currentX3 == 9))
                                {
                                    map3[currentY3, currentX3] = '■';
                                }
                                else
                                {
                                    map3[currentY3, currentX3] = '·';
                                }
                                currentX3++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            if (currentY3 == 0 && (currentX3 == 4 || currentX3 == 5) && Boss)
                            {
                                Room = 1;
                            }
                            else if (currentX3 == 0 && (currentY3 == 4 || currentY3 == 5))
                            {
                                Room = 2;
                            }
                            else if (currentX3 == 9 && (currentY3 == 4 || currentY3 == 5))
                            {
                                Room = 3;
                            }
                            break;
                        case ConsoleKey.Escape:
                            MainMenu();
                            break;
                    }

                    map3[currentY3, currentX3] = 'O';

                    DrawMap(map3, width3, height3);

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
    }

    static void ShopMenu()
    {
        string[,] shop = new string[,] { { " ", "Súllyozott boxkesztyűk (ütés bónusz)" }, { " ", "Kar védők (blokk bónusz)" }, { " ", "Edző cipők (kitérés bónusz)" }, { " ", "Testépítő olaj (flex bónusz)" }, { " ", "Étrendkiegészítők (életerő bónusz)" }, { " ", "Energiaital (energia bónusz))" }, { " ", "Vissza" } };
        int shopPoint = 0;
        int shopChoice = 0;
        shop[shopPoint, 0] = ">";
        bool shopExit = false;

        while (true)
        {
            
            Console.Clear();
            Console.WriteLine("===================================================================");
            if (HasItem)
            {
                Console.WriteLine($"Jelenlegi item: {shop[ItemCurrent, 1]}");
                Console.WriteLine();
                Console.WriteLine("Már van egy itemed, többet nem bír a szervezeted.");
            }
            else
            {
                Console.WriteLine("Jelenleg nincs aktív itemed.");
                Console.WriteLine();
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
                    if (!HasItem)
                    {
                        shopChoice = shopPoint + 1;
                    }
                    if (shopPoint == 6)
                    {
                        shopExit = true;
                    }
                    break;
                case ConsoleKey.Escape:
                    MainMenu();
                    break;
            }

            shop[shopPoint, 0] = ">";

            switch (shopChoice)
            {
                case 1:
                    if (!HasItem)
                    {
                        Item1 = 1;
                        HasItem = true;
                        ItemCurrent = 0;
                    }
                    break;
                case 2:
                    if (!HasItem)
                    { 
                        Item2 = 1;
                        HasItem = true;
                        ItemCurrent = 1;
                    }
                    break;
                case 3:
                    if (!HasItem)
                    {
                        Item3 = 1;
                        HasItem = true;
                        ItemCurrent = 2;
                    }
                    break;
                case 4:
                    if (!HasItem)
                    {
                        Item4 = 1;
                        HasItem = true;
                        ItemCurrent = 3;
                    }
                    break;
                case 5:
                    if (!HasItem)
                    {
                        Item5 = 10;
                        HasItem = true;
                        ItemCurrent = 4;
                    }
                    break;
                case 6:
                    if (!HasItem)
                    {
                        Item6 = 5;
                        HasItem = true;
                        ItemCurrent = 5;
                    }
                    break;
            }
            if (shopExit)
            {
                Room = 0;
                return;
            }
        }
    }

    static void CombatEnemy()
    {

        switch (Stage)
        {
            case 0:
                string[,] enemy = { { " ", "Ütés" }, { " ", "Blokk" }, { " ", "Kitérés" }, { " ", "Flex" } };
                enemy[0, 0] = ">";
                int roundHealth = Health + Item5;
                int roundEnergy = Energy + Item6;
                int oppRoundHealth = OppHealth;
                int oppRoundEnergy = OppEnergy;


                int damageDeal = 0;
                int damageBlock = 0;
                int oppDamageDeal = 0;
                int oppDamageBlock = 0;
                bool dodge = false;

                int enemyPoint = 0;
                int enemyChoice = 0;
                int enemyOppChoice = 0;
                bool oppDodge = false;

                string lastMove = "";
                string oppLastMove = "";

                while (true)
                {

                    Console.Clear();
                    Console.Write("Életerő: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(roundHealth + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség életereje: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(oppRoundHealth + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Energia: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(roundEnergy + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség energiája: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(oppRoundEnergy);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("        _____                   _____\r\n       /     \\                 /     \\\r\n       |     |                 |     |\r\n       \\_____/                 \\_____/\r\n         /|                       |\\\r\n         \\|//                   \\\\|/\r\n          Y/                     \\Y\r\n          |                       |\r\n          |                       |\r\n          A                       A\r\n         / \\                     / \\");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Válaszd ki a mozdulatodat: ");
                    Console.WriteLine();
                    DrawMenu(4, enemy);
                    Console.WriteLine();
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("Ahhoz hogy legyőzd az ellendéged, választanod kell a négy\nmozdulat közül:Ütés: sebzést okoz az ellenfelednek, hat rá a flex mozdulat, 5 energiába kerül");
                    Console.WriteLine("\tÜtés: sebzést okoz az ellenfelednek, hat rá a flex mozdulat,\n5 energiába kerül");
                    Console.WriteLine("\tBlokk: megvéd téged sebződéstől, 5 energiába kerül");
                    Console.WriteLine("\tKitérés: 25% eséllyel kitérsz teljesen az ellenség támadása elől,\n5 energiát nyersz vissza");
                    Console.WriteLine("\tFlex: erősebb lessz a következő ütésed (stackelhető), de szabad\nvagy támadásra, 5 energiát nyersz vissza");
                    Console.WriteLine("Ha kifogy az energiád, gyengébbek lesznek a mozdulataid.");
                    Console.WriteLine("Akkor nyersz, ha az ellenséged élete nulla. Ha meghalsz, visszakerülsz a pályára.");
                    Console.WriteLine(lastMove);
                    Console.WriteLine(oppLastMove);

                    ConsoleKeyInfo enemySelect = Console.ReadKey(true);
                    switch (enemySelect.Key)
                    {
                        case ConsoleKey.W:
                            enemy[enemyPoint, 0] = " ";
                            if (enemyPoint == 0)
                            {
                                enemyPoint = 3;
                            }
                            else
                            {
                                enemyPoint--;
                            }
                            break;
                        case ConsoleKey.S:
                            enemy[enemyPoint, 0] = " ";
                            if (enemyPoint == 3)
                            {
                                enemyPoint = 0;
                            }
                            else
                            {
                                enemyPoint++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            enemyChoice = enemyPoint + 1;
                            enemyOppChoice = random.Next(1, 5);
                            break;
                        case ConsoleKey.P:
                            Room = 0;
                            Boss = true;
                            return;
                        case ConsoleKey.Escape:
                            MainMenu();
                            break;
                    }

                    enemy[enemyPoint, 0] = ">";

                    switch (enemyChoice)
                    {
                        case 1:
                            damageDeal = MovePunch(Item1, PunchLVL, roundEnergy, FlexBonus);
                            roundEnergy -= 5;
                            lastMove = $"Ütöttél {damageDeal} pontot";
                            FlexBonus = 0;
                            break;
                        case 2:
                            damageBlock = MoveBlock(Item1, BlockLVL, roundEnergy);
                            roundEnergy -= 5;
                            lastMove = $"Blokkoltál {damageBlock}";
                            break;
                        case 3:
                            dodge = MoveDodge(Item3, DodgeLVL, roundEnergy);
                            roundEnergy += 5;
                            if (dodge)
                            {
                                lastMove = "Sikiresen kitértél";
                            }
                            else
                            {
                                lastMove = "Nem sikerült kitérned";
                            }
                            break;
                        case 4:
                            FlexBonus = MoveFlex(Item4, FlexLVL, roundEnergy);
                            roundEnergy += 5;
                            lastMove = $"{FlexBonus} pontot flexeltél";
                            break;
                    }

                    switch (enemyOppChoice)
                    {
                        case 1:
                            oppDamageDeal = MovePunch(0, OppPunchLVL, oppRoundEnergy, OppFlexBonus);
                            roundEnergy -= 5;
                            OppFlexBonus = 0;
                            oppLastMove = $"Az ellenfél {oppDamageDeal} pontot sebzett";
                            break;
                        case 2:
                            oppDamageBlock = MoveBlock(0, OppBlockLVL, oppRoundEnergy);
                            oppRoundEnergy -= 5;
                            oppLastMove = $"Az ellenfél {oppDamageBlock} pontot blokkolt";
                            break;
                        case 3:
                            oppDodge = MoveDodge(0, OppDodgeLVL, oppRoundEnergy);
                            oppRoundEnergy += 5;
                            if (oppDodge)
                            {
                                oppLastMove = "Az ellenfél sikeresen kitért";
                            }
                            else
                            {
                                oppLastMove = "Az ellenfélnek nem sikerült kitérni";
                            }
                            break;
                        case 4:
                            OppFlexBonus = MoveFlex(0, OppFlexLVL, oppRoundEnergy);
                            oppRoundEnergy += 5;
                            oppLastMove = $"Az ellenfél {OppFlexBonus} pontot flexelt";
                            break;
                    }

                    damageDeal -= oppDamageBlock;
                    oppDamageDeal -= damageBlock;

                    if (roundEnergy < 0)
                    {
                        roundEnergy = 0;
                    }

                    if (roundEnergy > (Energy + Item6))
                    {
                        roundEnergy = Energy + Item6;
                    }

                    if (oppRoundEnergy < 0)
                    {
                        oppRoundEnergy = 0;
                    }

                    if (oppRoundEnergy > OppEnergy)
                    {
                        oppRoundEnergy = OppEnergy;
                    }

                    if (damageDeal < 0)
                    {
                        damageDeal = 0;
                    }

                    if (oppDamageDeal < 0)
                    {
                        oppDamageDeal = 0;
                    }

                    if (dodge)
                    {
                        oppDamageDeal = 0;
                    }

                    if (oppDodge)
                    {
                        damageDeal = 0;
                    }

                    Console.WriteLine($"{damageDeal} pontot sebeztél");
                    Console.WriteLine($"{oppDamageDeal} pontot sebzett az ellenfél");

                    roundHealth = roundHealth - oppDamageDeal;
                    oppRoundHealth = oppRoundHealth - damageDeal;

                    enemyChoice = 0;
                    enemyOppChoice = 0;
                    oppDamageDeal = 0;
                    damageDeal = 0;
                    damageBlock = 0;
                    oppDamageBlock = 0;

                    if (roundHealth <= 0)
                    {
                        Room = 0;
                        return;
                    }
                    else if ((roundHealth > 0) && (oppRoundHealth <= 0))
                    {
                        Room = 0;
                        Boss = true;
                        return;
                    }
                }
            case 1:
                string[,] enemy1 = { { " ", "Ütés" }, { " ", "Blokk" }, { " ", "Kitérés" }, { " ", "Flex" } };
                enemy1[0, 0] = ">";
                int roundHealth1 = Health + Item5 + HealthLVL*10;
                int roundEnergy1 = Energy + Item6 + EnergyLVL*5;
                int oppRoundHealth1 = OppHealth + Stage * 10;
                int oppRoundEnergy1 = OppEnergy + Stage * 5;


                int damageDeal1 = 0;
                int damageBlock1 = 0;
                int oppDamageDeal1 = 0;
                int oppDamageBlock1 = 0;
                bool dodge1 = false;

                int enemyPoint1 = 0;
                int enemyChoice1 = 0;
                int enemyOppChoice1 = 0;
                bool oppDodge1 = false;

                string lastMove1 = "";
                string oppLastMove1 = "";

                while (true)
                {

                    Console.Clear();
                    Console.Write("Életerő: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(roundHealth1 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség életereje: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(oppRoundHealth1 + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Energia: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(roundEnergy1 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség energiája: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(oppRoundEnergy1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("        _____                   _____\r\n       /     \\                 /     \\\r\n       |     |                 |     |\r\n       \\_____/                 \\_____/\r\n         /|                       |\\\r\n         \\|//                   \\\\|/\r\n          Y/                     \\Y\r\n          |                       |\r\n          |                       |\r\n          A                       A\r\n         / \\                     / \\");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Válaszd ki a mozdulatodat: ");
                    Console.WriteLine();
                    DrawMenu(4, enemy1);
                    Console.WriteLine();
                    Console.WriteLine("===================================================================");
                    Console.WriteLine(lastMove1);
                    Console.WriteLine(oppLastMove1);

                    ConsoleKeyInfo enemySelect = Console.ReadKey(true);
                    switch (enemySelect.Key)
                    {
                        case ConsoleKey.W:
                            enemy1[enemyPoint1, 0] = " ";
                            if (enemyPoint1 == 0)
                            {
                                enemyPoint1 = 3;
                            }
                            else
                            {
                                enemyPoint1--;
                            }
                            break;
                        case ConsoleKey.S:
                            enemy1[enemyPoint1, 0] = " ";
                            if (enemyPoint1 == 3)
                            {
                                enemyPoint1 = 0;
                            }
                            else
                            {
                                enemyPoint1++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            enemyChoice1 = enemyPoint1 + 1;
                            enemyOppChoice1 = random.Next(1, 5);
                            break;
                        case ConsoleKey.P:
                            Room = 0;
                            Boss = true;
                            return;
                        case ConsoleKey.Escape:
                            MainMenu();
                            break;
                    }

                    enemy1[enemyPoint1, 0] = ">";

                    switch (enemyChoice1)
                    {
                        case 1:
                            damageDeal1 = MovePunch(Item1, PunchLVL, roundEnergy1, FlexBonus);
                            roundEnergy1 -= 5;
                            lastMove1 = $"Ütöttél {damageDeal1} pontot";
                            FlexBonus = 0;
                            break;
                        case 2:
                            damageBlock1 = MoveBlock(Item1, BlockLVL, roundEnergy1);
                            roundEnergy1 -= 5;
                            lastMove1 = $"Blokkoltál {damageBlock1}";
                            break;
                        case 3:
                            dodge1 = MoveDodge(Item3, DodgeLVL, roundEnergy1);
                            roundEnergy1 += 5;
                            if (dodge1)
                            {
                                lastMove1 = "Sikiresen kitértél";
                            }
                            else
                            {
                                lastMove1 = "Nem sikerült kitérned";
                            }
                            break;
                        case 4:
                            FlexBonus = MoveFlex(Item4, FlexLVL, roundEnergy1);
                            roundEnergy1 += 5;
                            lastMove1 = $"{FlexBonus} pontot flexeltél";
                            break;
                    }

                    switch (enemyOppChoice1)
                    {
                        case 1:
                            oppDamageDeal1 = MovePunch(0, OppPunchLVL, oppRoundEnergy1, OppFlexBonus);
                            roundEnergy1 -= 5;
                            OppFlexBonus = 0;
                            oppLastMove1 = $"Az ellenfél {oppDamageDeal1} pontot sebzett";
                            break;
                        case 2:
                            oppDamageBlock1 = MoveBlock(0, OppBlockLVL, oppRoundEnergy1);
                            oppRoundEnergy1 -= 5;
                            oppLastMove1 = $"Az ellenfél {oppDamageBlock1} pontot blokkolt";
                            break;
                        case 3:
                            oppDodge1 = MoveDodge(0, OppDodgeLVL, oppRoundEnergy1);
                            oppRoundEnergy1 += 5;
                            if (oppDodge1)
                            {
                                oppLastMove1 = "Az ellenfél sikeresen kitért";
                            }
                            else
                            {
                                oppLastMove1 = "Az ellenfélnek nem sikerült kitérni";
                            }
                            break;
                        case 4:
                            OppFlexBonus = MoveFlex(0, OppFlexLVL, oppRoundEnergy1);
                            oppRoundEnergy1 += 5;
                            oppLastMove1 = $"Az ellenfél {OppFlexBonus} pontot flexelt";
                            break;
                    }

                    damageDeal1 -= oppDamageBlock1;
                    oppDamageDeal1 -= damageBlock1;

                    if (roundEnergy1 < 0)
                    {
                        roundEnergy1 = 0;
                    }

                    if (roundEnergy1 > (Energy + Item6))
                    {
                        roundEnergy1 = Energy + Item6;
                    }

                    if (oppRoundEnergy1 < 0)
                    {
                        oppRoundEnergy1 = 0;
                    }

                    if (oppRoundEnergy1 > OppEnergy)
                    {
                        oppRoundEnergy1 = OppEnergy;
                    }

                    if (damageDeal1 < 0)
                    {
                        damageDeal1 = 0;
                    }

                    if (oppDamageDeal1 < 0)
                    {
                        oppDamageDeal1 = 0;
                    }

                    if (dodge1)
                    {
                        oppDamageDeal1 = 0;
                    }

                    if (oppDodge1)
                    {
                        damageDeal1 = 0;
                    }

                    Console.WriteLine($"{damageDeal1} pontot sebeztél");
                    Console.WriteLine($"{oppDamageDeal1} pontot sebzett az ellenfél");

                    roundHealth1 = roundHealth1 - oppDamageDeal1;
                    oppRoundHealth1 = oppRoundHealth1 - damageDeal1;

                    enemyChoice1 = 0;
                    enemyOppChoice1 = 0;
                    oppDamageDeal1 = 0;
                    damageDeal1 = 0;
                    damageBlock1 = 0;
                    oppDamageBlock1 = 0;

                    if (roundHealth1 <= 0)
                    {
                        Room = 0;
                        return;
                    }
                    else if ((roundHealth1 > 0) && (oppRoundHealth1 <= 0))
                    {
                        Room = 0;
                        Boss = true;
                        return;
                    }
                }
            case 2:
                string[,] enemy2 = { { " ", "Ütés" }, { " ", "Blokk" }, { " ", "Kitérés" }, { " ", "Flex" } };
                enemy2[0, 0] = ">";
                int roundHealth2 = Health + Item5 + HealthLVL*10;
                int roundEnergy2 = Energy + Item6 + EnergyLVL*5;
                int oppRoundHealth2 = OppHealth + Stage * 10;
                int oppRoundEnergy2 = OppEnergy + Stage * 5;


                int damageDeal2 = 0;
                int damageBlock2 = 0;
                int oppDamageDeal2 = 0;
                int oppDamageBlock2 = 0;
                bool dodge2 = false;

                int enemyPoint2 = 0;
                int enemyChoice2 = 0;
                int enemyOppChoice2 = 0;
                bool oppDodge2 = false;

                string lastMove2 = "";
                string oppLastMove2 = "";

                while (true)
                {

                    Console.Clear();
                    Console.Write("Életerő: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(roundHealth2 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség életereje: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(oppRoundHealth2 + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Energia: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(roundEnergy2 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség energiája: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(oppRoundEnergy2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("        _____                   _____\r\n       /     \\                 /     \\\r\n       |     |                 |     |\r\n       \\_____/                 \\_____/\r\n         /|                       |\\\r\n         \\|//                   \\\\|/\r\n          Y/                     \\Y\r\n          |                       |\r\n          |                       |\r\n          A                       A\r\n         / \\                     / \\");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Válaszd ki a mozdulatodat: ");
                    Console.WriteLine();
                    DrawMenu(4, enemy2);
                    Console.WriteLine();
                    Console.WriteLine("===================================================================");
                    Console.WriteLine(lastMove2);
                    Console.WriteLine(oppLastMove2);

                    ConsoleKeyInfo enemySelect = Console.ReadKey(true);
                    switch (enemySelect.Key)
                    {
                        case ConsoleKey.W:
                            enemy2[enemyPoint2, 0] = " ";
                            if (enemyPoint2 == 0)
                            {
                                enemyPoint2 = 3;
                            }
                            else
                            {
                                enemyPoint2--;
                            }
                            break;
                        case ConsoleKey.S:
                            enemy2[enemyPoint2, 0] = " ";
                            if (enemyPoint2 == 3)
                            {
                                enemyPoint2 = 0;
                            }
                            else
                            {
                                enemyPoint2++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            enemyChoice2 = enemyPoint2 + 1;
                            enemyOppChoice2 = random.Next(1, 5);
                            break;
                        case ConsoleKey.P:
                            Room = 0;
                            Boss = true;
                            return;
                        case ConsoleKey.Escape:
                            MainMenu();
                            break;
                    }

                    enemy2[enemyPoint2, 0] = ">";

                    switch (enemyChoice2)
                    {
                        case 1:
                            damageDeal2 = MovePunch(Item1, PunchLVL, roundEnergy2, FlexBonus);
                            roundEnergy2 -= 5;
                            lastMove2 = $"Ütöttél {damageDeal2} pontot";
                            FlexBonus = 0;
                            break;
                        case 2:
                            damageBlock2 = MoveBlock(Item1, BlockLVL, roundEnergy2);
                            roundEnergy2 -= 5;
                            lastMove2 = $"Blokkoltál {damageBlock2}";
                            break;
                        case 3:
                            dodge2 = MoveDodge(Item3, DodgeLVL, roundEnergy2);
                            roundEnergy2 += 5;
                            if (dodge2)
                            {
                                lastMove2 = "Sikiresen kitértél";
                            }
                            else
                            {
                                lastMove2 = "Nem sikerült kitérned";
                            }
                            break;
                        case 4:
                            FlexBonus = MoveFlex(Item4, FlexLVL, roundEnergy2);
                            roundEnergy2 += 5;
                            lastMove2 = $"{FlexBonus} pontot flexeltél";
                            break;
                    }

                    switch (enemyOppChoice2)
                    {
                        case 1:
                            oppDamageDeal2 = MovePunch(0, OppPunchLVL, oppRoundEnergy2, OppFlexBonus);
                            roundEnergy2 -= 5;
                            OppFlexBonus = 0;
                            oppLastMove2 = $"Az ellenfél {oppDamageDeal2} pontot sebzett";
                            break;
                        case 2:
                            oppDamageBlock2 = MoveBlock(0, OppBlockLVL, oppRoundEnergy2);
                            oppRoundEnergy2 -= 5;
                            oppLastMove2 = $"Az ellenfél {oppDamageBlock2} pontot blokkolt";
                            break;
                        case 3:
                            oppDodge2 = MoveDodge(0, OppDodgeLVL, oppRoundEnergy2);
                            oppRoundEnergy2 += 5;
                            if (oppDodge2)
                            {
                                oppLastMove2 = "Az ellenfél sikeresen kitért";
                            }
                            else
                            {
                                oppLastMove2 = "Az ellenfélnek nem sikerült kitérni";
                            }
                            break;
                        case 4:
                            OppFlexBonus = MoveFlex(0, OppFlexLVL, oppRoundEnergy2);
                            oppRoundEnergy2 += 5;
                            oppLastMove2 = $"Az ellenfél {OppFlexBonus} pontot flexelt";
                            break;
                    }

                    damageDeal2 -= oppDamageBlock2;
                    oppDamageDeal2 -= damageBlock2;

                    if (roundEnergy2 < 0)
                    {
                        roundEnergy2 = 0;
                    }

                    if (roundEnergy2 > (Energy + Item6))
                    {
                        roundEnergy2 = Energy + Item6;
                    }

                    if (oppRoundEnergy2 < 0)
                    {
                        oppRoundEnergy2 = 0;
                    }

                    if (oppRoundEnergy2 > OppEnergy)
                    {
                        oppRoundEnergy2 = OppEnergy;
                    }

                    if (damageDeal2 < 0)
                    {
                        damageDeal2 = 0;
                    }

                    if (oppDamageDeal2 < 0)
                    {
                        oppDamageDeal2 = 0;
                    }

                    if (dodge2)
                    {
                        oppDamageDeal2 = 0;
                    }

                    if (oppDodge2)
                    {
                        damageDeal2 = 0;
                    }

                    Console.WriteLine($"{damageDeal2} pontot sebeztél");
                    Console.WriteLine($"{oppDamageDeal2} pontot sebzett az ellenfél");

                    roundHealth2 = roundHealth2 - oppDamageDeal2;
                    oppRoundHealth2 = oppRoundHealth2 - damageDeal2;

                    enemyChoice2 = 0;
                    enemyOppChoice2 = 0;
                    oppDamageDeal2 = 0;
                    damageDeal2 = 0;
                    damageBlock2 = 0;
                    oppDamageBlock2 = 0;

                    if (roundHealth2 <= 0)
                    {
                        Room = 0;
                        return;
                    }
                    else if ((roundHealth2 > 0) && (oppRoundHealth2 <= 0))
                    {
                        Room = 0;
                        Boss = true;
                        return;
                    }
                }
            case 3:
                string[,] enemy3 = { { " ", "Ütés" }, { " ", "Blokk" }, { " ", "Kitérés" }, { " ", "Flex" } };
                enemy3[0, 0] = ">";
                int roundHealth3 = Health + Item5 + HealthLVL * 10;
                int roundEnergy3 = Energy + Item6 + EnergyLVL * 5;
                int oppRoundHealth3 = OppHealth + Stage * 10;
                int oppRoundEnergy3 = OppEnergy + Stage * 5;


                int damageDeal3 = 0;
                int damageBlock3 = 0;
                int oppDamageDeal3 = 0;
                int oppDamageBlock3 = 0;
                bool dodge3 = false;

                int enemyPoint3 = 0;
                int enemyChoice3 = 0;
                int enemyOppChoice3 = 0;
                bool oppDodge3 = false;

                string lastMove3 = "";
                string oppLastMove3 = "";

                while (true)
                {

                    Console.Clear();
                    Console.Write("Életerő: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(roundHealth3 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség életereje: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(oppRoundHealth3 + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Energia: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(roundEnergy3 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség energiája: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(oppRoundEnergy3);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("        _____                   _____\r\n       /     \\                 /     \\\r\n       |     |                 |     |\r\n       \\_____/                 \\_____/\r\n         /|                       |\\\r\n         \\|//                   \\\\|/\r\n          Y/                     \\Y\r\n          |                       |\r\n          |                       |\r\n          A                       A\r\n         / \\                     / \\");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Válaszd ki a mozdulatodat: ");
                    Console.WriteLine();
                    DrawMenu(4, enemy3);
                    Console.WriteLine();
                    Console.WriteLine("===================================================================");
                    Console.WriteLine(lastMove3);
                    Console.WriteLine(oppLastMove3);

                    ConsoleKeyInfo enemySelect = Console.ReadKey(true);
                    switch (enemySelect.Key)
                    {
                        case ConsoleKey.W:
                            enemy3[enemyPoint3, 0] = " ";
                            if (enemyPoint3 == 0)
                            {
                                enemyPoint3 = 3;
                            }
                            else
                            {
                                enemyPoint3--;
                            }
                            break;
                        case ConsoleKey.S:
                            enemy3[enemyPoint3, 0] = " ";
                            if (enemyPoint3 == 3)
                            {
                                enemyPoint3 = 0;
                            }
                            else
                            {
                                enemyPoint3++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            enemyChoice3 = enemyPoint3 + 1;
                            enemyOppChoice3 = random.Next(1, 5);
                            break;
                        case ConsoleKey.P:
                            Room = 0;
                            Boss = true;
                            return;
                        case ConsoleKey.Escape:
                            MainMenu();
                            break;
                    }

                    enemy3[enemyPoint3, 0] = ">";

                    switch (enemyChoice3)
                    {
                        case 1:
                            damageDeal3 = MovePunch(Item1, PunchLVL, roundEnergy3, FlexBonus);
                            roundEnergy3 -= 5;
                            lastMove3 = $"Ütöttél {damageDeal3} pontot";
                            FlexBonus = 0;
                            break;
                        case 2:
                            damageBlock3 = MoveBlock(Item1, BlockLVL, roundEnergy3);
                            roundEnergy3 -= 5;
                            lastMove3 = $"Blokkoltál {damageBlock3}";
                            break;
                        case 3:
                            dodge3 = MoveDodge(Item3, DodgeLVL, roundEnergy3);
                            roundEnergy3 += 5;
                            if (dodge3)
                            {
                                lastMove3 = "Sikiresen kitértél";
                            }
                            else
                            {
                                lastMove3 = "Nem sikerült kitérned";
                            }
                            break;
                        case 4:
                            FlexBonus = MoveFlex(Item4, FlexLVL, roundEnergy3);
                            roundEnergy3 += 5;
                            lastMove3 = $"{FlexBonus} pontot flexeltél";
                            break;
                    }

                    switch (enemyOppChoice3)
                    {
                        case 1:
                            oppDamageDeal3 = MovePunch(0, OppPunchLVL, oppRoundEnergy3, OppFlexBonus);
                            roundEnergy3 -= 5;
                            OppFlexBonus = 0;
                            oppLastMove3 = $"Az ellenfél {oppDamageDeal3} pontot sebzett";
                            break;
                        case 2:
                            oppDamageBlock3 = MoveBlock(0, OppBlockLVL, oppRoundEnergy3);
                            oppRoundEnergy3 -= 5;
                            oppLastMove3 = $"Az ellenfél {oppDamageBlock3} pontot blokkolt";
                            break;
                        case 3:
                            oppDodge3 = MoveDodge(0, OppDodgeLVL, oppRoundEnergy3);
                            oppRoundEnergy3 += 5;
                            if (oppDodge3)
                            {
                                oppLastMove3 = "Az ellenfél sikeresen kitért";
                            }
                            else
                            {
                                oppLastMove3 = "Az ellenfélnek nem sikerült kitérni";
                            }
                            break;
                        case 4:
                            OppFlexBonus = MoveFlex(0, OppFlexLVL, oppRoundEnergy3);
                            oppRoundEnergy3 += 5;
                            oppLastMove3 = $"Az ellenfél {OppFlexBonus} pontot flexelt";
                            break;
                    }

                    damageDeal3 -= oppDamageBlock3;
                    oppDamageDeal3 -= damageBlock3;

                    if (roundEnergy3 < 0)
                    {
                        roundEnergy3 = 0;
                    }

                    if (roundEnergy3 > (Energy + Item6))
                    {
                        roundEnergy3 = Energy + Item6;
                    }

                    if (oppRoundEnergy3 < 0)
                    {
                        oppRoundEnergy3 = 0;
                    }

                    if (oppRoundEnergy3 > OppEnergy)
                    {
                        oppRoundEnergy3 = OppEnergy;
                    }

                    if (damageDeal3 < 0)
                    {
                        damageDeal3 = 0;
                    }

                    if (oppDamageDeal3 < 0)
                    {
                        oppDamageDeal3 = 0;
                    }

                    if (dodge3)
                    {
                        oppDamageDeal3 = 0;
                    }

                    if (oppDodge3)
                    {
                        damageDeal3 = 0;
                    }

                    Console.WriteLine($"{damageDeal3} pontot sebeztél");
                    Console.WriteLine($"{oppDamageDeal3} pontot sebzett az ellenfél");

                    roundHealth3 = roundHealth3 - oppDamageDeal3;
                    oppRoundHealth3 = oppRoundHealth3 - damageDeal3;

                    enemyChoice3 = 0;
                    enemyOppChoice3 = 0;
                    oppDamageDeal3 = 0;
                    damageDeal3 = 0;
                    damageBlock3 = 0;
                    oppDamageBlock3 = 0;

                    if (roundHealth3 <= 0)
                    {
                        Room = 0;
                        return;
                    }
                    else if ((roundHealth3 > 0) && (oppRoundHealth3 <= 0))
                    {
                        Room = 0;
                        Boss = true;
                        return;
                    }
                }
        }

    }

    static int MovePunch(int item, int level, int currentEnergy, int flex)
    {
        int d20 = random.Next(1, 21);
        int damage;
        d20 += item;
        d20 += level;
        d20 += flex;
        if (currentEnergy == 0)
        {
            d20 -= 1;
        }
        if (d20 <= 1)
        {
            damage = 0;
        }
        else if ((d20 >= 2) && (d20 <= 10))
        {
            damage = 10;
        }
        else if ((d20 >= 11) && (d20 <= 19))
        {
            damage = 15;
        }
        else
        {
            damage = 20;
        }
        return damage;
    }

    static int MoveBlock(int item, int level, int currentEnergy)
    {
        int d20 = random.Next(1, 21);
        int block;
        d20 += item;
        d20 += level;
        if (currentEnergy == 0)
        {
            d20 -= 1;
        }
        if (d20 <= 1)
        {
            block = 0;
        }
        else if ((d20 >= 2) && (d20 <= 10))
        {
            block = 10;
        }
        else if ((d20 >= 11) && (d20 <= 19))
        {
            block = 15;
        }
        else
        {
            block = 20;
        }
        return block;
    }

    static bool MoveDodge(int item, int level, int currentEnergy)
    {
        int d20 = random.Next(1, 21);
        bool dodge;
        d20 += item;
        d20 += level;
        if (currentEnergy == 0)
        {
            d20 -= 1;
        }
        if (d20 >= 16)
        {
            dodge = true;
        }
        else
        {
            dodge = false;
        }
        return dodge;
    }

    static int MoveFlex(int item, int level, int currentEnergy)
    {
        int d20 = random.Next(1, 21);
        int flex;
        d20 += item;
        d20 += level;
        if (currentEnergy == 0)
        {
            d20 -= 1;
        }
        if (d20 <= 1)
        {
            flex = 1;
        }
        else if ((d20 >= 2) && (d20 <= 15))
        {
            flex = 2;
        }
        else if ((d20 >= 16) && (d20 <= 19))
        {
            flex = 3;
        }
        else
        {
            flex = 4;
        }
        return flex;
    }

    static void CombatBoss()
    {
        switch (Stage)
        {
            case 0:
                string[,] enemy = { { " ", "Ütés" }, { " ", "Blokk" }, { " ", "Kitérés" }, { " ", "Flex" } };
                enemy[0, 0] = ">";
                int roundHealth = Health + Item5;
                int roundEnergy = Energy + Item6;
                int oppRoundHealth = OppHealth;
                int oppRoundEnergy = OppEnergy;

                OppPunchLVL = Stage+1;
                OppBlockLVL = Stage+1;
                OppDodgeLVL = Stage+1;
                OppFlexLVL = Stage+1;

                int damageDeal = 0;
                int damageBlock = 0;
                int oppDamageDeal = 0;
                int oppDamageBlock = 0;
                bool dodge = false;

                int enemyPoint = 0;
                int enemyChoice = 0;
                int enemyOppChoice = 0;
                bool oppDodge = false;

                string lastMove = "";
                string oppLastMove = "";

                while (true)
                {

                    Console.Clear();
                    Console.Write("Életerő: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(roundHealth + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség életereje: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(oppRoundHealth + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Energia: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(roundEnergy + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség energiája: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(oppRoundEnergy);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("        _____                   _____\r\n       /     \\                 /     \\\r\n       |     |                 |     |\r\n       \\_____/                 \\_____/\r\n         /|                       |\\\r\n         \\|//                   \\\\|/\r\n          Y/                     \\Y\r\n          |                       |\r\n          |                       |\r\n          A                       A\r\n         / \\                     / \\");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Válaszd ki a mozdulatodat: ");
                    Console.WriteLine();
                    DrawMenu(4, enemy);
                    Console.WriteLine();
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("Öld meg a bosszt hogy befejezd a tutorialt.");
                    Console.WriteLine(lastMove);
                    Console.WriteLine(oppLastMove);

                    ConsoleKeyInfo enemySelect = Console.ReadKey(true);
                    switch (enemySelect.Key)
                    {
                        case ConsoleKey.W:
                            enemy[enemyPoint, 0] = " ";
                            if (enemyPoint == 0)
                            {
                                enemyPoint = 3;
                            }
                            else
                            {
                                enemyPoint--;
                            }
                            break;
                        case ConsoleKey.S:
                            enemy[enemyPoint, 0] = " ";
                            if (enemyPoint == 3)
                            {
                                enemyPoint = 0;
                            }
                            else
                            {
                                enemyPoint++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            enemyChoice = enemyPoint + 1;
                            enemyOppChoice = random.Next(1, 5);
                            break;
                        case ConsoleKey.P:
                            Room = 0;
                            MainMenu();
                            return;
                        case ConsoleKey.Escape:
                            MainMenu();
                            break;
                    }

                    enemy[enemyPoint, 0] = ">";

                    switch (enemyChoice)
                    {
                        case 1:
                            damageDeal = MovePunch(Item1, PunchLVL, roundEnergy, FlexBonus);
                            roundEnergy -= 5;
                            lastMove = $"Ütöttél {damageDeal} pontot";
                            FlexBonus = 0;
                            break;
                        case 2:
                            damageBlock = MoveBlock(Item1, BlockLVL, roundEnergy);
                            roundEnergy -= 5;
                            lastMove = $"Blokkoltál {damageBlock}";
                            break;
                        case 3:
                            dodge = MoveDodge(Item3, DodgeLVL, roundEnergy);
                            roundEnergy += 5;
                            if (dodge)
                            {
                                lastMove = "Sikiresen kitértél";
                            }
                            else
                            {
                                lastMove = "Nem sikerült kitérned";
                            }
                            break;
                        case 4:
                            FlexBonus = MoveFlex(Item4, FlexLVL, roundEnergy);
                            roundEnergy += 5;
                            lastMove = $"{FlexBonus} pontot flexeltél";
                            break;
                    }

                    switch (enemyOppChoice)
                    {
                        case 1:
                            oppDamageDeal = MovePunch(0, OppPunchLVL, oppRoundEnergy, OppFlexBonus);
                            roundEnergy -= 5;
                            OppFlexBonus = 0;
                            oppLastMove = $"Az ellenfél {oppDamageDeal} pontot sebzett";
                            break;
                        case 2:
                            oppDamageBlock = MoveBlock(0, OppBlockLVL, oppRoundEnergy);
                            oppRoundEnergy -= 5;
                            oppLastMove = $"Az ellenfél {oppDamageBlock} pontot blokkolt";
                            break;
                        case 3:
                            oppDodge = MoveDodge(0, OppDodgeLVL, oppRoundEnergy);
                            oppRoundEnergy += 5;
                            if (oppDodge)
                            {
                                oppLastMove = "Az ellenfél sikeresen kitért";
                            }
                            else
                            {
                                oppLastMove = "Az ellenfélnek nem sikerült kitérni";
                            }
                            break;
                        case 4:
                            OppFlexBonus = MoveFlex(0, OppFlexLVL, oppRoundEnergy);
                            oppRoundEnergy += 5;
                            oppLastMove = $"Az ellenfél {OppFlexBonus} pontot flexelt";
                            break;
                    }

                    damageDeal -= oppDamageBlock;
                    oppDamageDeal -= damageBlock;

                    if (roundEnergy < 0)
                    {
                        roundEnergy = 0;
                    }

                    if (roundEnergy > (Energy + Item6))
                    {
                        roundEnergy = Energy + Item6;
                    }

                    if (oppRoundEnergy < 0)
                    {
                        oppRoundEnergy = 0;
                    }

                    if (oppRoundEnergy > OppEnergy)
                    {
                        oppRoundEnergy = OppEnergy;
                    }

                    if (damageDeal < 0)
                    {
                        damageDeal = 0;
                    }

                    if (oppDamageDeal < 0)
                    {
                        oppDamageDeal = 0;
                    }

                    if (dodge)
                    {
                        oppDamageDeal = 0;
                    }

                    if (oppDodge)
                    {
                        damageDeal = 0;
                    }

                    Console.WriteLine($"{damageDeal} pontot sebeztél");
                    Console.WriteLine($"{oppDamageDeal} pontot sebzett az ellenfél");

                    roundHealth = roundHealth - oppDamageDeal;
                    oppRoundHealth = oppRoundHealth - damageDeal;

                    enemyChoice = 0;
                    enemyOppChoice = 0;
                    oppDamageDeal = 0;
                    damageDeal = 0;
                    damageBlock = 0;
                    oppDamageBlock = 0;

                    if (roundHealth <= 0)
                    {
                        Room = 0;
                        return;
                    }
                    else if ((roundHealth > 0) && (oppRoundHealth <= 0))
                    {
                        Room = 0;
                        MainMenu();
                        return;
                    }
                }
            case 1:
                string[,] enemy1 = { { " ", "Ütés" }, { " ", "Blokk" }, { " ", "Kitérés" }, { " ", "Flex" } };
                enemy1[0, 0] = ">";
                int roundHealth1 = Health + Item5 + HealthLVL * 10;
                int roundEnergy1 = Energy + Item6 + EnergyLVL * 5;
                int oppRoundHealth1 = OppHealth + Stage * 10;
                int oppRoundEnergy1 = OppEnergy + Stage * 5;

                OppPunchLVL = Stage + 1;
                OppBlockLVL = Stage + 1;
                OppDodgeLVL = Stage + 1;
                OppFlexLVL = Stage + 1;

                int damageDeal1 = 0;
                int damageBlock1 = 0;
                int oppDamageDeal1 = 0;
                int oppDamageBlock1 = 0;
                bool dodge1 = false;

                int enemyPoint1 = 0;
                int enemyChoice1 = 0;
                int enemyOppChoice1 = 0;
                bool oppDodge1 = false;

                string lastMove1 = "";
                string oppLastMove1 = "";

                while (true)
                {

                    Console.Clear();
                    Console.Write("Életerő: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(roundHealth1 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség életereje: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(oppRoundHealth1 + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Energia: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(roundEnergy1 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség energiája: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(oppRoundEnergy1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("        _____                   _____\r\n       /     \\                 /     \\\r\n       |     |                 |     |\r\n       \\_____/                 \\_____/\r\n         /|                       |\\\r\n         \\|//                   \\\\|/\r\n          Y/                     \\Y\r\n          |                       |\r\n          |                       |\r\n          A                       A\r\n         / \\                     / \\");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Válaszd ki a mozdulatodat: ");
                    Console.WriteLine();
                    DrawMenu(4, enemy1);
                    Console.WriteLine();
                    Console.WriteLine("===================================================================");
                    Console.WriteLine(lastMove1);
                    Console.WriteLine(oppLastMove1);

                    ConsoleKeyInfo enemySelect = Console.ReadKey(true);
                    switch (enemySelect.Key)
                    {
                        case ConsoleKey.W:
                            enemy1[enemyPoint1, 0] = " ";
                            if (enemyPoint1 == 0)
                            {
                                enemyPoint1 = 3;
                            }
                            else
                            {
                                enemyPoint1--;
                            }
                            break;
                        case ConsoleKey.S:
                            enemy1[enemyPoint1, 0] = " ";
                            if (enemyPoint1 == 3)
                            {
                                enemyPoint1 = 0;
                            }
                            else
                            {
                                enemyPoint1++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            enemyChoice1 = enemyPoint1 + 1;
                            enemyOppChoice1 = random.Next(1, 5);
                            break;
                        case ConsoleKey.P:
                            Room = 0;
                            Stage = 2;
                            Cutscene2();
                            return;
                        case ConsoleKey.Escape:
                            MainMenu();
                            break;
                    }

                    enemy1[enemyPoint1, 0] = ">";

                    switch (enemyChoice1)
                    {
                        case 1:
                            damageDeal1 = MovePunch(Item1, PunchLVL, roundEnergy1, FlexBonus);
                            roundEnergy1 -= 5;
                            lastMove1 = $"Ütöttél {damageDeal1} pontot";
                            FlexBonus = 0;
                            break;
                        case 2:
                            damageBlock1 = MoveBlock(Item1, BlockLVL, roundEnergy1);
                            roundEnergy1 -= 5;
                            lastMove1 = $"Blokkoltál {damageBlock1}";
                            break;
                        case 3:
                            dodge1 = MoveDodge(Item3, DodgeLVL, roundEnergy1);
                            roundEnergy1 += 5;
                            if (dodge1)
                            {
                                lastMove1 = "Sikiresen kitértél";
                            }
                            else
                            {
                                lastMove1 = "Nem sikerült kitérned";
                            }
                            break;
                        case 4:
                            FlexBonus = MoveFlex(Item4, FlexLVL, roundEnergy1);
                            roundEnergy1 += 5;
                            lastMove1 = $"{FlexBonus} pontot flexeltél";
                            break;
                    }

                    switch (enemyOppChoice1)
                    {
                        case 1:
                            oppDamageDeal1 = MovePunch(0, OppPunchLVL, oppRoundEnergy1, OppFlexBonus);
                            roundEnergy1 -= 5;
                            OppFlexBonus = 0;
                            oppLastMove1 = $"Az ellenfél {oppDamageDeal1} pontot sebzett";
                            break;
                        case 2:
                            oppDamageBlock1 = MoveBlock(0, OppBlockLVL, oppRoundEnergy1);
                            oppRoundEnergy1 -= 5;
                            oppLastMove1 = $"Az ellenfél {oppDamageBlock1} pontot blokkolt";
                            break;
                        case 3:
                            oppDodge1 = MoveDodge(0, OppDodgeLVL, oppRoundEnergy1);
                            oppRoundEnergy1 += 5;
                            if (oppDodge1)
                            {
                                oppLastMove1 = "Az ellenfél sikeresen kitért";
                            }
                            else
                            {
                                oppLastMove1 = "Az ellenfélnek nem sikerült kitérni";
                            }
                            break;
                        case 4:
                            OppFlexBonus = MoveFlex(0, OppFlexLVL, oppRoundEnergy1);
                            oppRoundEnergy1 += 5;
                            oppLastMove1 = $"Az ellenfél {OppFlexBonus} pontot flexelt";
                            break;
                    }

                    damageDeal1 -= oppDamageBlock1;
                    oppDamageDeal1 -= damageBlock1;

                    if (roundEnergy1 < 0)
                    {
                        roundEnergy1 = 0;
                    }

                    if (roundEnergy1 > (Energy + Item6))
                    {
                        roundEnergy1 = Energy + Item6;
                    }

                    if (oppRoundEnergy1 < 0)
                    {
                        oppRoundEnergy1 = 0;
                    }

                    if (oppRoundEnergy1 > OppEnergy)
                    {
                        oppRoundEnergy1 = OppEnergy;
                    }

                    if (damageDeal1 < 0)
                    {
                        damageDeal1 = 0;
                    }

                    if (oppDamageDeal1 < 0)
                    {
                        oppDamageDeal1 = 0;
                    }

                    if (dodge1)
                    {
                        oppDamageDeal1 = 0;
                    }

                    if (oppDodge1)
                    {
                        damageDeal1 = 0;
                    }

                    Console.WriteLine($"{damageDeal1} pontot sebeztél");
                    Console.WriteLine($"{oppDamageDeal1} pontot sebzett az ellenfél");

                    roundHealth1 = roundHealth1 - oppDamageDeal1;
                    oppRoundHealth1 = oppRoundHealth1 - damageDeal1;

                    enemyChoice1 = 0;
                    enemyOppChoice1 = 0;
                    oppDamageDeal1 = 0;
                    damageDeal1 = 0;
                    damageBlock1 = 0;
                    oppDamageBlock1 = 0;

                    if (roundHealth1 <= 0)
                    {
                        Room = 0;
                        return;
                    }
                    else if ((roundHealth1 > 0) && (oppRoundHealth1 <= 0))
                    {
                        Room = 0;
                        Stage = 2;
                        Cutscene2();
                        return;
                    }
                }
            case 2:
                string[,] enemy2 = { { " ", "Ütés" }, { " ", "Blokk" }, { " ", "Kitérés" }, { " ", "Flex" } };
                enemy2[0, 0] = ">";
                int roundHealth2 = Health + Item5 + HealthLVL * 10;
                int roundEnergy2 = Energy + Item6 + EnergyLVL * 5;
                int oppRoundHealth2 = OppHealth + Stage * 10;
                int oppRoundEnergy2 = OppEnergy + Stage * 5;

                OppPunchLVL = Stage + 1;
                OppBlockLVL = Stage + 1;
                OppDodgeLVL = Stage + 1;
                OppFlexLVL = Stage + 1;

                int damageDeal2 = 0;
                int damageBlock2 = 0;
                int oppDamageDeal2 = 0;
                int oppDamageBlock2 = 0;
                bool dodge2 = false;

                int enemyPoint2 = 0;
                int enemyChoice2 = 0;
                int enemyOppChoice2 = 0;
                bool oppDodge2 = false;

                string lastMove2 = "";
                string oppLastMove2 = "";

                while (true)
                {

                    Console.Clear();
                    Console.Write("Életerő: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(roundHealth2 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség életereje: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(oppRoundHealth2 + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Energia: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(roundEnergy2 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség energiája: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(oppRoundEnergy2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("        _____                   _____\r\n       /     \\                 /     \\\r\n       |     |                 |     |\r\n       \\_____/                 \\_____/\r\n         /|                       |\\\r\n         \\|//                   \\\\|/\r\n          Y/                     \\Y\r\n          |                       |\r\n          |                       |\r\n          A                       A\r\n         / \\                     / \\");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Válaszd ki a mozdulatodat: ");
                    Console.WriteLine();
                    DrawMenu(4, enemy2);
                    Console.WriteLine();
                    Console.WriteLine("===================================================================");
                    Console.WriteLine(lastMove2);
                    Console.WriteLine(oppLastMove2);

                    ConsoleKeyInfo enemySelect = Console.ReadKey(true);
                    switch (enemySelect.Key)
                    {
                        case ConsoleKey.W:
                            enemy2[enemyPoint2, 0] = " ";
                            if (enemyPoint2 == 0)
                            {
                                enemyPoint2 = 3;
                            }
                            else
                            {
                                enemyPoint2--;
                            }
                            break;
                        case ConsoleKey.S:
                            enemy2[enemyPoint2, 0] = " ";
                            if (enemyPoint2 == 3)
                            {
                                enemyPoint2 = 0;
                            }
                            else
                            {
                                enemyPoint2++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            enemyChoice2 = enemyPoint2 + 1;
                            enemyOppChoice2 = random.Next(1, 5);
                            break;
                        case ConsoleKey.P:
                            Room = 0;
                            Stage = 3;
                            Cutscene3();
                            return;
                        case ConsoleKey.Escape:
                            MainMenu();
                            break;
                    }

                    enemy2[enemyPoint2, 0] = ">";

                    switch (enemyChoice2)
                    {
                        case 1:
                            damageDeal2 = MovePunch(Item1, PunchLVL, roundEnergy2, FlexBonus);
                            roundEnergy2 -= 5;
                            lastMove2 = $"Ütöttél {damageDeal2} pontot";
                            FlexBonus = 0;
                            break;
                        case 2:
                            damageBlock2 = MoveBlock(Item1, BlockLVL, roundEnergy2);
                            roundEnergy2 -= 5;
                            lastMove2 = $"Blokkoltál {damageBlock2}";
                            break;
                        case 3:
                            dodge2 = MoveDodge(Item3, DodgeLVL, roundEnergy2);
                            roundEnergy2 += 5;
                            if (dodge2)
                            {
                                lastMove2 = "Sikiresen kitértél";
                            }
                            else
                            {
                                lastMove2 = "Nem sikerült kitérned";
                            }
                            break;
                        case 4:
                            FlexBonus = MoveFlex(Item4, FlexLVL, roundEnergy2);
                            roundEnergy2 += 5;
                            lastMove2 = $"{FlexBonus} pontot flexeltél";
                            break;
                    }

                    switch (enemyOppChoice2)
                    {
                        case 1:
                            oppDamageDeal2 = MovePunch(0, OppPunchLVL, oppRoundEnergy2, OppFlexBonus);
                            roundEnergy2 -= 5;
                            OppFlexBonus = 0;
                            oppLastMove2 = $"Az ellenfél {oppDamageDeal2} pontot sebzett";
                            break;
                        case 2:
                            oppDamageBlock2 = MoveBlock(0, OppBlockLVL, oppRoundEnergy2);
                            oppRoundEnergy2 -= 5;
                            oppLastMove2 = $"Az ellenfél {oppDamageBlock2} pontot blokkolt";
                            break;
                        case 3:
                            oppDodge2 = MoveDodge(0, OppDodgeLVL, oppRoundEnergy2);
                            oppRoundEnergy2 += 5;
                            if (oppDodge2)
                            {
                                oppLastMove2 = "Az ellenfél sikeresen kitért";
                            }
                            else
                            {
                                oppLastMove2 = "Az ellenfélnek nem sikerült kitérni";
                            }
                            break;
                        case 4:
                            OppFlexBonus = MoveFlex(0, OppFlexLVL, oppRoundEnergy2);
                            oppRoundEnergy2 += 5;
                            oppLastMove2 = $"Az ellenfél {OppFlexBonus} pontot flexelt";
                            break;
                    }

                    damageDeal2 -= oppDamageBlock2;
                    oppDamageDeal2 -= damageBlock2;

                    if (roundEnergy2 < 0)
                    {
                        roundEnergy2 = 0;
                    }

                    if (roundEnergy2 > (Energy + Item6))
                    {
                        roundEnergy2 = Energy + Item6;
                    }

                    if (oppRoundEnergy2 < 0)
                    {
                        oppRoundEnergy2 = 0;
                    }

                    if (oppRoundEnergy2 > OppEnergy)
                    {
                        oppRoundEnergy2 = OppEnergy;
                    }

                    if (damageDeal2 < 0)
                    {
                        damageDeal2 = 0;
                    }

                    if (oppDamageDeal2 < 0)
                    {
                        oppDamageDeal2 = 0;
                    }

                    if (dodge2)
                    {
                        oppDamageDeal2 = 0;
                    }

                    if (oppDodge2)
                    {
                        damageDeal2 = 0;
                    }

                    Console.WriteLine($"{damageDeal2} pontot sebeztél");
                    Console.WriteLine($"{oppDamageDeal2} pontot sebzett az ellenfél");

                    roundHealth2 = roundHealth2 - oppDamageDeal2;
                    oppRoundHealth2 = oppRoundHealth2 - damageDeal2;

                    enemyChoice2 = 0;
                    enemyOppChoice2 = 0;
                    oppDamageDeal2 = 0;
                    damageDeal2 = 0;
                    damageBlock2 = 0;
                    oppDamageBlock2 = 0;

                    if (roundHealth2 <= 0)
                    {
                        Room = 0;
                        return;
                    }
                    else if ((roundHealth2 > 0) && (oppRoundHealth2 <= 0))
                    {
                        Room = 0;
                        Stage = 3;
                        Cutscene3();
                        return;
                    }
                }
            case 3:
                string[,] enemy3 = { { " ", "Ütés" }, { " ", "Blokk" }, { " ", "Kitérés" }, { " ", "Flex" } };
                enemy3[0, 0] = ">";
                int roundHealth3 = Health + Item5 + HealthLVL * 10;
                int roundEnergy3 = Energy + Item6 + EnergyLVL * 5;
                int oppRoundHealth3 = OppHealth + Stage * 10;
                int oppRoundEnergy3 = OppEnergy + Stage * 5;

                OppPunchLVL = Stage + 1;
                OppBlockLVL = Stage + 1;
                OppDodgeLVL = Stage + 1;
                OppFlexLVL = Stage + 1;


                int damageDeal3 = 0;
                int damageBlock3 = 0;
                int oppDamageDeal3 = 0;
                int oppDamageBlock3 = 0;
                bool dodge3 = false;

                int enemyPoint3 = 0;
                int enemyChoice3 = 0;
                int enemyOppChoice3 = 0;
                bool oppDodge3 = false;

                string lastMove3 = "";
                string oppLastMove3 = "";

                while (true)
                {

                    Console.Clear();
                    Console.Write("Életerő: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(roundHealth3 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség életereje: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(oppRoundHealth3 + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Energia: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(roundEnergy3 + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Ellenség energiája: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(oppRoundEnergy3);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("===================================================================");
                    Console.WriteLine("        _____                   _____\r\n       /     \\                 /     \\\r\n       |     |                 |     |\r\n       \\_____/                 \\_____/\r\n         /|                       |\\\r\n         \\|//                   \\\\|/\r\n          Y/                     \\Y\r\n          |                       |\r\n          |                       |\r\n          A                       A\r\n         / \\                     / \\");
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Válaszd ki a mozdulatodat: ");
                    Console.WriteLine();
                    DrawMenu(4, enemy3);
                    Console.WriteLine();
                    Console.WriteLine("===================================================================");
                    Console.WriteLine(lastMove3);
                    Console.WriteLine(oppLastMove3);

                    ConsoleKeyInfo enemySelect = Console.ReadKey(true);
                    switch (enemySelect.Key)
                    {
                        case ConsoleKey.W:
                            enemy3[enemyPoint3, 0] = " ";
                            if (enemyPoint3 == 0)
                            {
                                enemyPoint3 = 3;
                            }
                            else
                            {
                                enemyPoint3--;
                            }
                            break;
                        case ConsoleKey.S:
                            enemy3[enemyPoint3, 0] = " ";
                            if (enemyPoint3 == 3)
                            {
                                enemyPoint3 = 0;
                            }
                            else
                            {
                                enemyPoint3++;
                            }
                            break;
                        case ConsoleKey.Enter:
                            enemyChoice3 = enemyPoint3 + 1;
                            enemyOppChoice3 = random.Next(1, 5);
                            break;
                        case ConsoleKey.P:
                            Room = 0;
                            Stage = 4;
                            Cutscene4();
                            return;
                        case ConsoleKey.Escape:
                            MainMenu();
                            break;
                    }

                    enemy3[enemyPoint3, 0] = ">";

                    switch (enemyChoice3)
                    {
                        case 1:
                            damageDeal3 = MovePunch(Item1, PunchLVL, roundEnergy3, FlexBonus);
                            roundEnergy3 -= 5;
                            lastMove3 = $"Ütöttél {damageDeal3} pontot";
                            FlexBonus = 0;
                            break;
                        case 2:
                            damageBlock3 = MoveBlock(Item1, BlockLVL, roundEnergy3);
                            roundEnergy3 -= 5;
                            lastMove3 = $"Blokkoltál {damageBlock3}";
                            break;
                        case 3:
                            dodge3 = MoveDodge(Item3, DodgeLVL, roundEnergy3);
                            roundEnergy3 += 5;
                            if (dodge3)
                            {
                                lastMove3 = "Sikiresen kitértél";
                            }
                            else
                            {
                                lastMove3 = "Nem sikerült kitérned";
                            }
                            break;
                        case 4:
                            FlexBonus = MoveFlex(Item4, FlexLVL, roundEnergy3);
                            roundEnergy3 += 5;
                            lastMove3 = $"{FlexBonus} pontot flexeltél";
                            break;
                    }

                    switch (enemyOppChoice3)
                    {
                        case 1:
                            oppDamageDeal3 = MovePunch(0, OppPunchLVL, oppRoundEnergy3, OppFlexBonus);
                            roundEnergy3 -= 5;
                            OppFlexBonus = 0;
                            oppLastMove3 = $"Az ellenfél {oppDamageDeal3} pontot sebzett";
                            break;
                        case 2:
                            oppDamageBlock3 = MoveBlock(0, OppBlockLVL, oppRoundEnergy3);
                            oppRoundEnergy3 -= 5;
                            oppLastMove3 = $"Az ellenfél {oppDamageBlock3} pontot blokkolt";
                            break;
                        case 3:
                            oppDodge3 = MoveDodge(0, OppDodgeLVL, oppRoundEnergy3);
                            oppRoundEnergy3 += 5;
                            if (oppDodge3)
                            {
                                oppLastMove3 = "Az ellenfél sikeresen kitért";
                            }
                            else
                            {
                                oppLastMove3 = "Az ellenfélnek nem sikerült kitérni";
                            }
                            break;
                        case 4:
                            OppFlexBonus = MoveFlex(0, OppFlexLVL, oppRoundEnergy3);
                            oppRoundEnergy3 += 5;
                            oppLastMove3 = $"Az ellenfél {OppFlexBonus} pontot flexelt";
                            break;
                    }

                    damageDeal3 -= oppDamageBlock3;
                    oppDamageDeal3 -= damageBlock3;

                    if (roundEnergy3 < 0)
                    {
                        roundEnergy3 = 0;
                    }

                    if (roundEnergy3 > (Energy + Item6))
                    {
                        roundEnergy3 = Energy + Item6;
                    }

                    if (oppRoundEnergy3 < 0)
                    {
                        oppRoundEnergy3 = 0;
                    }

                    if (oppRoundEnergy3 > OppEnergy)
                    {
                        oppRoundEnergy3 = OppEnergy;
                    }

                    if (damageDeal3 < 0)
                    {
                        damageDeal3 = 0;
                    }

                    if (oppDamageDeal3 < 0)
                    {
                        oppDamageDeal3 = 0;
                    }

                    if (dodge3)
                    {
                        oppDamageDeal3 = 0;
                    }

                    if (oppDodge3)
                    {
                        damageDeal3 = 0;
                    }

                    Console.WriteLine($"{damageDeal3} pontot sebeztél");
                    Console.WriteLine($"{oppDamageDeal3} pontot sebzett az ellenfél");

                    roundHealth3 = roundHealth3 - oppDamageDeal3;
                    oppRoundHealth3 = oppRoundHealth3 - damageDeal3;

                    enemyChoice3 = 0;
                    enemyOppChoice3 = 0;
                    oppDamageDeal3 = 0;
                    damageDeal3 = 0;
                    damageBlock3 = 0;
                    oppDamageBlock3 = 0;

                    if (roundHealth3 <= 0)
                    {
                        Room = 0;
                        return;
                    }
                    else if ((roundHealth3 > 0) && (oppRoundHealth3 <= 0))
                    {
                        Room = 0;
                        Stage = 4;
                        Cutscene4();
                        return;
                    }
                }
        }
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