using sessionizer.Resources;

namespace sessionizer.Utilities;

public interface IFileReader
{
    public List<VisitRecord> ReadFile(string csvFilePath);
}