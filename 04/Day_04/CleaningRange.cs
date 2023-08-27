public class CleaningRange
{
  private readonly int _start;
  private readonly int _end;

  public CleaningRange(int start, int end)
  {
    _start = start;
    _end = end;
  }

  public CleaningRange(string range)
  {
    string validatedRangeString = ValidateRangeString(range);

    string[] rangeParts = range.Split('-');
    try
    {
      int start = int.Parse(rangeParts[0]);
      int end = int.Parse(rangeParts[1]);

      _start = start;
      _end = end;
    }
    catch (FormatException e)
    {
      throw new ArgumentException($"Range must be in the format int-int, given: {range}", e);
    }
  }

  private string ValidateRangeString(string range)
  {
    if (string.IsNullOrEmpty(range))
    {
      throw new ArgumentException("Range cannot be null or empty");
    }

    if (!range.Contains("-"))
    {
      throw new ArgumentException("Range must contain a hyphen");
    }

    return range;
  }

  public int GetStart()
  {
    return _start;
  }

  public int GetEnd()
  {
    return _end;
  }


  /// <summary>
  /// Returns true if this range fully contains the other, or the other fully contains this range.
  /// </summary>
  /// <param name="other">The CleaningRange against which to compare.</param>
  /// <returns>True if either of these cleaning ranges fully overlap one another.</returns>
  public bool CompletelyOverlaps(CleaningRange? other)
  {
    if (other is null)
    {
      return false;
    }

    int otherStart = other.GetStart();
    int otherEnd = other.GetEnd();

    return (_start <= otherStart && _end >= otherEnd) || (_start >= otherStart && _end <= otherEnd);
  }


  /// <summary>
  /// Returns true if this range partially overlaps the other, or the other partially overlaps this range.
  /// </summary>
  /// <param name="other">The CleaningRange this CleaningRange is to partially overlap with</param>
  /// <returns>True if there is any overlap at all between this and the other CleaningRange.</returns>
  public bool PartiallyOverlaps(CleaningRange? other)
  {
    if (other is null)
    {
      return false;
    }

    int otherStart = other.GetStart();
    int otherEnd = other.GetEnd();

    if ((_start >= otherStart && _start <= otherEnd) || (otherStart >= _start && otherStart <= _end))
    {
      return true;
    }

    if ((_end >= otherStart && _end <= otherEnd) || (otherEnd >= _start && otherEnd <= _end))
    {
      return true;
    }

    return false;
  }
}