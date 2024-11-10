using MuscleMayhem_Lib;
using System;
Random random = new Random();
Console.Title = "MuscleMayhem";
Player player = new Player();
Game game = new Game();
Shop shop = new Shop();

//Display
void DrawMenu(string[,] menu)
{
    for (int i = 0; i < menu.GetLength(0); i++)
    {
        Console.WriteLine($"{menu[i, 0]}\t{menu[i, 1]}");
    }
}

void DrawMap(char[,] map, int height, int width)
{
    for (int i = 0; i < height; i++)
    {   
        Console.Write("\t");
        Console.Write('|');
        for (int j = 0; j < width; j++)
        {
            if (map[i, j] == '■')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" {map[i, j]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (map[i, j] == player.Character)
            {
                Console.ForegroundColor = player.Color;
                Console.Write($" {map[i, j]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write($" {map[i, j]}");
            }
        }
        Console.Write(" |");
        Console.WriteLine();
    }
}

//Menus
void MainMenu()
{
    Menu menu = new Menu();
    Console.Clear();
    menu.MenuPoint = 0;
    menu.MenuChoice = 0;
    menu.MainMenu[menu.MenuPoint, 0] = ">";
    while (true)
    {
        Console.Clear();
        Console.WriteLine("| __   __ __    __  ___   ____ __    _____\t\r\n| ||\\ /|| ||    || //    //    ||    ||\t\t\r\n| ||\\V/|| ||    || \\\\__  ||    ||    ||==\t    ,--.--._\r\n| || V || ||    ||    \\\\ ||    ||    ||\t\t  -\" _, \\___)\r\n| ||   ||  \\\\__//   __// \\\\___ ||___ ||___\t     / _/____)\r\n| __   __   ____  __    __ __   __ _____ __   __     \\//(____)\r\n| ||\\ /||   //\\\\   \\\\  //  ||   || ||    ||\\ /||  -\\     (__)\r\n| ||\\V/||  //  \\\\   \\\\//   ||===|| ||==  ||\\V/||    `-----\"\r\n| || V || ||====||   ||    ||   || ||    || V || \r\n| ||   || ||    ||   ||    ||   || ||___ ||   || \r\n|\t\t\t\t\t\t\n============================|Menü|============================");

        DrawMenu(menu.MainMenu);

        Console.WriteLine("==============================================================\n\nKészítette: Vörrös Ádám, Farkas Gergely ©2024");

        ConsoleKeyInfo Select = Console.ReadKey(true);
        switch (Select.Key)
        {
            case ConsoleKey.W:
                menu.MainMenu[menu.MenuPoint, 0] = " ";
                if (menu.MenuPoint == 0)
                {
                    menu.MenuPoint = 3;
                }
                else
                {
                    menu.MenuPoint--;
                }
                break;
            case ConsoleKey.S:
                menu.MainMenu[menu.MenuPoint, 0] = " ";
                if (menu.MenuPoint == 3)
                {
                    menu.MenuPoint = 0;
                }
                else
                {
                    menu.MenuPoint++;
                }
                break;
            case ConsoleKey.Enter:
                menu.MenuChoice = menu.MenuPoint + 1;
                break;

        }

        menu.MainMenu[menu.MenuPoint, 0] = ">";

        switch (menu.MenuChoice)
        {
            case 1:
                Cutscenes(1);
                break;
            case 2:
                Cutscenes(0);
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

void ClassSelect()
{
    Menu menu = new Menu();
    menu.MenuPoint = 0;
    menu.MenuChoice = 0;
    menu.ClassMenu[menu.MenuPoint, 0] = ">";

    while (true)
    {
        Console.Clear();
        Console.WriteLine("==============================================================");
        Console.WriteLine("Válassz egy karakter osztályt:");
        Console.WriteLine();

        DrawMenu(menu.ClassMenu);

        Console.WriteLine("==============================================================");

        ConsoleKeyInfo Select = Console.ReadKey(true);
        switch (Select.Key)
        {
            case ConsoleKey.W:
                menu.ClassMenu[menu.MenuPoint, 0] = " ";
                if (menu.MenuPoint == 0)
                {
                    menu.MenuPoint = 5;
                }
                else
                {
                    menu.MenuPoint--;
                }
                break;
            case ConsoleKey.S:
                menu.ClassMenu[menu.MenuPoint, 0] = " ";
                if (menu.MenuPoint == 5)
                {
                    menu.MenuPoint = 0;
                }
                else
                {
                    menu.MenuPoint++;
                }
                break;
            case ConsoleKey.Enter:
                menu.MenuChoice = menu.MenuPoint + 1;
                break;
            case ConsoleKey.Escape:
                MainMenu();
                break;
        }

        menu.ClassMenu[menu.MenuPoint, 0] = ">";

        switch (menu.MenuChoice)
        {
            case 1:
                player.PunchLVL++;
                game.Stage = 1;
                player.Color = ConsoleColor.Blue;
                CharacterSelect();
                break;
            case 2:
                player.BlockLVL++;
                game.Stage = 1;
                player.Color = ConsoleColor.Green;
                CharacterSelect();
                break;
            case 3:
                player.DodgeLVL++;
                game.Stage = 1;
                player.Color = ConsoleColor.Cyan;
                CharacterSelect();
                break;
            case 4:
                player.FlexLVL++;
                game.Stage = 1;
                player.Color = ConsoleColor.DarkMagenta;
                CharacterSelect();
                break;
            case 5:
                player.HealthLVL++;
                game.Stage = 1;
                player.Color = ConsoleColor.Red;
                CharacterSelect();
                break;
            case 6:
                player.EnergyLVL++;
                game.Stage = 1;
                player.Color = ConsoleColor.Yellow;
                CharacterSelect();
                break;
        }

    }
}

void CharacterSelect()
{
    Console.Clear();
    string character = "  ";
    int error = 0;
    while (character.Length != 1)
    {
        
        Console.Clear();
        Console.WriteLine("==============================================================");
        if (error == 1)
        {
            Console.WriteLine("A játékos ikon csak egy karakterből állhat.");
        }
        else if (error == 2)
        {
            Console.WriteLine("A játékos ikon így nem lessz látható, kérem adjon meg \nmásikat.");
        }
        Console.Write("Kérem adjon meg egy játékos ikont (billentyűzet karakter): ");
        character = Console.ReadLine();
        if (character.Length > 1)
        {
            error = 1;
        }
        if (character == " ")
        {
            error = 2;
            character = "  ";
        }
        Console.WriteLine("==============================================================");
    }
    player.Character = char.Parse(character);
    StartGame();
}

void ShowControls()
{
    Console.Clear();
    Console.WriteLine("============================|Irányítás|============================\nMozgás: WASD\nInterakció, kiválasztás: Enter\nFőmenü: Esc\nNyomj egy billentyűt a visszalépéshez a menübe...\n===================================================================");
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("...P: instakill...");
    Console.ForegroundColor = ConsoleColor.White;
    Console.ReadKey();
    MainMenu();
}

void ShopMenu()
{
    Menu menu = new Menu();
    menu.MenuPoint = 0;
    menu.MenuChoice = 0;
    menu.ShopMenu[menu.MenuPoint, 0] = ">";
    bool shopExit = false;

    while (true)
    {

        Console.Clear();
        Console.WriteLine("===================================================================");
        if (game.HasItem)
        {
            Console.WriteLine($"Jelenlegi tárgy: {menu.ShopMenu[game.CurrentItem, 1]}");
            Console.WriteLine();
            Console.WriteLine("Már van egy tárgyad, többet nem bír a szervezeted.\n-------------------------------------------------------------------");
        }
        else
        {
            Console.WriteLine("Jelenleg nincs aktív itemed.");
            Console.WriteLine();
            Console.WriteLine("Mivel nincs pénzed, az ilyedt kasszás megengedi neked, hogy \nelvigyélegy terméket ingyen.\n-------------------------------------------------------------------");
        }

        DrawMenu(menu.ShopMenu);

        if (game.Stage == 0)
        {
            Console.WriteLine("-------------------------------------------------------------------\nEz a bolt. Itt tudsz tárgyakat venni, amik bónuszt adnak a statiszt-\nikáidhoz. A szervezeted viszont egyszerre csak egy tárgyat bír, ami-\nnek a hatása a következő szobáig tart.");
        }
        Console.WriteLine("===================================================================");

        ConsoleKeyInfo Select = Console.ReadKey(true);
        switch (Select.Key)
        {
            case ConsoleKey.W:
                menu.ShopMenu[menu.MenuPoint, 0] = " ";
                if (menu.MenuPoint == 0)
                {
                    menu.MenuPoint = 6;
                }
                else
                {
                    menu.MenuPoint--;
                }
                break;
            case ConsoleKey.S:
                menu.ShopMenu[menu.MenuPoint, 0] = " ";
                if (menu.MenuPoint == 6)
                {
                    menu.MenuPoint = 0;
                }
                else
                {
                    menu.MenuPoint++;
                }
                break;
            case ConsoleKey.Enter:
                if (!game.HasItem)
                {
                    menu.MenuChoice = menu.MenuPoint + 1;
                }
                if (menu.MenuPoint == 6)
                {
                    shopExit = true;
                }
                break;
            case ConsoleKey.Escape:
                MainMenu();
                break;
        }

        menu.ShopMenu[menu.MenuPoint, 0] = ">";

        switch (menu.MenuChoice)
        {
            case 1:
                if (!game.HasItem)
                {
                    shop.Item1 = 1;
                    game.HasItem = true;
                    game.CurrentItem = 0;
                }
                break;
            case 2:
                if (!game.HasItem)
                {
                    shop.Item2 = 1;
                    game.HasItem = true;
                    game.CurrentItem = 1;
                }
                break;
            case 3:
                if (!game.HasItem)
                {
                    shop.Item3 = 1;
                    game.HasItem = true;
                    game.CurrentItem = 2;
                }
                break;
            case 4:
                if (!game.HasItem)
                {
                    shop.Item4 = 1;
                    game.HasItem = true;
                    game.CurrentItem = 3;
                }
                break;
            case 5:
                if (!game.HasItem)
                {
                    shop.Item5 = 10;
                    game.HasItem = true;
                    game.CurrentItem = 4;
                }
                break;
            case 6:
                if (!game.HasItem)
                {
                    shop.Item6 = 5;
                    game.HasItem = true;
                    game.CurrentItem = 5;
                }
                break;
        }
        if (shopExit)
        {
            game.Room = 0;
            return;
        }
    }
}

void CombatEnemy()
{
    Menu menu = new Menu();
    Enemy enemy = new Enemy();

    menu.CombatMenu[0, 0] = ">";
    int roundHealth = player.Health + shop.Item5;
    int roundEnergy = player.Energy + shop.Item6;
    int enemyRoundHealth = enemy.Health + (game.Stage * 10);
    int enemyRoundEnergy = enemy.Energy + (game.Stage * 5);

    if (game.Boss)
    {
        enemy.PunchLVL = game.Stage + 1;
        enemy.BlockLVL = game.Stage + 1;
        enemy.DodgeLVL = game.Stage + 1;
        enemy.FlexLVL = game.Stage + 1;
    }
    else
    {
        enemy.PunchLVL = game.Stage;
        enemy.BlockLVL = game.Stage;
        enemy.DodgeLVL = game.Stage;
        enemy.FlexLVL = game.Stage;
    }

    int damageDeal = 0;
    int damageBlock = 0;
    int enemyDamageDeal = 0;
    int enemyDamageBlock = 0;
    player.DodgeResult = false;

    menu.MenuPoint = 0;
    menu.MenuChoice = 0;
    int enemyChoice = 0;
    enemy.DodgeResult = false;

    string lastMove = "";
    string enemyLastMove = "";
    bool movePicked = false;

    while (true)
    {
        Console.Clear();
        Console.Write("Életerő: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(roundHealth + "\t");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Ellenség életereje: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(enemyRoundHealth + "\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Energia: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(roundEnergy + "\t");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Ellenség energiája: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(enemyRoundEnergy);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("===================================================================\n        _____                   _____\r\n       /     \\                 /     \\\r\n       |     |                 |     |\r\n       \\_____/                 \\_____/\r\n         /|                       |\\\r\n         \\|//                   \\\\|/\r\n          Y/                     \\Y\r\n          |                       |\r\n          |                       |\r\n          A                       A\r\n         / \\                     / \\\n-------------------------------------------------------------------\nVálaszd ki a mozdulatodat: \n");
        
        if (game.Stage == 0)
        {
            DrawMenu(menu.CombatTutorial);
        }
        else
        {
            DrawMenu(menu.CombatMenu);
        }
        Console.WriteLine("-------------------------------------------------------------------\nVálassz egy mozdulatot.");
        if (game.Stage == 0 && game.Boss && game.BossCheck)
        {
            Console.WriteLine("Győzd le a boss-t a tutorial befejezéséhez!");
        }
        else if (game.Stage == 0 && !game.BossCheck)
        {
            Console.WriteLine("Győzd le az ellenfelet a mozdulatok használatával! Miután legyőzöd \nezt az ellenfelet, harcolhatsz a szint boss-ával.");
        }
        Console.WriteLine("===================================================================");
        
        if ((lastMove != "") && (enemyLastMove != ""))
        {
            Console.WriteLine(lastMove);
            Console.WriteLine(enemyLastMove);
        }

        ConsoleKeyInfo Select = Console.ReadKey(true);
        switch (Select.Key)
        {
            case ConsoleKey.W:
                if (game.Stage == 0)
                {
                    menu.CombatTutorial[menu.MenuPoint, 0] = " ";
                }
                else
                {
                    menu.CombatMenu[menu.MenuPoint, 0] = " ";
                }

                if (menu.MenuPoint == 0)
                {
                    menu.MenuPoint = 3;
                }
                else
                {
                    menu.MenuPoint--;
                }

                break;
            case ConsoleKey.S:
                if (game.Stage == 0)
                {
                    menu.CombatTutorial[menu.MenuPoint, 0] = " ";
                }
                else
                {
                    menu.CombatMenu[menu.MenuPoint, 0] = " ";
                }

                if (menu.MenuPoint == 3)
                {
                    menu.MenuPoint = 0;
                }
                else
                {
                    menu.MenuPoint++;
                }

                break;
            case ConsoleKey.Enter:
                menu.MenuChoice = menu.MenuPoint + 1;
                enemyChoice = random.Next(1, 5);
                movePicked = true;
                break;
            case ConsoleKey.P:
                enemyRoundHealth = 0;
                break;
            case ConsoleKey.Escape:
                MainMenu();
                break;
        }

        if (game.Stage == 0)
        {
            menu.CombatTutorial[menu.MenuPoint, 0] = ">";
        }
        else
        {
            menu.CombatMenu[menu.MenuPoint, 0] = ">";
        }

        switch (menu.MenuChoice)
        {
            case 1:
                damageDeal = MovePunch(shop.Item1, player.PunchLVL, roundEnergy, player.FlexBonus);
                roundEnergy -= 5;
                lastMove = $"Ütöttél {damageDeal} pontot";
                player.FlexBonus = 0;
                break;
            case 2:
                damageBlock = MoveBlock(shop.Item2, player.BlockLVL, roundEnergy);
                roundEnergy -= 5;
                lastMove = $"Blokkoltál {damageBlock}";
                break;
            case 3:
                player.DodgeResult = MoveDodge(shop.Item3, player.DodgeLVL, roundEnergy);
                roundEnergy += 5;
                if (player.DodgeResult)
                {
                    lastMove = "Sikiresen kitértél";
                }
                else
                {
                    lastMove = "Nem sikerült kitérned";
                }
                break;
            case 4:
                player.FlexBonus = MoveFlex(shop.Item4, player.FlexLVL, roundEnergy);
                roundEnergy += 5;
                lastMove = $"{player.FlexBonus} pontot flexeltél";
                break;
        }

        switch (enemyChoice)
        {
            case 1:
                enemyDamageDeal = MovePunch(0, enemy.PunchLVL, enemyRoundEnergy, enemy.FlexBonus);
                roundEnergy -= 5;
                enemy.FlexBonus = 0;
                enemyLastMove = $"Az ellenfél {enemyDamageDeal} pontot sebzett";
                break;
            case 2:
                enemyDamageBlock = MoveBlock(0, enemy.BlockLVL, enemyRoundEnergy);
                enemyRoundEnergy -= 5;
                enemyLastMove = $"Az ellenfél {enemyDamageBlock} pontot blokkolt";
                break;
            case 3:
                enemy.DodgeResult = MoveDodge(0, enemy.DodgeLVL, enemyRoundEnergy);
                enemyRoundEnergy += 5;
                if (enemy.DodgeResult)
                {
                    enemyLastMove = "Az ellenfél sikeresen kitért";
                }
                else
                {
                    enemyLastMove = "Az ellenfélnek nem sikerült kitérni";
                }
                break;
            case 4:
                enemy.FlexBonus = MoveFlex(0, enemy.FlexLVL, enemyRoundEnergy);
                enemyRoundEnergy += 5;
                enemyLastMove = $"Az ellenfél {enemy.FlexBonus} pontot flexelt";
                break;
        }

        damageDeal -= enemyDamageBlock;
        enemyDamageDeal -= damageBlock;

        if (roundEnergy < 0)
        {
            roundEnergy = 0;
        }

        if (roundEnergy > (player.Energy + shop.Item6))
        {
            roundEnergy = player.Energy + shop.Item6;
        }

        if (enemyRoundEnergy < 0)
        {
            enemyRoundEnergy = 0;
        }

        if (enemyRoundEnergy > enemy.Energy)
        {
            enemyRoundEnergy = enemy.Energy;
        }

        if (damageDeal < 0)
        {
            damageDeal = 0;
        }

        if (enemyDamageDeal < 0)
        {
            enemyDamageDeal = 0;
        }

        if (player.DodgeResult)
        {
            enemyDamageDeal = 0;
        }

        if (enemy.DodgeResult)
        {
            damageDeal = 0;
        }

        if (movePicked)
        {
            Console.WriteLine($"{damageDeal} pontot sebeztél");
            Console.WriteLine($"{enemyDamageDeal} pontot sebzett az ellenfél");
        }

        roundHealth = roundHealth - enemyDamageDeal;
        enemyRoundHealth = enemyRoundHealth - damageDeal;

        menu.MenuChoice = 0;
        enemyChoice = 0;
        enemyDamageDeal = 0;
        damageDeal = 0;
        damageBlock = 0;
        enemyDamageBlock = 0;

        if (roundHealth <= 0)
        {
            Console.Clear();
            Console.WriteLine("==============================================================\nMeghaltál. \nVissza leszel rakva a pályára, és újrapróbálhatod.\n==============================================================");
            Console.ReadKey();
            game.Room = 0;
            return;
        }
        else if ((roundHealth > 0) && (enemyRoundHealth <= 0))
        {
            if (game.Boss)
            {
                if (game.BossCheck)
                {
                    if (game.Stage == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("==============================================================\nGratulálok, sikeresen kivitted a tutorialt! \nMost már készen állsz bosszút állni az edzőterem tulaján!.\n==============================================================");
                        Console.ReadKey();
                        MainMenu();
                    }
                    else
                    {
                        game.Room = 0;
                        game.Stage++;
                        Cutscenes(game.Stage);
                    }
                }
                else
                {
                    game.Room = 0;
                }
            }
            else if (!game.Boss)
            {
                game.Room = 0;
                game.Boss = true;
            }

            return;
        }
    }
}

void LVLUp()
{
    Menu menu = new Menu();
    Console.Clear();
    int LVLPoint = 0;
    int LVLChoice = 0;
    menu.LevelUpMenu[LVLPoint, 0] = ">";

    while (true)
    {
        Console.Clear();
        Console.WriteLine("==============================================================");
        Console.WriteLine("Szintet léptél! Fejlessz egy képességet:");
        Console.WriteLine();

        DrawMenu(menu.LevelUpMenu);

        Console.WriteLine("==============================================================");

        ConsoleKeyInfo Select = Console.ReadKey(true);
        switch (Select.Key)
        {
            case ConsoleKey.W:
                menu.LevelUpMenu[LVLPoint, 0] = " ";
                if (LVLPoint == 0)
                {
                    LVLPoint = 5;
                }
                else
                {
                    LVLPoint--;
                }
                break;
            case ConsoleKey.S:
                menu.LevelUpMenu[LVLPoint, 0] = " ";
                if (LVLPoint == 5)
                {
                    LVLPoint = 0;
                }
                else
                {
                    LVLPoint++;
                }
                break;
            case ConsoleKey.Enter:
                LVLChoice = LVLPoint + 1;
                break;
            case ConsoleKey.Escape:
                MainMenu();
                break;
        }

        menu.LevelUpMenu[LVLPoint, 0] = ">";

        switch (LVLChoice)
        {
            case 1:
                player.PunchLVL++;
                StartGame();
                break;
            case 2:
                player.BlockLVL++;
                StartGame();
                break;
            case 3:
                player.DodgeLVL++;
                StartGame();
                break;
            case 4:
                player.FlexLVL++;
                StartGame();
                break;
            case 5:
                player.HealthLVL++;
                StartGame();
                break;
            case 6:
                player.EnergyLVL++;
                StartGame();
                break;
        }

    }
}

//Levels
void StartGame()
{
    Console.Clear();
    game.HasItem = false;
    game.Boss = false;
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
                map[i, j] = ' ';
            }
        }
    }

    map[currentY, currentX] = player.Character;

    game.Room = 0;

    while (true)
    {
        Console.Clear();
        Console.WriteLine($"Szoba: {game.Stage}\n=======================================");
        DrawMap(map, width, height);
        Console.WriteLine("=======================================");
        if (game.Boss)
        {
            Console.WriteLine("Az ellenfél legyőzésével megnyílt az \nút a bosshoz.");
        }
        if(game.Boss && game.Stage == 0)
        {
            Console.WriteLine("---------------------------------------");
        }
        if (game.Stage == 0)
        {
            Console.WriteLine("Ez a tutorial:\n -Bal oldalt van a bolt.\n -Fent harcolhatsz a szint bosszával.\n -Bal oldalt van a szint ellensége.\n---------------------------------------\nMenj oda a zöld négyzethez, \nés nyomj egy entert hogy bemenj.\n=======================================");
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
                        map[currentY, currentX] = ' ';
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
                        map[currentY, currentX] = ' ';
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
                        map[currentY, currentX] = ' ';
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
                        map[currentY, currentX] = ' ';
                    }
                    currentX++;
                }
                break;
            case ConsoleKey.Enter:
                if (currentY == 0 && (currentX == 4 || currentX == 5) && game.Boss)
                {
                    game.Room = 1;
                }
                else if (currentX == 0 && (currentY == 4 || currentY == 5))
                {
                    game.Room = 2;
                }
                else if (currentX == 9 && (currentY == 4 || currentY == 5))
                {
                    game.Room = 3;
                }
                break;
            case ConsoleKey.Escape:
                MainMenu();
                break;
        }

        map[currentY, currentX] = player.Character;

        DrawMap(map, width, height);

        switch (game.Room)
        {
            case 1:
                if (game.Boss)
                {
                    game.BossCheck = true;
                    CombatEnemy();
                }
                break;
            case 2:
                ShopMenu();
                break;
            case 3:
                game.BossCheck = false;
                CombatEnemy();
                break;
        }
    }
}

//Moves
int MovePunch(int item, int level, int currentEnergy, int flex)
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

int MoveBlock(int item, int level, int currentEnergy)
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

bool MoveDodge(int item, int level, int currentEnergy)
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

int MoveFlex(int item, int level, int currentEnergy)
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

//Cutsceness
void Cutscenes(int n)
{
    switch (n)
    {
        case 0:
            Console.Clear();
            Console.WriteLine("==============================================================\nA tutorial szobában egy könnyített szinten fogsz játszani. \nMinden képernyő alján található magyarázó szöveg, ami segít \nmegérteni a játék működését.\nNyomj egy billentyűt a folytatáshoz...\n==============================================================");
            Console.ReadKey();
            player.Color = ConsoleColor.DarkGray;
            player.Character = '♦';
            game.Stage = 0;
            StartGame();
            break;
        case 1:
            Console.Clear();
            Console.WriteLine("==============================================================\n \t _______\t  |         |          _______     |\r\n \t |  |  |\t  |G   Y   M|\t       |  |  |     |\r\n \t |--+--|          |_________|          |--+--|     |\r\n \t |__|__|\t\t\t       |__|__|     |\r\n \t\t\t    _______\t\t\t   |\r\n \t\t\t   |   |   |\t\t___|__     |\r\n      _____ ___|___\t   |   |   |\t\t_|___|___  |\r\n_____/     \\_|_____________|___|___|___________________|___|_ \r\n     |     |\r\n     \\_____/\r\n        |\n--------------------------------------------------------------\nTegnap erősebben edzettél mint ebmer valaha edzett, viszont m-\negirigyelt az edzőterem tulaja, és visszavonta a tagságodat.\nIlyen bűn személyes bosszút követel. Megmutatod neki, hogy m-\nilyen erős vagy, és nem hagyod hogy bárki az utadba álljon.\nNyomj egy billentyűt a folytatáshoz...\n==============================================================");
            Console.ReadKey();
            ClassSelect();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("==============================================================\nA biztonsági őr elintézése után tovább mész leverni\na menedzsert.\nNyomj egy billentyűt a folytatáshoz...\n==============================================================");
            Console.ReadKey();
            LVLUp();
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("==============================================================\nA menedzsert is elverted, idelye legyőzni a tulajt.\nNyomj egy billentyűt a folytatáshoz...\n==============================================================");
            Console.ReadKey();
            LVLUp();
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("==============================================================\n         _______          |         |          _______     |\r\n         |  |  |          |G   Y   M|          |  |  |     |\r\n         |--+--|          |_________|          |--+--|     |\r\n         |__|__|                               |__|__|     |\r\n                            _______                        |\r\n                           |   |   |            ___|__     |\r\n      _____ ___|___        |   |   |            _|___|___  |\r\n_____/ * * \\_|_____________|___|___|___________________|___|_\r\n     |  U  |\r\n    \\\\_____//\r\n     \\  |  /\n--------------------------------------------------------------\nGratulálunk! Legyőzted a tulajt, és szégyenében odaadta neked\naz egész edzőtermet! Mostantól te vagy a tulaj!\nNyomj egy billentyűt a folytatáshoz...\n==============================================================");
            Console.ReadKey();
            MainMenu();
            break;
    }
}


MainMenu();