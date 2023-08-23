// Read input into string
string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
string input = File.ReadAllText(inputPath).Trim();

// Split input into groups on blank lines
string[] groups = input.Split("\n\n");

// Split groups into items
string[][] splitGroups = groups.Select(g => g.Split("\n")).ToArray();

// Parse groups into int arrays
int[][] parsedGroups = splitGroups.Select(g => g.Select(i => int.Parse(i)).ToArray()).ToArray();

// Create elves
Elf[] elves = parsedGroups.Select(g => new Elf(g)).ToArray();

// Sort elves
Array.Sort(elves);

// Elf with most calories
Elf mostCalories = elves.Last();

// Top three elves
Elf[] topThreeElves = elves.Skip(elves.Length - 3).ToArray();

// Print results
Console.WriteLine($"Elf with most calories: {mostCalories.getTotalCalories()}");
Console.WriteLine($"Calories carried by top three elves: {topThreeElves.Sum(e => e.getTotalCalories())}");

