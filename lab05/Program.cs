/* Задание 1
Создайте класс MyMatrix, представляющий матрицу m на n.
Создайте конструктор, принимающий число строк и столбцов, заполняющий матрицу случайными числами в диапазоне, 
который пользователь вводит при запуске программы.
Создайте метод Fill, перезаполняющий матрицу случайными значениями.
Создайте метод ChangeSize, изменяющий число строк и/или столбцов с копированием значений существующей матрицы. 
Если новая матрица больше существующий, то метод должен дозаполнить новую матрицу случайными числами.
Создайте метод ShowPartialy, принимающий в качестве параметров начальные и конечные значения строк и столбцов, 
значения матрицы внутри которых нужно вывести на консоль.
Создайте метод Show, выводящий все значения матрицы на консоль.
Создайте индексатор для матрицы вида this[int index1, int index2] с аксессором и мутатором. */

using System.Collections;
using System.Collections.Generic;

Console.Write("Задание 1\n");
MyMatrix matrix = new MyMatrix(3, 3, 10, 30);
matrix.Show();
Console.WriteLine();
matrix.Fill(10, 20);
matrix.Show();
Console.WriteLine();
matrix.ShowPartialy(1, 3, 1, 2);
Console.WriteLine();
matrix.ChangeSize(4, 4, 1, 20);
matrix.Show();
Console.WriteLine();

/* Задание 2
Создайте класс MyList<T>.
Реализуйте в простейшем приближении возможность использования его экземпляра аналогично экземпляру класса List<T>.
Минимально требуемый интерфейс взаимодействия с экземпляром должен включать метод добавления элемента,
индексатор для получения значения элемента по указанному индексу, свойство только для чтения для получения 
общего количества элементов и поддержку блока инициализации.
При выполнении нельзя использовать коллекции, только массивы.*/

Console.WriteLine("Задание 2\n");
MyList<int> myList = new MyList<int>(2, 65, 69, 79);
Console.Write("Изначальный лист - ");
for (var i = 0; i < myList.Size; ++i)
{
    Console.Write($"{myList[i]} ");
}
Console.WriteLine($"\n{myList[2]} - третий элемент ");
Console.WriteLine($"{myList.Size} - размер");
myList.Add(76);
Console.Write("Измененный лист - ");
for (var i = 0; i < myList.Size; ++i)
{
    Console.Write($"{myList[i]} ");
}

MyList<int> newList = new MyList<int> { 1, 2, 3 };
Console.Write("\nЧерез блок инициализации - ");
for (var i = 0; i < newList.Size; ++i)
{
    Console.Write($"{newList[i]} ");
}

/*Задание 3
 Создайте коллекцию MyDictionary<TKey,TValue>.
Реализуйте в простейшем приближении возможность использования ее экземпляра аналогично экземпляру класса 
Dictionary<TKey,TValue>.
Минимально требуемый интерфейс взаимодействия с экземпляром должен включать метод добавления элемента,
индексатор для получения значения элемента по указанному индексу и свойство только для чтения для получения общего 
количества элементов.
Реализуйте возможность перебора элементов коллекции в цикле foreach. При выполнении нельзя использовать коллекции, 
только массивы.*/

Console.WriteLine("\n\nЗадание 3");
KeyValuePair<string, int> kvalue = new KeyValuePair<string, int>("First", 7);
KeyValuePair<string, int> kvalue1 = new KeyValuePair<string, int>("Second", 13);
KeyValuePair<string, int> kvalue2 = new KeyValuePair<string, int>("Third", 27);
KeyValuePair<string, int> kvalue3 = new KeyValuePair<string, int>("Fourth", 63);
MyDictionary<string, int> myDictionary = new MyDictionary<string, int>(kvalue, kvalue1, kvalue2);
Console.WriteLine($"{myDictionary["Second"]} - второй элемент");
Console.WriteLine($"{myDictionary.Size} - размер");
myDictionary.Add(kvalue3);
Console.WriteLine($"{myDictionary.Size} - новый размер");

class MyMatrix //Класс для задания 1
{ 
    private List<List<double>> matrix;

    private int n
    {
        get { return matrix.Count; }
    }

    private int m
    {
        get { return matrix[0].Count(); }
    }

    public MyMatrix(int n, int m, int min, int max)
    {
        Random rand = new Random();
        matrix = new List<List<double>>();
        for (int i = 0; i < n; i++)
        {
            matrix.Add(new List<double>());
            for (int j = 0; j < m; j++)
            {
                matrix[i].Add(rand.Next(min, max));
            }
        }
    }

    public void Fill(int min, int max)
    {
        Random rand = new Random();
        for (int i = 0; i<n; i++)
        {
            for (int j= 0; j < m; j++)
            {
                matrix[i][j] = rand.Next(min, max);
            }
        }
    }

    public void ChangeSize(int new_n, int new_m, int min, int max)
    {
        Random rand = new Random();
        List<List<double>> new_matrix = new List<List<double>>(new_n);
        for (int i = 0; i < new_n; i++)
        {
            for (int j = 0; j < new_m; j++)
            {
                new_matrix.Add(new List<double>());
                if (i < n && j < m)
                {
                    new_matrix[i].Add(matrix[i][j]);
                }
                else
                {
                    new_matrix[i].Add(rand.Next(min, max));
                }
            }
        }
        matrix = new_matrix;
    }

    public void ShowPartialy(int start_n, int stop_n, int start_m, int stop_m)
    {
        for (int i = start_n - 1; i < stop_n; i++)
        {
            for (int j = start_m - 1; j < stop_m; j++)
            {
                Console.WriteLine($"{matrix[i][j]}");
            }
            Console.WriteLine();
        }
    }

    public void Show()
    {
        foreach (var row in matrix)
        {
            foreach (var num in row)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }
    }

    public double this[int a, int b]
    {
        get { return this.matrix[a][b]; }
        set { this.matrix[a][b] = value; }
    }
}

class MyList<T> : IEnumerable<T> //Для задания 2
{
    private T[] arr;
    public MyList(params T[] args)
    {
        arr = new T[args.Length];
        for (var i = 0; i < args.Length; ++i)
        {
            arr[i] = args[i];
        }
    }

    public void Add(T arg)
    {
        var tempArray = new T[arr.Length + 1];
        arr.CopyTo(tempArray, 0);
        tempArray[arr.Length] = arg;
        arr = tempArray;
    }

    public T this[int index] => arr[index];

    public int Size => arr.Length;
    public IEnumerator<T> GetEnumerator() => (IEnumerator<T>)arr.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class MyDictionary<TKey, TValue>  //Для задания 3
{
    private List<KeyValuePair<TKey, TValue>> dict;

    public MyDictionary(params KeyValuePair<TKey, TValue>[] args)
    {
        dict = Enumerable.ToList(args);
    }

    public void Add(KeyValuePair<TKey, TValue> arg)
    {
        dict.Add(arg);
    }

    public TValue this[TKey key] //Индексатор. Ключ - значение
    {
        get
        {
            foreach (var kvalue in dict)
            {
                if (Equals(kvalue.Key, key)) return kvalue.Value;
            }

            KeyValuePair<TKey, TValue> temp = new KeyValuePair<TKey, TValue>();
            return temp.Value;
        }
    }

    public int Size => dict.Count;
}
