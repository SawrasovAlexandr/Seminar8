// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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
//Возвращает произведение матриц
int[,] MultiMatrix(int[,] matrixA, int[,] matrixB)
{
    int[,] mult = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    for (int i = 0; i < matrixA.GetLength(0); i++)
    {
        for (int j = 0; j < matrixB.GetLength(1); j++)
        {
            for (int k = 0; k < matrixA.GetLength(1); k++)
            {
                mult[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }
    return mult;
}

int[,] arrA = GetRandom2DArray(5, 3, 1, 9);
int[,] arrB = GetRandom2DArray(3, 4, 1, 9);
Print2DArray(arrA);
Console.WriteLine("X");
Print2DArray(arrB);
if (arrA.GetLength(1) == arrB.GetLength(0))
{
    Console.WriteLine("=");
    Print2DArray(MultiMatrix(arrA, arrB));
}
else Console.WriteLine("Данные матрицы не могут быть перемножены");