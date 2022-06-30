using sessionizer.Models;

namespace sessionizer.Utilities;

public interface IFileReader
{
    public List<VisitRecord> ReadFile();
}