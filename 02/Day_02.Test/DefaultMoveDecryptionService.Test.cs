namespace Day_02.Test;

public class DefaultDecryptionTest
{
    [Fact]
    public void AlwaysReturnsCorrectValueForValidInput()
    {
        // Arrange
        var decryptionService = new DefaultMoveDecryptor();

        var validColumn1Inputs = new string[] { "A", "B", "C" };
        var validColumn2Inputs = new string[] { "X", "Y", "Z" };
        var expectedOutput = new Row[] {
            new(Move.Rock, Move.Rock),
            new(Move.Paper, Move.Paper),
            new(Move.Scissors, Move.Scissors)
        };

        // Act
        Row[] actualOutput = validColumn1Inputs.Zip(validColumn2Inputs, decryptionService.Decrypt).ToArray();

        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void AlwaysReturnsCorrectValueForValidInputCaseInsensitive()
    {
        // Arrange
        var decryptionService = new DefaultMoveDecryptor();

        var validColumn1Inputs = new string[] { "a", "b", "c" };
        var validColumn2Inputs = new string[] { "x", "y", "z" };
        var expectedOutput = new Row[] {
            new(Move.Rock, Move.Rock),
            new(Move.Paper, Move.Paper),
            new(Move.Scissors, Move.Scissors)
        };

        // Act
        Row[] actualOutput = validColumn1Inputs.Zip(validColumn2Inputs, decryptionService.Decrypt).ToArray();

        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }


    [Fact]
    public void AlwaysThrowsForInvalidString()
    {
        var decryptionService = new DefaultMoveDecryptor();
        Assert.Throws<ArgumentException>(() => decryptionService.Decrypt("D", "N"));
    }

    [Fact]
    public void AlwaysThrowsForNullString()
    {
        var decryptionService = new DefaultMoveDecryptor();
        Assert.Throws<ArgumentException>(() => decryptionService.Decrypt(null, null));
    }
}