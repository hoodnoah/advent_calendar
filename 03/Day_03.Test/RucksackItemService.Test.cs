namespace Day_03.Test;

public class UnitTest1
{
    [Fact]
    public void AlwaysReturnsExpectedValueForValidInput()
    {
        // Arrange
        RucksackItemService rucksackItemService = new RucksackItemService();
        var input = new char[] { 'a', 'b', 'c', 'X', 'Y', 'Z' };
        var expectedOutput = new int[] { 1, 2, 3, 50, 51, 52 };

        // Act
        var actualOutput = input.Select(rucksackItemService.GetItemPriority);

        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void AlwaysThrowsOnInvalidInput()
    {
        // Arrange
        RucksackItemService rucksackItemService = new RucksackItemService();
        char input = '!';

        Assert.Throws<ArgumentException>(() => rucksackItemService.GetItemPriority(input));
    }
}