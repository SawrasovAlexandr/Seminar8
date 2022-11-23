// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int[,] GetRandom2DArray(int row, int column, int minValue, int maxValue)
{
    int[,] result = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j],3}");
        }
        Console.WriteLine();
    }
}

void SortRow2DArray(int[,] array, int row)
{
    int temp = 0;
    bool sortOk = false;
    while (!sortOk)
    {
        sortOk = true;
        for (int i = 0; i < array.GetLength(1) - 1; i++)
        {  
            if (array[row, i] < array[row, i + 1])
            {
                temp = array[row, i];
                array[row, i] = array[row, i + 1];
                array[row, i + 1] = temp;
                sortOk = false;
            }
        }
    }
}

int[,] arr = GetRandom2DArray(10, 25, 0, 99);
Print2DArray(arr);
for (int i = 0; i < arr.GetLength(0); i++)
{
    SortRow2DArray(arr, i);
}
Console.WriteLine();
Print2DArray(arr);