public class RucksackItemService
{
  private readonly char[] _possibleItems;

  public RucksackItemService()
  {
    string possibleLowercase = "abcdefghijklmnopqrstuvwxyz";
    string possibleUppercase = possibleLowercase.ToUpper();
    _possibleItems = (possibleLowercase + possibleUppercase).ToCharArray();
  }

  public int GetItemPriority(char item)
  {
    if (!Array.Exists(_possibleItems, x => x == item))
    {
      throw new ArgumentException("Invalid item", nameof(item));
    }
    return Array.IndexOf(_possibleItems, item) + 1;
  }
}