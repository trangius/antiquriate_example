// ska bli ett system för ett antikvariat att hålla reda på alla sina böcker
static class Program
{
    static void Main()
    {
        Console.WriteLine("Välkommen till antikvariatet!");
        bool isRunning = true;
        while(isRunning)
        {
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Skapa en bok");
            Console.WriteLine("2. Lista alla böcker");
            Console.WriteLine("3. Avsluta programmet");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    CreateBook();
                    break;
                case "2":
                    ListBooks();
                    break;
                case "3":
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
        Book aBook = null;
        try
        {
            aBook = new Book(title, author, quality, year, publisher);
            Console.WriteLine($"Just nu är kvaliteten: {aBook.Quality}.");
            Console.WriteLine("Ange ny kvalitet:");
            aBook.Quality = Console.ReadLine();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        if (aBook != null)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("detta är boken du skapade:");
            Print(aBook);
        }
        else
        {
            Console.WriteLine("Du har inte skapat någon bok.");
        }
    }

    public static void ListBooks()
    {
        
    }
    public static void Print(Book theBookToPrint)
    {
        Console.WriteLine($"Title: {theBookToPrint.Title}");
        Console.WriteLine($"Author: {theBookToPrint.Author}");
        Console.WriteLine($"Quality: {theBookToPrint.Quality}");
        Console.WriteLine($"Year: {theBookToPrint.Year}");
        Console.WriteLine($"Publisher: {theBookToPrint.Publisher}");
    }
}

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
            quality = value; 
        }
        get
        {
            return quality;
        }
    }

    // detta är Get- och set-metoder på det traditionella viset,
    // så som man gjorde i C++, back in the days
    /*
    public void SetQuality(string quality)
    {
        if (quality == "")
        {
            throw new ArgumentException("Du har skrivit fel någonstans.");
        }
        this.quality = quality;
    }

    public string GetQuality()
    {
        return quality;
    }
    
    */

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