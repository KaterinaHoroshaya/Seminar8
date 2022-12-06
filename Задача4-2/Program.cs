/* Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Наименьший элемент - 1, на выходе получим 
следующий массив:
9 4 2
2 2 6
3 4 7 */

int ReadInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

void FillMatrixRandomNumbers(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(0,10);
        }
    }
}

void WriteMatrix(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int Min(int[,]array)
{
    int min =int.MaxValue;
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i,j]<min)
            {
                min = array[i,j];
            }
        }
    }
    return min;
}

int [] Find(int[,]array)
{
    int b = Min(array);
    int [] m =new int[2];
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i,j]==b)
            {
                m[0]=i;
                m[1]=j;
                break;
            }
        }
    }
    return m;
}

int [,] DeletedMas(int [,]array)
{
    int [] c=Find(array);
    int [,] otv = new int [array.GetLength(0) - 1, array.GetLength(1) - 1];
    int otvI = 0;
    int otvJ = 0;
    for(int i = 0; i < array.GetLength(0); i++)
    {
        if(i == c[0])
            continue;

        for(int j = 0; j < array.GetLength(1); j++)
        {
            if(j == c[1])
                continue;
            otv[otvI,otvJ]=array[i,j];
            otvJ++;
        }
        otvI++;
        otvJ = 0;
    }
    return otv;
}

int rows = ReadInt("Введите количество строк: ");
int columns = ReadInt("Введите количество столбцов: ");
int[,] numbers = new int[rows, columns];

FillMatrixRandomNumbers(numbers);
WriteMatrix(numbers);
WriteMatrix(DeletedMas(numbers));
