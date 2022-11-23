// Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
//            которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Пример:
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


//Создает ряд из всех двузначных чисел идущих по возрастанию
int[] GetBiDigitRow()
{
    int[]result = new int[90];
    for (int i = 0; i < result.Length; i++) result[i] = i + 10;
    return result;
}

//Перемешивает массив
void ShuffleArray(int[] array)
{
    int temp = 0;
    for (int i = 0; i < array.Length; i++)
    {
        int rnd = new Random().Next(0, array.Length);
        temp = array[i];
        array[i] = array[rnd];
        array[rnd] = temp;
    }
}

//Заполняет трехмерный массив, беря значения из указанного одномерного
void Fill3DArray(int[,,] array, int[] data)
{
    int l = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = data[l];
                l++;
            }
        }
    }
}

//Вывод трехмерного массива, по принципу изображенному в примере(строки 5-8)
// void Print3DArray(int[,,]array)
// {
//     for (int i = 0; i < array.GetLength(2); i++)
//     {
//         for (int j = 0; j < array.GetLength(0); j++)
//         {
//             for (int k = 0; k < array.GetLength(1); k++)
//             {
//                 Console.Write($"{array[j, k, i]}({j}, {k}, {i}) ");
//             }
//             Console.WriteLine();
//         }
//         Console.WriteLine();
//     }
// } 

//На мой взгляд не особо наглядный вариант, а потому предложу свой вариант вывода:
//Трехмерный массив будет выводится в виде строки, элементами которой будут двумерные массивы
//В случае с четырехмерным это была бы матрица из двумерных массивов
//И конечно же с соответствующей индексацией

//Возвращает значение максимального по модулю элемента массива
int MaxAbs3DArray(int[,,] array)
{
    int max = array[0, 0, 0];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (Math.Abs(max) < Math.Abs(array[i, j, k])) max = array[i, j, k];
            }
        }
    }
    return max;
}

//Возвращает количество знаков в числе
int CountDigit(int number)
{
    int count = 0;
    if (number < 0) count++;
    while (Math.Abs(number) > 0)
    {
        number /= 10;
        count++;
    }
    if (count == 0) count = 1;
    return count;
}

//Если индексы двумерного массивва мы называли номерами строк и столбцов, то пусть третьи индексы будут 
//номерами страниц (с таблицами из строк и столбцов)

//Вывод страницы трехмерного массива с указанным индексом
void PrintPage3DArray(int[,,]array, int index)
{
    int columnWidth = CountDigit(MaxAbs3DArray(array))+1;
    int start = Console.CursorLeft;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(2); j++)
        {
            for (int k = 0; k < columnWidth - CountDigit(array[index, i, j]); k++)
            {
                Console.Write(" ");
            }
            Console.Write($"{array[index, i, j]} ");
        }
        Console.SetCursorPosition(start, Console.CursorTop + 1);
    }
    Console.SetCursorPosition(start + (columnWidth + 1) * array.GetLength(2), Console.CursorTop - 1);
}

//Вывод страницы трехмерного массива с указанным индексом, с выводом индексов элементов массива
void PrintIndexedPage3DArray(int[,,]array, int index)
{
    int columnWidth = CountDigit(MaxAbs3DArray(array))+1;
    int firstColumnWidth = CountDigit(array.GetLength(1) - 1) + 1;
    int start = Console.CursorLeft;
    Console.SetCursorPosition(start + firstColumnWidth, Console.CursorTop);
    Console.Write("|");
    for (int i = 0; i < (columnWidth + 1) * array.GetLength(2) - (CountDigit(index) + 1); i++) Console.Write("_");
    Console.Write($"{index}|");
    Console.SetCursorPosition(start, Console.CursorTop + 1);
    for (int i = 0; i < firstColumnWidth; i++) Console.Write("_");
    Console.Write("|");
    for (int i = 0; i < array.GetLength(2); i++)
    {
        for (int j = 0; j < columnWidth - CountDigit(i); j++) Console.Write("_");
        Console.Write($"{i}|");
    }
    Console.SetCursorPosition(start, Console.CursorTop + 1);
    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < firstColumnWidth - CountDigit(i); j++) Console.Write("_");
        Console.Write($"{i}|");
        Console.SetCursorPosition(start, Console.CursorTop + 1);
    }
    Console.SetCursorPosition(start + firstColumnWidth + 1, Console.CursorTop - array.GetLength(1));
}

//Вывод трехмерного массива с выводом индексов элементов массива
void Print3DArray(int[,,] array)
{
    Console.Clear();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        PrintIndexedPage3DArray(array, i);
        PrintPage3DArray(array, i);
        Console.Write("\t");
        
        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - array.GetLength(1) - 1);
    }
    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + array.GetLength(1) + 2);
}



//Всего двузначных чисел 90 и если использовать их все, наиболее "кубически" будет выглядеть массив 3х5х6
int[,,] arr3D = new int[3, 5, 6];
int[] biDigit = GetBiDigitRow();
ShuffleArray(biDigit);
Fill3DArray(arr3D, biDigit);
Print3DArray(arr3D);

