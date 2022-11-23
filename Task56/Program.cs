// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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
            Console.Write($"{array[i, j],4}");
        }
        Console.WriteLine();
    }
}

//возвращает сумму элементов строки с указанным индексом двумерного массива
int GetSumRow2DArray(int[,] array, int row)
{
    int sum = 0;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        sum += array[row, i];
    }
    return sum;
}

int[,] arr = GetRandom2DArray(10, 15, -99, 99);
Print2DArray(arr);
int min = GetSumRow2DArray(arr, 0);
int indexMin = 0;
for (int i = 1; i < arr.GetLength(0); i++)
{
    if (GetSumRow2DArray(arr, i) < min)
    {
        min = GetSumRow2DArray(arr, i);
        indexMin = i;
    }
}
Console.WriteLine($"Индекс строки с наименьшей суммой элементов: {indexMin}");
//Если нужен порядковый номер строки, то необходимо в выводе к indexMin прибавить единицу