/* Составить частотный словарь элементов двумерного массива. Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.
1, 2, 3 
4, 6, 1 
2, 1, 6 */

int rows = ReadInt("Введите количество строк матрицы: ");
int columns = ReadInt("Введите количество столбцов матрицы: ");

int minValue;
int maxValue;

int[,] numbers = new int[rows, columns];

FillMatrixRandomNumbers(numbers);

minValue = numbers[0,0];
maxValue = numbers[0,0];

WriteMatrix(numbers);

// находим мин и макс
for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            if(numbers[i,j] < minValue)
                minValue = numbers[i,j];
            if(numbers[i,j] > maxValue)
                maxValue = numbers[i,j];
        }
    }

int[] quantity = new int[maxValue - minValue + 1];

// заполняем и выводим матрицу счетчиков
for (int count = 0; count < quantity.Length; count++)
{
    for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            if(numbers[i,j]==minValue)
            {
                quantity[count]++;
            }
        }
    }
    if(quantity[count]>0)
    {
        Console.WriteLine($"{minValue} встречается {quantity[count]} раз(а)");
    }
    minValue++;
}

int ReadInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

void FillMatrixRandomNumbers(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(-5, 9);
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
