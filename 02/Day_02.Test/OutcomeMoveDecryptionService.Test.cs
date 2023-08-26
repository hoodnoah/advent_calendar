namespace Day_02.Test;

public class OutcomeDecryptionTest
{
    [Fact]
    public void AlwaysReturnsCorrectValueForValidInput()
    {
        // Arrange
        var validColumn1Inputs = new string[] { "A", "B", "C" };
        var validColumn2Inputs = new string[] { "Y", "X", "Z" };
        var expectedOutput = new Row[] {
            new(Move.Rock, Move.Rock),
            new(Move.Paper, Move.Rock),
            new(Move.Scissors, Move.Rock)
        };

        var decryptionService = new OutcomeMoveDecryptor();

        // Act
        Row[] actualOutput = validColumn1Inputs.Zip(validColumn2Inputs, decryptionService.Decrypt).ToArray();

        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void AlwaysReturnsCorrectValueForValidInputCaseInsensitive()
    {
        // Arrange
        var validColumn1Inputs = new string[] { "a", "b", "c" };
        var validColumn2Inputs = new string[] { "y", "x", "z" };
        var expectedOutput = new Row[] {
            new(Move.Rock, Move.Rock),
            new(Move.Paper, Move.Rock),
            new(Move.Scissors, Move.Rock)
        };

        var decryptionService = new OutcomeMoveDecryptor();

        // Act
        Row[] actualOutput = validColumn1Inputs.Zip(validColumn2Inputs, decryptionService.Decrypt).ToArray();

        Assert.Equal(expectedOutput, actualOutput);

    }

    [Fact]
    public void AlwaysThrowsForInvalidString()
    {
        var decryptionService = new OutcomeMoveDecryptor();
        Assert.Throws<ArgumentException>(() => decryptionService.Decrypt("D", "X"));
    }

    [Fact]
    public void AlwaysThrowsForNullString()
    {
        var decryptionService = new OutcomeMoveDecryptor();
        Assert.Throws<ArgumentException>(() => decryptionService.Decrypt(null, null));
    }
}