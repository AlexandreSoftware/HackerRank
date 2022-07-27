public static string abbreviation(string stringToReplace, string modelString)
{
    int replaceLength = stringToReplace.Length,
     modelLength = modelString.Length;
    int[,] dp = new int[modelLength + 1,replaceLength + 1];
    for (int currentLetterIndex = 1; currentLetterIndex <= modelLength; currentLetterIndex++)
    {
        for (int compareLetter = 1; compareLetter <= replaceLength; compareLetter++)
        {
            if (Char.IsUpper(stringToReplace[compareLetter - 1]))
            {
                dp[currentLetterIndex,compareLetter] = dp[currentLetterIndex,compareLetter - 1] - 1;
            }
            else
            {
                dp[currentLetterIndex,compareLetter] = Math.Max(dp[currentLetterIndex,compareLetter - 1], dp[currentLetterIndex - 1,compareLetter]);
            }
            if (Char.ToLower(stringToReplace[compareLetter - 1]) == Char.ToLower(modelString[currentLetterIndex - 1]))
                dp[currentLetterIndex,compareLetter] = Math.Max(dp[currentLetterIndex - 1,compareLetter - 1] + 1, dp[currentLetterIndex,compareLetter]);
        }
    }
    return dp[modelLength,replaceLength] == modelLength ? "YES" : "NO";
}