using System;
using System.Collections.Generic; // Required for List<T>

namespace BookManagementApp
{
    // Define a simple Book class
    public class Book
    {
        // Properties of the Book class
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }

        // Constructor to initialize a new Book object
        public Book(string title, string author, int year, string isbn)
        {
            Title = title;
            Author = author;
            PublicationYear = year;
            ISBN = isbn;
        }

        // Method to display book details
        public void DisplayBookDetails()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Publication Year: {PublicationYear}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine("--------------------");
        }
    }

    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Book Management Application!");
            Console.WriteLine("------------------------------------------");

            // Create a list to store Book objects
            List<Book> library = new List<Book>();

            // Add some initial books to the library
            library.Add(new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 1979, "978-0345391803"));
            library.Add(new Book("1984", "George Orwell", 1949, "978-0451524935"));
            library.Add(new Book("Pride and Prejudice", "Jane Austen", 1813, "978-0141439518"));

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. View all books");
                Console.WriteLine("2. Add a new book");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- All Books in Library ---");
                        if (library.Count == 0)
                        {
                            Console.WriteLine("No books in the library yet.");
                        }
                        else
                        {
                            foreach (Book book in library)
                            {
                                book.DisplayBookDetails();
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n--- Add New Book ---");
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();

                        int year = 0;
                        bool isValidYear = false;
                        while (!isValidYear)
                        {
                            Console.Write("Enter Publication Year: ");
                            string yearInput = Console.ReadLine();
                            if (int.TryParse(yearInput, out year) && year > 0 && year <= DateTime.Now.Year)
                            {
                                isValidYear = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid year. Please enter a valid positive year (e.g., 2023).");
                            }
                        }

                        Console.Write("Enter ISBN: ");
                        string isbn = Console.ReadLine();

                        // Create a new Book object and add it to the list
                        Book newBook = new Book(title, author, year, isbn);
                        library.Add(newBook);
                        Console.WriteLine("Book added successfully!");
                        break;

                    case "3":
                        running = false;
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
