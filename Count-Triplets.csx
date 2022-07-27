static long countTriplets(List<long> tripletArray, long ratio) {
   Dictionary<long,long> secondDictionary = new(),
     thirdDictionary = new();
    long result = 0;
    foreach (var val in tripletArray)
    {
        if (thirdDictionary.ContainsKey(val))
            result += thirdDictionary[val];
        if (secondDictionary.ContainsKey(val))
            if (thirdDictionary.ContainsKey(val*ratio))
                thirdDictionary[val*ratio] += secondDictionary[val];
            else
                thirdDictionary[val*ratio] = secondDictionary[val];
        if (secondDictionary.ContainsKey(val*ratio))
            secondDictionary[val*ratio]++;
        else
            secondDictionary[val*ratio] = 1;
    }
    return result;
}