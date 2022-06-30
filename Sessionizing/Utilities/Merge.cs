using sessionizer.Resources;

namespace sessionizer.Utilities;

public class Merge
{
    public static List<VisitRecord> MergeTwo(List<VisitRecord> firstList, List<VisitRecord> secondList)
    {
        // Get sizes of vectors
        var firstListCount = firstList.Count;
        var secondListCount = secondList.Count;
        // Vector for storing Result
        var mergedList = new List<VisitRecord>
        {
            Capacity = firstListCount + secondListCount
        };
        var firstListIndex = 0;
        var secondListIndex = 0;
        while (firstListIndex < firstListCount && secondListIndex < secondListCount)
        {
            mergedList.Add(firstList[firstListIndex].VisitTime.CompareTo(secondList[secondListIndex].VisitTime) < 1 ? firstList[firstListIndex++] : secondList[secondListIndex++]);
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