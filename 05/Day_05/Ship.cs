public class Ship
{
  private List<Stack<char>> _stacks;
  private MovementSchedule _schedule;

  public Ship(List<Stack<char>> stacks, MovementSchedule schedule)
  {
    if (stacks is null)
    {
      throw new ArgumentException("Stacks cannot be null.");
    }

    if (schedule is null)
    {
      throw new ArgumentException("Schedule cannot be null.");
    }

    _stacks = stacks;
    _schedule = schedule;
  }

  public List<Stack<char>> GetStacks()
  {
    return _stacks;
  }

  public MovementSchedule GetMovementSchedule()
  {
    return _schedule;
  }

  public Stack<char> GetStack(int number)
  {
    Stack<char>? result = _stacks.Find(s => s.GetNumber() == number) ?? throw new ArgumentException($"Stack {number} does not exist.");
    return result;
  }
}