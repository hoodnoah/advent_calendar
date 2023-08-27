// Read input
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
string[] input = File.ReadAllLines(filePath);

// Split lines into pairs
List<CleaningPair> pairs = input.Select(line =>
{
  string[] parts = line.Split(",");
  return new CleaningPair(new CleaningRange(parts[0]), new CleaningRange(parts[1]));
}).ToList();

// Find all pairs fully overlapping
List<CleaningPair> fullyOverlappingPairs = pairs.Where(pair => pair?.GetFirst()?.CompletelyOverlaps(pair.GetSecond()) ?? false).ToList();
List<CleaningPair> partiallyOverlappingPairs = pairs.Where(pair => pair?.GetFirst()?.PartiallyOverlaps(pair.GetSecond()) ?? false).ToList();

// Print results
Console.WriteLine($"Found {fullyOverlappingPairs.Count} fully overlapping pairs.");
Console.WriteLine($"Found {partiallyOverlappingPairs.Count} partially overlapping pairs.");