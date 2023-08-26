public class DefaultMoveDecryptor : IMoveDecryptor
{
  private Move decryptSingleMove(string move)
  {
    return move.ToUpperInvariant() switch
    {
      "A" => Move.Rock,
      "B" => Move.Paper,
      "C" => Move.Scissors,
      "X" => Move.Rock,
      "Y" => Move.Paper,
      "Z" => Move.Scissors,
      _ => throw new ArgumentException($"Invalid move: {move}")
    };
  }

  public Row Decrypt(string? column1, string? column2)
  {
    if (string.IsNullOrWhiteSpace(column1) || string.IsNullOrWhiteSpace(column2))
    {
      throw new ArgumentException("Moves must not be null");
    }

    // return (decryptSingleMove(column1), decryptSingleMove(column2));
    return new(decryptSingleMove(column1), decryptSingleMove(column2));
  }
}