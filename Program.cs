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
        catch
        {
            Console.WriteLine("Det gick inte att skapa boken. Du har skrivit fel någonstans.");
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

    }
}

class Book
{
    string title;
    string author;
    string quality;
    int year;
    string publisher;

    public Book(string title, string author, string quality, int year, string publisher)
    {
        if (title == "")
        {
            throw new ArgumentException("Title can't be empty");
        }
        this.title = title;
        this.author = author;
        this.quality = quality;
        this.year = year;
        this.publisher = publisher;
    }

    public void Print()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Quality: {quality}");
        Console.WriteLine($"Year: {year}");
        Console.WriteLine($"Publisher: {publisher}");
    }
}