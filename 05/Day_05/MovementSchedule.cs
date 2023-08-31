public record MovementInstruction
{
  public int Number { get; init; }
  public int From { get; init; }
  public int To { get; init; }
}

public class MovementSchedule
{
  private readonly List<MovementInstruction> _instructions;

  public MovementSchedule(List<MovementInstruction> instructions)
  {
    _instructions = instructions;
  }
}