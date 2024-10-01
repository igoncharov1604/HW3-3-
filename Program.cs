//приклад 1
class TempRecord
{
    private readonly float[] temps = new float[10] { 56.2F, 56.7F, 56.5F, 56.9F, 58.8F, 61.3F, 65.9F, 62.1F, 59.2F, 57.5F };

    // Визначення індексатора
    public float this[int index]
    {
        get => temps[index];
        set => temps[index] = value;
    }
}

class Program
{
    static void Main()
    {
        TempRecord tempRecord = new TempRecord();

        // Використання індексатора для отримання та зміни значень
        tempRecord[3] = 58.3F;
        tempRecord[5] = 60.1F;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Element #{i} = {tempRecord[i]}");
        }
    }
}

//приклад 2
class DayCollection
{
    readonly string[] days = { "Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота", "Неділя" };

    private int GetDay(string testDay)
    {
        for (int j = 0; j < days.Length; j++)
        {
            if (days[j] == testDay)
                return j;
        }
        throw new ArgumentOutOfRangeException(testDay, "Неправильно вказаний день тижня");
    }

    public int this[string day] => GetDay(day);
}

class Program
{
    static void Main()
    {
        DayCollection week = new DayCollection();
        Console.WriteLine(week["Середа"]);

        try
        {
            Console.WriteLine(week["перший день"]);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
//приклад 3
class PwrOfTwo
{
    public int this[int index]
    {
        get
        {
            return index switch
            {
                >= 0 and < 16 => Pwr(index),
                _ => -1
            };
        }
    }

    static int Pwr(int p)
    {
        int result = 1;
        for (int i = 0; i < p; i++)
            result *= 2;
        return result;
    }
}

class UsePwrOfTwo
{
    static void Main()
    {
        PwrOfTwo pwr = new PwrOfTwo();
        Console.Write("Перші 8 ступенів числа 2: ");
        for (int i = 0; i < 8; i++)
        {
            Console.Write(pwr[i] + " ");
        }
        Console.WriteLine();

        Console.Write("А це деякі помилки: ");
        Console.Write(pwr[-1] + " " + pwr[17]);
    }
}
