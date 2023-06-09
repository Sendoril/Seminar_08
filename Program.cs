//Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива

//Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

//Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

//Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента

//Напишите программу, которая заполнит спирально массив 4 на 4

using System;
using System.Threading;
Console.WriteLine("Привет пользователь!");
Thread.Sleep(1000);
string word = "Выбери что ты хочешь сделать:\nЗадача №1: Упорядочивание по убыванию элементов каждой строки двумерного массива.\nЗадача №2: Найти строку с наименьшей суммой элементов\nЗадача №3: Произведение двух матриц\nЗадача №4 Вывод массива с индексами каждого элемента\nЗадача №5 Вывод массива, заполненного спирально\nВаш выбор? \n";

foreach (char letter in word)
{
    Console.Write(letter);
    Thread.Sleep(25);
}

int chose;
chose = Convert.ToInt32(Console.ReadLine());
switch (chose)
{
    case 1:

        Console.Write("Введите размерность m массива: ");
        int m = Convert.ToInt32(Console.ReadLine());

        int n = m;
        int[,] randomArray = new int[m, n];

        void mas(int m, int n)
        {
            int i, j;
            Random rand = new Random();
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    randomArray[i, j] = rand.Next(1, 9);
                }
            }
        }

        void printm(int[,] array)
        {
            int i, j;
            for (i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine();
                for (j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }

        }

        mas(m, n);
        Console.WriteLine("\nИсходный массив: ");
        printm(randomArray);


        void uporyadok(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(1) - 1; k++)
                    {
                        if (array[i, k] < array[i, k + 1])
                        {
                            int temp = array[i, k + 1];
                            array[i, k + 1] = array[i, k];
                            array[i, k] = temp;
                        }
                    }
                }
            }
        }

        uporyadok(randomArray);
        Console.WriteLine("\nОтсортированный массив: ");
        printm(randomArray);
        break;
    case 2:
        Console.Write("Введите размерность m массива: ");
        int m2 = Convert.ToInt32(Console.ReadLine());

        int n2 = m2;
        int[,] randomArray2 = new int[m2, n2];

        void mas2(int m2, int n2)
        {
            int i, j;
            Random rand = new Random();
            for (i = 0; i < m2; i++)
            {
                for (j = 0; j < n2; j++)
                {
                    randomArray2[i, j] = rand.Next(1, 9);
                }
            }
        }

        void printm2(int[,] array)
        {
            int i, j;
            for (i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine();
                for (j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        mas2(m2, n2);
        Console.WriteLine("\nИсходный массив: ");
        printm2(randomArray2);


        int SumLine(int[,] array, int i)
        {
            int sum = array[i, 0];
            for (int j = 1; j < array.GetLength(1); j++)
            {
                sum += array[i, j];
            }
            return sum;
        }

        int minSum = 1;
        int sum = SumLine(randomArray2, 0);
        for (int i2 = 1; i2 < randomArray2.GetLength(0); i2++)
        {
            if (sum > SumLine(randomArray2, i2))
            {
                sum = SumLine(randomArray2, i2);
                minSum = i2 + 1;
            }
        }
        Console.WriteLine($"\nСтрока c наименьшей суммой элементов: {minSum}");
        break;
    case 3:
        Console.WriteLine("Введите размеры матриц и диапазон случайных значений:");
        int m3 = InputNumbers("Введите число строк 1-й матрицы: ");
        int n3 = InputNumbers("Введите число столбцов 1-й матрицы (и строк 2-й): ");
        int p3 = InputNumbers("Введите число столбцов 2-й матрицы: ");

        int[,] firstMatrix = new int[m3, n3];
        CreateArray(firstMatrix);
        Console.WriteLine($"Первая матрица:");
        WriteArray(firstMatrix);

        int[,] secondMatrix = new int[n3, p3];
        CreateArray(secondMatrix);
        Console.WriteLine($"Вторая матрица:");
        WriteArray(secondMatrix);

        int[,] resultMatrix = new int[m3, p3];

        MultiplyMatrix(firstMatrix, secondMatrix, resultMatrix);
        Console.WriteLine($"Произведение первой и второй матриц:");
        WriteArray(resultMatrix);

        void MultiplyMatrix(int[,] firstMatrix, int[,] secondMatrix, int[,] resultMatrix)
        {
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int k = 0; k < firstMatrix.GetLength(1); k++)
                    {
                        sum += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                    resultMatrix[i, j] = sum;
                }
            }
        }

        int InputNumbers(string input)
        {
            Console.Write(input);
            int output = Convert.ToInt32(Console.ReadLine());
            return output;
        }

        void CreateArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = new Random().Next(0, 20);
                }
            }
        }

        void WriteArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        break;
    case 4:
        void InputMatrix(int[,,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(2); k++)
                        matrix[i, j, k] = RandomValue(matrix, i, j, k);
                }
            }
        }

        static int RandomValue(int[,,] matrix, int i, int j, int k)
        {
            int value = default;
            bool flag = true;
            while (flag)
            {
                bool noStop = true;
                value = new Random().Next(10, 100);
                for (int x = 0; x < matrix.GetLength(0) && noStop; x++)
                {
                    for (int y = 0; y < matrix.GetLength(1) && noStop; y++)
                    {
                        for (int z = 0; z < matrix.GetLength(2) && noStop; z++)
                        {
                            if (matrix[x, y, z] == value)
                                noStop = false;
                            if (x == i && y == j && z == k)
                                flag = false;
                        }
                    }
                }
            }
            return value;
        }

        void PrintMatrix(int[,,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(2); k++)
                        Console.Write($"{matrix[i, j, k],1}({i},{j},{k}) \t");
                    Console.WriteLine();
                }
            }
        }

        int[,,] matrix = new int[2, 2, 2];
        InputMatrix(matrix);
        PrintMatrix(matrix);
        break;
    case 5:
        int sq = 4;
        int[,] sqareMatrix = new int[sq, sq];

        int temp = 1;
        int i = 0;
        int j = 0;

        while (temp <= sqareMatrix.GetLength(0) * sqareMatrix.GetLength(1))
        {
            sqareMatrix[i, j] = temp;
            temp++;
            if (i <= j + 1 && i + j < sqareMatrix.GetLength(1) - 1)
                j++;
            else if (i < j && i + j >= sqareMatrix.GetLength(0) - 1)
                i++;
            else if (i >= j && i + j > sqareMatrix.GetLength(1) - 1)
                j--;
            else
                i--;
        }

        WriteArray5(sqareMatrix);

        void WriteArray5(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] / 10 <= 0)
                        Console.Write($" {array[i, j]} ");

                    else Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        break;
    default:
        Console.WriteLine("Выберете варианты 1-5");
        break;
}