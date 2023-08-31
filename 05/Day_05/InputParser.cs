public class InputParser
{
  private readonly ITextFileReader _textReader;

  public InputParser(ITextFileReader textReader)
  {
    _textReader = textReader;
  }

  private int StackNumToIndex(int stackNum)
  {
    return 4 * (stackNum - 1) + 1;
  }

  private List<Stack<char>> ParseStackString(string stackString)
  {
    List<Stack<char>> stacks = new List<Stack<char>>();

    // split stackString into lines
    List<string> lines = stackString.Split("\n").ToList();
    List<string> stacks_only = lines.Take(lines.Count - 1).ToList(); // skip last line, defining line numbers

    int lineLength = stacks_only[0].Length;

    // If all lines aren't same length, throw an exception
    if (!lines.All(line => line.Length == lineLength))
    {
      throw new Exception("All lines in stackString must be the same length.");
    }

    // Determine how many stacks are present
    int numStacks = lineLength % 4;

    for (int i = 0; i < numStacks; i++)
    {
      stacks.Add(new Stack<char>(i + 1));
    }

    for (int i = 0; i < numStacks; i++)
    {
      int stackContentsIndex = StackNumToIndex(i + 1);
      List<string> stackContents = stacks_only.Select(line => line.Substring(stackContentsIndex, 1)).ToList();
      stackContents.Reverse();

      foreach (string stackContent in stackContents)
      {
        if (stackContent != " ")
        {
          stacks[i].Push(stackContent[0]);
        }
      }
    }

    return stacks;
  }

  /// <summary>
  /// Given the string value of the input file, parse it into a Ship object.
  /// </summary>
  /// <param name="path">The path to the input</param>
  /// <returns>A fully-formed Ship object containing the populated stacks and their
  /// contents' movement schedule.</returns>
  /// <exception cref="NotImplementedException"></exception>
  public Ship ParseInput(string path)
  {
    string input = _textReader.ReadAllText(path);

    // Split into two sections
    string[] sections = input.Split("\n\n");
    string stackString = sections[0];
    string scheduleString = sections[1];

    List<Stack<char>> stacks = ParseStackString(stackString);

    return new Ship(stacks, new MovementSchedule(new List<MovementInstruction>()));
  }
}