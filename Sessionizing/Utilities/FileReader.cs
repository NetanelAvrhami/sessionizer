using sessionizer.Models;

namespace sessionizer.Utilities;

public class FileReader
{
    
    //read the csv and return it according to the template
    public static List<TableRecord> ConvertCsvToTableRecord(string csvFilePath)
    {
        var tableRecords = new List<TableRecord>();
        using var input1 = new StreamReader(csvFilePath);
        string? input1CurrentLine;
        while ((input1CurrentLine = input1.ReadLine()) != null)
        {
            var record = TableRecord.ConvertToTableRecord(input1CurrentLine);
            tableRecords.Add(record);
        }
        return tableRecords;
    }
    
    
    
}