// Парандюк Максим ІПЗ-42
// Варіант 8

// Читання з файлу
string path = ("C:\\Users\\Dalba\\source\\repos\\ConsoleApp2\\ConsoleApp2\\INPUT.txt");
string inputfile = File.ReadAllText(path);

// Присвоєння змінним значення з файлу
List<string> inputnum = new List<string>();
inputnum = inputfile.Split('\n').ToList();
int n = Convert.ToInt32(inputnum[0]);

// Створення масиву висот платформ
int[] heights = inputnum[1].Split(' ').Select(int.Parse).ToArray();

// Дублювання останнього елементу масиву, щоб уникнути проблеми виходу індексу за межі масиву
heights = heights.Concat(new int[] { heights[heights.Length - 1] }).ToArray();

Console.WriteLine("Platforms:");
for (int i = 0; i < heights.Length-1; i++)
{
    Console.Write(heights[i] + " ");
}
Console.WriteLine();

int energy = 0;
for (int i = 0; i < heights.Length - 2;)
{
    // Обчислення затрат енергії для обох видів стрибків
    int jump = Math.Abs(heights[i] - heights[i + 1]);
    int superjump = 3 * Math.Abs(heights[i] - heights[i + 2]);

    if (jump < superjump)
    {
        energy += jump;
    }
    else
    {
        energy += superjump;
        i += 1;
    }
    i++;
}

Console.WriteLine("Minimal amount of energy: " + energy);

// Запис у файл мінімальної необхідної кількості енергії
File.WriteAllText("C:\\Users\\Dalba\\source\\repos\\ConsoleApp2\\ConsoleApp2\\OUTPUT.txt", Convert.ToString(energy));
