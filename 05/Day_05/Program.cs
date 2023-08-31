// Step 1: read input
string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
string input = File.ReadAllText(path).Trim();

// Split on blank line
string[] inputParts = input.Split("\n\n");

string stacks = inputParts[0];
string instructions = inputParts[1];

