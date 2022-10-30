// Парандюк Максим ІПЗ-42
// Варіант 8

// Читання з файлу
string path = ("C:\\Users\\Dalba\\source\\repos\\ConsoleApp1\\ConsoleApp1\\INPUT.txt");
string inputfile = File.ReadAllText(path);

// Присвоєння змінним значення з файлу
List<string> inputnum = new List<string>();
inputnum = inputfile.Split(' ').ToList();
int n = Convert.ToInt32(inputnum[0]);
int m = Convert.ToInt32(inputnum[1]);

Console.WriteLine("N = " + n);
Console.WriteLine("M = " + m);

// Не розуміло що означає це число "количество последовательностей результатов подбрасывания монетки" в умові,
// тому вирішено реалізувати обчислення ймовірності перемоги Петра. Якщо решка випадає хоча б m разів то Петро переміг.

// Обчислення факторіалу
static double factorial(int x)
{
    double res = 1;
    while (x != 1)
    {
        res = res * x;
        x = x - 1;
    }
    return res;
}

// Обчислення біноміальної ймовірністі за формулою
static double binomial_probability(int n, int m)
{
    double x;
    if (n == m)
    {
        x = Math.Pow(0.5, m) * Math.Pow((1 - 0.5), (n - m));
        return x;
    }
    else
    {
        x = (factorial(n) / (factorial(m) * (factorial(n - m)))) * Math.Pow(0.5, m) * Math.Pow((1 - 0.5), (n - m));
        return x;
    }
}

// Сумування біноміальних ймовірностей, коли решка випадає m і більше разів
static double probability_calculation(int n, int m)
{
    double x = 0;
    for (int i = m; i <= n; i++)
    {
        x += binomial_probability(n, i);

    }
    
    return x * 100;
}

string output = Convert.ToString(Math.Round(probability_calculation(n, m), 3)) + "%";
Console.WriteLine("Win probability: " + output);

// Запис у файл ймовірності перемоги Петра
File.WriteAllText("C:\\Users\\Dalba\\source\\repos\\ConsoleApp1\\ConsoleApp1\\OUTPUT.txt", output);
