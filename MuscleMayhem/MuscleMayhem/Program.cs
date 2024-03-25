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

    static void ClassSelect()
    {
        Console.Clear();
        string[,] charclass = new string[,]{ { " ", "Nehéz öklű" }, { " ", "Vas bőrű" }, { " ", "Gyors lábú" }, { " ", "Izompacsirta"} };
        int classPoint = 0;
        int classChoice = 0;
        charclass[classPoint, 0] = ">";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============================================================");
            Console.WriteLine("Válassz egy karakter osztályt:");
            Console.WriteLine();

            DrawMenu(4, charclass);

            Console.WriteLine("==============================================================");

            ConsoleKeyInfo classSelect = Console.ReadKey(true);
            switch (classSelect.Key)
            {
                case ConsoleKey.W:
                    charclass[classPoint, 0] = " ";
                    if (classPoint == 0)
                    {
                        classPoint = 3;
                    }
                    else
                    {
                        classPoint--;
                    }
                    break;
                case ConsoleKey.S:
                    charclass[classPoint, 0] = " ";
                    if (classPoint == 3)
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
                    FlexLVL++; ;
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
            Console.WriteLine("Ez a tutorial szoba.\nJobb oldalt van a bolt, ahol itemeket tudsz venni.\nBal oldalt van az edzőtér, ahol harcolhatsz egy ellenféllel.\nFent van a folyosó a következő szobához, ahol egy bossal harcolatsz.\nAhhoz, hogy harcolhass a bossal, lekell győznöd előbb az ellenfelet.");
            if (Boss)
            {
                Console.WriteLine("Az ellenfél legyőzésével megnyílt a bosshoz");
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
        Console.Clear();
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
                    Console.ForegroundColor= ConsoleColor.White;
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
                while (true)
                {
                }
            case 2:
                while (true)
                {
                }
            case 3:
                while (true)
                {
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