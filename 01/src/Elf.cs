public class Elf : IComparable<Elf>
{
  int[] food;
  public Elf(int[] food)
  {
    this.food = food;
  }

  public int CompareTo(Elf? other)
  {
    if (other == null)
    {
      return 1;
    }

    return getTotalCalories() - other.getTotalCalories();
  }

  /// <summary>
  ///  Returns the total calories of all the food items the elf has.
  /// </summary>
  public int getTotalCalories()
  {
    return food.Sum();
  }
}