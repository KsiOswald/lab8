using System.Data;

[Serializable]
internal class Film
{
    private string _name;
    private int _year;
    private double _score;
    private int _minutes;
    private Category _category;

    public Film()
    {
        _name = "БезНазвания";
        _year = 1900;
        _score = 0;
        _minutes = 0;
        _category = Category.Other;
    }
    public Film(string name, int year, double score, int minutes, Category category)
    {
        Name = name;
        Year = year;
        Score = score;
        Minutes = minutes;
        Category = category;
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _name = value;
            }
            else
            {
                Console.WriteLine("Введено пустое название");
                _name = "БезНазвания";
            }
        }
    }
    public int Year
    {
        get
        {
            return _year;
        }
        set
        {
            if (value > 1900 && value < 2027)
            {
                _year = value;
            }
            else
            {
                Console.WriteLine("Введен некорректный год," +
                    " год изменен на 1900");
                _year = 1900;
            }
        }
    }
    public double Score
    {
        get
        {
            return _score;
        }
        set
        {
            if (value > 0.0 && value <= 10.0)
            {
                _score = value;
            }
            else
            {
                Console.WriteLine("Оценка введена некорректно," +
                   " оценка изменена на 0.0");
                _score = 0.0;
            }
        }
    }
    public int Minutes
    {
        get
        {
            return _minutes;
        }
        set
        {
            if (value >= 0)
            {
                _minutes = value;
            }
            else
            {
                Console.WriteLine("Продолжительность введена некорректно," +
                   " время изменена на 0");
                _minutes = 0;
            }
        }
    }
    public Category Category
    {
        get
        {
            return _category;
        }
        set
        {
            if (Enum.IsDefined(typeof(Category), value))
            {
                _category = value;
            }
            else
            {
                Console.WriteLine("Категория введена некорректно," +
                   " категория изменена на Other");
                _category = Category.Other;
            }
        }
    }
    public override string ToString()
    {
        return ($"Название: {Name} |" +
                $"Год выпуска: {Year} |" +
                $"Оценка: {Score}  |" +
                $"Продолжительность: {Minutes}  |" +
                $"Категория фильма: {Category}");
    }
}
