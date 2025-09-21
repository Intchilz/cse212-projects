using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1 - FindPairs
    // Finds symmetric pairs of two-letter words in the array.
    // For example: ["am", "ma"] will return ["ma & am"].
    // Uses a HashSet for O(n) time complexity.
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> wordSet = new(words); // store words for quick lookup
        List<string> pairs = new();

        foreach (string word in words)
        {
            if (word[0] == word[1]) continue; // skip same-letter words
            string reversed = new string(new char[] { word[1], word[0] });
            if (wordSet.Contains(reversed))
            {
                // Ensure each pair only appears once in output
                if (string.Compare(word, reversed) < 0)
                    pairs.Add($"{reversed} & {word}");
            }
        }

        return pairs.ToArray();
    }

    // Problem 2 - SummarizeDegrees
    // Reads a CSV file and counts how many times each degree appears.
    // Degree is assumed to be in the 4th column (index 3).
    public static Dictionary<string, int> SummarizeDegrees(string filePath)
    {
        var degreeCount = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filePath))
        {
            var columns = line.Split(',');
            if (columns.Length < 4) continue; // skip invalid lines

            string degree = columns[3].Trim(); // get degree
            if (degreeCount.ContainsKey(degree))
                degreeCount[degree]++;
            else
                degreeCount[degree] = 1;
        }

        return degreeCount;
    }

    // Problem 3 - IsAnagram
    // Determines if two strings are anagrams (same letters and counts).
    // Ignores spaces and letter case.
    public static bool IsAnagram(string a, string b)
    {
        // Clean input: lowercase and remove whitespace
        string cleanA = new string(a.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());
        string cleanB = new string(b.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());

        if (cleanA.Length != cleanB.Length) return false;

        // Count letters in first string
        var letterCount = new Dictionary<char, int>();
        foreach (char c in cleanA)
        {
            if (!letterCount.ContainsKey(c))
                letterCount[c] = 0;
            letterCount[c]++;
        }

        // Subtract counts using second string
        foreach (char c in cleanB)
        {
            if (!letterCount.ContainsKey(c) || letterCount[c] == 0)
                return false;
            letterCount[c]--;
        }

        return true; // all counts matched
    }

    // Problem 5 - EarthquakeDailySummary
    // Fetches earthquake data from USGS and returns formatted strings.
    // Each string shows the location and magnitude.
    public static string[] EarthquakeDailySummary()
    {
        string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        string json = client.GetStringAsync(url).Result;

        // Deserialize JSON into objects
        var data = JsonSerializer.Deserialize<FeatureCollection>(json);
        if (data?.features == null) return Array.Empty<string>();

        // Format each earthquake as "Place - Mag Magnitude"
        return data.features.Select(f => $"{f.properties.place} - Mag {f.properties.mag}").ToArray();
    }

    // Helper classes for JSON deserialization
    public class FeatureCollection
    {
        public Feature[] features { get; set; }
    }

    public class Feature
    {
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public string place { get; set; } // earthquake location
        public double mag { get; set; }   // magnitude
    }
}
