using sessionizer.Models;

namespace sessionizer.Utilities;

public static class FileReader
{
    
    public static List<TableRecord> ConvertCsvToTableRecord(string csvFilePath)
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