/*
Задача 54: Задайте двумерный массив. Напишите программу, 
которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4

В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2

Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер 
строки с наименьшей суммой элементов: 1 строка

Задача 58: Задайте две матрицы. Напишите программу, 
которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18

Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, 
которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)



Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/



void task1()
{
    int[,] arr = default_2_arr();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1) - 1; j++)
        {
            for (int k = 0; k < arr.GetLength(1) - 1; k++)
            {
                if (arr[i, k] < arr[i, k + 1])
                {
                    int b = arr[i, k];
                    arr[i, k] = arr[i, k + 1];
                    arr[i, k + 1] = b;
                }
            }
        }
    }
    write_2_arr(arr);
}

void task2()
{
    int[,] arr = default_2_arr();
    int min_Sum = 0, min_Row = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            sum += arr[i, j];
        }
        if (i == 0)
        {
            min_Sum = sum;
        }
        else if (sum < min_Sum)
        {
            min_Sum = sum;
            min_Row = i;
        }
    }
    Console.WriteLine($"Строка с минимальной суммой элементов - {min_Row + 1}");
}

void task3()
{
    Console.WriteLine("Введите количество строк массива");
    int SIZE1 = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов массива");
    int SIZE2 = int.Parse(Console.ReadLine());
    int[,] arr1 = new int[SIZE1, SIZE2],
        arr2 = new int[SIZE1, SIZE2],
        ans_Arr = new int[SIZE1, SIZE2];
    f_2_arr(arr1, 0, 10);
    write_2_arr(arr1);
    f_2_arr(arr2, 0, 10);
    write_2_arr(arr2);
    for (int i = 0; i < SIZE1; i++)
    {
        for (int j = 0; j < SIZE2; j++)
        {
            ans_Arr[i, j] = arr1[i, j] + arr2[i, j];
        }
    }
    Console.WriteLine("\nСумма массивов:");
    write_2_arr(ans_Arr);
}

void task4()
{
    int[,,] arr = new int[2, 2, 2];
    int[] arr_numbers = new int[100];
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < 2; j++)
        {
            for (int k = 0; k < 2; k++)
            {
                int rnd = new Random().Next(100);
                while (true)
                    if (arr_numbers[rnd] == 1)
                    {
                        rnd = new Random().Next(100);
                    }
                    else
                    {
                        arr_numbers[rnd] = 1;
                        break;
                    }
                
                arr_numbers[i * 3 + j * 2 + k] = rnd;
                arr[i, j, k] = arr_numbers[i * 3 + j * 2 + k];
                Console.WriteLine($"{arr[i, j, k]} ({i},{j},{k})");
            }
        }
    }
}

void task5()
{
    int[,] arr = new int[4, 4];
    bool direction = true, direction_x = true;

    int i1 = 0, i2 = 0, value = 1;
    while (value <= 16)
    {
        switch (direction, direction_x)
        {
            case (true, true):
                {
                    arr[i1, i2++] = value++;
                    if ((i2 == 4) || arr[i1, i2] > 0)
                    {
                        direction_x = false;
                        i1++;
                        i2--;
                    }
                    break;
                }
            case (true, false):
                {
                    arr[i1++, i2] = value++;
                    if (i1 == 4 || arr[i1, i2] > 0)
                    {
                        direction = false;
                        direction_x = true;
                        i2--;
                        i1--;
                    }
                    break;
                }
            case (false, true):
                {
                    arr[i1, i2--] = value++;
                    if (i2 == -1 || arr[i1, i2] > 0)
                    { 
                        direction_x = false;
                        i1--;
                        i2++; 
                    }
                    break;
                }
            case (false, false):
                {
                    arr[i1--, i2] = value++;
                    if (i1 == -1 || arr[i1, i2] > 0)
                    {
                        direction = true;
                        direction_x = true;
                        i2++;
                        i1++;
                    }
                    break;
                }
        } 
    }
    write_2_arr(arr);
}


while (true)
{
    Console.WriteLine();
    Console.Write("Введите номер задачи: ");
    int num = int.Parse(Console.ReadLine());
    Console.Clear();
    switch (num)
    {
        case 1:
            {
                task1();
                break;
            }
        case 2:
            {
                task2();
                break;
            }
        case 3:
            {
                task3();
                break;
            }
        case 4:
            {
                task4();
                break;
            }
        case 5:
            {
                task5();
                break;
            }
    }    
}

int new_value()
{
    Console.WriteLine("Введите число");
    return int.Parse(Console.ReadLine());
}

void f_arr(int[] arr, int min, int max) // запись массива
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = new Random().Next(min,max);
    }
}

void write_arr(int[] arr) // вывод массива
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($"{arr[i]} ");
    }
    Console.WriteLine();
}

void f_2_arr(int[,] arr, int min, int max) // запись двумерного массива
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = new Random().Next(min, max);
        }
    }
}   

void write_2_arr(int[,] arr) // вывод двумерного массива
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i,j]}\t");
        }               
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] default_2_arr()
{
    Console.WriteLine("Введите количество строк массива");
    int SIZE1 = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов массива");
    int SIZE2 = int.Parse(Console.ReadLine());
    int[,] arr = new int[SIZE1, SIZE2];
    f_2_arr(arr, 0, 10);
    write_2_arr(arr);
    return arr;
}