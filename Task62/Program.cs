// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

//Возвращает спирально заполненный массив размерностью х на у
int [,] GetSpiralArray(int x, int y)
{
    int[,] result = new int[x, y];
    int startX = 0;
    int endX = x - 1;
    int startY = 0;
    int endY = y - 1;
    int number = 1;
    while (true)
    {
        for (int i = startY; i <= endY; i++)
        {
            result[startX, i] = number;
            number++;
            if (number > x * y) return result;
        }
        startX++;
        for (int i = startX; i <= endX; i++)
        {
            result[i, endY] = number;
            number++;
            if (number > x * y) return result;
        }
        endY--;
        for (int i = endY; i >= startY; i--)
        {
            result[endX, i] = number;
            number++;
            if (number > x * y) return result;
        }
        endX--;
        for (int i = endX; i >= startX; i--)
        {
            result[i, startY] = number;
            number++;
            if (number > x * y) return result;
        }
        startY++;
    }
}

void Print2DArray (int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i,j].ToString().PadLeft(2, '0'),4}");
        }
        Console.WriteLine();
    }
}

int[,] spiral = GetSpiralArray(4, 4);
Print2DArray(spiral);