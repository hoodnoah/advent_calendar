public class OutcomeMoveDecryptor : IMoveDecryptor
{
  private readonly Dictionary<Move, Move> WinConditions = new Dictionary<Move, Move> {
    { Move.Rock, Move.Paper},
    { Move.Paper, Move.Scissors},
    { Move.Scissors, Move.Rock}
  };

  private readonly Dictionary<Move, Move> LoseConditions = new Dictionary<Move, Move> {
    { Move.Rock, Move.Scissors},
    { Move.Paper, Move.Rock},
    { Move.Scissors, Move.Paper}
  };

  private readonly Dictionary<Move, Move> DrawConditions = new Dictionary<Move, Move> {
    { Move.Rock, Move.Rock},
    { Move.Paper, Move.Paper },
    { Move.Scissors, Move.Scissors}
  };

  private Move DecryptColumn1(string? column1)
  {
    if (string.IsNullOrWhiteSpace(column1))
    {
      throw new ArgumentException("Moves must not be null");
    }

    return column1.ToUpperInvariant() switch
    {
      "A" => Move.Rock,
      "B" => Move.Paper,
      "C" => Move.Scissors,
      _ => throw new ArgumentException($"Invalid move: {column1}")
    };
  }

  private Move DecryptColumn2(Move opponentMove, string? column2)
  {
    if (string.IsNullOrWhiteSpace(column2))
    {
      throw new ArgumentException("Moves must not be null");
    }

    Outcome outcome = column2.ToUpperInvariant() switch
    {
      "X" => Outcome.Lose,
      "Y" => Outcome.Draw,
      "Z" => Outcome.Win,
      _ => throw new ArgumentException($"Invalid outcome: {column2}")
    };

    return outcome switch
    {
      Outcome.Win => WinConditions[opponentMove],
      Outcome.Draw => DrawConditions[opponentMove],
      Outcome.Lose => LoseConditions[opponentMove],
      _ => throw new ArgumentException($"Invalid outcome: {column2}")
    };
  }

  public Row Decrypt(string? column1, string? column2)
  {
    if (string.IsNullOrWhiteSpace(column1) || string.IsNullOrWhiteSpace(column2))
    {
      throw new ArgumentException("Moves must not be null/empty");
    }

    Move opponentMove = DecryptColumn1(column1);
    Move myMove = DecryptColumn2(opponentMove, column2);

    return new(opponentMove, myMove);
  }
}