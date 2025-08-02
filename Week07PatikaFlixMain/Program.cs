using System;
using System.Collections.Generic;
using System.Linq;
using Week07PatikaFlixMain;

public class Program
{
    public static void Main()
    {   // Series class definition
        List<Series> seriesList = new List<Series>
        {
            new Series { SerieName = "Avrupa Yakası", SerieProductionYear = 2004, SerieType = "Komedi", SerieStartedYear = 2004, SerieDirector = "Yüksel Aksu", SerieChannel = "Kanal D" },
            new Series { SerieName = "Yalan Dünya", SerieProductionYear = 2012, SerieType = "Komedi", SerieStartedYear = 2012, SerieDirector = "Gülseren Buda Başkaya", SerieChannel = "Fox TV" },
            new Series { SerieName = "Jet Sosyete", SerieProductionYear = 2018, SerieType = "Komedi", SerieStartedYear = 2018, SerieDirector = "Gülseren Buda Başkaya", SerieChannel = "TV8" },
            new Series { SerieName = "Dadı", SerieProductionYear = 2006, SerieType = "Komedi", SerieStartedYear = 2006, SerieDirector = "Yusuf Pirhasan", SerieChannel = "Kanal D" },
            new Series { SerieName = "Belalı Baldız", SerieProductionYear = 2007, SerieType = "Komedi", SerieStartedYear = 2007, SerieDirector = "Yüksel Aksu", SerieChannel = "Kanal D" },
            new Series { SerieName = "Arka Sokaklar", SerieProductionYear = 2004, SerieType = "Polisiye, Dram", SerieStartedYear = 2006, SerieDirector = "Orhan Oğuz", SerieChannel = "Kanal D" },
            new Series { SerieName = "Aşk-ı Memnu", SerieProductionYear = 2008, SerieType = "Dram, Romantik", SerieStartedYear = 2008, SerieDirector = "Hilal Saral", SerieChannel = "Kanal D" },
            new Series { SerieName = "Muhteşem Yüzyıl", SerieProductionYear = 2011, SerieType = "Tarih, Dram", SerieStartedYear = 2011, SerieDirector = "Mercan Çilingiroğlu", SerieChannel = "Star TV" },
            new Series { SerieName = "Yaprak Dökümü", SerieProductionYear = 2006, SerieType = "Dram", SerieStartedYear = 2006, SerieDirector = "Serdar Akar", SerieChannel = "Kanal D" }
        };
        // Console input for adding a new series
        Console.Write("Would you like to add a new series? (y/n): ");
        string answer = Console.ReadLine();

        if (answer.ToLower() == "y")
        {
            Series newSeries = new Series();

            Console.Write("Series Name: ");
            newSeries.SerieName = Console.ReadLine();

            Console.Write("Production Year: ");
            newSeries.SerieProductionYear = int.Parse(Console.ReadLine());

            Console.Write("Series Genre: ");
            newSeries.SerieType = Console.ReadLine();

            Console.Write("Release Year: ");
            newSeries.SerieStartedYear = int.Parse(Console.ReadLine());

            Console.Write("Director: ");
            newSeries.SerieDirector = Console.ReadLine();

            Console.Write("First Broadcast Platform: ");
            newSeries.SerieChannel = Console.ReadLine();

            seriesList.Add(newSeries);

            Console.WriteLine($"\n'{newSeries.SerieName}' has been successfully added to the list!");
        }

        // Comdey genre filtering
        var comedyList = seriesList
            .Where(s => s.SerieType.ToLower().Contains("komedi"))
            .Select(s => new ComedySeries
            {
                SerieName = s.SerieName,
                SerieType = s.SerieType,
                SerieDirector = s.SerieDirector
            })
            .OrderBy(s => s.SerieName)
            .ThenBy(s => s.SerieDirector)
            .ToList();

        // Comedy genre output
        Console.WriteLine("\nFiltered Comedy Series (Name / Genre / Director):");
        foreach (var comedy in comedyList)
        {
            Console.WriteLine($"{comedy.SerieName} / {comedy.SerieType} / {comedy.SerieDirector}");
        }
    }
}
