public class CleaningPair
{
  readonly CleaningRange? First;
  readonly CleaningRange? Second;

  public CleaningPair(CleaningRange first, CleaningRange second)
  {
    First = first;
    Second = second;
  }

  public CleaningRange? GetFirst()
  {
    return First;
  }

  public CleaningRange? GetSecond()
  {
    return Second;
  }

  public bool PartiallyOverlaps()
  {
    if (First is null || Second is null)
    {
      return false;
    }

    return First.PartiallyOverlaps(Second) || Second.PartiallyOverlaps(First);
  }

  public bool FullyOverlaps()
  {
    if (First is null || Second is null)
    {
      return false;
    }

    return First.CompletelyOverlaps(Second) || Second.CompletelyOverlaps(First);
  }
}