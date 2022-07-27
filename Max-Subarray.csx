public static long maximumSum(List<long> subArray, long modulo)
{
    SortedSet<long> sortedSet = new SortedSet<long>();
    long current = 0;
    long maxModuli = 0;
    long moduloSum = 0;

    for (int currentIndex = 0; currentIndex < subArray.Count; currentIndex++)
    {
        current = (current + subArray[currentIndex]) % modulo;

        maxModuli = Math.Max(current, maxModuli);

        if (sortedSet.Max > current)
        {
            long greaterNumber = sortedSet.GetViewBetween(current + 1, current - maxModuli + modulo).Min;
            maxModuli = Math.Max((current - greaterNumber + modulo) % modulo, maxModuli);
        }

        sortedSet.Add(current);
    }

    return maxModuli;
}