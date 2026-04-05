class SayaMusicTrack
{
    private int id;
    private string playCount;
    private string title;

    public SayaMusicTrack(string title)
    {
        this.title = title;
        this.playCount = "0";

        Random rnd = new Random();
        this.id = rnd.Next(10000, 100000);
    }

    public void IncreasePlayCount(int count)
    {
        int tempPlayCount = int.Parse(this.playCount);
        tempPlayCount += count;

        this.playCount = tempPlayCount.ToString();
    }

    public void PrintTrackDetails()
    {
        Console.WriteLine($"ID Lagu: {this.id}");
        Console.WriteLine($"Judul Lagu: {this.title}");
        Console.WriteLine($"Total Play: {this.playCount}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        SayaMusicTrack lagu = new SayaMusicTrack("Payung Teduh - Akad");

        Console.WriteLine("=== Data Awal ===");
        lagu.PrintTrackDetails();

        Console.WriteLine("\n=== Setelah Tambah Play Count ===");
        lagu.IncreasePlayCount(150);
        lagu.PrintTrackDetails();

        Console.ReadLine();
    }
}