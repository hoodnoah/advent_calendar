public class Stack<T>
{
  private List<T> _items;
  private int _number;

  public Stack(int number)
  {
    _number = number;
    _items = new List<T>();
  }

  public List<T> GetItems()
  {
    return _items;
  }

  public int GetNumber()
  {
    return _number;
  }

  /// <summary>
  /// Pushes an item onto the stack.
  /// </summary>
  /// <param name="item">The item to put onto the stack.</param>
  public void Push(T item)
  {
    _items.Add(item);
  }

  public T Pop()
  {
    if (_items.Count == 0)
    {
      throw new InvalidOperationException("Cannot pop from an empty stack.");
    }

    var item = _items[_items.Count - 1];
    _items.RemoveAt(_items.Count - 1);
    return item;
  }

  /// <summary>
  /// Compare the contents of this stack against another.
  /// </summary>
  /// <param name="other">The stack against which to compare the contents of this stack</param>
  /// <returns>True if the pairwise elements are the same for each stack.</returns>
  public bool Equals(Stack<T> other)
  {
    if (other is null)
    {
      return false;
    }

    var this_items = GetItems();
    var other_items = other.GetItems();

    if (this_items.Count != other_items.Count)
    {
      return false;
    }

    return this_items.Select((item, index) =>
    {
      return item?.Equals(other_items[index]) ?? false;
    }).All(x => x);
  }
}