// Парандюк Максим ІПЗ-42
// Варіант 8


List<int> x_axis = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<int> y_axis = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

int result = 0;

// Читання з файлу. Перша клітинка - кентавр, друга - ціль.
string path = (@"C:\Users\Dalba\source\repos\ConsoleApp3\ConsoleApp3\INPUT.txt");
string inputfile = File.ReadAllText(path);

// Заміна букв на цифри
inputfile = inputfile.Replace("A", "1").Replace("B", "2").Replace("C", "3")
    .Replace("D", "4").Replace("E", "5").Replace("F", "6").Replace("G", "7")
    .Replace("H", "8").Replace("I", "9");

// Розділення на координати
string[] cells = inputfile.Split(' ');

int x1 = cells[0][0] - '0';
int y1 = cells[0][1] - '0';
int x2 = cells[1][0] - '0';
int y2 = cells[1][1] - '0';

// Список x, y координат куди може піти кінь якщо з'явився на білій клітинці.
List<int> x1_list = new List<int> { };
List<int> y1_list = new List<int> { };

x1_list.Add(x1 + 2);
y1_list.Add(y1 + 1);

x1_list.Add(x1 + 2);
y1_list.Add(y1 - 1);

x1_list.Add(x1 + 1);
y1_list.Add(y1 + 2);

x1_list.Add(x1 + 1);
y1_list.Add(y1 - 2);

x1_list.Add(x1 - 1);
y1_list.Add(y1 + 2);

x1_list.Add(x1 - 1);
y1_list.Add(y1 - 2 );

x1_list.Add(x1 - 2);
y1_list.Add(y1 + 1);

x1_list.Add(x1 - 2);
y1_list.Add(y1 - 1);

List<string> knight_coords = new List<string> { };
for (int i = 0; i < x1_list.Count; i++)
{
    knight_coords.Add(Convert.ToString(x1_list[i]) + Convert.ToString(y1_list[i]));
}

// Список x, y координат з яких можна слоном дійти до цілі.
List<int> x2_list = new List<int> { };
List<int> y2_list = new List<int> { };

for (int i = 0; i < 9; i++)
{
    if (((x2 - i) > 0) && ((x2 - i) <= 9) && ((y2 + i) > 0) && ((y2 + i) <= 9) && ((y2 + i) != y2) && ((x2 - i) != x2))
    {
        x2_list.Add(x2 - i);
        y2_list.Add(y2 + i);
    }
}

for (int i = 0; i < 9; i++)
{
    if (((x2 + i) > 0) && ((x2 + i) <= 9) && ((y2 + i) > 0) && ((y2 + i) <= 9) && ((y2 + i) != y2) && ((x2 + i) != x2))
    {
        x2_list.Add(x2 + i);
        y2_list.Add(y2 + i);
    }
}

for (int i = 0; i < 9; i++)
{
    if (((x2 + i) > 0) && ((x2 + i) <= 9) && ((y2 - i) > 0) && ((y2 - i) <= 9) && ((y2 - i) != y2) && ((x2 + i) != x2))
    {
        x2_list.Add(x2 + i);
        y2_list.Add(y2 - i);
    }
    
}

for (int i = 0; i < 9; i++)
{
    if (((x2 - i) > 0) && ((x2 - i) <= 9) && ((y2 - i) > 0) && ((y2 - i) <= 9) && ((y2 - i) != y2) && ((x2 - i) != x2))
    {
        x2_list.Add(x2 - i);
        y2_list.Add(y2 - i);
    }
}

// Список x, y координат з яких можна слоном дійти до цілі.
List<string> bishop_coords = new List<string> { };
for (int i = 0; i < x2_list.Count; i++)
{
    bishop_coords.Add(Convert.ToString(x2_list[i]) + Convert.ToString(y2_list[i]));
}

// Чи встане кентавр на одну діагональ з ціллю після того як походить конем.(Результат програми:2)
bool two_steps = false;
for (int i = 0; i < knight_coords.Count; i++)
{
    if (bishop_coords.Contains(knight_coords[i]))
    {
        two_steps = true;
    }
}

// 1. Якщо цільова точка знаходиться на білій клітинці(номер клітинки парний), записує -1.
// З білої можна перейти на чорну, але не з чорної на білу.
if ((x2 + y2) % 2 != 0)
{
    result = -1;
}
// 1. Якщо кентавр з'явився на цільовій точці, записує 0
else if (cells[0] == cells[1])
{
    result = 0;
}
// 2. Якщо походивши конем може встати на цільову точку або з'явився на одній діагоналі з ціллю
else if (knight_coords.Contains(cells[1]) || bishop_coords.Contains(cells[0]))
{
    result = 1;
}
// 3. Якщо з'явився на чорній клітинці(може дойти до будь-якої чорної клітинки за 2 ходи) або "two_steps" = true
else if (two_steps || ((x1 * y1) % 2 != 0))
{
    result = 2;
}
// 4. Всі інші випадки.(до будь-якої точки можна дойти за 3 кроки)
else
{
    result = 3;
}


File.WriteAllText("C:\\Users\\Dalba\\source\\repos\\ConsoleApp3\\ConsoleApp3\\OUTPUT.txt", Convert.ToString(result));

