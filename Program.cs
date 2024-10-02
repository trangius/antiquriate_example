// ska bli ett system för ett antikvariat att hålla reda på alla sina böcker
static class Program
{
    static void Main()
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
        Book b = null;
        try
        {
            b = new Book(title, author, quality, year, publisher);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        

        if (b != null)
        {
            Console.WriteLine("detta är boken du skapade:");
            b.Print();
        }
        else
        {
            Console.WriteLine("Du har inte skapat någon bok.");
        }
        
        Console.WriteLine("Tack för att du använde programmet!");

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