using sessionizer.Resources;

namespace sessionizer.Utilities;

public class RecordsReader : IFileReader
{
    
    public List<VisitRecord> ReadFile(string csvFilePath)
    {
        var visitRecords = File.ReadAllLines(csvFilePath)
            .Select(x => x.Split(','))
            .Select(cell => new VisitRecord(
                cell[0].Split('_')[1],
                cell[1],
                cell[2],
                new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Convert.ToDouble(cell[3]))
            )).ToList();

        return visitRecords;
    }
}