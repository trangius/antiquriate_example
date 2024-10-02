// ska bli ett system för ett antikvariat att hålla reda på alla sina böcker
static class Program
{
    static void Main()
    {
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
                    CreateBook(); // Skapa en ny bok
                    break;
                case "2":
                    PrintAllBooks(); // Skriv ut alla böcker i listan
                    break;
                case "3":
                    //PrintBookDetails(); // Skriv ut detaljer för en viss bok
                    break;
                case "4": // Avsluta
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Du har skrivit fel, försök igen.");
                    break;
            }
        }
    }

    public static void CreateBook()
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
            Book aBook = new Book(title, author, quality, year, publisher);
            Console.WriteLine($"Just nu är kvaliteten: {aBook.Quality}.");
            Console.WriteLine("Ange ny kvalitet:");
            aBook.Quality = Console.ReadLine();
            // vad ska vi göra med boken???
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // PrintAllBooks. Skriver ut info om alla böcker. Men ej deras kvalitet.
    public static void PrintAllBooks()
    {
        
    }

    // PrintBookDetails. Skriver ut all info om en viss bok
    public static void PrintBookDetails(Book theBookToPrint)
    {
        Console.WriteLine($"Title: {theBookToPrint.Title}");
        Console.WriteLine($"Author: {theBookToPrint.Author}");
        Console.WriteLine($"Quality: {theBookToPrint.Quality}");
        Console.WriteLine($"Year: {theBookToPrint.Year}");
        Console.WriteLine($"Publisher: {theBookToPrint.Publisher}");
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