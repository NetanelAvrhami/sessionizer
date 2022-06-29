using sessionizer.Models;

namespace sessionizer.Utilities;

public class Merge
{
    public static List<TableRecord> MergeTwo(List<TableRecord> firstList, List<TableRecord> secondList)
    {
        // Get sizes of vectors
        var firstListCount = firstList.Count;
        var secondListCount = secondList.Count;
        // Vector for storing Result
        var mergedList = new List<TableRecord>
        {
            Capacity = firstListCount + secondListCount
        };
        var firstListIndex = 0;
        var secondListIndex = 0;
        while (firstListIndex < firstListCount && secondListIndex < secondListCount)
        {
            // mergedList.Add(firstList[firstListIndex].CompareTo(secondList[secondListIndex]) < 1 ? firstList[firstListIndex++] : secondList[secondListIndex++]);
        }

        // secondList has exhausted
        while (firstListIndex < firstListCount)
        {
            mergedList.Add(firstList[firstListIndex++]);
        }

        // firstList has exhausted
        while (secondListIndex < secondListCount)
        {
            mergedList.Add(secondList[secondListIndex++]);
        }

        return mergedList;
    }
}