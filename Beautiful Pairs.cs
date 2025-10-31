using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'beautifulPairs' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY A
     *  2. INTEGER_ARRAY B
     */

    public static int beautifulPairs(List<int> A, List<int> B)
    {
        Dictionary<int, int> countA = new Dictionary<int, int>();
        Dictionary<int, int> countB = new Dictionary<int, int>();

        foreach (var a in A)
        {
            if (!countA.ContainsKey(a))
                countA[a] = 0;
            countA[a]++;
        }

        foreach (var b in B)
        {
            if (!countB.ContainsKey(b))
                countB[b] = 0;
            countB[b]++;
        }

        int beautifulCount = 0;

        foreach (var kvp in countA)
        {
            int key = kvp.Key;
            if (countB.ContainsKey(key))
            {
                beautifulCount += Math.Min(kvp.Value, countB[key]);
            }
        }

        if (beautifulCount < A.Count)
            beautifulCount++;
        else
            beautifulCount--; 
        return beautifulCount;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

        List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

        int result = Result.beautifulPairs(A, B);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
