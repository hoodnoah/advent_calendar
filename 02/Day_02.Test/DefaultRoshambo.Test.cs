namespace Day_02.Test;

public class DefaultRoshamboTest
{
  [Fact]
  public void ReturnsCorrectScore()
  {
    string myMove = "Y";
    string opponentMove = "A";

    int expectedScore = 8;

    var roshambo = new Roshambo(new DefaultMoveDecryptor());

    int actualScore = roshambo.Play(opponentMove, myMove);

    Assert.Equal(expectedScore, actualScore);
  }

  [Fact]
  public void AlwaysFollowsExample()
  {
    // Arrange
    string[] myMoves = new string[] { "Y", "X", "Z" };
    string[] opponentMoves = new string[] { "A", "B", "C" };

    int expectedTotalScore = 15;

    // Act
    var roshambo = new Roshambo(new DefaultMoveDecryptor());
    int[] scores = myMoves.Zip(opponentMoves, (myMove, opponentMove) => roshambo.Play(opponentMove, myMove)).ToArray();
    int actualTotalScore = scores.Sum();

    // Assert
    Assert.Equal(expectedTotalScore, actualTotalScore);
  }
}