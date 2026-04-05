using System.Diagnostics;
class SayaMusicTrack
{
    private int id;
    private string playCount;
    private string title;

    public SayaMusicTrack(string title)
    {
        Debug.Assert(title != null, "Judul track tidak boleh null!");
        Debug.Assert(title.Length <= 100, "Judul track maksimal 100 karakter!");

        this.title = title;
        this.playCount = "0";

        Random rnd = new Random();
        this.id = rnd.Next(10000, 100000);
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count <= 10000000, "Penambahan maksimal 10.000.000 per pemanggilan!");

        try
        {
            checked
            {
                int tempPlayCount = int.Parse(this.playCount);
                tempPlayCount += count;
                this.playCount = tempPlayCount.ToString();
            }
        }
        catch (OverflowException e)
        {
            Console.WriteLine("\n[Error] Angka melebihi batas: " + e.Message);
        }
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
        Console.WriteLine("=== PENGUJIAN AMAN ===");
        SayaMusicTrack lagu1 = new SayaMusicTrack("Payung Teduh - Akad");
        lagu1.IncreasePlayCount(5000000);
        lagu1.PrintTrackDetails();

        Console.WriteLine("\n=== PENGUJIAN EXCEPTION OVERFLOW ===");
        SayaMusicTrack lagu2 = new SayaMusicTrack("Lagu Viral");

        for (int i = 0; i < 220; i++)
        {
            lagu2.IncreasePlayCount(10000000);
        }

        lagu2.PrintTrackDetails();

        Console.ReadLine();
    }
}