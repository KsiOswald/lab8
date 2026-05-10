internal class Program
{
    private static void Main(string[] args)
    {
        List<Film> database = CatalogOfFilms.LoadData();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Каталог фильмов");
            Console.WriteLine("1. Просмотреть все фильмы");
            Console.WriteLine("2. Добавить новый фильм");
            Console.WriteLine("3. Удалить фильм по названию");
            Console.WriteLine("4. Найти фильмы по году выпуска");
            Console.WriteLine("5. Найти фильмы по оценке");
            Console.WriteLine("6. Найти среднюю оценку фильмов в каталоге");
            Console.WriteLine("7. Найти количество фильмов в категории");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CatalogOfFilms.ShowDatabase(database);
                    break;
                case "2":
                    CatalogOfFilms.AddNewFilm(database);
                    break;
                case "3":
                    CatalogOfFilms.RemoveFilmByName(database);
                    break;
                case "4":
                    {
                        Console.Write("Введите год выпуска: ");
                        int year = TypeCheck.IsInteger();
                        List<Film> filmsInYear = new List<Film>();
                        filmsInYear = CatalogOfFilms.FilmsInYear(database, year);
                        Console.WriteLine("Найденные фильмы: ");
                        for (int i = 0; i < filmsInYear.Count; i++)
                        {
                            Console.WriteLine(filmsInYear[i]);
                        }
                        break;
                    }
                case "5":
                    Console.Write("Введите оценку: ");
                    double score = TypeCheck.IsDouble();
                    List<Film> filmsByScore = new List<Film>();
                    filmsByScore = CatalogOfFilms.BetterFilm(database, score);
                    Console.WriteLine($"Фильмы, оценка которых выше {score}: ");
                    for (int i = 0; i < filmsByScore.Count; i++)
                    {
                        Console.WriteLine(filmsByScore[i]);
                    }
                    break;
                case "6":
                    {
                        double averScore = CatalogOfFilms.AverageScore(database);
                        Console.WriteLine($"Средняя оценка всех фильмов: {averScore}");
                        break;
                    }
                case "7":
                    {
                        Console.Write("Выберите категорию (0-Horror, 1-Comedy, " +
                            "2-ScienceFiction, 3-History, 4-Cartoon, 5-Other): ");
                        Category category = (Category)TypeCheck.IsInteger();
                        int count = CatalogOfFilms.CountInCategory(database, category);
                        Console.WriteLine($"Найдено {count} фильмов по категории {category}");
                        break;
                    }
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Неверный ввод, попробуйте снова.");
                    break;
            }
            if (!exit)
            {
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}