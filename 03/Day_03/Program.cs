// Read input
string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
string[] input = File.ReadAllLines(inputPath);

// Parse into rucksacks
Rucksack[] rucksacks = input.Select(x => new Rucksack(x)).ToArray();

// #### PART 01 ####
// Find common item
CommonalityScore[] commonItems = rucksacks.Select(x => x.FindCommonCompartmentContents()).ToArray();

// Calculate sum
int sum = commonItems.Sum(x => x.Score);

// Print result
Console.WriteLine($"Sum of common items: {sum}");

// #### PART 02 ####
// Group rucksacks by three
Rucksack[][] rucksackGroups = rucksacks.Select((item, index) => new { Item = item, Index = index })
  .GroupBy(x => x.Index / 3)
  .Select(g => g.Select(x => x.Item).ToArray())
  .ToArray();

// Find common item (badge) within each group
CommonalityScore[] commonBadges = rucksackGroups.Select(x => x[0].FindCommonRucksackContents(x[1..])).ToArray();

// Sum scores
int badgeSum = commonBadges.Sum(x => x.Score);

// Print result
Console.WriteLine($"Sum of common badges: {badgeSum}");
