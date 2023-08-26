namespace Day_03.Test;

public class RucksackTest
{
  [Fact]
  public void AlwaysReturnsCorrectAnswerFromExample()
  {
    // Arrange
    var itemService = new RucksackItemService();
    var input = new string[] {
      "vJrwpWtwJgWrhcsFMMfFFhFp",
      "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
      "PmmdzqPrVvPwwTWBwg",
      "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
      "ttgJtRGJQctTZtZT",
      "CrZsJsPPZsGzwwsLwLmpwMDw"
    };
    var expectedOutput = new CommonalityScore[] {
      new('p', 16),
      new('L', 38),
      new('P', 42),
      new('v', 22),
      new('t', 20),
      new('s', 19)
    };

    Rucksack[] rucksacks = input.Select(x => new Rucksack(x)).ToArray();

    // Act
    var actualOutput = rucksacks.Select(x => x.FindCommonCompartmentContents());
  }

  [Fact]
  public void AlwaysReturnsAllContents()
  {
    // Arrange
    var itemService = new RucksackItemService();
    var input = new string[] {
      "vJrwpWtwJgWrhcsFMMfFFhFp",
      "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
      "PmmdzqPrVvPwwTWBwg",
      "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
      "ttgJtRGJQctTZtZT",
      "CrZsJsPPZsGzwwsLwLmpwMDw"
    };
    Rucksack[] rucksacks = input.Select(x => new Rucksack(x)).ToArray();

    // Act
    char[][] actualOutput = rucksacks.Select(x => x.GetAllContents()).ToArray();

    // Assert
    for (int i = 0; i < input.Length; i++)
    {
      Assert.Equal(input[i].ToCharArray(), actualOutput[i]);
    }
  }

  [Fact]
  public void AlwaysReturnsGroup1Correctly()
  {
    // Arrange
    var itemService = new RucksackItemService();
    var input = new string[]
    {
      "vJrwpWtwJgWrhcsFMMfFFhFp",
      "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
      "PmmdzqPrVvPwwTWBwg",
    };

    Rucksack[] rucksacks = input.Select(x => new Rucksack(x)).ToArray();

    var expectedOutput = new CommonalityScore('r', 18);

    // Act
    CommonalityScore actualOutput = rucksacks[0].FindCommonRucksackContents(rucksacks[1..]);

    // Assert
    Assert.Equal(expectedOutput, actualOutput);

  }

  [Fact]
  public void AlwaysReturnsGroup2Correctly()
  {
    // Arrange
    var itemService = new RucksackItemService();
    var input = new string[]
    {
      "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
      "ttgJtRGJQctTZtZT",
      "CrZsJsPPZsGzwwsLwLmpwMDw",
    };

    Rucksack[] rucksacks = input.Select(x => new Rucksack(x)).ToArray();

    var expectedOutput = new CommonalityScore('Z', 52);

    // Act
    CommonalityScore actualOutput = rucksacks[0].FindCommonRucksackContents(rucksacks[1..]);

    // Assert
    Assert.Equal(expectedOutput, actualOutput);

  }
}