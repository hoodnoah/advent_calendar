public enum Move
{
  Rock,
  Paper,
  Scissors
}

public enum Outcome
{
  Win,
  Lose,
  Draw
}

public class Roshambo
{
  private readonly IMoveDecryptor _moveDecryptor;

  public Roshambo(IMoveDecryptor moveDecryptor)
  {
    _moveDecryptor = moveDecryptor;
  }

  private Outcome CompareMoves(Move opponentMove, Move myMove)
  {
    if (opponentMove == myMove)
    {
      return Outcome.Draw;
    }
    else if (opponentMove == Move.Rock && myMove == Move.Paper)
    {
      return Outcome.Win;
    }
    else if (opponentMove == Move.Paper && myMove == Move.Scissors)
    {
      return Outcome.Win;
    }
    else if (opponentMove == Move.Scissors && myMove == Move.Rock)
    {
      return Outcome.Win;
    }
    else
    {
      return Outcome.Lose;
    }
  }

  private int calculateScore(Outcome outcome, Move myMove)
  {
    int outcomeScore;
    int moveScore;

    outcomeScore = outcome switch
    {
      Outcome.Win => 6,
      Outcome.Lose => 0,
      Outcome.Draw => 3,
      _ => throw new ArgumentException("Invalid outcome, must be Win, Lose or Draw")
    };

    moveScore = myMove switch
    {
      Move.Rock => 1,
      Move.Paper => 2,
      Move.Scissors => 3,
      _ => throw new ArgumentException("Invalid move, must be Rock, Paper or Scissors")
    };

    return outcomeScore + moveScore;
  }

  public int Play(string opponent, string me)
  {
    // Translate the opponent and my moves from strings to Moves
    (Move opponentMove, Move myMove) = _moveDecryptor.Decrypt(opponent, me);

    // Compare the moves
    Outcome outcome = CompareMoves(opponentMove, myMove);

    // Calculate the score
    return calculateScore(outcome, myMove);
  }
}