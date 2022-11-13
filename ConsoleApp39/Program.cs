//Функции и процедуры.

//   int[,] Генерация матрицы(n - размер)
//   void Запись матрицы в файл(матрица и имя файла)
//   int[,] Чтение матрицы из файла(имя файла, n размер)
//   void Вывод матрицы на экран (матрица)  

//Задания:
//1.Сгенерировать матрицу из простых чисел ( 2.. 1 000 000). 
//      Найти максимальное и минимальное числа. 
//	  Поменять строку с минимальных числом со строкой с максимальным числом  
//      Узнать есть ли симметричный столбец и посчитать его сумму.


//   2. Сгенерировать одну матрицу из нечётных чисел, вторую прочитать из файла.
//      Узнать является ли вторая матрица - магическим квадратом.
//      Сложить две матрицы. Вывести столбец матрицы в котором наибольшее количество 
//      простых чисел.

// Генерация матрицы
int[,] GenerationMatrix(int n)
{ 
    Random rnd = new Random();

    int[,] arr = new int[n, n];

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            int a = rnd.Next(0, 11);
            arr[i, j] = a;
        }
    }

    return arr;
}

// Генерация матрицы нечетных чисел
int[,] GenerationMatrixForOddNumbers(int n)
{
    Random rnd = new Random();

    int[,] arr = new int[n, n];

    for (int i = 0; i < n; i++)
    {
        int j = 0;
        while (j < n)
        {
            int a = rnd.Next(0, 11);
            if (a % 2 != 0)
            {
                arr[i, j] = a;
                j++;
            }
        }
    }
    return arr;
}

// Запись матрицы в файл
void WritingMatrixInFile(int[,] arr, string nameFile = "Output.txt")
{
    StreamWriter writer = new StreamWriter("Output.txt");

    int n = arr.GetLength(0);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            writer.Write($"{arr[i, j]} ");
        }
        writer.WriteLine();
    }

    writer.Close();
}

//чтение матрицы в файле
int[,] ReadingMatrixInFile(int n, string nameFile = "Output.txt")
{
    StreamReader reader = new StreamReader(nameFile);

    string a;

    int[,] arr = new int[n, n];

    int k = 0;
    for (int i = 0; i < n; i++)
    {
        a = reader.ReadLine();
        for (int j = 0; j < a.Length; j++)
        {
            if (a[j] != ' ' && k < n)
            {
                arr[i, k] = Convert.ToInt32(a[j].ToString());
                k++;
            }
        }
        k = 0;
    }
    reader.Close();

    return arr;
}

// Читает матрицу
void PrintMatrix(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(arr[i, j] + " ");
        }
        Console.WriteLine();
    }
}

//проверяет матрица является ли магическим квадратом
//на контрольной я сделал только для строк, а про столбцы и диагонали забыл
bool IsMagicSquare(int[,] arr)
{
    int a = 0, b = 0, c = 0, f = 0; 

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            a += arr[i, j];
            c += arr[j, i];
        }

        if (i > 0 && (b != a | f != c | b != c))
        {
            return false;
        }
        b = a;
        f = c;
        a = 0;
        c = 0;
    }

    int d = 0, s = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        d += arr[i, i];
        s += arr[i, arr.GetLength(0) - 1 - i];
    }

    if (s != d | s != b | d != b) return false;

    return true;
}

// складывает две матрицы
int[,] GetSumTwoMatrix(int[,] arr1, int[,] arr2)
{
    int[,] result = new int[arr1.GetLength(0), arr2.GetLength(1)];

    for (int i = 0; i < arr1.GetLength(0); i++)
    {
        for (int j = 0; j < arr1.GetLength(1); j++)
        {
            result[i, j] = arr1[i, j] + arr2[i, j];
        }
    }

    return result;
}

// является ли число простым
bool IsPrimeNumber(int a)
{
    for (int i = 2; i < a; i++)
    {
        if (a % i == 0) return false;
    }

    return true;
}

// возращает количество простых чисел в матрице
int ReturnsNumberOfPrimeNumbers(int[,] arr)
{
    int n = arr.GetLength(0);

    int count = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (IsPrimeNumber(arr[i, j]))
            {
                count += 1;
            }
        }
    }
    return count;
}

// возращает у какой матрицы больше простых чисел
void ReturnsWhichHasMorePrimes(int[,] arr1, int[,] arr2)
{
    int a = ReturnsNumberOfPrimeNumbers(arr1);
    int b = ReturnsNumberOfPrimeNumbers(arr2);

    if (a > b) Console.WriteLine("У первой матрицы больше простых чисел");
    else if (a == b) Console.WriteLine("Количество простых чисел равное");
    else Console.WriteLine("У второй матрицы больше простых чисел");
}

void Main()
{
    int n = 2;

    // Генерация матрицы
    int[,] arr = GenerationMatrix(n);

    WritingMatrixInFile(arr, "Output.txt");

    PrintMatrix(arr);

    Console.WriteLine("-----------------");
    // Генерация матрицы из нечетных чисел
    int[,] arr2 = GenerationMatrixForOddNumbers(n);

    PrintMatrix(arr2);

    Console.WriteLine("-----------------");
    // чтение матрицы из файла
    int[,] ReadArr = ReadingMatrixInFile(n, "Output.txt");

    PrintMatrix(ReadArr);

    Console.WriteLine("-----------------");
    //проверяет матрица является ли магическим квадратом
    Console.WriteLine(IsMagicSquare(ReadArr));

    Console.WriteLine("-----------------");
    // складывает две матрицы
    PrintMatrix(GetSumTwoMatrix(arr, arr2));

    Console.WriteLine("-----------------");
    // возращает у какой матрицы больше простых чисел
    ReturnsWhichHasMorePrimes(arr, arr2);
}

Main();