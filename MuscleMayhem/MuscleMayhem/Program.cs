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