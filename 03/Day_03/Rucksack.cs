public record CommonalityScore(char Item, int Score);

public class Rucksack
{
  char[] _compartment1;
  char[] _compartment2;
  RucksackItemService _rucksackItemService;

  private string ValidateRucksackString(string? contents)
  {
    if (string.IsNullOrWhiteSpace(contents))
    {
      throw new ArgumentException("Rucksack must have contents");
    }

    if (contents.Length % 2 != 0)
    {
      throw new ArgumentException("Rucksack must have even number of contents");
    }

    return contents;
  }

  public char[] GetAllContents()
  {
    return _compartment1.Concat(_compartment2).ToArray();
  }

  public Rucksack(string? allContents)
  {
    _rucksackItemService = new RucksackItemService();

    string validatedContents = ValidateRucksackString(allContents);

    int halfLength = validatedContents.Length / 2;

    _compartment1 = validatedContents[..halfLength].ToCharArray();
    _compartment2 = validatedContents.Substring(halfLength, halfLength).ToCharArray();
  }

  public CommonalityScore FindCommonCompartmentContents()
  {
    char[] intersection = _compartment1.Intersect(_compartment2).ToArray();

    if (intersection.Length != 1)
    {
      throw new ArgumentException("Rucksacks must have exactly one common item");
    }

    return new(intersection[0], _rucksackItemService.GetItemPriority(intersection[0]));
  }

  public CommonalityScore FindCommonRucksackContents(Rucksack[] others)
  {
    char[] intersection = GetAllContents().Concat(others.SelectMany(x => x.GetAllContents())).ToArray();
    intersection = intersection.Intersect(GetAllContents()).ToArray();

    for (int i = 0; i < others.Length; i++)
    {
      intersection = intersection.Intersect(others[i].GetAllContents()).ToArray();
    }

    if (intersection.Length != 1)
    {
      throw new ArgumentException($"Rucksacks must have exactly one common item, found {intersection.Length}");
    }

    return new(intersection[0], _rucksackItemService.GetItemPriority(intersection[0]));
  }
}