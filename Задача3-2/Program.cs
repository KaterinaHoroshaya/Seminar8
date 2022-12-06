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
            array[i, j] = new Random().Next(0,100);
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

int Max(int[,]array)
{
    int max =int.MinValue;
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i,j]>max)
            {
                max = array[i,j];
            }
        }
    }
    return max;
}

void Info(int[,]array)
{

    for (int c = Min(array);c<Max(array);c++)
    {
        int count=0;
        for(int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                if (c==array[i,j])
                {
                    count++;
                }
            }
        }
        if(count>0)Console.WriteLine($"{c} встречается {count} раз(а)");
    }
}

int rows = ReadInt("Введите количество строк: ");
int columns = ReadInt("Введите количество столбцов: ");
int[,] numbers = new int[rows, columns];

FillMatrixRandomNumbers(numbers);
WriteMatrix(numbers);
Info(numbers);

