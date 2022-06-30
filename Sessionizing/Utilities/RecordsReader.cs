using sessionizer.Resources;

namespace sessionizer.Utilities;

public class RecordsReader : IFileReader
{
    private const string Input1 = "Data/input_1.csv";
    private const string Input2 = "Data/input_2.csv";
    private const string Input3 = "Data/input_3.csv";



    public List<VisitRecord> ReadFile(string csvFilePath)
    {
        var visitRecords = File.ReadAllLines("Data/input_1.csv")
            .Select(x => x.Split(','))
            .Select(cell => new VisitRecord()
                {
                    UserId = cell[0].Contains('_') ? cell[0].Split('_')[1] : cell[0],
                    SiteUrl = cell[1],
                    PageViewUrl = cell[2],
                    VisitTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Convert.ToDouble(cell[3]))
                }
            ).ToList();

        return visitRecords;

    }
}