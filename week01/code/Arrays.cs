using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create a new array of doubles with size 'length'.
        // 2. Use a loop that runs from 0 to length-1.
        // 3. For each index i, calculate the multiple as number * (i + 1)
        //    because we want to start with 'number' itself as the first multiple.
        // 4. Assign the calculated value to the array at index i.
        // 5. After the loop completes, return the array.

        double[] multiples = new double[length]; // Step 1
        for (int i = 0; i < length; i++)          // Step 2
        {
            multiples[i] = number * (i + 1);      // Step 3 and 4
        }
        return multiples;                         // Step 5
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Create a temporary list to hold the rotated values.
        // 2. Loop through each index i in the original list.
        // 3. Compute the new index for each element as (i + amount) % data.Count.
        //    This handles wrapping around the end of the list back to 0.
        // 4. Place the element from the original list into its new position in the temporary list.
        // 5. After the loop, copy the values from the temporary list back into the original list
        //    to modify it in place.

        int n = data.Count;
        List<int> rotated = new List<int>(new int[n]); // Step 1: initialize with size n

        for (int i = 0; i < n; i++)                    // Step 2
        {
            int newIndex = (i + amount) % n;          // Step 3
            rotated[newIndex] = data[i];              // Step 4
        }

        for (int i = 0; i < n; i++)                   // Step 5
        {
            data[i] = rotated[i];
        }
    }
}
