int rows = ReadInt("Введите количество строк матрицы: ");
int columns = ReadInt("Введите количество столбцов матрицы: ");
int[,] numbers = new int[rows, columns];
int minValue = 1;
int maxValue = 9;
int minElement;

int rowToDelete = 0;
int columnToDelete = 0;

FillMatrixRandomNumbers(numbers, minValue, maxValue);
WriteMatrix(numbers);

minElement = numbers[0, 0];

for (int i = 0; i < numbers.GetLength(0); i++)
{
    for (int j = 0; j < numbers.GetLength(1); j++)
    {
        if (numbers[i, j] < minElement)
        {
            minElement = numbers[i, j];
            rowToDelete = i;
            columnToDelete = j;
        }
    }
}

int[,] newNumbers = new int[rows - 1, columns - 1];

for (int i = 0; i < newNumbers.GetLength(0); i++)
{
    for (int j = 0; j < newNumbers.GetLength(1); j++)
    {
        if (i < rowToDelete && j < columnToDelete)
            newNumbers[i, j] = numbers[i, j];
        else if (i < rowToDelete && j >= columnToDelete)
            newNumbers[i, j] = numbers[i, j+1];
        else if (i >= rowToDelete && j < columnToDelete)
            newNumbers[i, j] = numbers[i+1, j];
        else
            newNumbers[i, j] = numbers[i+1, j+1];
    }
}

WriteMatrix(newNumbers);
int ReadInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

void FillMatrixRandomNumbers(int[,] array, int min, int max)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(min, max + 1);
        }
    }
}

void WriteMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

