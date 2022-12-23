
/*Составить частотный словарь элементов двумерного массива. 
Частотный словарь содержит информацию о том, 
сколько раз встречается элемент входных данных.*/

int m = InputInt("Введите число строк: ");
int n = InputInt("Введите число столбцов: ");
int[,] array = Create2DRandomArray(m,n);
Print2DArray(array);
List <(int number, int frequence)> dictionary = FindFrequence(array);
Console.WriteLine(string.Join("\n", dictionary));


List <(int number, int frequence)> FindFrequence (int[,] array)
{
    List <(int number, int count)> dictionary = new List<(int, int)>();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int index = FindIndex(dictionary, array[i,j]);
            if(index != -1)
            {
                dictionary[index] = (array[i,j], dictionary[index].count+1);
            }
            else
            {
                dictionary.Add((array[i,j],1));
            }

        }
    }
    return dictionary;

}

int FindIndex(List <(int, int)> list, int number)
{
    for (int i = 0; i < list.Count; i++)
    {
        if(list[i].Item1 == number)
        {
            return i;
        }
    }
    return -1;
}


void Print2DArray(int[,] array)
{
    for (var i = 0; i < array.GetLength(0); i++)
    {
        for (var j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}

int[,] Create2DRandomArray(int m, int n)
{
    int[,] array = new int[m, n];

    Random random = new Random();

    for (var i = 0; i < array.GetLength(0); i++)
    {
        for (var j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(1, 10);
        }
    }

    return array;
}

int InputInt(string text)
{
    bool isParsed = false;
    int number = 0;

    while (!isParsed)
    {
        Console.Write(text);
        isParsed = int.TryParse(Console.ReadLine(), out number);
    }
    return number;
}