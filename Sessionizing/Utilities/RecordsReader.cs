using sessionizer.Models;

namespace sessionizer.Utilities;

public class RecordsReader : IFileReader
{
    private const string Input1 = "Data/input_1.csv";
    private const string Input2 = "Data/input_2.csv";
    private const string Input3 = "Data/input_3.csv";

    public List<TableRecord> ReadFile(string csvFilePath)
    {
        var tableRecords = new List<TableRecord>();
        using var streamReader = new StreamReader(csvFilePath);
        string? currentLine;
        while ((currentLine = streamReader.ReadLine()) != null)
        {
            var record = TableRecord.ConvertToTableRecord(currentLine);
            tableRecords.Add(record);
        }

        return tableRecords;
    }
}