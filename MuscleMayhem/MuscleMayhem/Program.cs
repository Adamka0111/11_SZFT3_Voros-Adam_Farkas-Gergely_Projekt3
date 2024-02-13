using System;

class Program
{
    static void Main(string[] args)
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