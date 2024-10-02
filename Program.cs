using System.Text.Json; 

// ska bli ett system för ett antikvariat att hålla reda på alla sina böcker
static class Program
{
    static List<Book> allBooks = new List<Book>();
    static void Main()
    {

        string jsonString = File.ReadAllText("allbooks.json");
        allBooks = JsonSerializer.Deserialize<List<Book>>(jsonString);

        Console.WriteLine("Välkommen till antikvariatet!");
        bool isRunning = true;
        
        // Mainloop som hanterar menyn   
        while(isRunning)
        {
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Skapa en bok");
            Console.WriteLine("2. Lista alla böcker");
            Console.WriteLine("3. Skriv ut info om en viss bok");
            Console.WriteLine("4. Avsluta programmet");

            // Tag in användarens input
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    AddBook(); // Skapa en ny bok
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    jsonString = JsonSerializer.Serialize(allBooks, options);
                    File.WriteAllText("allbooks.json", jsonString);
                    break;
                case "2":
                    PrintAllBooks(); // Skriv ut alla böcker i listan
                    break;
                case "3":
                    PrintBookDetails(); // Skriv ut detaljer för en viss bok
                    break;
                case "4": // Avsluta
                    Console.WriteLine("Tack för idag!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Du har skrivit fel, försök igen.");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }
    }

    // AddBook. Adds a book to the list.
    public static void AddBook()
    {
        Console.Write("skriv titel:");
        string title = Console.ReadLine();
        Console.Write("skriv författare:");
        string author = Console.ReadLine();
        Console.Write("skriv kvalitet:");
        string quality = Console.ReadLine();
        Console.Write("skriv år:");
        int year = int.Parse(Console.ReadLine());
        Console.Write("skriv förlag:");
        string publisher = Console.ReadLine();
        try
        {
            allBooks.Add(new Book(title, author, quality, year, publisher));
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // PrintAllBooks. Skriver ut info om alla böcker. Men ej deras kvalitet.
    public static void PrintAllBooks()
    {
        // iterera igenom listan allBooks och skapa en temporär referens b (en bok)
        // till vardera instans i den listan.
        for(int i = 0; i < allBooks.Count; i++)
        {
            Book theBook = allBooks[i];
            // skriv ut info om varje bok
            Console.Write($"Index: {i},");
            Console.Write($"Title: {theBook.Title, -40}");
            Console.Write($"Author: {theBook.Author, -35}\t\t\t");
            Console.Write($"Year: {theBook.Year}");
            Console.Write($"Publisher: {theBook.Publisher}\n");
        }
    }

    // PrintBookDetails. Skriver ut all info om en viss bok
    public static void PrintBookDetails()
    {
        PrintAllBooks();
        Console.Write("Ange index på den du vill se mer info om: ");
        int i = int.Parse(Console.ReadLine());
        Book theBook = allBooks[i];
        Console.WriteLine($"Title: {theBook.Title}");
        Console.WriteLine($"Author: {theBook.Author}");
        Console.WriteLine($"Quality: {theBook.Quality}");
        Console.WriteLine($"Year: {theBook.Year}");
        Console.WriteLine($"Publisher: {theBook.Publisher}");
    }
}

// Klassen Book håller reda på EN bok och endast EN.
class Book
{
    public string Title{get;set;}
    public string Author{get;set;}
    string quality;
    public int Year{set;get;}
    public string Publisher{get;set;}

    // Här är en egenskap, Quality (stort Q). Den ska ändra på värdet på den privata
    // variabeln quality (litet q). Denna egenskap implementerar set- och get-.
    public string Quality
    {
        set
        {
            if (quality == "")
            {
                throw new ArgumentException("Du har skrivit fel någonstans.");
            }
            quality = value;
        }
        get
        {
            return quality;
        }
    }

    // konstruktor
    public Book(string title, string author, string quality, int year, string publisher)
    {
        if (title == "" || author == "" || quality == "" || year == 0 || publisher == "")
        {
            throw new ArgumentException("Du har skrivit fel någonstans.");
        }

        Title = title;
        Author = author;
        Quality = quality;
        Year = year;
        Publisher = publisher;
    }
}