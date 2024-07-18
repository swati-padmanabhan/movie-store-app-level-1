using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;
using MovieStoreLevel1.models;

namespace MovieStoreLevel1
{
    internal class Program
    {
        static List<Movie> movies = new List<Movie>();
        static void Main(string[] args)
        {
            DisplayMenu();
        }
        static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("==========Welcome to Movie Store Application : Swati Padmanabhan==========");
                Console.WriteLine("What do you wish to do?\n" +
                    "1. Add New Movie\n" +
                    "2. Display All Movies\n" +
                    "3. Find Movie By Id\n" +
                    "4. Remove Movie by Id\n" +
                    "5. Clear All Movies\n" +
                    "6. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                DoTask(choice);
            }
        }
        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddNewMovie();
                    break;
                case 2:
                    if (movies.Count == 0)
                        Console.WriteLine("Movie List is Empty");
                    else
                        movies.ForEach(movie => Console.WriteLine(movie));
                    break;
                case 3:
                    Movie findMovie = FindMovieById();
                    if (findMovie != null)
                        Console.WriteLine(findMovie);
                    else
                        Console.WriteLine("Account Not Found");
                    break;
                case 4:
                    RemoveMovie();
                    break;
                case 5:
                    if (movies.Count == 0)
                        Console.WriteLine("Account List is already Empty !");
                    else
                        movies.Clear();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please Enter Valid Input !");
                    break;

            }
        }
        static void AddNewMovie()
        {
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name of the Movie: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the Genre of the Movie: ");
            string genre = Console.ReadLine();

            Console.WriteLine("Enter Year of Release of the Movie in (DD/MM/YYYY): ");
            DateTime yearOfRelease = Convert.ToDateTime(Console.ReadLine());

            Movie newMovie = Movie.CreateMovie(id, name, genre, yearOfRelease);
            movies.Add(newMovie);
            Console.WriteLine("New Movie Added Successfully !");
        }

        static Movie FindMovieById()
        {
            Movie findMovie = null;
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            findMovie = movies.Where(item => item.Id == id).FirstOrDefault();
            return findMovie;
        }

        static void RemoveMovie()
        {
            Movie findMovie = FindMovieById();
            if (findMovie == null)
                Console.WriteLine("Movie Not Found");
            else
            {
                movies.Remove(findMovie);
                Console.WriteLine("Movie Deleted Successfully !");
            }
        }


    }
}
