using System.Runtime.CompilerServices;

internal class CatalogOfFilms
{
    private const string FileName = "database.bin";

    public static List<Film> LoadData()
    {
        List<Film> films = new List<Film>();

        if (!File.Exists(FileName))
        {
            return films;
        }

        using (BinaryReader reader =
            new BinaryReader(File.Open(FileName, FileMode.Open)))
        {
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Film film = new Film();
                film.Name = reader.ReadString();
                film.Year = reader.ReadInt32();
                film.Score = reader.ReadDouble();
                film.Minutes = reader.ReadInt32();
                film.Category = (Category)reader.ReadInt32();
                films.Add(film);
            }
        }

        return films;
    }
    public static void SaveData(List<Film> films)
    {
        using (BinaryWriter writer
            = new BinaryWriter(File.Open(FileName, FileMode.Create)))
        {
            writer.Write(films.Count);
            foreach (Film film in films)
            {
                writer.Write(film.Name);
                writer.Write(film.Year);
                writer.Write(film.Score);
                writer.Write(film.Minutes);
                writer.Write((int)film.Category);
            }
        }
    }
    public static void ShowDatabase(List<Film> films)
    {
        Console.WriteLine("Содержимое базы");
        if (films.Count == 0)
        {
            Console.WriteLine("База данных пуста.");
        }
        else
        {
            foreach (var film in films)
            {
                Console.WriteLine(film.ToString());
            }
        }
    }

    public static void AddNewFilm(List<Film> films)
    {
        Console.WriteLine("Добавление нового фильма");
        Console.Write("Введите название: ");
        string name = Console.ReadLine();

        Console.Write("Введите год выпуска фильма: ");
        int year = TypeCheck.IsInteger();

        Console.Write("Введите оценку фильма: ");
        double score = TypeCheck.IsDouble();

        Console.Write("Введите продолжительность фильма в минутах: ");
        int minutes = TypeCheck.IsInteger();

        Console.Write("Выберите категорию (0-Horror, 1-Comedy, " +
            "2-ScienceFiction, 3-History, 4-Cartoon, 5-Other): ");
        Category category = (Category)TypeCheck.IsInteger();

        Film newFilm = new Film(name, year, score, minutes, category);

        films.Add(newFilm);
        SaveData(films);
        Console.WriteLine("Фильм добавлен и сохранен.");
    }

    public static void RemoveFilmByName(List<Film> films)
    {
        Console.Write("Введите название фильма для удаления: ");
        string name = Console.ReadLine();

        var filmToRemove = films.FirstOrDefault(p => p.Name == name);

        if (filmToRemove != null)
        {
            films.Remove(filmToRemove);
            SaveData(films);
            Console.WriteLine("Фильм удален.");
        }
        else
        {
            Console.WriteLine("Фильм с таким названием не найден.");
        }
    }

    public static List<Film> FilmsInYear(List<Film> films, int year)
    {
        return films.Where(film => film.Year == year).ToList();
    }

    public static List<Film> BetterFilm(List<Film> films, double score)
    {
        return films.Where(film => film.Score >= score).ToList();
    }

    public static double AverageScore(List<Film> films)
    {
        return films.Any() ? films.Average(film => film.Score):0;
    }

    public static int CountInCategory(List<Film> films, Category category)
    {
        return films.Count(film => film.Category == category);
    }
}