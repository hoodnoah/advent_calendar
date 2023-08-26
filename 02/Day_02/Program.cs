// Create game
var part1Game = new Roshambo(new DefaultMoveDecryptor());
var part2Game = new Roshambo(new OutcomeMoveDecryptor());

// Read input
var inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var input = File.ReadAllLines(inputPath);

// Split each line on the space character
var splitInput = input.Select(x => x.Split(' '));

// Map over each line and play the game
int[] part1Scores = splitInput.Select(x => part1Game.Play(x[0], x[1])).ToArray();
int[] part2Scores = splitInput.Select(x => part2Game.Play(x[0], x[1])).ToArray();

// Sum the scores
int part1TotalScore = part1Scores.Sum();
int part2TotalScore = part2Scores.Sum();

// Print the total score
Console.WriteLine($"Part 1 total score: {part1TotalScore}");
Console.WriteLine($"Part 2 total score: {part2TotalScore}");